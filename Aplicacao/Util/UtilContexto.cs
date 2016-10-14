using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Routing;

namespace Aplicacao.Util
{/// <summary>
    /// Classe Util 
    /// </summary>
    public class UtilContexto
    {
        public class ValidaCsv
        {
            public Int32 Id { get; set; }
            public string Desc { get; set; }
            public int tamanho { get; set; }
            public string tipo { get; set; }
            public bool obrigatorio { get; set; }
            public string TipoExibicao { get; set; }
            public string regra { get; set; }
            public string NomeExibicao { get; set; }
        }

        public static IEnumerable<ValidaCsv> ValidacoesCsv =
        new List<ValidaCsv>
        {
            new ValidaCsv {Id = 0,  Desc = "Nome",NomeExibicao="NOME", tamanho=70,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA (Não se aplica)"},
            new ValidaCsv {Id = 1,  Desc = "Cpf",NomeExibicao="CPF", tamanho = 14,tipo = "fixo",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 2,  Desc = "DataNascimento",NomeExibicao="DATA DE NASCIMENTO", tamanho= 10,tipo = "fixo",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "Formato dd/mm/aaaa"},
            new ValidaCsv {Id = 3,  Desc = "Rg",NomeExibicao="RG", tamanho = 12,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
        };
    }
}