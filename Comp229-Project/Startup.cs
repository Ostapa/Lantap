using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comp229_Project.Startup))]
namespace Comp229_Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
