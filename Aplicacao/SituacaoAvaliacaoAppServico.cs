using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;   

namespace Aplicacao
{
    public class SituacaoAvaliacaoAppServico : AppServicoBase<SituacaoAvaliacao>, ISituacaoAvaliacaoAppServico         
    {                                                                                    
        private readonly ISituacaoAvaliacaoServico _situacaoAvaliacaoServico;

        public SituacaoAvaliacaoAppServico(ISituacaoAvaliacaoServico situacaoAvaliacaoServico)
            : base(situacaoAvaliacaoServico)                                                        
        {
            _situacaoAvaliacaoServico = situacaoAvaliacaoServico;                                            
        }                                                        
    }
}
