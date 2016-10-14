using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class CategoriaQuestaoAppServico : AppServicoBase<CategoriaQuestao>, ICategoriaQuestaoAppServico         
    {                                                                                    
        private readonly ICategoriaQuestaoServico _categoriaQuestaoServico;                                
                                                                                         
        public CategoriaQuestaoAppServico(ICategoriaQuestaoServico categoriaQuestaoServico)
            : base(categoriaQuestaoServico)                                                        
        {
            _categoriaQuestaoServico = categoriaQuestaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

