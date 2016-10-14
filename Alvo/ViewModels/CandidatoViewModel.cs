using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class CandidatoViewModel
    {
        public CandidatoViewModel()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivoViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public virtual ICollection<CandidatoProcessoSeletivoViewModel> CandidatoProcessoSeletivo { get; set; }

        public virtual string DataFormatada { 
            get
            {
                return DataNascimento.ToShortDateString();
            } 
        }
    }
}
