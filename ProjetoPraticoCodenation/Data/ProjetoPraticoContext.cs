using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoPraticoCodenation.Models;

namespace ProjetoPraticoCodenation.Data
{
    public class ProjetoPraticoContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<LogErro> Logs { get; set; }

        // this constructor is for enable testing with in-memory data
        public ProjetoPraticoContext(DbContextOptions<ProjetoPraticoContext> options)
            : base(options)
        {
        }

        public ProjetoPraticoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //usado nos testes
            if (!optionsBuilder.IsConfigured)
                //azure
                //optionsBuilder.UseSqlServer(@"Server=tcp:squad4.database.windows.net,1433;Initial Catalog=ProjetoPratico;Persist Security Info=False;User ID=projetofinal;Password=@ProjetoPratico123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                //ELIS
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-QT7ODQ6\SQLEXPRESS;Database=ProjetoPratico;User Id =user_codenation;Password=12345;Trusted_Connection=False;");
                //AGATHA
                //optionsBuilder.UseSqlServer(@"Server=DESKTOP-KU0JVQH;Database=ProjetoPratico;User Id =user_codenation;Password=1234;Trusted_Connection=False;");
                //RAQUEL
                //optionsBuilder.UseSqlServer(@"Server=DESKTOP-52JLAFC\SQLEXPRESS;Database=ProjetoPratico;User Id =codenation;Password=1234;Trusted_Connection=False;");
        }
    }
}
