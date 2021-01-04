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
    public class CasaController : Controller
    {

        private ConexaoContext db = new ConexaoContext();
        // GET: Pessoal
        public ActionResult Index()
        {
            return View(db.casadb.ToList());
        }
        public ActionResult CasaCadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CasaCadastro(CasaModel casa)
        {

            db.casadb.Add(casa);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult EditarCasa(int Id)
        {
            var model = db.casadb.Find(Id);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditarCasa(CasaModel casa)
        {

            db.Entry(casa).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletarCasa(int id)
        {

            var obj = db.casadb.Find(id);
            db.casadb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}