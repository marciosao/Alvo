using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class RespostaQuestaoServico : ServicoBase<RespostaQuestao>, IRespostaQuestaoServico            
    {                                                                              
        private readonly IRespostaQuestaoRepositorio _respostaQuestaoRepositorio;                    
                                                                                   
        public RespostaQuestaoServico(IRespostaQuestaoRepositorio respostaQuestaoRepositorio)                
            : base(respostaQuestaoRepositorio)                                              
        {                                                                          
            _respostaQuestaoRepositorio = respostaQuestaoRepositorio;                                
        }

        public RespostaQuestao ObtemPorQuestaoAvaliacao(int? pIdQuestao, int? pIdAvaliacao)
        {
            return _respostaQuestaoRepositorio.ObtemPorQuestaoAvaliacao(pIdQuestao,pIdAvaliacao);
        }
    }                                                                              
}                                                                                  

