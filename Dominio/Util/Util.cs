using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Linq;

namespace SIGANT.Dominio
{
    public class Util
    {
        public static bool ValidarCPF(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "").Replace("_", "");

            if (cpf.Length != 11)
                return false;

            if (!VerificaNumeroRepetido(cpf))
                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }

        public static string Base64Decode(string base64EncodedData)
        {
            if (base64EncodedData == "0")
            {
                return base64EncodedData;
            }

            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);

            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(Object data)
        {

            string plainText = Convert.ToString(data);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static bool VerificaNumeroRepetido(string cpf)
        {
            switch (cpf)
            {
                case "00000000000":
                case "11111111111":
                case "22222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
            }
            return true;
        }
    }
}