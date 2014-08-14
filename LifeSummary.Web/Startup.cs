using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeSummary.Startup))]
namespace LifeSummary
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
