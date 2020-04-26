using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Services;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetoPraticoCodenation.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    class LogErroController : ControllerBase
    {
        private readonly ILogErroService _logErroService;
        private readonly IMapper _mapper;

        public LogErroController(ILogErroService produtoService, IMapper mapper)
        {
            _logErroService = produtoService;
            _mapper = mapper;
        }

        // GET api/LogErro/{nivel, ambiente}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LogErroDTO>> Get(string nivel, string ambiente)
        {
            var listaLogErro = _logErroService.LocalizarPorNivelAmbiente(nivel, ambiente);

            if (listaLogErro != null)
            {
                var retorno = _mapper.Map<List<LogErroDTO>>(listaLogErro);

                return Ok(retorno);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("id invalido");

            _logErroService.Remover(id);

            return Ok();
        }
    }
}
