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
            this.Questao = new List<QuestaoViewModel>();
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
        public virtual List<RespostaQuestaoViewModel> RespostaQuestao { get; set; }

        public virtual string NomePrefessor
        {
            get
            {
                if (Usuario !=null)
                {
                    return Usuario.Nome;
                }
                else
                {
                    return "-";
                }
            }
        }

        public virtual QuestionarioViewModel Questionario { get; set; }

        public virtual List<QuestaoViewModel> Questao { get; set; }
    }
}
