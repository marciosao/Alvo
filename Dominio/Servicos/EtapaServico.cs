using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;   

namespace Dominio.Servicos
{
    public class EtapaServico : ServicoBase<Etapa>, IEtapaServico            
    {                                                                              
        private readonly IEtapaRepositorio _etapaRepositorio;                    
                                                                                   
        public EtapaServico(IEtapaRepositorio etapaRepositorio)                
            : base(etapaRepositorio)                                              
        {                                                                          
            _etapaRepositorio = etapaRepositorio;                                
        }                                                                          
    }
}
