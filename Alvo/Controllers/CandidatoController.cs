using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Alvo.ViewModels;
using AutoMapper;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.Text;
using Aplicacao.Util;

namespace Alvo.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoAppServico _candidatoAppServico;
        private readonly IProcessoSeletivoAppServico _processoSeletivoAppServico;
        private readonly IAreaConcentracaoAppServico _areaConcentracaoAppServico;

        public CandidatoController(ICandidatoAppServico candidatoAppServico, IProcessoSeletivoAppServico processoSeletivoAppServico, IAreaConcentracaoAppServico areaConcentracaoAppServico)
        {
            _candidatoAppServico = candidatoAppServico;
            _processoSeletivoAppServico = processoSeletivoAppServico;
            _areaConcentracaoAppServico = areaConcentracaoAppServico;
        }
        // GET: Candidato
        public ActionResult Index()
        {
            var CandidatoViewModel = Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoViewModel>>(_candidatoAppServico.ObtemTodos());
            return View(CandidatoViewModel);
        }

        // GET: Candidato/Details/5
        public ActionResult Details(int id)
        {
            var lCandidato = _candidatoAppServico.ObtemPorId(id);
            var lCandidatoViewModel = Mapper.Map<Candidato, CandidatoViewModel>(lCandidato);

            return View(lCandidatoViewModel);
        }

        // GET: Candidato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidatoViewModel pCandidato)
        {
            if (ModelState.IsValid)
            {
                var lCandidatoDomain = Mapper.Map<CandidatoViewModel, Candidato>(pCandidato);

                _candidatoAppServico.Add(lCandidatoDomain);

                return RedirectToAction("Index");
            }

            return View(pCandidato);
        }

        // GET: Candidato/Edit/5
        public ActionResult Edit(int id)
        {
            var lCandidato = _candidatoAppServico.ObtemPorId(id);
            var lCandidatoViewModel = Mapper.Map<Candidato, CandidatoViewModel>(lCandidato);

            return View(lCandidatoViewModel);
        }

        // POST: Candidato/Edit/5
        [HttpPost]
        public ActionResult Edit(CandidatoViewModel pCandidatoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lCandidato = Mapper.Map<CandidatoViewModel, Candidato>(pCandidatoViewModel);
                _candidatoAppServico.Update(lCandidato);

                return RedirectToAction("Index");
            }

            return View(pCandidatoViewModel);
        }

        // GET: Candidato/Delete/5
        public ActionResult Delete(int id)
        {
            var lCandidato = _candidatoAppServico.ObtemPorId(id);
            var lCandidatoViewModel = Mapper.Map<Candidato, CandidatoViewModel>(lCandidato);

            return View(lCandidatoViewModel);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lCandidato = _candidatoAppServico.ObtemPorId(id);
            _candidatoAppServico.Remove(lCandidato);

            return RedirectToAction("Index");
        }

        public ActionResult PopUpImportarCandidatos()
        {
            ViewBag.ProcessoSeletivo = new SelectList(_processoSeletivoAppServico.ObtemTodos(), "Id", "Titulo");

            return PartialView("~/Views/Candidato/_ImportarCandidatos.cshtml");
        }

        public ActionResult ImportarCandidatos(FormCollection FormPartial, HttpPostedFileBase FileUpload)
        {
            var lIdProcessoSeletivo = FormPartial["ProcessoSeletivo"];
            List<string> listaErros = new List<string>();

            if (ModelState.IsValid)
            {
                if (FileUpload != null && FileUpload.ContentLength > 0)
                {
                    if (FileUpload.FileName.EndsWith(".csv") || FileUpload.FileName.EndsWith(".xls") || FileUpload.FileName.EndsWith(".xlsx"))
                    {
                        List<Candidato> lListaCandidatos = new List<Candidato>();

                        string path = AppDomain.CurrentDomain.BaseDirectory + "Upload\\" + FileUpload.FileName;

                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        FileUpload.SaveAs(path);

                        //Executa a importação do arquivo contendo candidatos
                        _candidatoAppServico.ImportarCandidatos(int.Parse(lIdProcessoSeletivo), path);
                    }
                    else
                    {
                        ModelState.AddModelError("Arquivo", "O formato do arquivo não é suportado. Somente arquivos CSV, XLS ou XLSX poderão ser importados.");
                        //return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Arquivo", "Selecione um arquivo para importar.");
                }
            }

            ViewBag.ProcessoSeletivo = new SelectList(_processoSeletivoAppServico.ObtemTodos(), "Id", "Titulo");

            return View("Index");
        }

    }
}
