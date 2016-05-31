using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndirectlyApp.Startup))]
namespace IndirectlyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
