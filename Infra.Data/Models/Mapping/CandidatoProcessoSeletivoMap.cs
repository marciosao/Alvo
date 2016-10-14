using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class CandidatoProcessoSeletivoMap : EntityTypeConfiguration<CandidatoProcessoSeletivo>
    {
        public CandidatoProcessoSeletivoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TemaProjeto)
                .HasMaxLength(150);

            this.Property(t => t.DescricaoTema)
                .HasMaxLength(65535);

            // Table & Column Mappings
            this.ToTable("candidatoprocessoseletivo", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdProcessoSeletivo).HasColumnName("IdProcessoSeletivo");
            this.Property(t => t.IdCandidato).HasColumnName("IdCandidato");
            this.Property(t => t.IdAreaConcentracao).HasColumnName("IdAreaConcentracao");
            this.Property(t => t.TemaProjeto).HasColumnName("TemaProjeto");
            this.Property(t => t.DescricaoTema).HasColumnName("DescricaoTema");

            // Relationships
            this.HasOptional(t => t.AreaConcentracao)
                .WithMany(t => t.CandidatoProcessoSeletivo)
                .HasForeignKey(d => d.IdAreaConcentracao);
            this.HasOptional(t => t.Candidato)
                .WithMany(t => t.CandidatoProcessoSeletivo)
                .HasForeignKey(d => d.IdCandidato);
            this.HasOptional(t => t.ProcessoSeletivo)
                .WithMany(t => t.CandidatoProcessoSeletivo)
                .HasForeignKey(d => d.IdProcessoSeletivo);

        }
    }
}
