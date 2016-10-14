using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class RespostaQuestaoViewModel
    {
        public int Id { get; set; }
        public int? IdQuestao { get; set; }
        public int? IdAvaliacao { get; set; }
        public string ValorResposta { get; set; }
        public virtual AvaliacaoViewModel avaliacao { get; set; }
        public virtual QuestaoViewModel questao { get; set; }
    }
}
