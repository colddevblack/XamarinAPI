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
    public class CasaModelsController : ApiController
    {
        private ConexaoContext db = new ConexaoContext();

        // GET: api/CasaModels
        public IQueryable<CasaModel> Getcasadb()
        {
            return db.casadb;
        }

        // GET: api/CasaModels/5
        [ResponseType(typeof(CasaModel))]
        public IHttpActionResult GetCasaModel(int id)
        {
            CasaModel casaModel = db.casadb.Find(id);
            if (casaModel == null)
            {
                return NotFound();
            }

            return Ok(casaModel);
        }

        // PUT: api/CasaModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCasaModel(int id, CasaModel casaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != casaModel.Id)
            {
                return BadRequest();
            }

            db.Entry(casaModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaModelExists(id))
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

        // POST: api/CasaModels
        [ResponseType(typeof(CasaModel))]
        public IHttpActionResult PostCasaModel(CasaModel casaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.casadb.Add(casaModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = casaModel.Id }, casaModel);
        }

        // DELETE: api/CasaModels/5
        [ResponseType(typeof(CasaModel))]
        public IHttpActionResult DeleteCasaModel(int id)
        {
            CasaModel casaModel = db.casadb.Find(id);
            if (casaModel == null)
            {
                return NotFound();
            }

            db.casadb.Remove(casaModel);
            db.SaveChanges();

            return Ok(casaModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CasaModelExists(int id)
        {
            return db.casadb.Count(e => e.Id == id) > 0;
        }
    }
}