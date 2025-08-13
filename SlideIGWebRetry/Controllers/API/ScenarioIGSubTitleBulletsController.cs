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
    public class ScenarioIGSubTitleBulletsController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioIGSubTitleBullets
        public IQueryable<ScenarioIGSubTitleBullet> GetScenarioIGSubTitleBullets()
        {
            return db.ScenarioIGSubTitleBullets;
        }

        // GET: api/ScenarioIGSubTitleBullets/5
        [ResponseType(typeof(ScenarioIGSubTitleBullet))]
        public async Task<IHttpActionResult> GetScenarioIGSubTitleBullet(int id)
        {
            ScenarioIGSubTitleBullet scenarioIGSubTitleBullet = await db.ScenarioIGSubTitleBullets.FindAsync(id);
            if (scenarioIGSubTitleBullet == null)
            {
                return NotFound();
            }

            return Ok(scenarioIGSubTitleBullet);
        }

        // PUT: api/ScenarioIGSubTitleBullets/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioIGSubTitleBullet(int id, ScenarioIGSubTitleBullet scenarioIGSubTitleBullet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioIGSubTitleBullet.IDScenarioIGSubTitleBullets)
            {
                return BadRequest();
            }

            db.Entry(scenarioIGSubTitleBullet).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioIGSubTitleBulletExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioIGSubTitleBullet;
        }

        // POST: api/ScenarioIGSubTitleBullets
        [ResponseType(typeof(ScenarioIGSubTitleBullet))]
        public async Task<object> PostScenarioIGSubTitleBullet(ScenarioIGSubTitleBullet scenarioIGSubTitleBullet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScenarioIGSubTitleBullets.Add(scenarioIGSubTitleBullet);
            await db.SaveChangesAsync();

            return scenarioIGSubTitleBullet;
        }

        // DELETE: api/ScenarioIGSubTitleBullets/5
        [ResponseType(typeof(ScenarioIGSubTitleBullet))]
        public async Task<IHttpActionResult> DeleteScenarioIGSubTitleBullet(int id)
        {
            ScenarioIGSubTitleBullet scenarioIGSubTitleBullet = await db.ScenarioIGSubTitleBullets.FindAsync(id);
            if (scenarioIGSubTitleBullet == null)
            {
                return NotFound();
            }

            db.ScenarioIGSubTitleBullets.Remove(scenarioIGSubTitleBullet);
            await db.SaveChangesAsync();

            return Ok(scenarioIGSubTitleBullet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioIGSubTitleBulletExists(int id)
        {
            return db.ScenarioIGSubTitleBullets.Count(e => e.IDScenarioIGSubTitleBullets == id) > 0;
        }
    }
}