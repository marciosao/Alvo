using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class CandidatoProcessoSeletivo
    {
        public CandidatoProcessoSeletivo()
        {
            this.Avaliacao = new List<Avaliacao>();
        }
        
        public int Id { get; set; }
        public int? IdProcessoSeletivo { get; set; }
        public int? IdCandidato { get; set; }
        public int? IdAreaConcentracao { get; set; }
        public string TemaProjeto { get; set; }
        public string DescricaoTema { get; set; }
        public virtual AreaConcentracao AreaConcentracao { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual ProcessoSeletivo ProcessoSeletivo { get; set; }

        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
