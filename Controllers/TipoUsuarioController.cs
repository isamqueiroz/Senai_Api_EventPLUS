using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : Controller
    {
        private readonly ITiposUsuariosRepository _tipoUsuarioRepository;
        public TipoUsuarioController(ITiposUsuariosRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        /// <summary>
        /// Endpoint para listar tipos de usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para cadastrar novos tipos de usuarios.
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposUsuarios novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        /// <summary>
        /// Endpoint para buscar tipo usuarios pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposUsuarios tipoBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(tipoBuscado);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        /// <summary>
        /// Endpoint para deletar tipos usuarios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint para atualizar tipos usuarios
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuarios tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
    }
}
