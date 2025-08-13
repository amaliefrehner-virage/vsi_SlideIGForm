using SlideIGWebRetry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SlideIGWebRetry.Controllers
{
    public class PrintMultipleController : Controller
    {
        // GET: PrintMultiple
        public ActionResult Index()
        {
            var apicontroller = new APIScenarioController();
            List<Models.ScenarioModel> ListOfScenarios = new List<Models.ScenarioModel> { };
            List<string> listIDS = new List<string> { };
            for (int i = 1; i < 100; i++)
            {
                string listofIds = Request.Cookies["listofIds" + i]?.Value;
                if (listofIds != null)
                {
                    listIDS.Add(listofIds);
                }
                else
                {
                    break;
                }
            }
            if (listIDS.Count != 0 && listIDS[0] != "")
            {
                foreach (var h in listIDS)
                {
                    List<string> listIds = h.Split(',').ToList();
                    // Now you can use the 'listIds' variable as a list of IDs
                    foreach (var i in listIds)  // Iterate over 'listIds' instead of 'listofIds'
                    {
                        if (i.Contains("-"))
                        {
                            int i_id = Int32.Parse(i.Split('-')[0]);
                            string i_type = i.Split('-')[1];
                            string i_lang = i.Split('-')[2];
                            var ScenarioModel = apicontroller.Get(i_id, i_type, i_lang);
                            ListOfScenarios.Add(ScenarioModel);
                        }
                    }
                }
            }
            else
            {
                var all = apicontroller.GetAll("", "en", "vs500");
                foreach (var i in all.ScenariosList)
                {
                    var ScenarioModel = apicontroller.Get(i.Id, "vs500", "en");
                    ListOfScenarios.Add(ScenarioModel);
                }
            }

            var ScenarioListLol = new Models.ScenarioModelList
            {
                scenarioModels = ListOfScenarios
            };

            //get Languages & Types
            var listLang = apicontroller.GetLanguages();
            var listType = apicontroller.GetTypes();
            ViewBag.listLang = listLang;
            ViewBag.listType = listType;


            if (ScenarioListLol == null)
            {
                var VideScenario = new Models.ScenarioModel
                {
                    Id = 1,
                    Type = "vs500",
                    Language = "en"
                };
                return View(VideScenario);
            }

            return View(ScenarioListLol);
        }

    }
}