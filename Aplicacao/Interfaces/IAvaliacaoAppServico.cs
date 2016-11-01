using Dominio.Entidades;                                    
                                                                           
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface IAvaliacaoAppServico : IAppServicoBase<Avaliacao>         
    {
        void GravarRespostasAvaliacao(Avaliacao lAvaliacao);
    }                                                                      
}                                                                          

