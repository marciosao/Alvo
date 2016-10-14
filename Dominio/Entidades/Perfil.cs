using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Perfil
    {
        public Perfil()
        {
            this.perfilmenus = new List<PerfilMenu>();
            this.usuarios = new List<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<PerfilMenu> perfilmenus { get; set; }
        public virtual ICollection<Usuario> usuarios { get; set; }
    }
}
