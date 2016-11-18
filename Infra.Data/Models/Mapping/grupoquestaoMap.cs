using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class GrupoQuestaoMap : EntityTypeConfiguration<GrupoQuestao>
    {
        public GrupoQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(50);

            // Table & Column Mappings
            ////////this.ToTable("grupoquestao", "db_spsgestec");
            this.ToTable("GrupoQuestao");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
