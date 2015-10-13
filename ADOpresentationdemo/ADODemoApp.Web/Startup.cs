using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADODemoApp.Web.Startup))]
namespace ADODemoApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
