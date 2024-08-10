using System.ComponentModel.DataAnnotations;

namespace BrainDumpApi_2.DTOs
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nome de usuário é requerido")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }


    }
}
