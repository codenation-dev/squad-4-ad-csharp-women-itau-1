using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using ProjetoPraticoCodenation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Services
{
    public class UserProfileService : IProfileService
    {

        private ProjetoPraticoContext _context;

        public UserProfileService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {

            var request = context.ValidatedRequest as ValidatedTokenRequest;

            if (request != null)
            {
                var user = _context.Usuarios.FirstOrDefault(x => x.Login == request.UserName);
                if (user != null)
                    context.AddRequestedClaims(GetUserClaims(user));
            }

            return Task.CompletedTask;
        }


        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }


        public static Claim[] GetUserClaims(Usuario user)
        {
            return new[]
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Login),
                new Claim(ClaimTypes.Role, "user")
            };
        }


    }
}
