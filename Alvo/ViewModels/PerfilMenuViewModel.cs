using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class PerfilMenuViewModel
    {
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }
        public virtual MenuViewModel menu { get; set; }
        public virtual PerfilViewModel perfil { get; set; }
    }
}
