using Dominio.Entidades;                                    
                                                                           
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface IQuestionarioAppServico : IAppServicoBase<Questionario>         
    {
        Questionario ObtemQuestionarioPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
    }                                                                      
}                                                                          

