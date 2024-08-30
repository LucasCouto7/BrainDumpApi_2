using AutoMapper;
using BrainDumpApi_2.Context;
using BrainDumpApi_2.DTOs;
using BrainDumpApi_2.Models;
using BrainDumpApi_2.Pagination;
using BrainDumpApi_2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using Microsoft.AspNetCore.Http;

namespace BrainDumpApi_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public NotasController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet("notas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<NotaDTO>>> GetNotasPorCategoriaAsync(int id)
        {
            var notas = await _uof.NotaRepository.GetNotasPorCategoriaAsync(id);

            if (notas is null)
                return NotFound();

            //var destino = _mapper.Map<Destino>(origem);
            var notasDto = _mapper.Map<IEnumerable<NotaDTO>>(notas);

            return Ok(notasDto);
        }

        [Authorize(Policy = "UserOnly")]
        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<NotaDTO>>> Get([FromQuery]
                                   NotasParameters notasParams)
        {
            var notas = await _uof.NotaRepository.GetNotasAsync(notasParams);

            return ObterNotas(notas);
        }

        private ActionResult<IEnumerable<NotaDTO>> ObterNotas(IPagedList<Nota> notas)
        {
            var metadata = new
            {
                notas.Count,
                notas.PageSize,
                notas.PageCount,
                notas.TotalItemCount,
                notas.HasNextPage,
                notas.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            var notasDto = _mapper.Map<IEnumerable<NotaDTO>>(notas);
            return Ok(notasDto);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<NotaDTO>>> Get()
        {
            var notas = await _uof.NotaRepository.GetAllAsync();
            if (notas is null)
                return NotFound();

            var notasDto = _mapper.Map<IEnumerable<NotaDTO>>(notas);
            return Ok(notasDto);
        }

        [HttpGet("{id}", Name = "ObterNotas")]
        public async Task<ActionResult<NotaDTO>> Get(int id)
        {
            var nota = await _uof.NotaRepository.GetAsync(n => n.Id == id);
            if (nota is null)
            {
                return NotFound("Nota não encontrada...");
            }
            var NotaDTO = _mapper.Map<NotaDTO>(nota);
            return Ok(NotaDTO);
        }

        // a implementar PATCH


        [HttpPost]
        public async Task<ActionResult<NotaDTO>> Post(NotaDTO NotaDTO)
        {
            if (NotaDTO is null)
                return BadRequest();

            var nota = _mapper.Map<Nota>(NotaDTO);

            var novaNota = _uof.NotaRepository.Create(nota);
            await _uof.Commit();

            var novoNotaDTO = _mapper.Map<NotaDTO>(novaNota);

            return new CreatedAtRouteResult("ObterNotas",
                new { id = novoNotaDTO.Id }, novoNotaDTO);
        }
    }
}
