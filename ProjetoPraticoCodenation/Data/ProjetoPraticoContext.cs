using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Models
{
    public class ProjetoPraticoContext : DbContext
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


            if (!optionsBuilder.IsConfigured)
            //ELIS
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QT7ODQ6\SQLEXPRESS;Database=ProjetoPratico;User Id =user_codenation;Password=12345;Trusted_Connection=False;");
        //        //AGATHA
        //        //optionsBuilder.UseSqlServer(@"Server=DESKTOP-KU0JVQH;Database=ProjetoPratico;User Id =user_codenation;Password=1234;Trusted_Connection=False;");
        //        //RAQUEL
        //       // optionsBuilder.UseSqlServer(@"Server=DESKTOP-52JLAFC\SQLEXPRESS;Database=ProjetoPratico;User Id =codenation;Password=1234;Trusted_Connection=False;");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
