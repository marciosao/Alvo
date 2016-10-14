using Dominio.Entidades;
using System.IO;
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface ICandidatoAppServico : IAppServicoBase<Candidato>         
    {
        void ImportarCandidatos(int pIdProcessoSeletivo, string pCaminhoArquivo);

        Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF);
    }                                                                      
}                                                                          

