using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class TipoQuestaoMap : EntityTypeConfiguration<TipoQuestao>
    {
        public TipoQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("tipoquestao", "db_spsgestec");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
