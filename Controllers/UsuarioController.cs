using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuariosRepository _usuarioRepository;

        public UsuarioController(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para listar usuario por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return null!;
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        /// <summary>
        /// Endpoint para cadastrar usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuarios usuarios)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuarios);
                return StatusCode(201, usuarios);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
