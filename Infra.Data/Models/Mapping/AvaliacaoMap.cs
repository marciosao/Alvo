using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class AvaliacaoMap : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("avaliacao", "db_spsgestec");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdCandidatoProcessoSeletivo).HasColumnName("IdCandidatoProcessoSeletivo");
            this.Property(t => t.IdProfessor).HasColumnName("IdProfessor");
            this.Property(t => t.IdSituacaoAvaliacao).HasColumnName("IdSituacaoAvaliacao");
            this.Property(t => t.NotaFinal).HasColumnName("NotaFinal");
            this.Property(t => t.DataAvaliacao).HasColumnName("DataAvaliacao");
            this.Property(t => t.Aprovado).HasColumnName("Aprovado");
            this.Property(t => t.Concluida).HasColumnName("Concluida");
            this.Property(t => t.ParecerAvaliador).HasColumnName("ParecerAvaliador");

            // Relationships
            this.HasOptional(t => t.Usuario)
                .WithMany(t => t.Avaliacao)
                .HasForeignKey(d => d.IdProfessor);

            this.HasOptional(t => t.CandidatoProcessoSeletivo)
                .WithMany(t => t.Avaliacao)
                .HasForeignKey(d => d.IdCandidatoProcessoSeletivo);

            this.HasOptional(t => t.SituacaoAvaliacao)
                .WithMany(t => t.Avaliacao)
                .HasForeignKey(d => d.IdSituacaoAvaliacao);
        }
    }
}
