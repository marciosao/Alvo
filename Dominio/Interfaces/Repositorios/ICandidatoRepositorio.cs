using Dominio.Entidades;                              
                                                                     
namespace Dominio.Interfaces.Repositorios            
{                                                                    
    public interface ICandidatoRepositorio : IRepositorioBase<Candidato>   
    {
        Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF);
    }
}                                                                    

