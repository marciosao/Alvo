using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {
            this.PerfilMenus = new List<PerfilMenuViewModel>();
            this.Usuarios = new List<UsuarioViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<PerfilMenuViewModel> PerfilMenus { get; set; }
        public virtual ICollection<UsuarioViewModel> Usuarios { get; set; }
    }
}
