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
    public class ScenarioIGTitlesController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioIGTitles
        public IQueryable<ScenarioIGTitle> GetScenarioIGTitles()
        {
            return db.ScenarioIGTitles;
        }

        // GET: api/ScenarioIGTitles/5
        [ResponseType(typeof(ScenarioIGTitle))]
        public async Task<IHttpActionResult> GetScenarioIGTitle(int id)
        {
            ScenarioIGTitle scenarioIGTitle = await db.ScenarioIGTitles.FindAsync(id);
            if (scenarioIGTitle == null)
            {
                return NotFound();
            }

            return Ok(scenarioIGTitle);
        }

        // PUT: api/ScenarioIGTitles/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioIGTitle(int id, ScenarioIGTitle scenarioIGTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioIGTitle.IDScenarioIGTitle)
            {
                return BadRequest();
            }

            db.Entry(scenarioIGTitle).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioIGTitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioIGTitle;
        }

        // POST: api/ScenarioIGTitles
        [ResponseType(typeof(ScenarioIGTitle))]
        public async Task<object> PostScenarioIGTitle(ScenarioIGTitle scenarioIGTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScenarioIGTitles.Add(scenarioIGTitle);
            await db.SaveChangesAsync();

            return scenarioIGTitle;
        }

        // DELETE: api/ScenarioIGTitles/5
        [ResponseType(typeof(ScenarioIGTitle))]
        public async Task<IHttpActionResult> DeleteScenarioIGTitle(int id)
        {
            ScenarioIGTitle scenarioIGTitle = await db.ScenarioIGTitles.FindAsync(id);
            if (scenarioIGTitle == null)
            {
                return NotFound();
            }

            db.ScenarioIGTitles.Remove(scenarioIGTitle);
            await db.SaveChangesAsync();

            return Ok(scenarioIGTitle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioIGTitleExists(int id)
        {
            return db.ScenarioIGTitles.Count(e => e.IDScenarioIGTitle == id) > 0;
        }
    }
}