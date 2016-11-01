using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Menu
    {
        public Menu()
        {
            this.PerfilMenus = new List<PerfilMenu>();
        }

        public int Id { get; set; }
        public int? IdPai { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public virtual ICollection<Menu> SubMenus { get; set; }
        public virtual Menu MenuPai { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenus { get; set; }
    }
}
