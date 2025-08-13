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
    public class ScenarioSlideTitlesController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioSlideTitles
        public IQueryable<ScenarioSlideTitle> GetScenarioSlideTitles()
        {
            return db.ScenarioSlideTitles;
        }

        // GET: api/ScenarioSlideTitles/5
        [ResponseType(typeof(ScenarioSlideTitle))]
        public async Task<IHttpActionResult> GetScenarioSlideTitle(int id)
        {
            ScenarioSlideTitle scenarioSlideTitle = await db.ScenarioSlideTitles.FindAsync(id);
            if (scenarioSlideTitle == null)
            {
                return NotFound();
            }

            return Ok(scenarioSlideTitle);
        }

        // PUT: api/ScenarioSlideTitles/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioSlideTitle(int id, ScenarioSlideTitle scenarioSlideTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioSlideTitle.IDScenarioSlideTitle)
            {
                return BadRequest();
            }

            db.Entry(scenarioSlideTitle).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioSlideTitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioSlideTitle;
        }

        // POST: api/ScenarioSlideTitles
        [ResponseType(typeof(ScenarioSlideTitle))]
        public async Task<object> PostScenarioSlideTitle(ScenarioSlideTitle scenarioSlideTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScenarioSlideTitles.Add(scenarioSlideTitle);
            await db.SaveChangesAsync();

            return scenarioSlideTitle;
        }

        // DELETE: api/ScenarioSlideTitles/5
        [ResponseType(typeof(ScenarioSlideTitle))]
        public async Task<object> DeleteScenarioSlideTitle(int id)
        {
            ScenarioSlideTitle scenarioSlideTitle = await db.ScenarioSlideTitles.FindAsync(id);
            if (scenarioSlideTitle == null)
            {
                return NotFound();
            }

            db.ScenarioSlideTitles.Remove(scenarioSlideTitle);
            await db.SaveChangesAsync();

            return scenarioSlideTitle;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioSlideTitleExists(int id)
        {
            return db.ScenarioSlideTitles.Count(e => e.IDScenarioSlideTitle == id) > 0;
        }
    }
}