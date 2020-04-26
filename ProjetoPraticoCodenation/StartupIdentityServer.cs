using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Validation;
using IdentityServer4.Services;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.ConfigStartup
{
    public class StartupIdentityServer
    {
        private object identitySrvConfig;

        public IHostingEnvironment Environment { get; }

        public StartupIdentityServer(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
 
            services.AddDbContext<ProjetoPraticoContext>();
            services.AddScoped<IResourceOwnerPasswordValidator, ValidaSenhaService>();
            services.AddScoped<IProfileService, UserProfileService>();

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityConfig.GetRecursosIdentity())
                .AddInMemoryApiResources(IdentityConfig.GetApis())
                .AddInMemoryClients(IdentityConfig.GetClients())
                .AddProfileService<UserProfileService>();


            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("Ambiente de produção precisa de chave real");
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIdentityServer();
        }

    }
}
