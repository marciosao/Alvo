using AutoMapper;
using Dominio.Entidades;
using Alvo.ViewModels;

namespace Alvo.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AreaConcentracao, AreaConcentracaoViewModel>();
            Mapper.CreateMap<Avaliacao, AvaliacaoViewModel>();
            Mapper.CreateMap<AvaliacaoQuestionario, AvaliacaoQuestionarioViewModel>();
            Mapper.CreateMap<Candidato, CandidatoViewModel>();
            Mapper.CreateMap<CandidatoProcessoSeletivo, CandidatoProcessoSeletivoViewModel>();
            Mapper.CreateMap<CategoriaQuestao, CategoriaQuestaoViewModel>();
            Mapper.CreateMap<GrupoQuestao, GrupoQuestaoViewModel>();
            Mapper.CreateMap<Menu, MenuViewModel>();
            Mapper.CreateMap<OpcaoQuestao, OpcaoQuestaoViewModel>();
            Mapper.CreateMap<Perfil, PerfilViewModel>();
            Mapper.CreateMap<PerfilMenu, PerfilMenuViewModel>();
            Mapper.CreateMap<ProcessoSeletivo, ProcessoSeletivoViewModel>();
            Mapper.CreateMap<Questao, QuestaoViewModel>();
            Mapper.CreateMap<Questionario, QuestionarioViewModel>();
            Mapper.CreateMap<RespostaQuestao, RespostaQuestaoViewModel>();
            Mapper.CreateMap<TipoQuestao, TipoQuestaoViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Etapa, EtapaViewModel>();
            Mapper.CreateMap<SituacaoAvaliacao, SituacaoAvaliacaoViewModel>();
        }
    }
}