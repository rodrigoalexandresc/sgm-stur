using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STUR_mvc.Models
{
    public class InfoGeoMap
    {
        public InfoGeoMap(EntityTypeBuilder<InfoGeo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("infogeo");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.DataAtualizacao).HasColumnName("dataatualizacao");
            entityBuilder.Property(x => x.AreaConstruida).HasColumnName("areaconstruida");
            entityBuilder.Property(x => x.AreaTerreno).HasColumnName("areaterreno");
            entityBuilder.Property(x => x.InscricaoImovel).HasColumnName("inscricaoimovel");
        }
    }
}
