using System;
using System.Collections.Generic;

namespace UserCredentialCache
{
	public class UserCache
	{
		public Dictionary<string, UserCredential> LoginUserList = null;
		public enum LoginFrom
		{
			Unknown = 0,
			FromClient = 1,
			FromMaster = 2
		};

		public UserCache() {

		}

		public void InitializeLoginUserList() {
			LoginUserList = new Dictionary<string, UserCredential>();
		}

		public void ClearUserCredentialList()
		{
			LoginUserList = null;
		}

		public void AddUserToLoginList(Guid userGuid, string userName, 
			string userFullName, LoginFrom userLoginFrom) {
			try
			{
				if (!LoginUserList.ContainsKey(userName)) {
					LoginUserList.Add(userName, AssignValuesToUserCredentials(userGuid, 
						userName, userFullName, userLoginFrom));
				}
			}
			catch (Exception excp)
			{ throw excp; }
		}

		private UserCredential AssignValuesToUserCredentials(Guid userGuid,
			string userName, string userFullName, LoginFrom userLoginFrom) {
			UserCredential returnLoginCredential = new UserCredential();
			returnLoginCredential.UserID = userGuid;
			returnLoginCredential.UserName = userName;
			returnLoginCredential.UserFullName = userFullName;
			returnLoginCredential.UserLoginFrom = userLoginFrom;

			return returnLoginCredential;
		}

		public void RemoveUserFromLoginList(string userName)
		{
			try
			{
				if (LoginUserList.ContainsKey(userName))
				{
					LoginUserList.Remove(userName);
				}
			}
			catch (Exception excp)
			{ throw excp; }
		}

		public class UserCredential {
			public Guid UserID { get; set; }
			public string UserName { get; set; }
			public string UserFullName { get; set; }
			public string UserApplication { get; set; }
			public LoginFrom UserLoginFrom { get; set; }

			public UserCredential() {

			}
		}
	}
}
