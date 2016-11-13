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
        public int? IdSituacaoAvaliacao { get; set; }
        public decimal? NotaFinal { get; set; }
        public bool Aprovado { get; set; }
        public bool Concluida { get; set; }
        public DateTime? DataAvaliacao { get; set; }
        public string ParecerAvaliador { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual SituacaoAvaliacaoViewModel SituacaoAvaliacao { get; set; }
        public virtual CandidatoProcessoSeletivoViewModel CandidatoProcessoSeletivo { get; set; }
        public virtual ICollection<AvaliacaoQuestionarioViewModel> AvaliacaoQuestionario { get; set; }
        public virtual List<RespostaQuestaoViewModel> RespostaQuestao { get; set; }

        public virtual string NomePrefessor
        {
            get
            {
                if (Usuario != null)
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

        public virtual string Resultado
        {
            get
            {
                return (Aprovado == false) ? "Reprovado" : "Aprovado";
            }
        }

        public virtual string Situacao
        {
            get
            {
                return (Concluida == false) ? "Pendente" : "Concluída";
            }
        }
    }
}
