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
    public class ScenarioInfoesController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/ScenarioInfoes
        public IQueryable<ScenarioInfo> GetScenarioInfoes()
        {
            return db.ScenarioInfoes;
        }

        // GET: api/ScenarioInfoes/5
        [ResponseType(typeof(ScenarioInfo))]
        public async Task<IHttpActionResult> GetScenarioInfo(int id)
        {
            ScenarioInfo scenarioInfo = await db.ScenarioInfoes.FindAsync(id);
            if (scenarioInfo == null)
            {
                return NotFound();
            }

            return Ok(scenarioInfo);
        }

        // PUT: api/ScenarioInfoes/5
        [ResponseType(typeof(void))]
        public async Task<object> PutScenarioInfo(int id, ScenarioInfo scenarioInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenarioInfo.IDScenarioInfo)
            {
                return BadRequest();
            }

            db.Entry(scenarioInfo).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return scenarioInfo;
        }

        // POST: api/ScenarioInfoes
        [ResponseType(typeof(ScenarioInfo))]
        public async Task<ScenarioInfo> PostScenarioInfo(ScenarioInfo scenarioInfo)
        {

            db.ScenarioInfoes.Add(scenarioInfo);
            await db.SaveChangesAsync();

            return scenarioInfo;
        }

        // DELETE: api/ScenarioInfoes/5
        [ResponseType(typeof(ScenarioInfo))]
        public async Task<object> DeleteScenarioInfo(int id)
        {
            ScenarioInfo scenarioInfo = await db.ScenarioInfoes.FindAsync(id);

            int? idscenario = scenarioInfo.IDScenario;

            if (scenarioInfo == null)
            {
                return NotFound();
            }

            
            db.ScenarioInfoes.Remove(scenarioInfo);
			
			await db.SaveChangesAsync();

            IEnumerable<ScenarioInfo> otherLanguages = await db.ScenarioInfoes.ToListAsync();
            otherLanguages = otherLanguages.Where(s => s.IDScenario == idscenario);
			if (otherLanguages.Count() == 0)
			{
				Scenario scenario = await db.Scenarios.FindAsync(idscenario);
				if (scenario != null)
                {
					db.Scenarios.Remove(scenario);
					await db.SaveChangesAsync();
				}
			}
			return scenarioInfo;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScenarioInfoExists(int id)
        {
            return db.ScenarioInfoes.Count(e => e.IDScenarioInfo == id) > 0;
        }

        public bool ScenarioInfoExistsLangType(int language, int type, int id)
        {
            return db.ScenarioInfoes.Count(e => e.IDLanguage == language && e.IDSimulatorType == type && e.IDScenario == id) > 0;
        }

        public List<ScenarioInfo> GetScenarioInfoesWithOfLanguage(int languageId)
        {
            List<ScenarioInfo> scenarioInfo = db.ScenarioInfoes.Where(s => s.IDLanguage == languageId).ToList();
            if (scenarioInfo == null)
            {
                return null;
            }
            return scenarioInfo;
        }
    }
}