using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class OpcaoQuestao
    {
        public int Id { get; set; }
        public int? IdQuestao { get; set; }
        public string Descricao { get; set; }
        public virtual Questao Questao { get; set; }
    }
}
