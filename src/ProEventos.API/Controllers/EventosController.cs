using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _evento;

        public EventosController(IEventoService evento)
        {
            _evento = evento;
        }

        [HttpGet]
        public async Task<IActionResult> ObterEventos() //todos eventos
        {
            try
            {
                var eventos = await _evento.ObterEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar eventos. Erro: {err.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEventoPorId(int id) //por id
        {
            try
            {
                var evento = await _evento.ObterEventoPorIdAsync(id, true);
                if (evento == null) return NotFound("Nenhum evento encontrado");

                return Ok(evento);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar recuperar eventos. Erro: {err.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> ObterEventoPorTema(string tema) //por tema
        {
            try
            {
                var evento = await _evento.ObterEventosPorTemaAsync(tema, true);
                if (evento == null) return NotFound("Nenhum evento encontrado");

                return Ok(evento);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar recuperar eventos. Erro: {err.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AdicionarEvento(Evento evento) //adicionar um novo evento
        {
            try
            {
                var novoEvento = await _evento.AdicionarEventos(evento);
                if (novoEvento == null) return BadRequest("Não foi possível adicionar um novo evento"); 

                return Ok(novoEvento);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {err.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEvento(int id, Evento evento) //atualizar evento
        {
            try
            {
                var atualizarEvento = await _evento.AtualizarEventos(id, evento);
                if (atualizarEvento == null) return NotFound("Não foi possível atualizar o evento");

                return Ok(atualizarEvento);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {err.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEvento(int id) //deletar evento
        {
            try
            {
                return await _evento.DeletarEventos(id) ? Ok("Evento deletado com suscesso!") : BadRequest("Não foi possível deletar o evento!"); //se for deletado => Ok : senão => BadRequest

            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar deletar eventos. Erro: {err.Message}");
            }
        }
    }
}