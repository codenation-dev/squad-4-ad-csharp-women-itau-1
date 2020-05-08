using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Services;
using System.Collections.Generic;
using ProjetoPraticoCodenation.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPraticoCodenation.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        // GET api/LogErro/{nivel, ambiente, teste}
        [HttpGet("BuscarNivelAmbiente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LogErroDTO>> GetNivelAmbiente(string nivel, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            var listaLogErro = _logErroService.LocalizarPorNivelAmbiente(nivel, ambiente);


            if (listaLogErro != null)
            {
                if (ordenarPorNivel)
                {
                    listaLogErro = _logErroService.OrdenarPorNivel(listaLogErro);
                }
                else if (ordenarPorFrequencia)
                {
                    listaLogErro = _logErroService.OrdenarPorFrequencia(listaLogErro);
                }

                var retorno = _mapper.Map<List<LogErroDTO>>(listaLogErro);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

        // GET api/LogErro/{ambiente}
        [HttpGet("BuscarAmbiente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LogErroDTO>> GetAmbiente(string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            var listaLogErro = _logErroService.LocalizarPorAmbiente(ambiente);

            if (listaLogErro != null)
            {
                if (ordenarPorNivel)
                {
                    listaLogErro = _logErroService.OrdenarPorNivel(listaLogErro);
                }
                else if (ordenarPorFrequencia)
                {
                    listaLogErro = _logErroService.OrdenarPorFrequencia(listaLogErro);
                }

                var retorno = _mapper.Map<List<LogErroDTO>>(listaLogErro);
                return Ok(retorno);
            }
            else
                return NotFound();
        }
        // GET api/LogErro/{descricao, ambiente}
        [HttpGet("BuscarDescricaoAmbiente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LogErroDTO>> GetDescricaoAmbiente(string descricao, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            var listaLogErro = _logErroService.LocalizarPorDescricaoAmbiente(descricao, ambiente);

            if (listaLogErro != null)
            {
                if (ordenarPorNivel)
                {
                    listaLogErro = _logErroService.OrdenarPorNivel(listaLogErro);
                }
                else if (ordenarPorFrequencia)
                {
                    listaLogErro = _logErroService.OrdenarPorFrequencia(listaLogErro);
                }

                var retorno = _mapper.Map<List<LogErroDTO>>(listaLogErro);
                return Ok(retorno);
            }
            else
                return NotFound();
        }
        // GET api/LogErro/{origem, ambiente, teste}
        [HttpGet("BuscarOrigemAmbiente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LogErroDTO>> GetOrigemAmbiente(string origem, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            var listaLogErro = _logErroService.LocalizarPorOrigemAmbiente(origem, ambiente);

            if (listaLogErro != null)
            {
                if (ordenarPorNivel) {                    
                     listaLogErro = _logErroService.OrdenarPorNivel(listaLogErro);
                }
                else if (ordenarPorFrequencia){
                     listaLogErro = _logErroService.OrdenarPorFrequencia(listaLogErro);
                }
               
                var retorno = _mapper.Map<List<LogErroDTO>>(listaLogErro);
                return Ok(retorno);
            }
            else
                return NotFound();
        }
        [HttpGet("Arquivados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LogErroDTO> GetArquivados()
        {
            var logErro = _logErroService.LocalizarArquivados();

            if (logErro != null)
            {
                var retorno = _mapper.Map<List<LogErroDTO>>(logErro);

                return Ok(retorno);
            }
            else
                return NoContent();
        }
        // POST api/Incluir
        [HttpPost("Incluir")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<LogErroDTO>> Post([FromBody]List<LogErroDTO> value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<LogErroDTO> retorno = new List<LogErroDTO>();

            foreach (LogErroDTO log in value)
            {
                var logErro = new LogErro()
                {
                    Titulo = log.Titulo,
                    Descricao = log.Descricao,
                    Nivel = log.Nivel,
                    UsuarioOrigem = log.UsuarioOrigem,
                    Evento = log.Evento,
                    Origem = log.Origem,
                    Arquivado = false,
                    Ambiente = log.Ambiente,
                    DataCriacao = log.DataCriacao
                };

                var retornoLogErro = _logErroService.Salvar(logErro);

                retorno.Add(_mapper.Map<LogErroDTO>(retornoLogErro));
            }

            return Ok(retorno);
        }
        // PUT api/Arquivar
        [HttpPut("Arquivar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]    
        public ActionResult Arquivar(IList<int> listaIds)
        {
            if (listaIds.Count == 0)
                return BadRequest("Nenhum item para arquivar");

            foreach (int id in listaIds)
            {
                _logErroService.Arquivar(id);
            }

            return Ok();
        }
        // PUT api/Desarquivar
        [HttpPut("Desarquivar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Desarquivar(IList<int> listaIds)
        {
            if (listaIds.Count == 0)
                return BadRequest("Nenhum item para desarquivar");

            foreach (int id in listaIds)
            {
                _logErroService.Desarquivar(id);
            }

            return Ok();
        }
        // DELETE api/Remover
        [HttpDelete("Remover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(IList<int> listaIds)
        {
            if (listaIds.Count == 0)
                return BadRequest("Nenhum item para deletar");

            foreach (int id in listaIds)
            {
                _logErroService.Remover(id);
            }

            return Ok();
        }
    }
}
