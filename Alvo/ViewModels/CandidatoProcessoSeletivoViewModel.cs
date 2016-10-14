using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class CandidatoProcessoSeletivoViewModel
    {
        public int Id { get; set; }
        public int? IdProcessoSeletivo { get; set; }
        public int? IdCandidato { get; set; }
        public int? IdAreaConcentracao { get; set; }
        public string TemaProjeto { get; set; }
        public string DescricaoTema { get; set; }
        public virtual AreaConcentracaoViewModel AreaConcentracao { get; set; }
        public virtual CandidatoViewModel Candidato { get; set; }
        public virtual ProcessoSeletivoViewModel ProcessoSeletivo { get; set; }
    }
}
