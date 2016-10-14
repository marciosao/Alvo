using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class AvaliacaoQuestionarioViewModel
    {
        public int Id { get; set; }
        public int? IdAvaliacao { get; set; }
        public int? IdQuestionario { get; set; }
        public virtual AvaliacaoViewModel avaliacao { get; set; }
        public virtual QuestionarioViewModel questionario { get; set; }
    }
}
