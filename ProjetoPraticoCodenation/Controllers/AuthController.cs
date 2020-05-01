using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Extensions;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetoPraticoCodenation.Models;

namespace ProjetoPraticoCodenation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new IdentityUser // automapper
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            //retorna erro no model ErrorResponse
            return BadRequest(ErrorResponse.FromIdentity(result.Errors.ToList()));
        }



        private async Task<LoginResponseDTO> GerarJwt(string email)
        {
            // buscar usuario na base
            var user = await _userManager.FindByEmailAsync(email);
            // buscar claims
            var claims = await _userManager.GetClaimsAsync(user);
            // buscar regras
            var userRoles = await _userManager.GetRolesAsync(user);

            // add nas claims
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));

            // add roles
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // criar token
            var tokenHandler = new JwtSecurityTokenHandler();

            // chave - app settings
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            // criar token baseado nas info
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            // gerar código
            var encodedToken = tokenHandler.WriteToken(token);

            // add obj resposta
            var response = new LoginResponseDTO
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(2).TotalSeconds,
                UserToken = new UserTokenDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimDTO { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }


    }


}

