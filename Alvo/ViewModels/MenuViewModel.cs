using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            this.perfilmenus = new List<PerfilMenuViewModel>();
        }

        public int Id { get; set; }
        public int? IdPai { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public virtual ICollection<PerfilMenuViewModel> perfilmenus { get; set; }
    }
}
