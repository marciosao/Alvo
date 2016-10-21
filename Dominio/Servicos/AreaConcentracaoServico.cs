using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;

namespace Dominio.Servicos                                         
{
    public class AreaConcentracaoServico : ServicoBase<AreaConcentracao>, IAreaConcentracaoServico            
    {
        private readonly IAreaConcentracaoRepositorio _areaConcentracaoRepositorio;

        public AreaConcentracaoServico(IAreaConcentracaoRepositorio areaConcentracaoRepositorio)                
            : base(areaConcentracaoRepositorio)                                              
        {                                                                          
            _areaConcentracaoRepositorio = areaConcentracaoRepositorio;                                
        }

        public AreaConcentracao ObtemAreaConcentracaoPorNome(string pNome)
        {
            return _areaConcentracaoRepositorio.ObtemAreaConcentracaoPorNome(pNome);
        }
    }                                                                              
}                                                                                  

