using Azure;
using BrainDumpApi_2.DTOs;
using BrainDumpApi_2.Models;
using BrainDumpApi_2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BrainDumpApi_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenService tokenService, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

                if (roleResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                            new ResponseModel
                            {
                                Status = "Success",
                                Message =
                            $"Role {roleName} adicionado com sucesso"
                            });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                       new ResponseModel
                       {
                           Status = "Error",
                           Message =
                           $"Erro ao adicionar role {roleName}"
                       });
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest,
              new ResponseModel { Status = "Error", Message = "Role já existe" });
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                           new ResponseModel
                           {
                               Status = "Success",
                               Message =
                           $"User {user.Email} added to the {roleName} role"
                           });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
                    {
                        Status = "Error",
                        Message = $"Error: Unable to add user {user.Email} to the {roleName} role"
                    });
                }
            }
            return BadRequest(new { error = "Unable to find user" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName!);

            if (user is not null && await _userManager.CheckPasswordAsync(user, model.Password!))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _tokenService.GenerateAccessToken(authClaims, _configuration);

                var refreshToken = _tokenService.GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);

                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                user.RefreshToken = refreshToken;

                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                });

            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userNameExists = await _userManager.FindByNameAsync(model.Username!);

            if ((userNameExists) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Nome de usuário já existe" });    
            }

            var emailExists = await _userManager.FindByEmailAsync(model.Username!);

            if ((emailExists) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Email já vinculado com outro usuário" });
            }

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (!(result).Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Falha na criação do usuário" });
            }

            return Ok(new ResponseModel { Status = "Success", Message = "Usuário criado com sucesso" });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel == null)
                return BadRequest("Requisição inválida");

            string? accessToken = tokenModel.AccessToken ?? throw new ArgumentNullException(nameof(tokenModel));

            string? refreshToken = tokenModel.RefreshToken ?? throw new ArgumentNullException(nameof(tokenModel));

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken!, _configuration);

            if (principal is null)
                return BadRequest("Access/Refresh token inválido");

            string userName = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(userName);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest("Access/Refresh token inválido");

            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _configuration);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{userName}")]
        public async Task<IActionResult> Revoke(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null) return BadRequest("Nome de usuário inválido");

            user.RefreshToken = null;

            await _userManager.UpdateAsync(user);

            return NoContent();
        }

    }
}
