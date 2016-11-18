using Alvo.Common.MvcExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [DisplayName("Data Inicio: ")]
        [Required(ErrorMessage = "*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Mask("99/99/9999", "DataInicio")]
        public DateTime? DataInicio { get; set; }

        [DisplayName("Data Fim: ")]
        [Required(ErrorMessage = "*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Mask("99/99/9999", "DataFim")]
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
