using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class AvaliacaoAppServico : AppServicoBase<Avaliacao>, IAvaliacaoAppServico         
    {                                                                                    
        private readonly IAvaliacaoServico _avaliacaoServico;                                
                                                                                         
        public AvaliacaoAppServico(IAvaliacaoServico avaliacaoServico)
            : base(avaliacaoServico)                                                        
        {
            _avaliacaoServico = avaliacaoServico;                                            
        }



        public void GravarRespostasAvaliacao(Avaliacao lAvaliacao)
        {
            throw new System.NotImplementedException();
        }
    }                                                                                    
}                                                                                        

