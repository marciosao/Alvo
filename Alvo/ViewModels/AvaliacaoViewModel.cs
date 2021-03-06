using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class AvaliacaoViewModel
    {
        public AvaliacaoViewModel()
        {
            this.AvaliacaoQuestionario = new List<AvaliacaoQuestionarioViewModel>();
            this.RespostaQuestao = new List<RespostaQuestaoViewModel>();
        }

        public int Id { get; set; }
        public int? IdCandidatoProcessoSeletivo { get; set; }
        public int? IdProfessor { get; set; }
        public decimal? NotaFinal { get; set; }
        public bool Aprovado { get; set; }
        public bool Concluida { get; set; }
        public DateTime? DataAvaliacao { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual CandidatoProcessoSeletivoViewModel CandidatoProcessoSeletivo { get; set; }
        public virtual ICollection<AvaliacaoQuestionarioViewModel> AvaliacaoQuestionario { get; set; }
        public virtual ICollection<RespostaQuestaoViewModel> RespostaQuestao { get; set; }
    }
}
