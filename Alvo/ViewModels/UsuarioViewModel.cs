using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Alvo.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }

        [DisplayName("CPF: ")]
        [Required(ErrorMessage = "*")]

        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Senha: ")]
        [Required(ErrorMessage = "*")]
        public string Senha { get; set; }
        public virtual PerfilViewModel perfil { get; set; }

    }
}
