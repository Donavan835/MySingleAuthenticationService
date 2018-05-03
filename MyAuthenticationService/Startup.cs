using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAuthenticationService.Startup))]
namespace MyAuthenticationService
{
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			ConfigureAuth(app);
		}
	}
}
