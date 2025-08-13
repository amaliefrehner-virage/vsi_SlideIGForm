using System.Web.Mvc;

namespace SlideIGWebRetry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var apicontroller = new APIScenarioController();
            var listLang = apicontroller.GetLanguages();
            var listType = apicontroller.GetTypes();
            ViewBag.listLang = listLang;
            ViewBag.listType = listType;
            //get by scenario by id
            var Scenarios = apicontroller.GetAll();
            return View(Scenarios);
        }

        public void UploadJSON(string content) 
        {
            var api = new APIScenarioController();
        }
    }
}