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
        public ActionResult<UsuarioDTO> Get(int id)
        {
            return Ok(_mapper.Map<UsuarioDTO>(_usuarioService.FindById(id)));
        }


    }
}