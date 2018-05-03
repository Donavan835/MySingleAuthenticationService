using System;
using System.Data;
using System.Linq;
using System.Web.Services;
using UserCredentialCache;

namespace MyAuthenticationService
{
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]

	public class SingleAuthenticator : System.Web.Services.WebService
	{
		public UserCache _UserCache;
		string _UserName;
		public SingleAuthenticator(string UserName)
		{
			_UserName = UserName;
		}

		[WebMethod]
		public bool AuthenticateUser(string userPassword) {
			MyAuthenticationDataContext myDatabase = new MyAuthenticationDataContext();
			var password = (from credential in myDatabase.UserCredentials
							where credential.UserName == _UserName
						select credential.Password).ToList();

			string strPsw = String.Empty;
			if (password != null && password.Count > 0)
			{
				strPsw = password[0].ToString();
				return strPsw == userPassword ? true : false;
			}
			else {
				return false;
			}
		}

		[WebMethod]
		public DataTable GetUserDetails() {
			DataTable userCredential = new DataTable();
			MyAuthenticationDataContext myDatabase = new MyAuthenticationDataContext();
			var userResults = (from user in myDatabase.UserCredentials
								where user.UserName == _UserName
								select user).ToList();
			userCredential.Columns.Add("UserGuid");
			userCredential.Columns.Add("UserName");
			userCredential.Columns.Add("FullName");

			foreach (var userResult in userResults) {
				DataRow userRow = userCredential.NewRow();
				userRow[0] = userResult.UserGuid;
				userRow[1] = userResult.UserName;
				userRow[2] = userResult.FullName;
				userCredential.Rows.Add(userRow);
			}
			return userCredential;
		}

		[WebMethod]
		public DataTable GetAppAccessDetails() {
			DataTable applicationUser = new DataTable();
			MyAuthenticationDataContext myDatabase = new MyAuthenticationDataContext();
			var dataResults = (from application in myDatabase.Applications
								join appUser in myDatabase.ApplicationUsers on 
								application.ApplicationId equals appUser.ApplicationId
								where appUser.UserName == _UserName
								select application).ToList();
			
			applicationUser.Columns.Add("ApplicationCode");
			applicationUser.Columns.Add("ApplicationName");
			applicationUser.Columns.Add("ApplicationURL");

			foreach (var appUserResult in dataResults) {
				DataRow applicationUserRow = applicationUser.NewRow();
				applicationUserRow[0] = appUserResult.ApplicationCode;
				applicationUserRow[1] = appUserResult.ApplicationName;
				applicationUserRow[2] = appUserResult.ApplicationUrl;
				applicationUser.Rows.Add(applicationUserRow);
			}
			return applicationUser;
		}

		[WebMethod]
		public string AuthenticateClientUrl(string clientUrl) {
			return clientUrl + "?MyUserName=" + _UserName + "&SSOAuth=1";
		}

		[WebMethod]
		public void CheckUserCache() {
			if (Session["UserCache"] != null) {
				_UserCache = (UserCache)Session["UserCache"];
			}
			else {
				StartUserCache();
			}
		}

		[WebMethod]
		private UserCache StartUserCache()
		{
			_UserCache = new UserCache();
			_UserCache.InitializeLoginUserList();
			return _UserCache;
		}

		[WebMethod]
		public void AssignUserToCache(UserCache.LoginFrom userLoginFrom)
		{
			DataTable userCredential = GetUserDetails();
			Guid userGuid = Guid.Empty;
			Guid.TryParse(userCredential.Rows[0]["UserGuid"].ToString(), out userGuid);

			_UserCache.AddUserToLoginList(userGuid, userCredential.Rows[0]["UserName"].ToString(),
				userCredential.Rows[0]["FullName"].ToString(), userLoginFrom);
		}

		[WebMethod]
		public void RemoveUserFromCache(string userName) {
			if (_UserCache != null && _UserCache.LoginUserList.ContainsKey(userName)) {
				_UserCache.RemoveUserFromLoginList(userName);
			}
		}
	}
}
