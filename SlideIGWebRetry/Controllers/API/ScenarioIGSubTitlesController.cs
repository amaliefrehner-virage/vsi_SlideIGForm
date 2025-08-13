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
    public class ScenarioIGSubTitlesController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioIGSubTitles
        public IQueryable<ScenarioIGSubTitle> GetScenarioIGSubTitles()
        {
            return db.ScenarioIGSubTitles;
        }

        // GET: api/ScenarioIGSubTitles/5
        [ResponseType(typeof(ScenarioIGSubTitle))]
        public async Task<IHttpActionResult> GetScenarioIGSubTitle(int id)
        {
            ScenarioIGSubTitle scenarioIGSubTitle = await db.ScenarioIGSubTitles.FindAsync(id);
            if (scenarioIGSubTitle == null)
            {
                return NotFound();
            }

            return Ok(scenarioIGSubTitle);
        }

        // PUT: api/ScenarioIGSubTitles/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioIGSubTitle(int id, ScenarioIGSubTitle scenarioIGSubTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioIGSubTitle.IDScenarioIGSubTitle)
            {
                return BadRequest();
            }

            db.Entry(scenarioIGSubTitle).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioIGSubTitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioIGSubTitle;
        }

        // POST: api/ScenarioIGSubTitles
        [ResponseType(typeof(ScenarioIGSubTitle))]
        public async Task<object> PostScenarioIGSubTitle(ScenarioIGSubTitle scenarioIGSubTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScenarioIGSubTitles.Add(scenarioIGSubTitle);
            await db.SaveChangesAsync();

            return scenarioIGSubTitle;
        }

        // DELETE: api/ScenarioIGSubTitles/5
        [ResponseType(typeof(ScenarioIGSubTitle))]
        public async Task<IHttpActionResult> DeleteScenarioIGSubTitle(int id)
        {
            ScenarioIGSubTitle scenarioIGSubTitle = await db.ScenarioIGSubTitles.FindAsync(id);
            if (scenarioIGSubTitle == null)
            {
                return NotFound();
            }

            db.ScenarioIGSubTitles.Remove(scenarioIGSubTitle);
            await db.SaveChangesAsync();

            return Ok(scenarioIGSubTitle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioIGSubTitleExists(int id)
        {
            return db.ScenarioIGSubTitles.Count(e => e.IDScenarioIGSubTitle == id) > 0;
        }
    }
}