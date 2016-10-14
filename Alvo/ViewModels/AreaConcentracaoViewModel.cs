using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class AreaConcentracaoViewModel
    {
        public AreaConcentracaoViewModel()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivoViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<CandidatoProcessoSeletivoViewModel> CandidatoProcessoSeletivo { get; set; }
    }
}
