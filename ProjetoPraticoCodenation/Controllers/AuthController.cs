using System;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Extensions;
using System.Web;
using ProjetoPraticoCodenation.Services;

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
        private readonly IEmailServices _emailServices;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings, IEmailServices emailServices)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _emailServices = emailServices;
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new IdentityUser
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

            return BadRequest(ErrorResponse.FromIdentity(result.Errors.ToList()));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(await GerarJwt(loginUser.Email));
            }
            if (result.IsLockedOut)
            {
                return BadRequest(loginUser);
            }

            return NotFound(loginUser);
        }

        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost("forgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(forgotPassword.Email);

            if (user == null)
            {
                return NotFound($"Usuário '{forgotPassword}' não encontrado.");
            }
            else
            {

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetPassword = new ResetPasswordDTO();
                resetPassword.Code = code;
                resetPassword.Email = user.Email;
                resetPassword.UserId = user.Id;
                return Ok(resetPassword);
            }
        }


        private async Task<EmailResponse> ForgotMainPassword(IdentityUser user)
        {
   
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            //Gerar link
            var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, HttpUtility.UrlEncode(code), Request.Scheme);

            return await _emailServices.SendEmailResetPasswordAsync(user.Email, callbackUrl);
        }


        // utilizar quando for usar sendgrid
        //[HttpGet("resetPassword")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ResetPassword(string userId, string code)
        //{
        //    if (userId == null || code == null)
        //    {
        //        return BadRequest("Não foi possível resetar a senha");
        //    }

        //    var resetPassword = new ResetPasswordDTO();
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return NotFound($"Usuário ID '{userId}' não encontrado.");
        //    }
        //    else
        //    {
        //        resetPassword.Code = code;
        //        resetPassword.Email = user.Email;
        //        resetPassword.UserId = userId;
        //        return Ok(resetPassword);
        //    }
        //}


        [HttpPost("resetPasswordConfirm")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordConfirmDTO resetPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                return NotFound($"Usuário ID não encontrado.");
            }
            else
            {
     
                return Ok(await _userManager.ResetPasswordAsync(user, resetPassword.Code, resetPassword.Password));
            }
        }



        private async Task<LoginResponseDTO> GerarJwt(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

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
