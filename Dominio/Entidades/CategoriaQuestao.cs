using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class CategoriaQuestao
    {
        public CategoriaQuestao()
        {
            this.Questao = new List<Questao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdGrupoQuestao { get; set; }
        public virtual GrupoQuestao GrupoQuestao { get; set; }
        public virtual ICollection<Questao> Questao { get; set; }
    }
}
