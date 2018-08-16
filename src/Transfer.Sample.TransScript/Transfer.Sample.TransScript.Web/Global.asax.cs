using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Transfer.Sample.TransScript.Register;

namespace Transfer.Sample.TransScript.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacExt.InitAutofac();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
