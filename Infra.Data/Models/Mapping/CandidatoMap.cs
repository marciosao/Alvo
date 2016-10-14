using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class CandidatoMap : EntityTypeConfiguration<Candidato>
    {
        public CandidatoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(70);

            this.Property(t => t.CPF)
                .HasMaxLength(14);

            this.Property(t => t.RG)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("candidato", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.RG).HasColumnName("RG");
        }
    }
}
