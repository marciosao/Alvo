using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace Alvo.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Login: ")]
        //[Required(ErrorMessage = "*")]

        public string Login { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Senha: ")]
        [Required(ErrorMessage = "*")]
        public string Senha { get; set; }


        [DataType(DataType.Password)]
        [DisplayName("Nova Senha: ")]
        [NotEqualTo("Senha", ErrorMessage = "Você usou essa senha recentemente. Escolha outra.")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirmar Senha: ")]
        [Required(ErrorMessage = "*")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não correspondem.")]
        public string ConfirmarSenha { get; set; }


    }
}