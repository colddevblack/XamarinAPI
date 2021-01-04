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
    public class TrabalhoModelsController : ApiController
    {
        private ConexaoContext db = new ConexaoContext();

        // GET: api/TrabalhoModels
        public IQueryable<TrabalhoModel> Gettrabalhodb()
        {
            return db.trabalhodb;
        }

        // GET: api/TrabalhoModels/5
        [ResponseType(typeof(TrabalhoModel))]
        public IHttpActionResult GetTrabalhoModel(int id)
        {
            TrabalhoModel trabalhoModel = db.trabalhodb.Find(id);
            if (trabalhoModel == null)
            {
                return NotFound();
            }

            return Ok(trabalhoModel);
        }

        // PUT: api/TrabalhoModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrabalhoModel(int id, TrabalhoModel trabalhoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabalhoModel.Id)
            {
                return BadRequest();
            }

            db.Entry(trabalhoModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabalhoModelExists(id))
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

        // POST: api/TrabalhoModels
        [ResponseType(typeof(TrabalhoModel))]
        public IHttpActionResult PostTrabalhoModel(TrabalhoModel trabalhoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.trabalhodb.Add(trabalhoModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trabalhoModel.Id }, trabalhoModel);
        }

        // DELETE: api/TrabalhoModels/5
        [ResponseType(typeof(TrabalhoModel))]
        public IHttpActionResult DeleteTrabalhoModel(int id)
        {
            TrabalhoModel trabalhoModel = db.trabalhodb.Find(id);
            if (trabalhoModel == null)
            {
                return NotFound();
            }

            db.trabalhodb.Remove(trabalhoModel);
            db.SaveChanges();

            return Ok(trabalhoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrabalhoModelExists(int id)
        {
            return db.trabalhodb.Count(e => e.Id == id) > 0;
        }
    }
}