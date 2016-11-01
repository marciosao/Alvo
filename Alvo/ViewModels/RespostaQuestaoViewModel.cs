using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alvo.ViewModels
{
    public class RespostaQuestaoViewModel
    {
        public int Id { get; set; }
        public int? IdQuestao { get; set; }
        public int? IdAvaliacao { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99.99)]
        public string ValorResposta { get; set; }
        public virtual AvaliacaoViewModel avaliacao { get; set; }
        public virtual QuestaoViewModel questao { get; set; }
    }
}
