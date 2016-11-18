using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class SituacaoAvaliacaoMap : EntityTypeConfiguration<SituacaoAvaliacao>
    {
        public SituacaoAvaliacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Situacao)
                .HasMaxLength(20);

            // Table & Column Mappings
            ////////this.ToTable("SituacaoAvaliacao", "db_spsgestec");
            this.ToTable("SituacaoAvaliacao");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Situacao).HasColumnName("Situacao");
        }
    }
}
