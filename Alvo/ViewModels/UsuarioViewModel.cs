using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alvo.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            this.Avaliacao = new List<AvaliacaoViewModel>();
        }
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public string Nome { get; set; }

        public string Matricula { get; set; }

        [Required(ErrorMessage = "*")]
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        public string Senha { get; set; }
        public virtual PerfilViewModel Perfil { get; set; }
        public virtual ICollection<AvaliacaoViewModel> Avaliacao { get; set; }

    }
}
