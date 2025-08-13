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
    public class ScenarioSlideSubTitleBulletsController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioSlideSubTitleBullets
        public IQueryable<ScenarioSlideSubTitleBullet> GetScenarioSlideSubTitleBullets()
        {
            return db.ScenarioSlideSubTitleBullets;
        }

        // GET: api/ScenarioSlideSubTitleBullets/5
        [ResponseType(typeof(ScenarioSlideSubTitleBullet))]
        public async Task<IHttpActionResult> GetScenarioSlideSubTitleBullet(int id)
        {
            ScenarioSlideSubTitleBullet scenarioSlideSubTitleBullet = await db.ScenarioSlideSubTitleBullets.FindAsync(id);
            if (scenarioSlideSubTitleBullet == null)
            {
                return NotFound();
            }

            return Ok(scenarioSlideSubTitleBullet);
        }

        // PUT: api/ScenarioSlideSubTitleBullets/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioSlideSubTitleBullet(int id, ScenarioSlideSubTitleBullet scenarioSlideSubTitleBullet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioSlideSubTitleBullet.IDScenarioSlideSubTitleBullets)
            {
                return BadRequest();
            }

            db.Entry(scenarioSlideSubTitleBullet).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioSlideSubTitleBulletExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioSlideSubTitleBullet;
        }

        // POST: api/ScenarioSlideSubTitleBullets
        [ResponseType(typeof(ScenarioSlideSubTitleBullet))]
        public async Task<object> PostScenarioSlideSubTitleBullet(ScenarioSlideSubTitleBullet scenarioSlideSubTitleBullet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScenarioSlideSubTitleBullets.Add(scenarioSlideSubTitleBullet);
            await db.SaveChangesAsync();

            return scenarioSlideSubTitleBullet;
        }

        // DELETE: api/ScenarioSlideSubTitleBullets/5
        [ResponseType(typeof(ScenarioSlideSubTitleBullet))]
        public async Task<object> DeleteScenarioSlideSubTitleBullet(int id)
        {
            ScenarioSlideSubTitleBullet scenarioSlideSubTitleBullet = await db.ScenarioSlideSubTitleBullets.FindAsync(id);
            if (scenarioSlideSubTitleBullet == null)
            {
                return NotFound();
            }

            db.ScenarioSlideSubTitleBullets.Remove(scenarioSlideSubTitleBullet);
            await db.SaveChangesAsync();

            return scenarioSlideSubTitleBullet;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioSlideSubTitleBulletExists(int id)
        {
            return db.ScenarioSlideSubTitleBullets.Count(e => e.IDScenarioSlideSubTitleBullets == id) > 0;
        }
    }
}