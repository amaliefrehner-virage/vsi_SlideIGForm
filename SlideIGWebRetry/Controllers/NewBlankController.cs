using System.Web.Mvc;

namespace SlideIGWebRetry.Controllers
{
    public class NewBlankController : Controller
    {
        // GET: NewBlank
        public ActionResult Index()
        {
            var apicontroller = new APIScenarioController();
            var listLang = apicontroller.GetLanguages();
            var listType = apicontroller.GetTypes();
            ViewBag.listLang = listLang;
            ViewBag.listType = listType;
            return View();
        }
    }
}