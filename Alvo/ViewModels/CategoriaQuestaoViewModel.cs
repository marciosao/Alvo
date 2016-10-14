using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class CategoriaQuestaoViewModel
    {
        public CategoriaQuestaoViewModel()
        {
            this.Questao = new List<QuestaoViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdGrupoQuestao { get; set; }
        public virtual GrupoQuestaoViewModel GrupoQuestao { get; set; }
        public virtual ICollection<QuestaoViewModel> Questao { get; set; }
    }
}
