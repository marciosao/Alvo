using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class PerfilMenuMap : EntityTypeConfiguration<PerfilMenu>
    {
        public PerfilMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("perfilmenu", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.IdMenu).HasColumnName("IdMenu");

            // Relationships
            this.HasOptional(t => t.menu)
                .WithMany(t => t.PerfilMenus)
                .HasForeignKey(d => d.IdMenu);
            this.HasOptional(t => t.perfil)
                .WithMany(t => t.perfilmenus)
                .HasForeignKey(d => d.IdPerfil);

        }
    }
}
