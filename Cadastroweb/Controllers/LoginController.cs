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
    public class LoginController : Controller
    {


        private ConexaoContext db = new ConexaoContext();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.logindb.ToList());
        }

        public ActionResult RegistroLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistroLogin(LoginModel logindf)
        { 

            db.logindb.Add(logindf);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}