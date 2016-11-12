using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Alvo.Common.MvcExtensions;
using Newtonsoft.Json.Serialization;
using Alvo.Common.MvcExtensions;

namespace Alvo.ViewModels
{
    public class RecuperarViewModel : LoginViewModel
    {

        [DisplayName("CPF: ")]
        [Required(ErrorMessage = "*")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        [Mask("999.999.999-99", "Cpf")]
        public string Cpf { get; set; }

        [DisplayName("Matrícula: ")]
        [Required(ErrorMessage = "*")]
        public string Matricula { get; set; }

        [DisplayName("E-mail: ")]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

    }
}