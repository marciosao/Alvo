using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(70);

            this.Property(t => t.CPF)
                .HasMaxLength(12);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Telefone1)
                .HasMaxLength(12);

            this.Property(t => t.Telefone2)
                .HasMaxLength(12);

            this.Property(t => t.Senha)
                .HasMaxLength(150);

            // Table & Column Mappings
            ////////this.ToTable("Usuario", "db_spsgestec");
            this.ToTable("Usuario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Matricula).HasColumnName("Matricula");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefone1).HasColumnName("Telefone1");
            this.Property(t => t.Telefone2).HasColumnName("Telefone2");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
            this.Property(t => t.Senha).HasColumnName("Senha");

            // Relationships
            this.HasOptional(t => t.Perfil)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.IdPerfil);

        }
    }
}
