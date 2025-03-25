﻿using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : Controller
    {
        private readonly IPresencasEventosRepository _presencaRepository;
        public PresencaController(IPresencasEventosRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        /// <summary>
        /// Endpoint para Listar Presenças
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Inscrever(Cadastrar presença)
        /// </summary>
        /// <param name="novaPresenca"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(PresencasEventos novaPresenca)
        {
            try
            {
                _presencaRepository.Inscrever(novaPresenca);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para buscar por id as presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BucarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencasEventos presencaBuscada = _presencaRepository.BuscarPorId(id);
                return Ok(presencaBuscada);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint para deletar presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint para listar suas presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<PresencasEventos> listarMinhasPresencas = _presencaRepository.ListarMinhasPresencas(id);
                return Ok(listarMinhasPresencas);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }
    }
}
