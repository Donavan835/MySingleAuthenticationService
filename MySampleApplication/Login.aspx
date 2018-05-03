<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MySampleApplication.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>ASP.NET</h1>
		<p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
		<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
	</div>

	<div>
		<table>
			<tr>
				<td>
					<asp:Label ID="lblMain" runat="server" Font-Bold="True" Font-Names="Broadway" 
						Font-Size="X-Large">My Sample Application</asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Login ID="LoginControl" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" 
						BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" 
						OnAuthenticate="LoginControl_Authenticate">
						<TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
					</asp:Login>
				</td>
			</tr>
		</table>	
	</div>

</asp:Content>
