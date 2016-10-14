using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class QuestaoServico : ServicoBase<Questao>, IQuestaoServico            
    {                                                                              
        private readonly IQuestaoRepositorio _questaoRepositorio;                    
                                                                                   
        public QuestaoServico(IQuestaoRepositorio questaoRepositorio)                
            : base(questaoRepositorio)                                              
        {                                                                          
            _questaoRepositorio = questaoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

