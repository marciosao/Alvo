using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class RespostaQuestaoMap : EntityTypeConfiguration<RespostaQuestao>
    {
        public RespostaQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ValorResposta)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("respostaquestao", "db_spsgestec");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdQuestao).HasColumnName("IdQuestao");
            this.Property(t => t.IdAvaliacao).HasColumnName("IdAvaliacao");
            this.Property(t => t.ValorResposta).HasColumnName("ValorResposta");

            // Relationships
            this.HasOptional(t => t.Avaliacao)
                .WithMany(t => t.RespostaQuestao)
                .HasForeignKey(d => d.IdAvaliacao);
            this.HasOptional(t => t.Questao)
                .WithMany(t => t.RespostaQuestao)
                .HasForeignKey(d => d.IdQuestao);
        }
    }
}
