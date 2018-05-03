using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyAuthenticationService;
using UserCredentialCache;

namespace MySampleApplication
{
	public partial class LoginPage : Page
	{
		SingleAuthenticator _myAuthenticator;
		string returnUrl;

		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void LoginControl_Authenticate(object sender, AuthenticateEventArgs e) {
			_myAuthenticator = new SingleAuthenticator(LoginControl.UserName);

			if (_myAuthenticator.AuthenticateUser(LoginControl.Password))
			{
				Session["MyUserName"] = LoginControl.UserName;

				_myAuthenticator.CheckUserCache();
				_myAuthenticator.AssignUserToCache(UserCache.LoginFrom.FromClient);
				Session["UserCache"] = _myAuthenticator._UserCache;

				returnUrl = "~/ClientMainPage.aspx?SSOAuth=1";
				Response.Redirect(returnUrl);
			}

		}
	}
}