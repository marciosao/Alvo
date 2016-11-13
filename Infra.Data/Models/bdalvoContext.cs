using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Infra.Data.Models.Mapping;
using Dominio.Entidades;

namespace Infra.Data.Models
{
    public class bdalvoContext : DbContext
    {
        static bdalvoContext()
        {
            Database.SetInitializer<bdalvoContext>(null);
        }

        public bdalvoContext()
            : base("Name=bdalvoContext")
        {
        }

        public DbSet<AreaConcentracao> AreaConcentracao { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<AvaliacaoQuestionario> AvaliacaoQuestionario { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<CandidatoProcessoSeletivo> CandidatoProcessoSeletivo { get; set; }
        public DbSet<CategoriaQuestao> CategoriaQuestao { get; set; }
        public DbSet<GrupoQuestao> GrupoQuestao { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<OpcaoQuestao> OpcaoQuestao { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilMenu> PerfilMenu { get; set; }
        public DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Questionario> Questionario { get; set; }
        public DbSet<RespostaQuestao> RespostaQuestao { get; set; }
        public DbSet<TipoQuestao> TipoQuestao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Etapa> Etapa { get; set; }
        public DbSet<SituacaoAvaliacao> SituacaoAvaliacao { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AreaConcentracaoMap());
            modelBuilder.Configurations.Add(new AvaliacaoMap());
            modelBuilder.Configurations.Add(new AvaliacaoQuestionarioMap());
            modelBuilder.Configurations.Add(new CandidatoMap());
            modelBuilder.Configurations.Add(new CandidatoProcessoSeletivoMap());
            modelBuilder.Configurations.Add(new CategoriaQuestaoMap());
            modelBuilder.Configurations.Add(new GrupoQuestaoMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new OpcaoQuestaoMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new PerfilMenuMap());
            modelBuilder.Configurations.Add(new ProcessoSeletivoMap());
            modelBuilder.Configurations.Add(new QuestaoMap());
            modelBuilder.Configurations.Add(new QuestionarioMap());
            modelBuilder.Configurations.Add(new RespostaQuestaoMap());
            modelBuilder.Configurations.Add(new TipoQuestaoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EtapaMap());
            modelBuilder.Configurations.Add(new SituacaoAvaliacaoMap());

            ////////modelBuilder.Properties().Where(p => "Id" + p.Name == p.ReflectedType.Name).Configure(p => p.IsKey());
            modelBuilder.Properties().Where(p => "Id" == p.ReflectedType.Name).Configure(p => p.IsKey());
        }
    }
}
