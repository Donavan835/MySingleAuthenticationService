<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientMainPage.aspx.cs" Inherits="MySampleApplication.ClientMainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	
	 <table>
			<tr>
				<td>
					<asp:Label ID="lblClientApplication" runat="server" Font-Bold="True" 
						Font-Names="Broadway" Font-Size="X-Large" Text="My Client Application" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblLiteral" runat="server" />
				</td>
			</tr>
			<tr><td><br /></td></tr>
			<tr>
				<td>
					<asp:button ID="btnLogOut" runat="server" Text="Logout" OnClick="UserLogOff" />
				</td>
			</tr>
		</table>
	</form>
</body>
</html>
