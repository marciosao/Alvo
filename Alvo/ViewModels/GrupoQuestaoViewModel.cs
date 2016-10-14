using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class GrupoQuestaoViewModel
    {
        public GrupoQuestaoViewModel()
        {
            this.categoriaquestaos = new List<CategoriaQuestaoViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<CategoriaQuestaoViewModel> categoriaquestaos { get; set; }
    }
}
