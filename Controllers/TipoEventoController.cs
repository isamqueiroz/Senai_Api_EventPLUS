using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITiposEventosRepository _tipoeventoRepository;

        public TipoEventoController(ITiposEventosRepository tipoEventoRepository)
        {
            _tipoeventoRepository = tipoEventoRepository;
        }

        /// <summary>
        /// Endpoint para listar tipos de eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposEventos> lista = _tipoeventoRepository.Listar();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para cadastras novos tipos de eventos
        /// </summary>
        /// <param name="novoTipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposEventos novoTipoEvento)
        {
            try
            {
                _tipoeventoRepository.Cadastrar(novoTipoEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para buscar tipos de eventos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposEventos tipoBuscado = _tipoeventoRepository.BuscarPorId(id);
                return Ok(tipoBuscado);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        /// <summary>
        /// Endpoint para deletar tipos de eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _tipoeventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }


        }




        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposEventos tipoEvento)
        {
            try
            {
                _tipoeventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
