using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Avaliacao
    {
        public Avaliacao()
        {
            this.AvaliacaoQuestionario = new List<AvaliacaoQuestionario>();
            this.RespostaQuestao = new List<RespostaQuestao>();
        }

        public int Id { get; set; }
        public int? IdCandidatoProcessoSeletivo { get; set; }
        public int? IdProfessor { get; set; }
        public Nullable<decimal> NotaFinal { get; set; }
        public DateTime? DataAvaliacao { get; set; }
        public bool Aprovado { get; set; }
        public bool Concluido { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual CandidatoProcessoSeletivo CandidatoProcessoSeletivo { get; set; }
        public virtual ICollection<AvaliacaoQuestionario> AvaliacaoQuestionario { get; set; }
        public virtual ICollection<RespostaQuestao> RespostaQuestao { get; set; }
    }
}
