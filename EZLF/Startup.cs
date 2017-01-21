using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZLF.Startup))]
namespace EZLF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
