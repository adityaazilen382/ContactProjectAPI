using System;
using System.Web.Http;

namespace ContactAPI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityWebApiActivator.Start();
            Business.Helper.RegisterAutoMapper.Register();
        }
    }
}