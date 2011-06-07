<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="MB_Comments_View"
    Theme="DefaultVamsa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../App_Themes/DefaultVamsa/DefaultVamsa.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enableviewstate="true">
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    <div class="page">
                        <table class="tableComment">
                            <tr>
                                <td colspan="5">
                                    <h2>
                                        Ver Comentario</h2>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text="Enviado el :"></asp:Label>                                    
                                </td>
                                <td>                                    
                                    <asp:Label ID="lblCreatedOnDate" runat="server" ></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>                                    
                                </td>
                                <td>
                                    <a href='' onClick="parent.location.href=parent.location.href;parent.Shadowbox.close()" class="CloseMsg">CERRAR</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text="Nombre :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbleMail" runat="server" Text="Email :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxeMail" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany" runat="server" Text="¿Empresa en la que laboras?"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxCompanyWorking" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany0" runat="server" Text="¿Que tan  seguro te sientes en la empresa?"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblSecurityAnswer" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany1" runat="server" Text="¿Cómo ves la Empresa?"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblCompanyOpinionRating" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany2" runat="server" Text="¿Como calificarías a tu Jefe Directo?"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblSupervisorRating" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany4" runat="server" Text="¿Qué opinas del Director del Grupo?"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblGroupDirectorRating" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany3" runat="server" Text="¿En general como calificas el&lt;br/&gt; ambiente laboral de la empresa?"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblWorkEnviromentRating" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSubject" runat="server" Text="Asunto:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxSubject" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblComment" runat="server" Text="¿Algún comentario o sugerencia &lt;br/&gt;para la mejora del grupo?"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxComment" runat="server" TextMode="MultiLine" SkinID="tbxCommentSKIN"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblComment0" runat="server" Text="Reenviar a:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxForward" runat="server" TextMode="MultiLine" 
                                        SkinID="tbxCommentSKIN"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvForward" runat="server" 
                                        ControlToValidate="tbxForward" 
                                        ErrorMessage="Se requiere al menos un email para el reenvio." 
                                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="regexEmailAddress" runat="server" 
                                    ControlToValidate="tbxForward" Display="Dynamic" 
                                    ErrorMessage="Lo(s) eMail no contienen formato correo, verifique la informacion ej. usuario1@dominio.com;usuario2@dominio.com" 
                                    ValidationExpression="^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*[;]?\s*\b)*$" 
                                    ValidationGroup="">*</asp:RegularExpressionValidator></td>
                                <td>
                                    <asp:Button ID="btnForward" runat="server" Text="Reenviar" 
                                        onclick="btnForward_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
