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
        private readonly IUsuarioServico _usuarioServico;

        public CandidatoProcessoSeletivoAppServico(ICandidatoProcessoSeletivoServico candidatoProcessoSeletivoServico, IAvaliacaoServico avaliacaoServico, IUsuarioServico usuarioServico)
            : base(candidatoProcessoSeletivoServico)                                                        
        {
            _candidatoProcessoSeletivoServico = candidatoProcessoSeletivoServico;
            _avaliacaoServico = avaliacaoServico;
            _usuarioServico = usuarioServico;
        }

        public IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            return _candidatoProcessoSeletivoServico.ObtemTodosSemAvaliacao();
        }

        public void DistribuiAvaliacaoResponsavel(int pCandidatoProcessoSeletivo, int lIdProfessor)
        {
            CandidatoProcessoSeletivo lCandidatoProcessoSeletivo = _candidatoProcessoSeletivoServico.ObtemPorId(pCandidatoProcessoSeletivo);

            Avaliacao lAvaliacao = _avaliacaoServico.ObtemAvaliacaoPorCandidatoProcesso(lCandidatoProcessoSeletivo.Id);

            lAvaliacao.IdProfessor = lIdProfessor;

            _avaliacaoServico.Update(lAvaliacao);
        }

        public IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int pIdProfessor)
        {
            var lUsuario = _usuarioServico.ObtemPorId(pIdProfessor);
            int lIdProfessor = 0;

            if(lUsuario.perfil.Id == (int)Dominio.Enums.Perfil.Professor)
            {
                lIdProfessor = lUsuario.Id;
            }
            return _candidatoProcessoSeletivoServico.ObtemAvaliacoesPorProfessor(lIdProfessor);
        }
    }                                                                                    
}                                                                                        

