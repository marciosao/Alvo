using Dominio.Entidades;
using System.Collections.Generic;                              
                                                                     
namespace Dominio.Interfaces.Repositorios            
{                                                                    
    public interface ICandidatoRepositorio : IRepositorioBase<Candidato>   
    {
        Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF);
        IEnumerable<Candidato> ObtemCandidatoPorProcesso(int pIdProcessoSeletivo);
    }
}                                                                    

