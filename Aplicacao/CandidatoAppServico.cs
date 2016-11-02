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
        private readonly IAvaliacaoServico _avaliacaoServico;

        public CandidatoAppServico(ICandidatoServico candidatoServico, ICandidatoProcessoSeletivoServico candidatoProcessoSeletivoServico, IAreaConcentracaoServico areaConcentracaoServico, IAvaliacaoServico avaliacaoServico)
            : base(candidatoServico)
        {
            _candidatoServico = candidatoServico;
            _candidatoProcessoSeletivoServico = candidatoProcessoSeletivoServico;
            _areaConcentracaoServico = areaConcentracaoServico;
            _avaliacaoServico = avaliacaoServico;
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

                    if (lCandidatoExistente == null)
                    {
                        //Gravando o CandidatoProcessoSeletivo com o Id do processo seletivo e do candidato recém cadastrado
                        item.IdProcessoSeletivo = pIdProcessoSeletivo;
                        CandidatoProcessoSeletivo lCandidadoProcesso = _candidatoProcessoSeletivoServico.AddWithReturn(item);

                        //Criando uma AVALIAÇÃO que estará pendente até que seja informado um PROFESSOR RESPONSÁVEL pela avaliação
                        Avaliacao lAvaliacao = new Avaliacao();
                        lAvaliacao.IdCandidatoProcessoSeletivo = lCandidadoProcesso.Id;
                        lAvaliacao.Aprovado = false;
                        lAvaliacao.Concluida = false;

                        _avaliacaoServico.Add(lAvaliacao);
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

        private List<CandidatoProcessoSeletivo> CandidatoProcessoSeletivoArquivo(string pCaminhoArquivo)
        {
            List<CandidatoProcessoSeletivo> lListaCandidatoProcessoSeletivo = new List<CandidatoProcessoSeletivo>();

            DataTable lDttCandidatos = Arquivos.LoadDataTable(pCaminhoArquivo);

            if (lDttCandidatos != null && lDttCandidatos.Rows.Count > 0)
            {
                if (lDttCandidatos.Columns.Count >= 21)
                {
                    foreach (DataRow item in lDttCandidatos.Rows)
                    {
                        Candidato lCandidato = new Candidato();
                        CandidatoProcessoSeletivo lCandidatoProcessoSeletivo = new CandidatoProcessoSeletivo();

                        lCandidato.Nome = item.ItemArray[0].ToString().Trim();
                        lCandidato.CPF = item.ItemArray[1].ToString().Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace(" ", string.Empty).Trim();
                        lCandidato.RG = item.ItemArray[2].ToString().Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace(" ", string.Empty).Trim();
                        lCandidato.OrgaoExpedidor = item.ItemArray[3].ToString().Trim();
                        lCandidato.DataNascimento = DateTime.Parse(item.ItemArray[4].ToString().Trim()).Date;
                        lCandidato.CotaNegros = (item.ItemArray[5].ToString().Trim().Equals("Sim") ? true : false);
                        lCandidato.CotaIndigena = (item.ItemArray[6].ToString().Trim().Equals("Sim") ? true : false);
                        lCandidato.LinguaEstrangeira = item.ItemArray[7].ToString().Trim();

                        lCandidatoProcessoSeletivo.IdAreaConcentracao = _areaConcentracaoServico.ObtemAreaConcentracaoPorNome(item.ItemArray[8].ToString().Trim()).Id;

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

                        if (lDttCandidatos.Columns.Count == 22)
                        {
                            lCandidatoProcessoSeletivo.TemaProjeto = item.ItemArray[21].ToString().Trim();
                        }

                        lListaCandidatoProcessoSeletivo.Add(lCandidatoProcessoSeletivo);

                        lCandidato = null;
                        lCandidatoProcessoSeletivo = null;
                    }
                }
            }

            return lListaCandidatoProcessoSeletivo;
        }
    }
}

