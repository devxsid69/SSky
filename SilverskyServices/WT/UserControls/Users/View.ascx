<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="UserControls_Users_View" %>

<style type="text/css" >
@Import url("../../App_Themes/Default/Default.css");
</style>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblUserName" runat="server" Text="Usuario:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="tbxUserName"
                Display="Dynamic" ErrorMessage="Usuario es Requerido." ValidationGroup="OnSave"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbxPassword"
                Display="Dynamic" ErrorMessage="Contraseña es requerida." ValidationGroup="OnSave"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirmar Contraseña:" 
                CssClass="TdLabels"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="tbxPasswordConfirm"
                Display="Dynamic" ErrorMessage="Confirmar Contraseña es requerida." ValidationGroup="OnSave"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxPassword"
                ControlToValidate="tbxPasswordConfirm" ErrorMessage="Contraseña y Confirmar contraseña no coinciden."
                SetFocusOnError="True" ValidationGroup="OnSave">*</asp:CompareValidator>
        </td>
        <td class="TdTextBoxes">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblFirstName" runat="server" Text="Nombre(s):"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" Display="Dynamic"
                ErrorMessage="Nombre(s) es requerido." ValidationGroup="OnSave" ControlToValidate="tbxFirstName"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblLastName" runat="server" Text="Apellido(s):"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxLastName" runat="server"></asp:TextBox>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" Display="Dynamic"
                ErrorMessage="Apellido es requerido." ValidationGroup="OnSave" ControlToValidate="tbxLastName"
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
        <tr>
        <td class="TdLabels">
            <asp:Label ID="lblEmail" runat="server" Text="E-Mail:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                ControlToValidate="tbxEmail" ErrorMessage="E-Mail es requerido." 
                ValidationGroup="OnSave">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="tbxEmail" Display="Dynamic" 
                ErrorMessage="El formato del E-mail es incorrecto." 
                ValidationExpression="(^[a-zA-Z0-9_\+-]+(\.[a-zA-Z0-9_\+-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.([a-zA-Z]{2,4})$)|" 
                ValidationGroup="OnSave">*</asp:RegularExpressionValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblCompany" runat="server" Text="Empresa:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlCompany" runat="server" 
                DataSourceID="ObjectDataSource3" DataTextField="Name" 
                DataValueField="IdCompany">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                SelectMethod="GetAllDDL" TypeName="CoreLibrary.Company.Controller">
            </asp:ObjectDataSource>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvCompany" runat="server" 
                ErrorMessage="Empresa es requerido." InitialValue="-1" 
                ControlToValidate="ddlCompany">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblRole" runat="server" Text="Perfil:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="ObjectDataSource2"
                DataTextField="Name" DataValueField="IdRole">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="CoreLibrary.Security.RoleController"
                SelectMethod="GetAllRolesDDL"></asp:ObjectDataSource>
        </td>
        <td class="TdValidators" >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                ErrorMessage="Perfil es requerido." ValidationGroup="OnSave" ControlToValidate="ddlRoles"
                InitialValue="-1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </td>
        <td class="style1">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="ObjectDataSource1"
                DataTextField="Name" DataValueField="IdStatus">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="CoreLibrary.Status.Controller"
                SelectMethod="GetAllDDL"></asp:ObjectDataSource>
        </td>
        <td class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                ErrorMessage="Estado es requerido." ValidationGroup="OnSave" ControlToValidate="ddlStatus"
                SetFocusOnError="True" InitialValue="-1">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;
        </td>
        <td class="TdTextBoxes">
            &nbsp;
        </td>
        <td class="TdValidators">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;</td>
        <td class="TdTextBoxes">
            <asp:Label ID="lblError" runat="server" Text="" SkinID="LabelError"></asp:Label>
        </td>
        <td class="TdValidators">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;
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
        <td class="TdValidators">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;
        </td>
        <td class="TdTextBoxes">
            &nbsp;
        </td>
        <td class="TdValidators">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;
        </td>
        <td colspan="3" class="TdValidators">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="OnSave" />
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;
        </td>
        <td class="TdTextBoxes">
            &nbsp;
        </td>
        <td class="TdValidators">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
