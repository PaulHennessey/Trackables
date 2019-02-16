using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trackables.Startup))]
namespace Trackables
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
