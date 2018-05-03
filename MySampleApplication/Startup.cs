using Microsoft.Owin;
using Owin;

//[assembly: OwinStartupAttribute(typeof(MySampleApplication.Startup))]
namespace MySampleApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
