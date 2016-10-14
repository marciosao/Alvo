using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(50);

            this.Property(t => t.Url)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("menu", "bdalvo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdPai).HasColumnName("IdPai");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Url).HasColumnName("Url");
        }
    }
}
