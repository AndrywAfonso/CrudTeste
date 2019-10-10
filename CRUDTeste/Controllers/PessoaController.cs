using CRUDTeste.Models;
using CRUDTeste.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDTeste.Controllers
{
    public class PessoaController : Controller
    {
        private PessoasRepository _repositorio;

        public ActionResult ObterPessoas()
        {
            _repositorio = new PessoasRepository();

            ModelState.Clear();
            return View(_repositorio.ObterPessoas());
        }

        public ActionResult AdicionarPessoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarPessoa(Pessoas pessoasObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new PessoasRepository();

                    if (_repositorio.AdicionarPessoa(pessoasObj))
                    {
                        ViewBag.Mensagem = "Pessoa Cadastrada";
                    }
                }

                return RedirectToAction("ObterPessoas");
            }
            catch (Exception ex)
            {
                return View("ObterPessoas");
            }
        }

        public ActionResult AtualizarPessoa(int id)
        {
            _repositorio = new PessoasRepository();

            return View(_repositorio.ObterPessoas().Find(t => t.PES_ID == id));
        }

        [HttpPost]
        public ActionResult AtualizarPessoa(int id, Pessoas pessoasObj)
        {
            try
            {
                _repositorio = new PessoasRepository();
                _repositorio.AtualizarPessoa(pessoasObj);


                return RedirectToAction("ObterPessoas");
            }
            catch (Exception ex)
            {
                return View("ObterPessoas");
            }
        }

        public ActionResult DeletePessoa(int id)
        {
            try
            {
                _repositorio = new PessoasRepository();

                if (_repositorio.DeletePessoa(id))
                {
                    ViewBag.Mensagem = "Pessoa Excluida com sucesso";
                }

                return RedirectToAction("ObterPessoas");
            }
            catch (Exception)
            {
                return View("ObterPessoas");
            }
        }
    }
}