using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class PerfilMenu
    {
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
