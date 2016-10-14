using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class QuestaoMap : EntityTypeConfiguration<Questao>
    {
        public QuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("questao", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.IdTipoQuestao).HasColumnName("IdTipoQuestao");
            this.Property(t => t.IdCategoriaQuestao).HasColumnName("IdCategoriaQuestao");
            this.Property(t => t.IdQuestionario).HasColumnName("IdQuestionario");
            this.Property(t => t.ValorBarema).HasColumnName("ValorBarema");
            this.Property(t => t.IdEtapa).HasColumnName("IdEtapa");

            // Relationships
            this.HasOptional(t => t.CategoriaQuestao)
                .WithMany(t => t.Questao)
                .HasForeignKey(d => d.IdCategoriaQuestao);
            this.HasOptional(t => t.Questionario)
                .WithMany(t => t.Questao)
                .HasForeignKey(d => d.IdQuestionario);
            this.HasOptional(t => t.TipoQuestao)
                .WithMany(t => t.Questao)
                .HasForeignKey(d => d.IdTipoQuestao);
            this.HasOptional(t => t.Etapa)
                .WithMany(t=>t.Questao)
                .HasForeignKey(d => d.IdEtapa);

            ////////modelBuilder.Entity<Completed>().HasRequired(e => e.OldStep).WithMany().HasForeignKey(e => e.OldStepId);

        }
    }
}
