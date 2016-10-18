using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class AreaConcentracaoRepositorio : RepositorioBase<AreaConcentracao>, IAreaConcentracaoRepositorio  
    {
        public AreaConcentracao ObtemAreaConcentracaoPorNome(string pNome)
        {
            var areaConcentracao = Db.AreaConcentracao.FirstOrDefault(x => x.Nome.Contains(pNome.Trim().TrimEnd().TrimStart()));

            return areaConcentracao;
        }
    }                                                                            
}                                                                                

