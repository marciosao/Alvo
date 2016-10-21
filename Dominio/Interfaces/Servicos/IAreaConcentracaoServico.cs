using Dominio.Entidades;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{
    public interface IAreaConcentracaoServico : IServicoBase<AreaConcentracao>        
    {
        AreaConcentracao ObtemAreaConcentracaoPorNome(string pNome);
    }                                                               
}                                                                   

