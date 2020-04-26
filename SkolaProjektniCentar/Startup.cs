using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkolaProjektniCentar.Startup))]
namespace SkolaProjektniCentar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
