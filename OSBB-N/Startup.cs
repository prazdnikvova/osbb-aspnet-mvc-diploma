using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OSBB_N.Startup))]
namespace OSBB_N
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
