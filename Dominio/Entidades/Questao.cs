using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Questao
    {
        public Questao()
        {
            this.OpcaoQuestao = new List<OpcaoQuestao>();
            this.RespostaQuestao = new List<RespostaQuestao>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdEtapa { get; set; }
        public int? IdTipoQuestao { get; set; }
        public int? IdCategoriaQuestao { get; set; }
        public int? IdQuestionario { get; set; }
        public Nullable<decimal> ValorBarema { get; set; }
        public virtual Etapa Etapa { get; set; }
        public virtual CategoriaQuestao CategoriaQuestao { get; set; }
        public virtual ICollection<OpcaoQuestao> OpcaoQuestao { get; set; }
        public virtual Questionario Questionario { get; set; }
        public virtual TipoQuestao TipoQuestao { get; set; }
        public virtual ICollection<RespostaQuestao> RespostaQuestao { get; set; }
    }
}
