using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class PerfilMenuViewModel
    {
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }


        public virtual MenuViewModel Menu { get; set; }
        public virtual PerfilViewModel Perfil { get; set; }
    }
}
