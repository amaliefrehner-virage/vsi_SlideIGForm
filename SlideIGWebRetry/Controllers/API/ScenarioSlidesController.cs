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
    public class ScenarioSlidesController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioSlides
        public IQueryable<ScenarioSlide> GetScenarioSlides()
        {
            return db.ScenarioSlides;
        }

        // GET: api/ScenarioSlides/5
        [ResponseType(typeof(ScenarioSlide))]
        public async Task<IHttpActionResult> GetScenarioSlide(int id)
        {
            ScenarioSlide scenarioSlide = await db.ScenarioSlides.FindAsync(id);
            if (scenarioSlide == null)
            {
                return NotFound();
            }

            return Ok(scenarioSlide);
        }

        // PUT: api/ScenarioSlides/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutScenarioSlide(int id, ScenarioSlide scenarioSlide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioSlide.IDScenarioSlide)
            {
                return BadRequest();
            }
            db.Entry(scenarioSlide).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioSlideExists(id))
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

        // POST: api/ScenarioSlides
        [ResponseType(typeof(ScenarioSlide))]
        public async Task<ScenarioSlide> PostScenarioSlide(ScenarioSlide scenarioSlide)
        {

            db.ScenarioSlides.Add(scenarioSlide);
            await db.SaveChangesAsync();

            return scenarioSlide;
        }

        // DELETE: api/ScenarioSlides/5
        [ResponseType(typeof(ScenarioSlide))]
        public async Task<IHttpActionResult> DeleteScenarioSlide(int id)
        {
            ScenarioSlide scenarioSlide = await db.ScenarioSlides.FindAsync(id);
            if (scenarioSlide == null)
            {
                return NotFound();
            }

            db.ScenarioSlides.Remove(scenarioSlide);
            await db.SaveChangesAsync();

            return Ok(scenarioSlide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioSlideExists(int id)
        {
            return db.ScenarioSlides.Count(e => e.IDScenarioSlide == id) > 0;
        }
    }
}