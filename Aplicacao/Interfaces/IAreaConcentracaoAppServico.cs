using Dominio.Entidades;                                    
                                                                           
namespace Aplicacao.Interfaces                           
{
    public interface IAreaConcentracaoAppServico : IAppServicoBase<AreaConcentracao>         
    {
        AreaConcentracao ObtemAreaConcentracaoPorNome(string pNome);
    }
}                                                                          

