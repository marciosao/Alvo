using System;
using System.Collections.Generic;

namespace Alvo.ViewModels
{
    public class ProcessoSeletivoViewModel
    {
        public ProcessoSeletivoViewModel()
        {
            this.candidatoprocessoseletivoes = new List<CandidatoProcessoSeletivoViewModel>();
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
        public virtual ICollection<CandidatoProcessoSeletivoViewModel> candidatoprocessoseletivoes { get; set; }

        public virtual string ProcessoLiberado { 
            get
            {
                if (this.Liberado)
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            } 
        }

        public virtual string ProcessoAtivo
        {
            get
            {
                if (this.Ativo)
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            }
        }
    }
}
