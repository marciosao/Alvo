using Dominio.Entidades;                              
                                                                     
namespace Dominio.Interfaces.Repositorios            
{                                                                    
    public interface IQuestionarioRepositorio : IRepositorioBase<Questionario>   
    {
        Questionario ObtemQuestionarioPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
    }                                                                
}                                                                    

