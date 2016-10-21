using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorios            
{
    public interface IAreaConcentracaoRepositorio : IRepositorioBase<AreaConcentracao>   
    {
        AreaConcentracao ObtemAreaConcentracaoPorNome(string pNome);
    }
}

