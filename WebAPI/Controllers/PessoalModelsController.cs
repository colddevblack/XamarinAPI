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
    public class PessoalModelsController : ApiController
    {
        private ConexaoContext db = new ConexaoContext();

        // GET: api/PessoalModels
        public IQueryable<PessoalModel> Getpessoaldb()
        {
            return db.pessoaldb;
        }

        // GET: api/PessoalModels/5
        [ResponseType(typeof(PessoalModel))]
        public IHttpActionResult GetPessoalModel(int id)
        {
            PessoalModel pessoalModel = db.pessoaldb.Find(id);
            if (pessoalModel == null)
            {
                return NotFound();
            }

            return Ok(pessoalModel);
        }

        // PUT: api/PessoalModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPessoalModel(int id, PessoalModel pessoalModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoalModel.Id)
            {
                return BadRequest();
            }

            db.Entry(pessoalModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoalModelExists(id))
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

        // POST: api/PessoalModels
        [ResponseType(typeof(PessoalModel))]
        public IHttpActionResult PostPessoalModel(PessoalModel pessoalModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pessoaldb.Add(pessoalModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pessoalModel.Id }, pessoalModel);
        }

        // DELETE: api/PessoalModels/5
        [ResponseType(typeof(PessoalModel))]
        public IHttpActionResult DeletePessoalModel(int id)
        {
            PessoalModel pessoalModel = db.pessoaldb.Find(id);
            if (pessoalModel == null)
            {
                return NotFound();
            }

            db.pessoaldb.Remove(pessoalModel);
            db.SaveChanges();

            return Ok(pessoalModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoalModelExists(int id)
        {
            return db.pessoaldb.Count(e => e.Id == id) > 0;
        }
    }
}