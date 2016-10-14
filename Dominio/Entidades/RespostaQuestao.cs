using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class RespostaQuestao
    {
        public int Id { get; set; }
        public int? IdQuestao { get; set; }
        public int? IdAvaliacao { get; set; }
        public string ValorResposta { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Questao Questao { get; set; }
    }
}
