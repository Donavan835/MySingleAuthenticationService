<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyAuthenticationService.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>ASP.NET</h1>
		<p class="lead">ASP.NET is a free web framework for building great Web sites 
			and Web applications using HTML, CSS, and JavaScript.</p>
		<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
	</div>
	<div>
		<table>
			<tr>
				<td>
					<asp:Label ID="lblMain" runat="server" Font-Bold="True" Font-Names="Broadway" 
						Font-Size="X-Large" Text="My Authentication Login" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Login ID="LoginControl" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" 
						BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="12pt" 
						OnAuthenticate="LoginControl_Authentication">
						<TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
					</asp:Login>
				</td>
			</tr>
		</table>
	</div>

</asp:Content>