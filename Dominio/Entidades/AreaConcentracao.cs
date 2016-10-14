using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class AreaConcentracao
    {
        public AreaConcentracao()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<CandidatoProcessoSeletivo> CandidatoProcessoSeletivo { get; set; }
    }
}
