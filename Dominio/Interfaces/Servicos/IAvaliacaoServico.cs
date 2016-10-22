using Dominio.Entidades;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface IAvaliacaoServico : IServicoBase<Avaliacao>        
    {
        Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
    }                                                               
}                                                                   

