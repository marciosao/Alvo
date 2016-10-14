using Dominio.Entidades;                                          
using Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;                        
                                                                                 
namespace Infra.Data.Repositorios                               
{                                                                                
   public class CandidatoProcessoSeletivoRepositorio : RepositorioBase<CandidatoProcessoSeletivo>, ICandidatoProcessoSeletivoRepositorio  
    {
        public IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            var lCandidatoProcessoSeletivo = Db.CandidatoProcessoSeletivo.ToList().Where(x=>
                                                                                           x.IdAreaConcentracao == null);
            return lCandidatoProcessoSeletivo;
        }
    }                                                                            
}                                                                                

