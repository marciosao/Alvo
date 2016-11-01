using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class QuestionarioViewModel
    {
        public QuestionarioViewModel()
        {
            this.AvaliacaoQuestionarios = new List<AvaliacaoQuestionarioViewModel>();
            this.Questao = new List<QuestaoViewModel>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public virtual List<AvaliacaoQuestionarioViewModel> AvaliacaoQuestionarios { get; set; }
        public virtual List<QuestaoViewModel> Questao { get; set; }

        public virtual string ParecerAvaliador { get; set; }
    }
}
