using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Professor
    {
        public Professor()
        {
            this.Avaliacao = new List<Avaliacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
