using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Candidato
    {
        public Candidato()
        {
            this.CandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string OrgaoExpedidor { get; set; }
        public bool CotaNegros { get; set; }
        public string LinguaEstrangeira { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool NecessidadesEspeciais { get; set; }
        public string TipoNecessidade { get; set; }
        public string Curso { get; set; }
        public string Instituicao { get; set; }

        public virtual ICollection<CandidatoProcessoSeletivo> CandidatoProcessoSeletivo { get; set; }
    }
}
