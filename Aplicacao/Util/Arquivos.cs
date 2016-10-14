using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Util
{
    public static class Arquivos
    {
        public static DataTable LoadDataTable(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            switch (fileExtension.ToLower())
            {
                case ".xlsx":
                    return ConvertExcelToDataTable(filePath, true);
                case ".xls":
                    return ConvertExcelToDataTable(filePath);
                case ".csv":
                    return ConvertCsvToDataTable(filePath);
                default:
                    return new DataTable();
            }

        }

        public static DataTable ConvertExcelToDataTable(string filePath, bool isXlsx = false)
        {
            FileStream stream = null;
            IExcelDataReader excelReader = null;
            DataTable dataTable = null;
            stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            excelReader = isXlsx ? ExcelReaderFactory.CreateOpenXmlReader(stream) : ExcelReaderFactory.CreateBinaryReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();
            if (result != null && result.Tables.Count > 0)
                dataTable = result.Tables[0];
            return dataTable;
        }

        public static DataTable ConvertCsvToDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }

        public static void LerCsv(string pCaminhoArquivo)
        {
            //Declaro uma string que será utilizada para receber a linha completa do arquivo
            string linha = null;

            //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado
            string[] linhaseparada = null;

            //Contador da linha do arquivo. Para arquivo que tem os títulos das colinas na primeira linha, 
            //deve-se considerar a partir da segunda linha 
            int lNumeroLinha = 0;

            using (StreamReader rd = new StreamReader(pCaminhoArquivo, Encoding.GetEncoding("iso-8859-1")))
            {
                try
                {
                    //realizo o while para ler o conteudo da linha
                    while (!rd.EndOfStream)
                    {
                        lNumeroLinha++;

                        linha = rd.ReadLine();
                        if (lNumeroLinha > 1)
                        {
                            //com o split adiciono a string 'quebrada' dentro do array
                            linhaseparada = linha.Split(';');

                            ////////Candidato lCandidato = new Candidato();
                            ////////lCandidato.Nome = linhaseparada[0];
                            ////////lCandidato.CPF = linhaseparada[1];
                            ////////lCandidato.DataNascimento = DateTime.Parse(linhaseparada[2]);
                            ////////lCandidato.RG = linhaseparada[3];

                            ////////lListaCandidatos.Add(lCandidato);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    rd.Close();
                }
            }

        }
    }
}
