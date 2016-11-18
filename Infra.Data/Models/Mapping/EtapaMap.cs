using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class EtapaMap : EntityTypeConfiguration<Etapa>
    {
        public EtapaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(20);

            // Table & Column Mappings
            ////////this.ToTable("etapa", "db_spsgestec");
            this.ToTable("Etapa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
