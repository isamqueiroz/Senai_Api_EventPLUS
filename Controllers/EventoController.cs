using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : Controller
    {
           private readonly IEventosRepository _eventoRepository;

        public EventoController(IEventosRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }



        [HttpPost]

        public IActionResult Post(Eventos novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Atualizar
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Eventos novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //Buscar Por Id

        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Eventos eventoBuscarPorId = _eventoRepository.BuscarPorId(id);
                return Ok(eventoBuscarPorId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        //Listar

        [HttpGet]

        public IActionResult Get()
        {

            try
            {
                List<Eventos> listaDeEvento = _eventoRepository.Listar();
                return Ok(listaDeEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }


    }
}

