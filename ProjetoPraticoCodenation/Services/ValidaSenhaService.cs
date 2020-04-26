using IdentityServer4.Models;
using IdentityServer4.Validation;
using ProjetoPraticoCodenation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Services
{
    class ValidaSenhaService : IResourceOwnerPasswordValidator
    {
        private readonly ProjetoPraticoContext _context;

        public ValidaSenhaService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Login == context.UserName);

            if (user != null && user.Senha == context.Password) //inicialmente para testes - mudar elis
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user)
                );

                return Task.CompletedTask;
            }
            else
            {
                context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant, "Usuário ou senha inválidos");

                return Task.FromResult(context.Result);
            }

        }
    }
}
