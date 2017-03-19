using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityPortalApp.Web.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace UniversityPortalApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
