using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class OpcaoQuestaoViewModel
    {
        public int Id { get; set; }
        public int? IdQuestao { get; set; }
        public string Descricao { get; set; }
        public virtual QuestaoViewModel questao { get; set; }
    }
}
