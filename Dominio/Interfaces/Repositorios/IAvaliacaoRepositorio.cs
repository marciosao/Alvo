using Dominio.Entidades;                              
                                                                     
namespace Dominio.Interfaces.Repositorios            
{                                                                    
    public interface IAvaliacaoRepositorio : IRepositorioBase<Avaliacao>   
    {
        Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
    }                                                                
}                                                                    

