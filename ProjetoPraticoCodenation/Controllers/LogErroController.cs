using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Services;
using System;
using System.Collections.Generic;
using ProjetoPraticoCodenation.Models;
using System.Web.Http;

namespace ProjetoPraticoCodenation.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LogErroController : ControllerBase
    {
        private readonly ILogErroService _logErroService;
        private readonly IMapper _mapper;

        public LogErroController(ILogErroService produtoService, IMapper mapper)
        {
            _logErroService = produtoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<LogErroDTO> Get(int id)
        {
           
            var logErro = _logErroService.FindById(id);

            if (logErro != null)
            {
                var retorno = _mapper.Map<LogErroDTO>(logErro);

                return Ok(retorno);
            }
            else
                return NotFound();
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

        [HttpGet]
        public ActionResult<IEnumerable<LogErroDTO>> GetAll(string descricao, string ambiente)
        {
            var listaLogErro = _logErroService.LocalizarPorDescricaoAmbiente(descricao, ambiente);
            
            if (listaLogErro != null)
            {
                var retorno = _mapper.Map<List<LogErroDTO>>(listaLogErro);

                return Ok(retorno);
            }
            else
                return NotFound();

        }

        [HttpPost]
        public ActionResult<LogErroDTO> Post([FromBody]LogErroDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var logErro = new LogErro()
            {
                Titulo = value.Titulo,
                Descricao = value.Descricao,
                Nivel = value.Nivel,
                UsuarioOrigem = value.UsuarioOrigem,
                Evento = value.Evento,
                IPOrigem = value.IPOrigem,
                Arquivado = value.Arquivado,
                Ambiente = value.Ambiente,
                DataCriacao = value.DataCriacao
            };

            var retornoLogErro = _logErroService.Salvar(logErro);

            var retorno = _mapper.Map<LogErroDTO>(retornoLogErro);

            return Ok(retorno);
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
