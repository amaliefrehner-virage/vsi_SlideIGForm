using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlideIGWebRetry.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index(int id = -1, string type = "-1", string lang = "-1")
        {
            if (id == -1) { return View(); }
            if (type == "-1") { return View(); }
            if (lang == "-1") { return View(); }
            var apicontroller = new APIScenarioController();
            //get scenario by id
            var ScenarioModel = apicontroller.Get(id, type, lang);

            //get Languages & Types
            var listLang = apicontroller.GetLanguages();
            var listType = apicontroller.GetTypes();
            ViewBag.listLang = listLang;
            ViewBag.listType = listType;


            if (ScenarioModel == null)
            {
                var VideScenario = new Models.ScenarioModel
                {
                    Id = id,
                    Type = type,
                    Language = lang
                };
                return View(VideScenario);
            }

            return View(ScenarioModel);
        }
    }
}