using Dominio.Entidades;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface ICandidatoServico : IServicoBase<Candidato>        
    {
        Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF);
    }
}                                                                   

