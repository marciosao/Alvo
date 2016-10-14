using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Questionario
    {
        public Questionario()
        {
            this.AvaliacaoQuestionario = new List<AvaliacaoQuestionario>();
            this.Questao = new List<Questao>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<AvaliacaoQuestionario> AvaliacaoQuestionario { get; set; }
        public virtual ICollection<Questao> Questao { get; set; }
    }
}
