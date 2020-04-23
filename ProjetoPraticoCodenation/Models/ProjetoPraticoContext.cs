using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Models
{
    public class ProjetoPraticoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LogErro> Logs { get; set; }


        // this constructor is for enable testing with in-memory data
        public ProjetoPraticoContext(DbContextOptions<ProjetoPraticoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjetoPratico;Trusted_Connection=False");
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-QT7ODQ6\SQLEXPRESS;Database=ProjetoPratico;User Id =user_codenation;Password=12345;Trusted_Connection=False;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogErroConfiguration());
        }
    }
}
