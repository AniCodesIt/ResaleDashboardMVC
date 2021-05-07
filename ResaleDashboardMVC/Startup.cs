using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FusionCharts.Samples.Models.Startup))]
namespace FusionCharts.Samples.Models
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
