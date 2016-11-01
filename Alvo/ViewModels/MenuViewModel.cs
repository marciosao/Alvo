using System;
using System.Collections.Generic;
using System.Linq;

namespace Alvo.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            this.perfilmenus = new List<PerfilMenuViewModel>();
            this.SubMenus = new List<MenuViewModel>();
        }

        public int Id { get; set; }
        public int? IdPai { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }

        public virtual string Action
        {
            get { return Url != null && !Url.Split('/').Any() ? String.Empty : Url.Split('/')[1]; }
            set { }
        }

        public virtual string Controller
        {
            get { return Url != null && !Url.Split('/').Any() ? String.Empty : Url.Split('/')[0]; }
            set { }
        }

        public virtual ICollection<MenuViewModel> SubMenus { get; set; }
        public virtual MenuViewModel MenuPai { get; set; }
        public virtual ICollection<PerfilMenuViewModel> perfilmenus { get; set; }
    }
}
