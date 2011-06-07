<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BrowseComments.ascx.cs"
    Inherits="MB_UserControls_BrowseComments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager>
        <link rel="stylesheet" type="text/css" href="../../App_Themes/DefaultVamsa/DefaultVamsa.css" />
<link rel="stylesheet" type="text/css" href="../../js/shadowbox-3.0.3/shadowbox.css" />
            <script type="text/javascript" src="../../js/shadowbox-3.0.3/shadowbox.js"></script>
            <script type="text/javascript">
                Shadowbox.init();
            </script>

<%--<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../js/shadowbox.js"></script>
<script type="text/javascript">
    Shadowbox.init({
        players: [''] // whatever players you want here
    });
    </script>--%>
<div class="page">
<table class="tableComment">     
<tr>
    <td colspan="5"><h2>Listado de Mensajes</h2></td>
</tr>    
<tr>
<td colspan="5">
<table id="tblDateRange" runat="server" >      
    <tr>
        <td>
            <asp:Label ID="lblCompany" runat="server" Text="Compañía" />
        </td>
        <td>
            <asp:Label ID="lblStartDate" runat="server" Text="Fecha Inicio" />
        </td>
        <td>
            <asp:Label ID="lblEndDate" runat="server" Text="Fecha Fin" />
        </td>
        <td>
            <asp:Label ID="lblState" runat="server" Text="Estado" />
        </td>
        <td></td>        
    </tr>
    <tr>        
        <td valign="top">
            <asp:DropDownList ID="ddlCompany" runat="server">
                <asp:ListItem Selected="True">Todas</asp:ListItem>
                <asp:ListItem>No Especificada</asp:ListItem>
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
        <td valign="top">
        
            <asp:TextBox ID="tbxStartDate" runat="server" SkinID="tbxDateSKIN">1/1/2010</asp:TextBox>
            <asp:RegularExpressionValidator ID="revDateRangeStart" runat="server" ErrorMessage="Formato de fecha de inicio no valido"
                Text="*" ValidationExpression="(([3]{1}[0-1]{1}[/]{1}[1]{1}[0-2]{1}[/]{1}[0-9]{4})|([3]{1}[0-1]{1}[/]{1}[0]{1}[0-9]{1}[/]{1}[0-9]{4})|([0-2]{1}[0-9]{1}[/]{1}[1]{1}[0-2]{1}[/]{1}[0-9]{4})|([0-2]{1}[0-9]{1}[/]{1}[0]{1}[0-9]{1}[/]{1}[0-9]{4}))"
                ControlToValidate="tbxStartDate" ValidationGroup="daterange"></asp:RegularExpressionValidator>
            <asp:calendarextender id="ceStartDate" runat="server" enabled="True" targetcontrolid="tbxStartDate"
                popupbuttonid="imgStartDate" format="dd/MM/yyyy">
                                    </asp:calendarextender>
            <asp:Image ID="imgStartDate" runat="server" ImageUrl="~/App_Themes/DefaultVamsa/images/calendar.jpg" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxStartDate"
                ErrorMessage="La fecha de inicio es requerida" Display="Dynamic" ValidationGroup="daterange"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td valign="top">
            <asp:TextBox ID="tbxEndDate" runat="server" SkinID="tbxDateSKIN">10/10/2010</asp:TextBox>
            <asp:RegularExpressionValidator ID="revDateRangeEnd" runat="server" ErrorMessage="Formato de fecha de inicio no valido"
                Text="*" ValidationExpression="(([3]{1}[0-1]{1}[/]{1}[1]{1}[0-2]{1}[/]{1}[0-9]{4})|([3]{1}[0-1]{1}[/]{1}[0]{1}[0-9]{1}[/]{1}[0-9]{4})|([0-2]{1}[0-9]{1}[/]{1}[1]{1}[0-2]{1}[/]{1}[0-9]{4})|([0-2]{1}[0-9]{1}[/]{1}[0]{1}[0-9]{1}[/]{1}[0-9]{4}))"
                ControlToValidate="tbxEndDate" ValidationGroup="daterange"></asp:RegularExpressionValidator>
            <asp:calendarextender id="ceEndDate" runat="server" enabled="True" targetcontrolid="tbxEndDate"
                popupbuttonid="imgEndDate" format="dd/MM/yyyy">
                                    </asp:calendarextender>
            <asp:Image ID="imgEndDate" runat="server" ImageUrl="~/App_Themes/DefaultVamsa/images/calendar.jpg" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxEndDate"
                ErrorMessage="La fecha de término es requerida" Display="Dynamic" ValidationGroup="daterange"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td valign="top">
            <asp:RadioButtonList ID="rblEstate" runat="server">
                <asp:ListItem Value="-1" Selected="True">Todos</asp:ListItem>
                <asp:ListItem Value="1">Leidos</asp:ListItem>
                <asp:ListItem Value="0">Sin Leer</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td valign="top">
            <asp:ImageButton ID="imgbtnRefresh" runat="server" ImageUrl="~/App_Themes/DefaultVamsa/Images/refresh.jpg"
                Width="16px" Height="16px" OnClick="imgbtnRefresh_Click" ValidationGroup="daterange" />
                <br />
                <br />
            <asp:ImageButton ID="imbtnExport" runat="server" 
                ImageUrl="~/MB/Images/ExportToPDF.jpg" onclick="imbtnExport_Click" />
        </td>
    </tr>
    <tr>        
        <td valign="top" colspan="5">
        
<asp:ListView ID="lvMessagesList" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr style="">
            <td>
            <%--'<%# string.Concat("~/CustomersSecure/TicketDetail.aspx?IdTicket=", Eval("IdTicket"),"&Accion=1") %>'--%>
                <a href='<%# string.Concat("../Comments/View.aspx?IdComment=", Eval("IdComment")) %>' rel='shadowbox;width=700;height=585'  class="a_Ver">Ver</a>
                <%--<asp:Label ID="IdCommentLabel" runat="server" Text='<%# Eval("IdComment") %>' />--%>
            </td>
            <td>
                <asp:Label ID="CompanyWorkingLabel" runat="server" Text='<%# Eval("CompanyWorking") %>' />
            </td>
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
            </td>
            <td>
                <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("Subject") %>' />
            </td>                        
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# DateTime.Parse(Eval("CreatedOn").ToString()).ToString("dd/MM/yyyy")  %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsReadCheckBox" runat="server" Checked='<%# Eval("IsRead") %>'
                    Enabled="false" />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <td>
            <a href='<%# string.Concat("../Comments/View.aspx?IdComment=", Eval("IdComment")) %>' rel='shadowbox;width=700;height=585' class="a_Ver">Ver</a>
                <%--<asp:Label ID="IdCommentLabel" runat="server" Text='<%# Eval("IdComment") %>' />--%>
            </td>
            <td>
                <asp:Label ID="CompanyWorkingLabel" runat="server" Text='<%# Eval("CompanyWorking") %>' />
            </td>
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
            </td>
            <td>
                <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("Subject") %>' />
            </td>
            
            
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# DateTime.Parse(Eval("CreatedOn").ToString()).ToString("dd/MM/yyyy") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsReadCheckBox" runat="server" Checked='<%# Eval("IsRead") %>'
                    Enabled="false" />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table id="Table1" runat="server" style="">
            <tr>
                <td>
                    No se ha encontrado ningún mensaje.
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <LayoutTemplate>
        <table id="Table2" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                        <tr id="Tr2" runat="server" style="">
                            <th id="Th1" runat="server">
                                
                            </th>
                            <th id="Th7" runat="server">
                                Compañía
                            </th>
                            <th id="Th2" runat="server">
                                Nombre
                            </th>
                            <th id="Th3" runat="server">
                                Email
                            </th>
                            <th id="Th4" runat="server">
                                Asunto
                            </th>                            
                            <th id="Th5" runat="server">
                                Creado
                            </th>
                            <th id="Th6" runat="server">
                                Leido
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td id="Td2" runat="server" style="">
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCommentsByFilter"
    TypeName="CoreLibrary.Comment.Controller">
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlCompany" Name="slCompany" 
            PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="tbxStartDate" DefaultValue="1/1/2011" 
            Name="StartDate" PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="tbxEndDate" DefaultValue="1/1/2012" 
            Name="EndDate" PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="rblEstate" DefaultValue="-1" Name="IsRead" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
            </td>        
        
    </tr>
</table>
<table>
<tr>
<td>

</td>
</tr>
</table>
</td>
</tr>
</table>
</div>