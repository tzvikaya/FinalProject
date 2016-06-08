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
using SmartCalendar.DB;
using System.Web.Http.Cors;

namespace SmartCalendar.API.Controllers
{
    public class SourcesController : ApiController
    {
        private zvikaEntities db = new zvikaEntities();

        // GET: api/Sources
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<Sources> GetSources()
        {
            return db.Sources;
        }

        // GET: api/Sources/5
        [ResponseType(typeof(Sources))]
        public IHttpActionResult GetSources(int id)
        {
            Sources sources = db.Sources.Find(id);
            if (sources == null)
            {
                return NotFound();
            }

            return Ok(sources);
        }

        // PUT: api/Sources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSources(int id, Sources sources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sources.source_id)
            {
                return BadRequest();
            }

            db.Entry(sources).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourcesExists(id))
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

        // POST: api/Sources
        [ResponseType(typeof(Sources))]
        public IHttpActionResult PostSources(Sources sources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sources.Add(sources);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sources.source_id }, sources);
        }

        // DELETE: api/Sources/5
        [ResponseType(typeof(Sources))]
        public IHttpActionResult DeleteSources(int id)
        {
            Sources sources = db.Sources.Find(id);
            if (sources == null)
            {
                return NotFound();
            }

            db.Sources.Remove(sources);
            db.SaveChanges();

            return Ok(sources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SourcesExists(int id)
        {
            return db.Sources.Count(e => e.source_id == id) > 0;
        }
    }
}