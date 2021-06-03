using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCMEF.Plugin01
{
    [Export(typeof(IController))]
    [ExportMetadata("controllerName", "Demo")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Plugins/Plugin01Views/Demo/Index.cshtml");
        }
    }
}
