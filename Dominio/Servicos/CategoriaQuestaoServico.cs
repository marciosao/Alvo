using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class CategoriaQuestaoServico : ServicoBase<CategoriaQuestao>, ICategoriaQuestaoServico            
    {                                                                              
        private readonly ICategoriaQuestaoRepositorio _categoriaQuestaoRepositorio;                    
                                                                                   
        public CategoriaQuestaoServico(ICategoriaQuestaoRepositorio categoriaQuestaoRepositorio)                
            : base(categoriaQuestaoRepositorio)                                              
        {                                                                          
            _categoriaQuestaoRepositorio = categoriaQuestaoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

