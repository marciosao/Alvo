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
            new ValidaCsv {Id = 2,  Desc = "Rg",NomeExibicao="RG", tamanho = 12,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 3,  Desc = "OrgaoExpedidor",NomeExibicao="ORGAO EXPEDIDOR", tamanho= 15,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 4,  Desc = "DataNascimento",NomeExibicao="DATA DE NASCIMENTO", tamanho= 10,tipo = "fixo",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "Formato dd/mm/aaaa"},

            //boleano
            new ValidaCsv {Id = 5,  Desc = "CotaNegros",NomeExibicao="COTA NEGROS", tamanho= 3,tipo = "fixo",obrigatorio = true,TipoExibicao = "Numérico",regra= "1-Sim;|2-Não"},
            new ValidaCsv {Id = 6,  Desc = "CotaIndigena",NomeExibicao="COTA INDIGENAS", tamanho= 3,tipo = "fixo",obrigatorio = true,TipoExibicao = "Numérico",regra= "1-Sim;|2-Não"},
            
            new ValidaCsv {Id = 7,  Desc = "LinguaEstrangeira",NomeExibicao="LINGUA ESTRANGEIRA", tamanho= 50,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            
            //inteiro/objeto
            new ValidaCsv {Id = 8,  Desc = "IdAreaConcentracao",NomeExibicao="LINHA PESQUISA", tamanho= 50,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},

            new ValidaCsv {Id = 9,  Desc = "Endereco",NomeExibicao="ENDERECO", tamanho= 100,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 10,  Desc = "Bairro",NomeExibicao="BAIRRO", tamanho= 50,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 11,  Desc = "Cidade",NomeExibicao="CIDADE", tamanho= 50,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 12,  Desc = "Estado",NomeExibicao="ESTADO", tamanho= 2,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 13,  Desc = "CEP",NomeExibicao="CEP", tamanho= 9,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 14,  Desc = "Email",NomeExibicao="E-MAIL", tamanho= 100,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 15,  Desc = "Telefone",NomeExibicao="TELEFONE", tamanho= 12,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 16,  Desc = "Celular",NomeExibicao="CELULAR", tamanho= 12,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            
            //boleano
            new ValidaCsv {Id = 17,  Desc = "NecessidadesEspeciais",NomeExibicao="NECESSIDADES ESPECIAIS", tamanho= 3,tipo = "fixo",obrigatorio = true,TipoExibicao = "Numérico",regra= "1-Sim;|2-Não"},

            new ValidaCsv {Id = 18,  Desc = "TipoNecessidade",NomeExibicao="TIPO NECESSIDADES ESPECIAIS", tamanho= 20,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 19,  Desc = "Curso",NomeExibicao="CURSO", tamanho= 100,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 20,  Desc = "Instituicao",NomeExibicao="INSTITUICAO", tamanho= 100,tipo = "variavel",obrigatorio = true,TipoExibicao = "Alfanumérico",regra= "NA"},
            new ValidaCsv {Id = 21,  Desc = "TemaProjeto",NomeExibicao="TEMA", tamanho= 5000,tipo = "variavel",obrigatorio = false,TipoExibicao = "Alfanumérico",regra= "NA"}
        };

        public static bool ValidarCampos(string Campo, string texto, bool obrigatorio)
        {
            bool retorno = false;
            if (!obrigatorio && texto == string.Empty)
            {
                retorno = true;
            }
            else
            {
                foreach (var item in Util.UtilContexto.ValidacoesCsv)
                {
                    if (Campo == item.Desc)
                    {
                        if (item.tipo == "fixo")
                        {
                            if (texto.Length == item.tamanho)
                            {
                                retorno = true;
                            }
                            else retorno = false;
                        }
                        else if (item.tipo == "variavel")
                        {
                            if (texto.Length > 0 && texto.Length <= item.tamanho)
                            {
                                retorno = true;
                            }
                            else
                                retorno = false;
                        }
                    }

                }
            }

            return retorno;

        }
    }
}