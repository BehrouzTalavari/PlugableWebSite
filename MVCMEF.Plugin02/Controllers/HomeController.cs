using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace MVCMEF.Plugin02.Controllers
{
    [Export(typeof(IController))]
    [ExportMetadata("controllerName", "KaizenHome")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Plugins/Plugin02Views/Home/Index.cshtml");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}