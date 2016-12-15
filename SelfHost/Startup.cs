using System.Web.Http;
using Owin;
using SDSK.API;

namespace SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
