using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alvo.ViewModels
{
    public class SituacaoAvaliacaoViewModel
    {
        public SituacaoAvaliacaoViewModel()
        {
            this.Avaliacao = new List<AvaliacaoViewModel>();
        }
        public int Id { get; set; }
        public string Situacao { get; set; }
        public virtual ICollection<AvaliacaoViewModel> Avaliacao { get; set; }
    }
}
