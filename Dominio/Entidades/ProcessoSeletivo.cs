using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class ProcessoSeletivo
    {
        public ProcessoSeletivo()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivo>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NumeroEdital { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Liberado { get; set; }
        public bool Ativo { get; set; }
        public int? IdUsuarioCadastro { get; set; }
        public int? IdUsuarioLiberacao { get; set; }
        public virtual ICollection<CandidatoProcessoSeletivo> CandidatoProcessoSeletivo { get; set; }
    }
}
