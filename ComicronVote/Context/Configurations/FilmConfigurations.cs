using ComicronVote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicronVote.Context.Configurations
{
    public class FilmConfigurations : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Regista).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Titolo).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Codice).HasMaxLength(200).IsRequired();
            builder.HasMany(x => x.Voti).WithOne().HasForeignKey(x => x.FilmId);
        }
    }
}
