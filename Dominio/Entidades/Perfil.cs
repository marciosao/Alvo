using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Perfil
    {
        public Perfil()
        {
            this.PerfilMenus = new List<PerfilMenu>();
            this.Usuarios = new List<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenus { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
