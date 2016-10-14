using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {
            this.perfilmenus = new List<PerfilMenuViewModel>();
            this.usuarios = new List<UsuarioViewModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<PerfilMenuViewModel> perfilmenus { get; set; }
        public virtual ICollection<UsuarioViewModel> usuarios { get; set; }
    }
}
