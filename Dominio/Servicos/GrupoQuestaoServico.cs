using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class GrupoQuestaoServico : ServicoBase<GrupoQuestao>, IGrupoQuestaoServico            
    {                                                                              
        private readonly IGrupoQuestaoRepositorio _grupoQuestaoRepositorio;                    
                                                                                   
        public GrupoQuestaoServico(IGrupoQuestaoRepositorio grupoQuestaoRepositorio)                
            : base(grupoQuestaoRepositorio)                                              
        {                                                                          
            _grupoQuestaoRepositorio = grupoQuestaoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

