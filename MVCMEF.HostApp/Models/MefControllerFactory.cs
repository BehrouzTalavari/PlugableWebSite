using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MVCMEF.HostApp.Models
{
    public class MefControllerFactory : IControllerFactory
    {
        private string pluginPath;
        private DirectoryCatalog catalog;
        private CompositionContainer container;

        private DefaultControllerFactory defaultControllerFactory;

        public MefControllerFactory(string pluginPath)
        {
            this.pluginPath = pluginPath;
            this.catalog = new DirectoryCatalog(pluginPath);
            this.container = new CompositionContainer(catalog);

            this.defaultControllerFactory = new DefaultControllerFactory();
        }

        #region IControllerFactory Members

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IController controller = null;

            if (controllerName != null)
            {
                string controllerClassName = controllerName + "Controller";

                

                var exportDs = this.container.GetExports<IController, IDictionary<string, object>>();

                Lazy<IController, IDictionary<string, object>> export = 
                    
                    exportDs.Where(c => c.Metadata.Keys.Contains("controllerName") && 
                    c.Metadata.Values.Any(x=>x.ToString().ToLowerInvariant().Equals(controllerName.ToLowerInvariant()))).
                    FirstOrDefault();

                if (export != null)
                {
                    controller = export.Value;
                }
            }

            if (controller == null)
            {
                return this.defaultControllerFactory.CreateController(requestContext, controllerName);
            }

            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion
    }
}