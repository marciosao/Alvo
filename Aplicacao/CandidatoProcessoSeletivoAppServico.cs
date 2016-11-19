using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using Dominio.Enums;
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class CandidatoProcessoSeletivoAppServico : AppServicoBase<CandidatoProcessoSeletivo>, ICandidatoProcessoSeletivoAppServico         
    {                                                                                    
        private readonly ICandidatoProcessoSeletivoServico _candidatoProcessoSeletivoServico;
        private readonly IAvaliacaoServico _avaliacaoServico;
        private readonly IAvaliacaoQuestionarioServico _avaliacaoQuestionarioServico;
        private readonly IQuestionarioServico _questionarioServico;
        private readonly IUsuarioServico _usuarioServico;

        public CandidatoProcessoSeletivoAppServico(ICandidatoProcessoSeletivoServico candidatoProcessoSeletivoServico, IAvaliacaoServico avaliacaoServico, IUsuarioServico usuarioServico, IAvaliacaoQuestionarioServico avaliacaoQuestionarioServico, IQuestionarioServico questionarioServico)
            : base(candidatoProcessoSeletivoServico)                                                        
        {
            _candidatoProcessoSeletivoServico = candidatoProcessoSeletivoServico;
            _avaliacaoServico = avaliacaoServico;
            _usuarioServico = usuarioServico;
            _avaliacaoQuestionarioServico = avaliacaoQuestionarioServico;
            _questionarioServico = questionarioServico;
        }

        public IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            return _candidatoProcessoSeletivoServico.ObtemTodosSemAvaliacao();
        }

        public void DistribuiAvaliacaoResponsavel(int pCandidatoProcessoSeletivo, int lIdProfessor)
        {
            CandidatoProcessoSeletivo lCandidatoProcessoSeletivo = _candidatoProcessoSeletivoServico.ObtemPorId(pCandidatoProcessoSeletivo);
            
            //Está fixo pois, neste momento tem apenas 1 questionário
            Questionario lQuestionario = _questionarioServico.ObtemPorId(1);

            Avaliacao lAvaliacao = _avaliacaoServico.ObtemAvaliacaoPorCandidatoProcesso(lCandidatoProcessoSeletivo.Id);
            lAvaliacao.IdProfessor = lIdProfessor;
            ////////lAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIISecretaria;
            lAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIIProfessor;
            _avaliacaoServico.Update(lAvaliacao);

            AvaliacaoQuestionario lAvaliacaoQuestionario = new AvaliacaoQuestionario();
            lAvaliacaoQuestionario.IdAvaliacao = lAvaliacao.Id;
            lAvaliacaoQuestionario.IdQuestionario = lQuestionario.Id;
            _avaliacaoQuestionarioServico.Add(lAvaliacaoQuestionario);
        }

        /// <summary>
        /// Obtem as avaliações por professor com a situação disponível para professor.
        /// </summary>
        /// <param name="pIdProfessor">Identificador do Professor (Id)</param>
        /// <returns>Lista de Candidatos</returns>
        public IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int pIdProfessor, int pIdProcessoSeletivo, int pIdSituacaoAvaliacao, int pIdProfessorPesquisa)
        {
            var lUsuario = _usuarioServico.ObtemPorId(pIdProfessor);
            int lIdProfessor = 0;

            if(lUsuario.Perfil.Id == (int)Dominio.Enums.Perfil.Professor)
            {
                lIdProfessor = lUsuario.Id;
            }
            return _candidatoProcessoSeletivoServico.ObtemAvaliacoesPorProfessor(lIdProfessor,pIdProcessoSeletivo,pIdSituacaoAvaliacao,pIdProfessorPesquisa);
        }

        public IEnumerable<CandidatoProcessoSeletivo> ObtemCandidatosClassificacao(int pIdProcessoSeletivo)
        {
            return _candidatoProcessoSeletivoServico.ObtemCandidatosClassificacao(pIdProcessoSeletivo);
        }
    }                                                                                    
}                                                                                        

