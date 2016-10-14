using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class PerfilMenu
    {
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }
        public virtual Menu menu { get; set; }
        public virtual Perfil perfil { get; set; }
    }
}
