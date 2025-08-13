using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SlideIGWebRetry.Models;

namespace SlideIGWebRetry.Controllers
{
    public class ScenarioIGsController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioIGs
        public IQueryable<ScenarioIG> GetScenarioIGs()
        {
            return db.ScenarioIGs;
        }

        // GET: api/ScenarioIGs/5
        [ResponseType(typeof(ScenarioIG))]
        public async Task<IHttpActionResult> GetScenarioIG(int id)
        {
            ScenarioIG scenarioIG = await db.ScenarioIGs.FindAsync(id);
            if (scenarioIG == null)
            {
                return NotFound();
            }

            return Ok(scenarioIG);
        }

        // PUT: api/ScenarioIGs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutScenarioIG(int id, ScenarioIG scenarioIG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioIG.IDScenarioIG)
            {
                return BadRequest();
            }

            db.Entry(scenarioIG).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioIGExists(id))
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

        // POST: api/ScenarioIGs
        [ResponseType(typeof(ScenarioIG))]
        public async Task<ScenarioIG> PostScenarioIG(ScenarioIG scenarioIG)
        {

            db.ScenarioIGs.Add(scenarioIG);
            await db.SaveChangesAsync();

            return scenarioIG;
        }

        // DELETE: api/ScenarioIGs/5
        [ResponseType(typeof(ScenarioIG))]
        public async Task<IHttpActionResult> DeleteScenarioIG(int id)
        {
            ScenarioIG scenarioIG = await db.ScenarioIGs.FindAsync(id);
            if (scenarioIG == null)
            {
                return NotFound();
            }

            db.ScenarioIGs.Remove(scenarioIG);
            await db.SaveChangesAsync();

            return Ok(scenarioIG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioIGExists(int id)
        {
            return db.ScenarioIGs.Count(e => e.IDScenarioIG == id) > 0;
        }
    }
}