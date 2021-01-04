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
    public class TrabalhoController : Controller
    {

        private ConexaoContext db = new ConexaoContext();
        // GET: Pessoal
        public ActionResult Index()
        {
            return View(db.trabalhodb.ToList());
        }
        public ActionResult TrabalhoCadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrabalhoCadastro(TrabalhoModel trabalho)
        {

            db.trabalhodb.Add(trabalho);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult EditarTrabalho(int Id)
        {
            var model = db.trabalhodb.Find(Id);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditarTrabalho(TrabalhoModel trabalho)
        {

            db.Entry(trabalho).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletarTrabalho(int id)
        {

            var obj = db.trabalhodb.Find(id);
            db.trabalhodb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}