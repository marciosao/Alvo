using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Aplicacao.Util;

namespace Aplicacao
{
    public class CandidatoAppServico : AppServicoBase<Candidato>, ICandidatoAppServico
    {
        private readonly ICandidatoServico _candidatoServico;
        private readonly ICandidatoProcessoSeletivoServico _candidatoProcessoSeletivoServico;
        private readonly IAreaConcentracaoServico _areaConcentracaoServico;

        public CandidatoAppServico(ICandidatoServico candidatoServico, ICandidatoProcessoSeletivoServico candidatoProcessoSeletivoServico, IAreaConcentracaoServico areaConcentracaoServico)
            : base(candidatoServico)
        {
            _candidatoServico = candidatoServico;
            _candidatoProcessoSeletivoServico = candidatoProcessoSeletivoServico;
            _areaConcentracaoServico = areaConcentracaoServico;
        }

        public void ImportarCandidatos(int pIdProcessoSeletivo, string pCaminhoArquivo)
        {
            //Obtendo os candidados a partir do arquivo
            ////////List<Candidato> lListaCandidatos = CandidadosArquivo(pCaminhoArquivo);
            List<CandidatoProcessoSeletivo> lListaCandidatoProcessoSeletivo = CandidatoProcessoSeletivoArquivo(pCaminhoArquivo);
            StringBuilder lListaCandidatosExistentes = new StringBuilder();

            if (lListaCandidatoProcessoSeletivo != null && lListaCandidatoProcessoSeletivo.Count > 0)
            {
                foreach (var item in lListaCandidatoProcessoSeletivo)
                {
                    //Verificando se já existe um candidado com o mesmo cpf para o processo seletivo. Se existir o candidato não deverá ser importado
                    var lCandidatoExistente = this.ObtemCandidatoPorProcessoCPF(pIdProcessoSeletivo, item.Candidato.CPF);
                    ////////var lAreaConcentracao = ObtemAreaConcentracaoPorNome();

                    if (lCandidatoExistente == null)
                    {
                        //Gravando o candidato e obtendo o ID do candidato recém inserido
                        ////////var lCandidato = _candidatoServico.AddWithReturn(item);

                        //Gravando o CandidatoProcessoSeletivo com o Id do processo seletivo e do candidato recém cadastrado
                        ////////CandidatoProcessoSeletivo lcandidatoProcessoSeletivo = new CandidatoProcessoSeletivo();
                        item.IdProcessoSeletivo = pIdProcessoSeletivo;
                        ////////lcandidatoProcessoSeletivo.Candidato = item;


                        ////////foreach (var itemAreaConcentracao in item.CandidatoProcessoSeletivo)
                        ////////{
                        ////////    lcandidatoProcessoSeletivo.AreaConcentracao = itemAreaConcentracao.AreaConcentracao;
                        ////////}

                        _candidatoProcessoSeletivoServico.Add(item);
                    }
                    else
                    {
                        lListaCandidatosExistentes.Append(lCandidatoExistente.Nome);
                    }
                }
            }
        }
        public Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF)
        {
            return _candidatoServico.ObtemCandidatoPorProcessoCPF(pIdProcessoSeletivo, pCPF);
        }


        private List<Candidato> CandidadosArquivo(string pCaminhoArquivo)
        {
            List<Candidato> lListaCandidatos = new List<Candidato>();

            DataTable lDttCandidatos = Arquivos.LoadDataTable(pCaminhoArquivo);

            if (lDttCandidatos != null && lDttCandidatos.Rows.Count > 0)
            {
                foreach (DataRow item in lDttCandidatos.Rows)
                {
                    Candidato lCandidato = new Candidato();

                    lCandidato.Nome = item.ItemArray[0].ToString().Trim();
                    lCandidato.CPF = item.ItemArray[1].ToString().Trim();
                    lCandidato.RG = item.ItemArray[2].ToString().Trim();
                    lCandidato.OrgaoExpedidor = item.ItemArray[3].ToString().Trim();
                    lCandidato.DataNascimento = DateTime.Parse(item.ItemArray[4].ToString().Trim()).Date;
                    lCandidato.CotaNegros =  (item.ItemArray[5].ToString().Trim().Equals("Sim")?true:false);
                    lCandidato.CotaIndigena = (item.ItemArray[6].ToString().Trim().Equals("Sim") ? true : false);
                    lCandidato.LinguaEstrangeira = item.ItemArray[7].ToString().Trim();

                    ////////CandidatoProcessoSeletivo lCandidatoProcessoSeletivo = new CandidatoProcessoSeletivo();
                    ////////lCandidatoProcessoSeletivo.AreaConcentracao = _areaConcentracaoServico.ObtemAreaConcentracaoPorNome(item.ItemArray[8].ToString().Trim());

                    ////////if (lCandidatoProcessoSeletivo.AreaConcentracao != null)
                    ////////{
                    ////////    lCandidato.CandidatoProcessoSeletivo.Add(lCandidatoProcessoSeletivo);
                    ////////}
                    lCandidato.Endereco = item.ItemArray[9].ToString().Trim();
                    lCandidato.Bairro = item.ItemArray[10].ToString().Trim();
                    lCandidato.Cidade = item.ItemArray[11].ToString().Trim();
                    lCandidato.Estado = item.ItemArray[12].ToString().Trim();
                    lCandidato.CEP = item.ItemArray[13].ToString().Trim();
                    lCandidato.Email = item.ItemArray[14].ToString().Trim();
                    lCandidato.Telefone = item.ItemArray[15].ToString().Trim();
                    lCandidato.Celular = item.ItemArray[16].ToString().Trim();
                    lCandidato.NecessidadesEspeciais = (item.ItemArray[17].ToString().Trim().Equals("Sim") ? true : false);
                    lCandidato.TipoNecessidade = item.ItemArray[18].ToString().Trim();
                    lCandidato.Curso = item.ItemArray[19].ToString().Trim();
                    lCandidato.Instituicao = item.ItemArray[20].ToString().Trim();

                    lListaCandidatos.Add(lCandidato);
                }
            }


            return lListaCandidatos;
        }

        private List<CandidatoProcessoSeletivo> CandidatoProcessoSeletivoArquivo(string pCaminhoArquivo)
        {
            List<CandidatoProcessoSeletivo> lListaCandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivo>();

            DataTable lDttCandidatos = Arquivos.LoadDataTable(pCaminhoArquivo);

            if (lDttCandidatos != null && lDttCandidatos.Rows.Count > 0)
            {
                foreach (DataRow item in lDttCandidatos.Rows)
                {
                    Candidato lCandidato = new Candidato();
                    CandidatoProcessoSeletivo lCandidatoProcessoSeletivo = new CandidatoProcessoSeletivo();

                    lCandidato.Nome = item.ItemArray[0].ToString().Trim();
                    lCandidato.CPF = item.ItemArray[1].ToString().Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Trim();
                    lCandidato.RG = item.ItemArray[2].ToString().Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Trim();
                    lCandidato.OrgaoExpedidor = item.ItemArray[3].ToString().Trim();
                    lCandidato.DataNascimento = DateTime.Parse(item.ItemArray[4].ToString().Trim()).Date;
                    lCandidato.CotaNegros = (item.ItemArray[5].ToString().Trim().Equals("Sim") ? true : false);
                    lCandidato.CotaIndigena = (item.ItemArray[6].ToString().Trim().Equals("Sim") ? true : false);
                    lCandidato.LinguaEstrangeira = item.ItemArray[7].ToString().Trim();

                    ////////CandidatoProcessoSeletivo lCandidatoProcessoSeletivo = new CandidatoProcessoSeletivo();
                    ////////lCandidatoProcessoSeletivo.AreaConcentracao = _areaConcentracaoServico.ObtemAreaConcentracaoPorNome(item.ItemArray[8].ToString().Trim());

                    ////////if (lCandidatoProcessoSeletivo.AreaConcentracao != null)
                    ////////{
                    ////////    lCandidato.CandidatoProcessoSeletivo.Add(lCandidatoProcessoSeletivo);
                    ////////}
                    lCandidato.Endereco = item.ItemArray[9].ToString().Trim();
                    lCandidato.Bairro = item.ItemArray[10].ToString().Trim();
                    lCandidato.Cidade = item.ItemArray[11].ToString().Trim();
                    lCandidato.Estado = item.ItemArray[12].ToString().Trim();
                    lCandidato.CEP = item.ItemArray[13].ToString().Replace(".", string.Empty).Trim();
                    lCandidato.Email = item.ItemArray[14].ToString().Trim();
                    lCandidato.Telefone = item.ItemArray[15].ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Trim(); ;
                    lCandidato.Celular = item.ItemArray[16].ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Trim(); ;
                    lCandidato.NecessidadesEspeciais = (item.ItemArray[17].ToString().Trim().Equals("Sim") ? true : false);
                    lCandidato.TipoNecessidade = item.ItemArray[18].ToString().Trim();
                    lCandidato.Curso = item.ItemArray[19].ToString().Trim();
                    lCandidato.Instituicao = item.ItemArray[20].ToString().Trim();

                    lCandidatoProcessoSeletivo.Candidato = lCandidato;
                    lCandidatoProcessoSeletivo.IdAreaConcentracao = _areaConcentracaoServico.ObtemAreaConcentracaoPorNome(item.ItemArray[8].ToString().Trim()).Id;

                    lListaCandidatoProcessoSeletivo.Add(lCandidatoProcessoSeletivo);

                    lCandidato = null;
                    lCandidatoProcessoSeletivo = null;
                }
            }


            return lListaCandidatoProcessoSeletivo;
        }
    }
}

