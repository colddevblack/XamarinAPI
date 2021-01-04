using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cadastroweb.Models;
using Cadastroweb.DataAccess;

namespace Cadastroweb.Controllers
{
    public class PessoalController : Controller
    {

        private ConexaoContext db = new ConexaoContext();
        // GET: Pessoal
        public ActionResult Index()
        {
            return View(db.pessoaldb.ToList());
        }
        public ActionResult PessoalCadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PessoalCadastro(PessoalModel pessoal)
        {

            db.pessoaldb.Add(pessoal);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        public ActionResult EditarPessoal(int Id)
        {
            var model = db.pessoaldb.Find(Id);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditarPessoal(PessoalModel pessoal)
        {

            db.Entry(pessoal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletarPessoal(int id)
        {

            var obj = db.pessoaldb.Find(id);
            db.pessoaldb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}