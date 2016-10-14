using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;   

namespace Aplicacao
{
    public class EtapaAppServico : AppServicoBase<Etapa>, IEtapaAppServico         
    {                                                                                    
        private readonly IEtapaServico _etapaServico;

        public EtapaAppServico(IEtapaServico etapaServico)
            : base(etapaServico)                                                        
        {
            _etapaServico = etapaServico;                                            
        }                                                        
    }
}
