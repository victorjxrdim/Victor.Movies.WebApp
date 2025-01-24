using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Data.Mappings
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> b)
        {
            b.ToTable("genero");
            b.HasKey(x => x.GenderId);
            b.Property(x => x.GenderId).HasColumnName("GENDER_ID");
            b.Property(x => x.Gender).HasColumnName("GENDER");
        }
    }
}
