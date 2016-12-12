using System.Data.Entity.ModelConfiguration;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Persistence.EntityConfigurations
{
    public class MovieConfigurations : EntityTypeConfiguration<Movie>
    {
        public MovieConfigurations()
        {
            HasKey(m => m.Id);

            Property(m => m.GenreId).IsRequired();

            Property(m => m.Name).HasMaxLength(50).IsRequired();

            Property(m => m.PosterImageUrl).HasMaxLength(400);

            Property(m => m.YoutubeTrailerUrl).HasMaxLength(400);
        }
    }
}