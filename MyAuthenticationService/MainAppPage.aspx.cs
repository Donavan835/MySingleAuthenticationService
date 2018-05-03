using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using UserCredentialCache;

namespace MyAuthenticationService
{
	public partial class MainAppPage : System.Web.UI.Page {
		UserCache _UserCache;
		string _LoginUserName;

		protected void Page_Load(object sender, EventArgs e) {
			if (Session["MyUserName"] == null)
				FormsAuthentication.RedirectToLoginPage();
			else
			{
				AssignUser();
				ShowWelcomeMessage();
				ConstructApplicationLinks();
			}
		}

		private void AssignUser() {
			_LoginUserName = Session["MyUserName"].ToString();
			_UserCache = (UserCache)Session["UserCache"];
		}

		private void ShowWelcomeMessage() {
			string userFullName = string.Empty;
			if (_UserCache != null && _UserCache.LoginUserList.ContainsKey(_LoginUserName)) {
				userFullName = _UserCache.LoginUserList[_LoginUserName].UserFullName;
			}

			lblLiteral.Text = "Welcome " + userFullName + " to My Main Application.";
		}

		private void ConstructApplicationLinks() {
			SingleAuthenticator authService = new SingleAuthenticator(_LoginUserName);
			DataTable applicationResults = authService.GetAppAccessDetails();

			foreach (DataRow application in applicationResults.Rows)
			{
				HyperLink _hyperlink = new HyperLink();
				_hyperlink.Text = application["ApplicationName"].ToString();
				_hyperlink.NavigateUrl = authService.AuthenticateClientUrl(application["ApplicationURL"].ToString());
				divLinks.Controls.Add(_hyperlink);
				divLinks.Controls.Add(new LiteralControl("<BR>"));
			}
		}

		protected void UserLogOff(object sender, EventArgs e)
		{
			SingleAuthenticator authService = new SingleAuthenticator(_LoginUserName);
			authService.RemoveUserFromCache(_LoginUserName);

			Session["UserCache"] = authService._UserCache;
			Session["MyUserName"] = null;

			string returnUrl = "~/Login.aspx";
			Response.Redirect(returnUrl);
		}
	}
}