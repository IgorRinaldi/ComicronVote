using ComicronVote.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ComicronVote.Context
{
    public class ComicronDB : DbContext
    {
        public ComicronDB()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ComicronDB;Integrated Security=True; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FilmConfigurations());
            modelBuilder.ApplyConfiguration(new VotoConfigurations());
        }

    }
}
