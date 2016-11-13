using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class SituacaoAvaliacao
    {
        public SituacaoAvaliacao()
        {
            this.Avaliacao = new List<Avaliacao>();
        }
        public int Id { get; set; }
        public string Situacao { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
