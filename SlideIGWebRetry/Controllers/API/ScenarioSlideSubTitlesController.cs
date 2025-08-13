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
    public class ScenarioSlideSubTitlesController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioSlideSubTitles
        public IQueryable<ScenarioSlideSubTitle> GetScenarioSlideSubTitles()
        {
            return db.ScenarioSlideSubTitles;
        }

        // GET: api/ScenarioSlideSubTitles/5
        [ResponseType(typeof(ScenarioSlideSubTitle))]
        public async Task<IHttpActionResult> GetScenarioSlideSubTitle(int id)
        {
            ScenarioSlideSubTitle scenarioSlideSubTitle = await db.ScenarioSlideSubTitles.FindAsync(id);
            if (scenarioSlideSubTitle == null)
            {
                return NotFound();
            }

            return Ok(scenarioSlideSubTitle);
        }

        // PUT: api/ScenarioSlideSubTitles/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioSlideSubTitle(int id, ScenarioSlideSubTitle scenarioSlideSubTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioSlideSubTitle.IDScenarioSlideSubTitle)
            {
                return BadRequest();
            }

            db.Entry(scenarioSlideSubTitle).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioSlideSubTitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioSlideSubTitle;
        }

        // POST: api/ScenarioSlideSubTitles
        [ResponseType(typeof(ScenarioSlideSubTitle))]
        public async Task<object> PostScenarioSlideSubTitle(ScenarioSlideSubTitle scenarioSlideSubTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScenarioSlideSubTitles.Add(scenarioSlideSubTitle);
            await db.SaveChangesAsync();

            return scenarioSlideSubTitle;
        }

        // DELETE: api/ScenarioSlideSubTitles/5
        [ResponseType(typeof(ScenarioSlideSubTitle))]
        public async Task<object> DeleteScenarioSlideSubTitle(int id)
        {
            ScenarioSlideSubTitle scenarioSlideSubTitle = await db.ScenarioSlideSubTitles.FindAsync(id);
            if (scenarioSlideSubTitle == null)
            {
                return NotFound();
            }

            db.ScenarioSlideSubTitles.Remove(scenarioSlideSubTitle);
            await db.SaveChangesAsync();

            return scenarioSlideSubTitle;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioSlideSubTitleExists(int id)
        {
            return db.ScenarioSlideSubTitles.Count(e => e.IDScenarioSlideSubTitle == id) > 0;
        }
    }
}