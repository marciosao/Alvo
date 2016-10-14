using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class OpcaoQuestaoMap : EntityTypeConfiguration<OpcaoQuestao>
    {
        public OpcaoQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("opcaoquestao", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdQuestao).HasColumnName("IdQuestao");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            // Relationships
            this.HasOptional(t => t.Questao)
                .WithMany(t => t.OpcaoQuestao)
                .HasForeignKey(d => d.IdQuestao);

        }
    }
}
