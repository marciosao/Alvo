using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Alvo.ViewModels
{
    public class QuestaoViewModel
    {
        public QuestaoViewModel()
        {
            this.OpcaoQuestao = new List<OpcaoQuestaoViewModel>();
            this.RespostaQuestao = new List<RespostaQuestaoViewModel>();
        }

        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Título")]
        public string Descricao { get; set; }

        [DisplayName("Etapa")]
        public int? IdEtapa { get; set; }

        [DisplayName("Tipo da Questão")]
        public int? IdTipoQuestao { get; set; }

        [DisplayName("Categoria")]
        public int? IdCategoriaQuestao { get; set; }

        [DisplayName("Questionário")]
        public int? IdQuestionario { get; set; }

        [DisplayName("Valor")]
        public decimal? ValorBarema { get; set; }

        public virtual EtapaViewModel Etapa { get; set; }
        public virtual CategoriaQuestaoViewModel CategoriaQuestao { get; set; }
        public virtual ICollection<OpcaoQuestaoViewModel> OpcaoQuestao { get; set; }
        public virtual QuestionarioViewModel Questionario { get; set; }
        public virtual TipoQuestaoViewModel tipoquestao { get; set; }
        public virtual List<RespostaQuestaoViewModel> RespostaQuestao { get; set; }
    }
}
