using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel()
        {
            this.avaliacaos = new List<AvaliacaoViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public virtual ICollection<AvaliacaoViewModel> avaliacaos { get; set; }
    }
}
