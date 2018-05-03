using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserCredentialCache;

namespace MyAuthenticationService
{
	public partial class LoginPage : Page
	{
		SingleAuthenticator _MyAuthenticator;
		string _ReturnUrl;
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				
			}
		}

		protected void LoginControl_Authentication(object sender, AuthenticateEventArgs e) {
			_MyAuthenticator = new SingleAuthenticator(LoginControl.UserName);

			if (_MyAuthenticator.AuthenticateUser(LoginControl.Password)) {
				Session["MyUserName"] = LoginControl.UserName;
				
				_MyAuthenticator.CheckUserCache();
				_MyAuthenticator.AssignUserToCache(UserCache.LoginFrom.FromMaster);
				Session["UserCache"] = _MyAuthenticator._UserCache;

				_ReturnUrl = "~/MainAppPage.aspx";
				Response.Redirect(_ReturnUrl);
			}
		}
	}
}