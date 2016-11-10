using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class AvaliacaoQuestionarioMap : EntityTypeConfiguration<AvaliacaoQuestionario>
    {
        public AvaliacaoQuestionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("avaliacaoquestionario", "db_spsgestec");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdAvaliacao).HasColumnName("IdAvaliacao");
            this.Property(t => t.IdQuestionario).HasColumnName("IdQuestionario");

            // Relationships
            this.HasOptional(t => t.Avaliacao)
                .WithMany(t => t.AvaliacaoQuestionario)
                .HasForeignKey(d => d.IdAvaliacao);
            this.HasOptional(t => t.Questionario)
                .WithMany(t => t.AvaliacaoQuestionario)
                .HasForeignKey(d => d.IdQuestionario);

        }
    }
}
