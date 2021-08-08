using FluentValidation.Results;
using IMDb.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Data.Context
{
    public class IMDbDbContext : DbContext
    {
        public IMDbDbContext(DbContextOptions<IMDbDbContext> options) : base(options) { }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Evitar a registrar os mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMDbDbContext).Assembly);

            //Ignora propriedade ValidationResult, não criar no banco de dados
            modelBuilder.Ignore<ValidationResult>();

            base.OnModelCreating(modelBuilder);
        }
    }
}