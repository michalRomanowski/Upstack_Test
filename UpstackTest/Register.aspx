<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UpstackTest.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register: <br/><br/>

            Username: <asp:TextBox id="Username" runat="server" /> <br/><br/>
            E-Mail: <asp:TextBox id="Email" runat="server" /> <br/><br/>
            Password: <asp:TextBox id="Password" TextMode="Password" runat="server" /> <br/><br/>

            <asp:Button Text="Register" ID="Register" runat="server" OnClick="Register_Click"/>

            <asp:Label ID="Info" runat="server" />
        </div>
    </form>
</body>
</html>
