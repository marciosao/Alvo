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
            this.Property(t => t.OrgaoExpedidor).HasColumnName("OrgaoExpedidor");
            this.Property(t => t.CotaNegros).HasColumnName("CotaNegros");
            this.Property(t => t.LinguaEstrangeira).HasColumnName("LinguaEstrangeira");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.NecessidadesEspeciais).HasColumnName("NecessidadesEspeciais ");
            this.Property(t => t.TipoNecessidade).HasColumnName("TipoNecessidade"); 
            this.Property(t => t.Curso).HasColumnName("Curso");
            this.Property(t => t.Instituicao).HasColumnName("Instituicao");
        }
    }
}
