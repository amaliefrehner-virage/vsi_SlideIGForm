using System.Web.Mvc;

namespace SlideIGWebRetry.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index(int id = -1, string type = "-1", string lang = "-1")
        {
            var apicontroller = new APIScenarioController();
            var listLang = apicontroller.GetLanguages();
            var listType = apicontroller.GetTypes();
            var listBullets = apicontroller.GetBulletPoints();
            Models.ScenarioListModel ScenariosList = apicontroller.GetAll();
            ViewBag.listBullets = listBullets;
            ViewBag.listLang = listLang;
            ViewBag.listType = listType;
            ViewBag.listScenarios = ScenariosList.ScenariosList;

            if (id == -1) { return View(); }
            if (type == "-1") { return View(); }
            if (lang == "-1") { return View(); }
            //get by scenario by id
            var ScenarioModel = apicontroller.Get(id, type, lang);

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