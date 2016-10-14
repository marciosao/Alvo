using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Menu
    {
        public Menu()
        {
            this.perfilmenus = new List<PerfilMenu>();
        }

        public int Id { get; set; }
        public int? IdPai { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public virtual ICollection<PerfilMenu> perfilmenus { get; set; }
    }
}
