﻿using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class CandidatoServico : ServicoBase<Candidato>, ICandidatoServico
    {
        private readonly ICandidatoRepositorio _candidatoRepositorio;

        public CandidatoServico(ICandidatoRepositorio candidatoRepositorio)
            : base(candidatoRepositorio)
        {
            _candidatoRepositorio = candidatoRepositorio;
        }
        public Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF)
        {
            return _candidatoRepositorio.ObtemCandidatoPorProcessoCPF(pIdProcessoSeletivo, pCPF);
        }

        public IEnumerable<Candidato> ObtemCandidatoPorProcesso(int pIdProcessoSeletivo)
        {
            return _candidatoRepositorio.ObtemCandidatoPorProcesso(pIdProcessoSeletivo);
        }
    }
}

