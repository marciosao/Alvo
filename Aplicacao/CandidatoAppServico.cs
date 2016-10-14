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

        public CandidatoAppServico(ICandidatoServico candidatoServico, ICandidatoProcessoSeletivoServico candidatoProcessoSeletivoServico)
            : base(candidatoServico)
        {
            _candidatoServico = candidatoServico;
            _candidatoProcessoSeletivoServico = candidatoProcessoSeletivoServico;
        }

        public void ImportarCandidatos(int pIdProcessoSeletivo, string pCaminhoArquivo)
        {
            //Obtendo os candidados a partir do arquivo
            List<Candidato> lListaCandidatos = CandidadosArquivo(pCaminhoArquivo);

            StringBuilder lListaCandidatosExistentes = new StringBuilder();

            if (lListaCandidatos != null && lListaCandidatos.Count > 0)
            {
                foreach (var item in lListaCandidatos)
                {
                    //Verificando se já existe um candidado com o mesmo cpf para o processo seletivo. Se existir o candidato não deverá ser importado
                    var lCandidatoExistente = this.ObtemCandidatoPorProcessoCPF(pIdProcessoSeletivo, item.CPF);

                    if (lCandidatoExistente == null)
                    {
                        //Gravando o candidato e obtendo o ID do candidato recém inserido
                        ////////var lCandidato = _candidatoServico.AddWithReturn(item);

                        //Gravando o CandidatoProcessoSeletivo com o Id do processo seletivo e do candidato recém cadastrado
                        CandidatoProcessoSeletivo lcandidatoProcessoSeletivo = new CandidatoProcessoSeletivo();
                        lcandidatoProcessoSeletivo.IdProcessoSeletivo = pIdProcessoSeletivo;
                        lcandidatoProcessoSeletivo.Candidato = item;

                        _candidatoProcessoSeletivoServico.Add(lcandidatoProcessoSeletivo);
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
                    lCandidato.DataNascimento = DateTime.Parse(item.ItemArray[2].ToString().Trim()).Date;
                    lCandidato.RG = item.ItemArray[3].ToString().Trim();

                    lListaCandidatos.Add(lCandidato);
                }
            }


            return lListaCandidatos;
        }
    }
}

