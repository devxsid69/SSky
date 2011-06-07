<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="UserControls_Categories_View" %>
<style type="text/css" >
@Import url("../../App_Themes/Default/Default.css");
</style>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblName" runat="server" Text="Nombre:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbxName" Display="Dynamic" 
                ErrorMessage="Nombre es Requerido." ValidationGroup="OnSave">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblAssignedTo" runat="server" Text="Asignar a:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlAssignedTo" runat="server" AutoPostBack="True" 
                DataSourceID="ObjectDataSource2" DataTextField="UserCompleteName" 
                DataValueField="IdUser" 
                onselectedindexchanged="ddlAssignedTo_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                SelectMethod="GetUsersDDL" TypeName="CoreLibrary.Security.MembershipController">
            </asp:ObjectDataSource>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="ddlAssignedTo" Display="Dynamic" 
                ErrorMessage="Asignar a es requerido." ValidationGroup="OnSave" 
                InitialValue="-1">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="Label2" runat="server" Text="Default E-Mail:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxDefaultEmail" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
            &nbsp;</td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="Label3" runat="server" Text="E-Mail Alternativo:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxAlternativeEmail" runat="server"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="tbxAlternativeEmail" Display="Dynamic" 
                ErrorMessage="E-Mail alternativo es requerido." ValidationGroup="OnSave">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="tbxAlternativeEmail" Display="Dynamic" 
                ErrorMessage="El formato del E-mail alternativo es incorrecto." 
                ValidationExpression="(^[a-zA-Z0-9_\+-]+(\.[a-zA-Z0-9_\+-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.([a-zA-Z]{2,4})$)|" 
                ValidationGroup="OnSave">*</asp:RegularExpressionValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="Label4" runat="server" Text="Estado:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="ObjectDataSource1"
                DataTextField="Name" DataValueField="IdStatus">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="CoreLibrary.Status.Controller"
                SelectMethod="GetAllDDL"></asp:ObjectDataSource>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                Display="Dynamic" ErrorMessage="RequiredFieldValidator" 
                ValidationGroup="OnSave" ControlToValidate="ddlStatus">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;</td>
        <td class="TdTextBoxes">
        </td>
        <td width="10px" class="TdValidators">
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
        </td>
        <td class="TdTextBoxes">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Guardar" ValidationGroup="OnSave" OnClick="btnSave_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancelar"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="10px" class="TdValidators">
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>