using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;
using System.Collections.Generic;
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class CandidatoProcessoSeletivoServico : ServicoBase<CandidatoProcessoSeletivo>, ICandidatoProcessoSeletivoServico            
    {                                                                              
        private readonly ICandidatoProcessoSeletivoRepositorio _candidatoProcessoSeletivoRepositorio;                    
                                                                                   
        public CandidatoProcessoSeletivoServico(ICandidatoProcessoSeletivoRepositorio candidatoProcessoSeletivoRepositorio)                
            : base(candidatoProcessoSeletivoRepositorio)                                              
        {                                                                          
            _candidatoProcessoSeletivoRepositorio = candidatoProcessoSeletivoRepositorio;                                
        }


        public IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            return _candidatoProcessoSeletivoRepositorio.ObtemTodosSemAvaliacao();
        }


        public IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int? pIdProfessor, int pIdProcessoSeletivo, int pIdSituacaoAvaliacao, int pIdProfessorPesquisa)
        {
            return _candidatoProcessoSeletivoRepositorio.ObtemAvaliacoesPorProfessor(pIdProfessor,pIdProcessoSeletivo,pIdSituacaoAvaliacao,pIdProfessorPesquisa);
        }


        public IEnumerable<CandidatoProcessoSeletivo> ObtemCandidatosClassificacao(int pIdProcessoSeletivo)
        {
            return _candidatoProcessoSeletivoRepositorio.ObtemCandidatosClassificacao(pIdProcessoSeletivo);
        }


        public IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int? pIdProfessor)
        {
            return _candidatoProcessoSeletivoRepositorio.ObtemAvaliacoesPorProfessor(pIdProfessor);
        }
    }                                                                              
}                                                                                  

