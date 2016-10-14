using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class TipoQuestaoViewModel
    {
        public TipoQuestaoViewModel()
        {
            this.Questao = new List<QuestaoViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<QuestaoViewModel> Questao { get; set; }
    }
}
