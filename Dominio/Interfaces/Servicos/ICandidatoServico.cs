using Dominio.Entidades;
using System.Collections.Generic;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface ICandidatoServico : IServicoBase<Candidato>        
    {
        Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF);
        IEnumerable<Candidato> ObtemCandidatoPorProcesso(int pIdProcessoSeletivo);
    }
}                                                                   

