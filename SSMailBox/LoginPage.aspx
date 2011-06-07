<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" Theme="DefaultVamsa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" AsyncPostBackTimeout="120">
    </asp:ScriptManager>
    <div align="center" style="width:60%;">
        <img alt="" src="App_Themes/DefaultVamsa/Images/Logo.jpg" / width="300px"></div>
    <div align="center" style="width:60%;">
        <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn" 
            OnLoginError="Login1_LoginError" 
            
            FailureText="El intento de ingreso no pudo ser completado. Por favor intentalo nuevamente." 
            DestinationPageUrl="~/Default.aspx">
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <LayoutTemplate>
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse; height:200px;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="TitleLabel" runat="server" SkinID="TitleLabelSkin">Acceso</asp:Label>
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:5px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="UserNameLabel" runat="server" SkinID="LabelLogin" AssociatedControlID="UserName">Usuario:</asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:5px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" SkinID="LabelLogin">Contraseña:</asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:5px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" SkinID="LoginButtonSkin" CommandName="Login" Text="Ingresar" ValidationGroup="Login1" />
                                    </td>
                                </tr>                                
                            </table>
                            <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                <tr>
                                    <td align="center" style="color: Red;">
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="Usuario es requerido." ToolTip="Usuario es requerido." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Contraseña es requerida." ToolTip="Contraseña es requerida." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </div>

    </div>
    </form>
</body>
</html>
