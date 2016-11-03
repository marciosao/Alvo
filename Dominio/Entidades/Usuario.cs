using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            this.Avaliacao = new List<Avaliacao>();
        }

        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }
        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
