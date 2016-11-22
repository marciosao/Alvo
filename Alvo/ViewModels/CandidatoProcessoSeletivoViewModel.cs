using System;
using System.Collections.Generic;
using System.Linq;

namespace Alvo.ViewModels
{
    public class CandidatoProcessoSeletivoViewModel
    {
        public CandidatoProcessoSeletivoViewModel()
        {
            this.Avaliacao = new List<AvaliacaoViewModel>();
        }
        public int Id { get; set; }
        public int? IdProcessoSeletivo { get; set; }
        public int? IdCandidato { get; set; }
        public int? IdAreaConcentracao { get; set; }
        public string TemaProjeto { get; set; }
        public string DescricaoTema { get; set; }
        public virtual AreaConcentracaoViewModel AreaConcentracao { get; set; }
        public virtual CandidatoViewModel Candidato { get; set; }
        public virtual ProcessoSeletivoViewModel ProcessoSeletivo { get; set; }

        public virtual ICollection<AvaliacaoViewModel> Avaliacao { get; set; }

        public virtual string EstadoAvaliacao
        {
            get
            {
                string lRetorno = string.Empty;
                var lAvaliacao = this.Avaliacao.Where(x => x.IdCandidatoProcessoSeletivo == this.Id).First();

                if (lAvaliacao.Concluida)
                {
                    lRetorno = "Finalizada";
                }
                else
                {
                    lRetorno = "Pendente";
                }

                return lRetorno;
            }
        }

        public virtual string SituacaoAvaliacao
        {
            get
            {
                string lRetorno = string.Empty;
                var lAvaliacao = this.Avaliacao.Where(x => x.IdCandidatoProcessoSeletivo == this.Id).First();

                return lAvaliacao.SituacaoAvaliacao.Situacao;
            }
        }

        public virtual string Resultado
        {
            get
            {
                string lRetorno = string.Empty;
                var lAvaliacao = this.Avaliacao.Where(x => x.IdCandidatoProcessoSeletivo == this.Id).First();

                if (lAvaliacao.Concluida && lAvaliacao.Aprovado)
                {
                    lRetorno = "Aprovado";
                }
                else if (lAvaliacao.Concluida && !lAvaliacao.Aprovado)
                {
                    lRetorno = "Reprovado";
                }
                else
                {
                    lRetorno = "-";
                }

                return lRetorno;
            }
        }

        public virtual string Professor
        {
            get
            {
                string lRetorno = string.Empty;

                lRetorno = (this.Avaliacao.FirstOrDefault().IdProfessor != null) ? this.Avaliacao.FirstOrDefault().Usuario.Nome : "-";

                return lRetorno;
            }
        }
     }
}
