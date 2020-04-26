using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.Controllers
{


    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]


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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<UsuarioDTO> Get(int id)
        {
            var user = _mapper.Map<UsuarioDTO>(_usuarioService.FindById(id));

            if (user != null)
            {
                var retorno = _mapper.Map<UsuarioDTO>(_usuarioService.FindById(id));
                return Ok(retorno);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("getToken")]
        public async Task<ActionResult<TokenResponse>> GetToken([FromBody]TokenDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //endpoint token- http://localhost:5000/connect/token

            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            var TokenClient = new TokenClient(disco.TokenEndpoint, "codenation.api_client", "codenation.api_secret");


            var httpClient = new HttpClient();
            var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "codenation.api_client",
                ClientSecret = "codenation.api_secret",
                UserName = value.UserName,
                Password = value.Password,
                Scope = "codenation"
            });

            if (!tokenResponse.IsError)
            {
                return Ok(tokenResponse);
            }

            return Unauthorized(tokenResponse.ErrorDescription);
        }



    }
}
