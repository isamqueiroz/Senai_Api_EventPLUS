using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : Controller
    {

        private readonly IComentariosEventosRepository _comentarioEventoRepository;


        public ComentarioController(IComentariosEventosRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        [HttpGet("{idUsuario}/{idEvento}")]
        public IActionResult BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            var comentario = _comentarioEventoRepository.BuscarPorIdUsuario(idUsuario, idEvento);
            if (comentario == null)
                return NotFound("Comentário não encontrado.");

            return Ok(comentario);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] ComentariosEventos comentarioEvento)
        {
            _comentarioEventoRepository.Cadastrar(comentarioEvento);
            return StatusCode(201, "Comentário cadastrado com sucesso.");
        }

        

        [HttpGet("evento/{idEvento}")]
        public IActionResult Listar(Guid idEvento)
        {
            var comentarios = _comentarioEventoRepository.Listar(idEvento);
            return Ok(comentarios);
        }

    }
}

