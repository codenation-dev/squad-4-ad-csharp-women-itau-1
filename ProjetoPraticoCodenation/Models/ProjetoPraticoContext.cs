using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Models
{
    public class ProjetoPraticoContext : DbContext
    {
        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
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
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjetoPratico;Trusted_Connection=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}