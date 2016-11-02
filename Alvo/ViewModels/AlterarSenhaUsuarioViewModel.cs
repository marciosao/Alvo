using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alvo.ViewModels
{
    public class AlterarSenhaUsuarioViewModel : UsuarioViewModel
    {
        [DataType(DataType.Password)]
        [DisplayName("Nova Senha: ")]
       // [NotEqualTo("Senha", ErrorMessage = "Você usou essa senha recentemente. Escolha outra.")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirmar Senha: ")]
        [Required(ErrorMessage = "*")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não correspondem.")]
        public string ConfirmarSenha { get; set; }
    }
}