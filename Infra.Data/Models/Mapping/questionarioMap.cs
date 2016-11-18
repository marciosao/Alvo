using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class QuestionarioMap : EntityTypeConfiguration<Questionario>
    {
        public QuestionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(65535);

            // Table & Column Mappings
            ////////this.ToTable("questionario", "db_spsgestec");
            this.ToTable("Questionario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
