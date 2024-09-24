using gaicosCrud.Models;
using gaicosCrud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gaicosCrud.Controllers
{
    public class PessoaController : Controller
    {
        

        [HttpGet]
        public ActionResult Cadastrar()
        {
            if (TempData["mensagemSucesso"] != null)
            {
                ViewBag.mensagemSucesso = TempData["mensagemSucesso"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPost(PessoaViewModel dados)
        {
            dados.Validar();


            Pessoa model = new Pessoa();
            model.Nome = dados.Nome;
            model.DataNascimento = dados.DataNascimento;
            model.Sexo = dados.Sexo;
            model.EstadoCivil = dados.EstadoCivil;
            model.CPF = dados.CPF;
            model.CEP = dados.CEP;
            model.Bairro = dados.Bairro;
            model.Endereco = dados.Endereco;
            model.Numero = dados.Numero;
            model.Complemento = dados.Complemento;
            model.Cidade = dados.Cidade;
            model.UF = dados.UF;

            using (Conexao DB = new Conexao())
            {
                

                DB.Pessoa.Add(model);
                DB.SaveChanges();
            }



            TempData["mensagemSucesso"] = "Pessoa Cadastrada com Sucesso";
            return RedirectToAction("Cadastrar");

           
        }
    }
}