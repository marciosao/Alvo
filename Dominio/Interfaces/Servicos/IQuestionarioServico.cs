using Dominio.Entidades;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface IQuestionarioServico : IServicoBase<Questionario>        
    {
        Questionario ObtemQuestionarioPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
    }                                                               
}                                                                   

