using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace MVCMEF.Plugin01
{
    [Export(typeof(IController))]
    [ExportMetadata("controllerName", "Demo")]
    [ExportMetadata("MenuName", "DemoMenu")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Plugins/Plugin01Views/Demo/Index.cshtml");
        }
    }
}
