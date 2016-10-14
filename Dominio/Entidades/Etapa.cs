using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Etapa
    {
        public Etapa()
        {
            this.Questao = new List<Questao>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Questao> Questao { get; set; }
    }
}
