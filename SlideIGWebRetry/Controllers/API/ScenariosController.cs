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
    public class ScenariosController : ApiController
    {
        private SlideIGWebEntities db = new SlideIGWebEntities();

        // GET: api/Scenarios
        public IQueryable<Scenario> GetScenarios()
        {
            return db.Scenarios;
        }

        // GET: api/Scenarios/5
        [ResponseType(typeof(Scenario))]
        public async Task<IHttpActionResult> GetScenario(int id)
        {
            Scenario scenario = await db.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            return Ok(scenario);
        }

        // PUT: api/Scenarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutScenario(int id, Scenario scenario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scenario.IDScenario)
            {
                return BadRequest();
            }

            db.Entry(scenario).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioExists(id))
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

        // POST: api/Scenarios
        [ResponseType(typeof(Scenario))]
        public async Task<object> PostScenario(Scenario scenario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Scenarios.Add(scenario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScenarioExists(scenario.IDScenario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return scenario;
        }

        // DELETE: api/Scenarios/5
        [ResponseType(typeof(Scenario))]
        public async Task<IHttpActionResult> DeleteScenario(int id)
        {
            Scenario scenario = await db.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            db.Scenarios.Remove(scenario);
            await db.SaveChangesAsync();

            return Ok(scenario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool ScenarioExists(int id)
        {
            return db.Scenarios.Count(e => e.IDScenario == id) > 0;
        }

        public bool ScenarioExistsNumber(string sc_number)
        {
            return db.Scenarios.Count(e => e.ScenarioNumber == sc_number) > 0;
        }

        //public bool ScenarioExistsLangType(string language, string type, int id)
        //{
        //    return db.Scenarios.Count(e => e.ScenarioInfoes. == language && e.Type == type && e.IDScenario == id) > 0;
        //}
    }
}