using System;
using System.Text;
using System.Web.Security;
using MyAuthenticationService;
using UserCredentialCache;

namespace MySampleApplication
{
	public partial class ClientMainPage : System.Web.UI.Page {
		UserCache _UserCache;
		string _LoginUserName = string.Empty;

		protected void Page_Load(object sender, EventArgs e) {
			AssignUserName();

			if (String.IsNullOrEmpty(_LoginUserName))
				FormsAuthentication.RedirectToLoginPage();
			else
			{
				AssignUserCache();

				string userFullName = string.Empty;
				UserCache.LoginFrom userLoginFrom = UserCache.LoginFrom.Unknown;
				GetLoginUserDetails(ref userFullName, ref userLoginFrom);

				ShowWelcomeMessage(userFullName, userLoginFrom);
			}
		}

		private void AssignUserName() {
			if (Request.QueryString["MyUserName"] != null) {
				_LoginUserName = Request.QueryString["MyUserName"].ToString();
			}
			else if (Session["MyUserName"] != null) {
				_LoginUserName = Session["MyUserName"].ToString();
			}
		}

		private void AssignUserCache() {
			if (Session["UserCache"] != null) {
				_UserCache = (UserCache)Session["UserCache"];
			}
			else {
				SingleAuthenticator authenticator = new SingleAuthenticator(_LoginUserName);
				authenticator.CheckUserCache();
				authenticator.AssignUserToCache(UserCache.LoginFrom.FromMaster);
				
				_UserCache = authenticator._UserCache;
				Session["UserCache"] = authenticator._UserCache;
			}
		}

		private void GetLoginUserDetails(ref string userFullName, ref UserCache.LoginFrom userLoginFrom) {
			if (_UserCache != null && _UserCache.LoginUserList.ContainsKey(_LoginUserName))
			{
				userFullName = _UserCache.LoginUserList[_LoginUserName].UserFullName;
				userLoginFrom = _UserCache.LoginUserList[_LoginUserName].UserLoginFrom;
			}
		}

		private void ShowWelcomeMessage(string userFullName, UserCache.LoginFrom userLoginFrom)
		{
			StringBuilder welcomeBuilder = new StringBuilder();
			welcomeBuilder.Append("Welcome " + userFullName + " to My Main Application.");
			welcomeBuilder.Append(System.Environment.NewLine);

			switch (userLoginFrom) {
				case UserCache.LoginFrom.FromClient:
					welcomeBuilder.Append("You've login from the client-login.");
					break;
				case UserCache.LoginFrom.FromMaster:
					welcomeBuilder.Append("You've redirected from the master-application.");
					break;
				default:
					// Do nothing
					break;
			}

			welcomeBuilder.AppendLine("This Login is authenticated by SSO.");
			lblLiteral.Text = welcomeBuilder.ToString();
		}

		protected void UserLogOff(object sender, EventArgs e) {
			SingleAuthenticator authenticator = new SingleAuthenticator(_LoginUserName);
			authenticator.RemoveUserFromCache(_LoginUserName);

			Session["UserCache"] = authenticator._UserCache;
			Session["MyUserName"] = null;

			string returnUrl = "~/Login.aspx";
			Response.Redirect(returnUrl);
		}
	}
}