using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BASITraining.Startup))]
namespace BASITraining
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
