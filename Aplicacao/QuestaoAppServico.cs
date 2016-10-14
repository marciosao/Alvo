using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class QuestaoAppServico : AppServicoBase<Questao>, IQuestaoAppServico         
    {                                                                                    
        private readonly IQuestaoServico _questaoServico;                                
                                                                                         
        public QuestaoAppServico(IQuestaoServico questaoServico)
            : base(questaoServico)                                                        
        {
            _questaoServico = questaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

