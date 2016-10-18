using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alvo.ViewModels
{
    public class CandidatoViewModel
    {
        public CandidatoViewModel()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivoViewModel>();
        }

        public int Id { get; set; }

        [DisplayName("Nome")]
        [StringLength(70)]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [StringLength(14)]
        public string CPF { get; set; }

        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("RG")]
        [StringLength(12)]
        public string RG { get; set; }

        [DisplayName("Órgão Expedidor")]
        [StringLength(15)]
        public string OrgaoExpedidor { get; set; }

        [DisplayName("Cota Negros")]
        public bool CotaNegros { get; set; }

        [DisplayName("Cota Indigena")]
        public bool CotaIndigena { get; set; }


        [DisplayName("Língua Estrangeiro")]
        [StringLength(50)]
        public string LinguaEstrangeira { get; set; }

        [DisplayName("Endereço")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [DisplayName("Bairro")]
        [StringLength(50)]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [StringLength(50)]
        public string Cidade { get; set; }

        [DisplayName("UF")]
        [StringLength(2)]
        public string Estado { get; set; }

        [DisplayName("CEP")]
        [StringLength(9)]
        public string CEP { get; set; }

        [DisplayName("E-mail")]
        [StringLength(100)]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        [StringLength(12)]
        public string Telefone { get; set; }

        [DisplayName("Celular")]
        [StringLength(12)]
        public string Celular { get; set; }

        [DisplayName("Necessidades Especiais")]
        public bool NecessidadesEspeciais { get; set; }

        [DisplayName("Tipo Necessidade")]
        [StringLength(20)]
        public string TipoNecessidade { get; set; }

        [DisplayName("Curso")]
        [StringLength(100)]
        public string Curso { get; set; }

        [DisplayName("Instituição")]
        [StringLength(100)]
        public string Instituicao { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<CandidatoProcessoSeletivoViewModel> CandidatoProcessoSeletivo { get; set; }

        [ScaffoldColumn(false)]
        public virtual string DataFormatada { 
            get
            {
                return DataNascimento.ToShortDateString();
            } 
        }
    }
}
