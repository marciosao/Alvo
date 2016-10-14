using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class GrupoQuestao
    {
        public GrupoQuestao()
        {
            this.CategoriaQuestao = new List<CategoriaQuestao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<CategoriaQuestao> CategoriaQuestao { get; set; }
    }
}
