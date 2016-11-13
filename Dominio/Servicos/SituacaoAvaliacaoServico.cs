using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;   

namespace Dominio.Servicos
{
    public class SituacaoAvaliacaoServico : ServicoBase<SituacaoAvaliacao>, ISituacaoAvaliacaoServico            
    {                                                                              
        private readonly ISituacaoAvaliacaoRepositorio _situacaoAvaliacaoRepositorio;

        public SituacaoAvaliacaoServico(ISituacaoAvaliacaoRepositorio situacaoAvaliacaoRepositorio)                
            : base(situacaoAvaliacaoRepositorio)                                              
        {
            _situacaoAvaliacaoRepositorio = situacaoAvaliacaoRepositorio;                                
        }                                                                          
    }
}
