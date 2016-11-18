using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class CategoriaQuestaoMap : EntityTypeConfiguration<CategoriaQuestao>
    {
        public CategoriaQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(50);

            // Table & Column Mappings
            ////////this.ToTable("categoriaquestao", "db_spsgestec");
            this.ToTable("CategoriaQuestao");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.IdGrupoQuestao).HasColumnName("IdGrupoQuestao");

            // Relationships
            this.HasOptional(t => t.GrupoQuestao)
                .WithMany(t => t.CategoriaQuestao)
                .HasForeignKey(d => d.IdGrupoQuestao);

        }
    }
}
