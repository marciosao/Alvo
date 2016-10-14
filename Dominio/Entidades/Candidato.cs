using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Candidato
    {
        public Candidato()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public virtual ICollection<CandidatoProcessoSeletivo> CandidatoProcessoSeletivo { get; set; }
    }
}
