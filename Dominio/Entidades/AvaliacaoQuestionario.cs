using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class AvaliacaoQuestionario
    {
        public int Id { get; set; }
        public int? IdAvaliacao { get; set; }
        public int? IdQuestionario { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Questionario Questionario { get; set; }
    }
}
