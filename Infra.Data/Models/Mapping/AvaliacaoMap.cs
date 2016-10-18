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
            this.ToTable("avaliacao", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdCandidatoProcessoSeletivo).HasColumnName("IdCandidatoProcessoSeletivo");
            this.Property(t => t.IdProfessor).HasColumnName("IdProfessor");
            this.Property(t => t.NotaFinal).HasColumnName("NotaFinal");
            this.Property(t => t.DataAvaliacao).HasColumnName("DataAvaliacao");
            this.Property(t => t.Aprovado).HasColumnName("Aprovado");
            this.Property(t => t.Concluido).HasColumnName("Concluido");

            // Relationships
            this.HasOptional(t => t.Usuario)
                .WithMany(t => t.Avaliacao)
                .HasForeignKey(d => d.IdProfessor);

        }
    }
}
