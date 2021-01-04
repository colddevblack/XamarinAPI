using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cadastroweb.DataAccess;
using Cadastroweb.Models;

namespace WebAPI.Controllers
{
    public class LoginAPIController : ApiController
    {
        private ConexaoContext db = new ConexaoContext();

        // GET: api/LoginAPI
        public IQueryable<LoginModel> Getlogindb()
        {
            return db.logindb;
        }

        // GET: api/LoginAPI/5
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult GetLoginModel(int id)
        {
            LoginModel loginModel = db.logindb.Find(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            return Ok(loginModel);
        }

        // PUT: api/LoginAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoginModel(int id, LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginModel.Id)
            {
                return BadRequest();
            }

            db.Entry(loginModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LoginAPI
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult PostLoginModel(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.logindb.Add(loginModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loginModel.Id }, loginModel);
        }

        // DELETE: api/LoginAPI/5
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult DeleteLoginModel(int id)
        {
            LoginModel loginModel = db.logindb.Find(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            db.logindb.Remove(loginModel);
            db.SaveChanges();

            return Ok(loginModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginModelExists(int id)
        {
            return db.logindb.Count(e => e.Id == id) > 0;
        }
    }
}