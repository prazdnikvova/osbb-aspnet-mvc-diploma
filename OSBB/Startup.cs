using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OSBB.Startup))]
namespace OSBB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
