using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.Data.Models.Mapping
{
    public class ProcessoSeletivoMap : EntityTypeConfiguration<ProcessoSeletivo>
    {
        public ProcessoSeletivoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Titulo)
                .HasMaxLength(100);

            this.Property(t => t.NumeroEdital)
                .HasMaxLength(20);

            this.Property(t => t.Descricao)
                .HasMaxLength(65535);

            // Table & Column Mappings
            ////////this.ToTable("processoseletivo", "db_spsgestec");
            this.ToTable("ProcessoSeletivo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.NumeroEdital).HasColumnName("NumeroEdital");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.DataInicio).HasColumnName("DataInicio");
            this.Property(t => t.DataFim).HasColumnName("DataFim");
            this.Property(t => t.Liberado).HasColumnName("Liberado");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
            this.Property(t => t.IdUsuarioCadastro).HasColumnName("IdUsuarioCadastro");
            this.Property(t => t.IdUsuarioLiberacao).HasColumnName("IdUsuarioLiberacao");
        }
    }
}
