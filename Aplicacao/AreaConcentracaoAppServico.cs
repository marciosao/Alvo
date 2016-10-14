using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{
    public class AreaConcentracaoAppServico : AppServicoBase<AreaConcentracao>, IAreaConcentracaoAppServico         
    {
        private readonly IAreaConcentracaoServico _areaConcentracaoServico;

        public AreaConcentracaoAppServico(IAreaConcentracaoServico areaConcentracaoServico)
            : base(areaConcentracaoServico)                                                        
        {
            _areaConcentracaoServico = areaConcentracaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

