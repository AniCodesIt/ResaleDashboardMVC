using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResaleDashboardMVC.Startup))]
namespace ResaleDashboardMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
