using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Data.Mappings
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> b)
        {
            b.ToTable("filme");
            b.HasKey(x => x.MovieId);
            b.Property(x => x.MovieId).HasColumnName("MOVIE_ID");
            b.Property(x => x.MovieName).HasColumnName("MOVIE_NAME");
            b.Property(x => x.MovieYear).HasColumnName("MOVIE_YEAR");
            b.Property(x => x.MovieDirector).HasColumnName("MOVIE_DIRECTOR");
            b.Property(x => x.MovieImg).HasColumnName("MOVIE_IMG");
            b.Property(x => x.GenderId).HasColumnName("GENDER_ID");
            b.Property(x => x.Description).HasColumnName("DESCRIPTION");
            b.Property(x => x.Trailer).HasColumnName("TRAILER");
        }
    }
}
