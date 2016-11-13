using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alvo.ViewModels;
using Dominio.Entidades;
using AutoMapper;

namespace Alvo.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AreaConcentracaoViewModel, AreaConcentracao>();
            Mapper.CreateMap<AvaliacaoViewModel, Avaliacao>();
            Mapper.CreateMap<AvaliacaoQuestionarioViewModel, AvaliacaoQuestionario>();
            Mapper.CreateMap<CandidatoViewModel, Candidato>();
            Mapper.CreateMap<CandidatoProcessoSeletivoViewModel, CandidatoProcessoSeletivo>();
            Mapper.CreateMap<CategoriaQuestaoViewModel, CategoriaQuestao>();
            Mapper.CreateMap<GrupoQuestaoViewModel, GrupoQuestao>();
            Mapper.CreateMap<MenuViewModel, Menu>();
            Mapper.CreateMap<OpcaoQuestaoViewModel, OpcaoQuestao>();
            Mapper.CreateMap<PerfilViewModel, Perfil>();
            Mapper.CreateMap<PerfilMenuViewModel, PerfilMenu>();
            Mapper.CreateMap<ProcessoSeletivoViewModel, ProcessoSeletivo>();
            Mapper.CreateMap<QuestaoViewModel, Questao>();
            Mapper.CreateMap<QuestionarioViewModel, Questionario>();
            Mapper.CreateMap<RespostaQuestaoViewModel, RespostaQuestao>();
            Mapper.CreateMap<TipoQuestaoViewModel, TipoQuestao>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<EtapaViewModel, Etapa>();
            Mapper.CreateMap<SituacaoAvaliacaoViewModel, SituacaoAvaliacao>();
        }
    }
}