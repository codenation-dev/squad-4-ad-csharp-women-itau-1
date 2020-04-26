using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        private IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        //GET api/usuario/{id}
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


        [HttpPost]
        public ActionResult<LogErroDTO> Post([FromBody]LogErroDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ErrorResponse.FromModelState(ModelState));

            var logErro = new logErro()
            {
                Titulo = value.Titulo,
                Descricao = value.Descricao,
                Nivel = value.Nivel,
                UsuarioOrigem = value.UsuarioOrigem,
                Evento = value.Evento,
                IPOrigem = value.IPOrigem,
                eArquivado = value.Arquivado,
                Ambiente = value.Ambiente,
                DataCriacao = value.DataCriacao
            };

            var retornoLogErro = _logErroService.Salvar(logErro);

            var retorno = _mapper.Map<LogErroDTO>(retornoLogErro);

            return Ok(retorno);
        }

    }
}