<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FormQuestions.ascx.cs"
    Inherits="MB_UserControls_FormQuestions" %>
<%@ Register Assembly="CaptchaCtrl" Namespace="CaptchaCtrl" TagPrefix="cc1" %>
<link rel="stylesheet" type="text/css" href="../../App_Themes/DefaultVamsa/DefaultVamsa.css" />
<div class="page">
    <table style="width: 100%;">
        <tr>
            <td align="center">
                <div class="page">
                    <table class="tableComment">
                        <tr>
                            <td colspan="5">
                                <h2>
                                    Enviar Comentario</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="lblMsgInformation" Text="Para su comodidad y respetando su confidencialidad, todos los datos requeridos en esta página <br/>son opcionales y serán entregados única y exclusivamente al Director del Grupo.<br/><br/><br/>Agradecemos de antemano su colaboración. <br/><br/>Favor de contestar el próximo cuestionario, donde 1 es la puntuación mas baja  y 5 es la puntuación más alta"
                                    runat="server"></asp:Label>
                                <br />
                                <br />
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
                                <asp:DropDownList ID="ddlCompany" runat="server">
                                    <asp:ListItem Selected="True">No Especificada</asp:ListItem>
                                    <asp:ListItem>Vamsa Aguascalientes</asp:ListItem>
                                    <asp:ListItem>Renault Aguascalientes</asp:ListItem>
                                    <asp:ListItem>Renault Acapulco</asp:ListItem>
                                    <asp:ListItem>Renault Leon</asp:ListItem>
                                    <asp:ListItem>Hino Aguascalientes</asp:ListItem>
                                    <asp:ListItem>BMW Aguascalientes</asp:ListItem>
                                    <asp:ListItem>BMW Tijuana</asp:ListItem>
                                    <asp:ListItem>BMW Mexicali</asp:ListItem>
                                    <asp:ListItem>BPR</asp:ListItem>
                                    <asp:ListItem>2x3 By Vamsa</asp:ListItem>
                                    <asp:ListItem>Audi Aguascalientes</asp:ListItem>
                                </asp:DropDownList>
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
                            <td colspan="5" align="right">
                                <div style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px;
                                    color: #666666;">
                                    <cc1:CaptchaControl ID="CaptchaControl1" runat="server" Text="Ingrese el Codigo:" />
                                </div>
                                <div>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblCustomMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
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
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnSend" runat="server" Text="Enviar" OnClick="btnSend_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>
