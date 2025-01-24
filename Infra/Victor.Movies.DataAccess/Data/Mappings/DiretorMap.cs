using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Data.Mappings
{
    public class DiretorMap : IEntityTypeConfiguration<Diretor>
    {
        public void Configure(EntityTypeBuilder<Diretor> b)
        {
            b.ToTable("diretor");
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).HasColumnName("ID");
            b.Property(x => x.Nome).HasColumnName("NOME");
        }
    }
}
