using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class QuestaoViewModel
    {
        public QuestaoViewModel()
        {
            this.OpcaoQuestao = new List<OpcaoQuestaoViewModel>();
            this.respostaquestaos = new List<RespostaQuestaoViewModel>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdEtapa { get; set; }
        public int? IdTipoQuestao { get; set; }
        public int? IdCategoriaQuestao { get; set; }
        public int? IdQuestionario { get; set; }
        public decimal? ValorBarema { get; set; }
        public virtual EtapaViewModel Etapa { get; set; }
        public virtual CategoriaQuestaoViewModel CategoriaQuestao { get; set; }
        public virtual ICollection<OpcaoQuestaoViewModel> OpcaoQuestao { get; set; }
        public virtual QuestionarioViewModel Questionario { get; set; }
        public virtual TipoQuestaoViewModel tipoquestao { get; set; }
        public virtual ICollection<RespostaQuestaoViewModel> respostaquestaos { get; set; }
    }
}
