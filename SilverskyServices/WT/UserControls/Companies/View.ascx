<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="UserControls_Companies_View" %>
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
            <asp:Label ID="lblDescription" runat="server" Text="Descripción:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxDescription" runat="server"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                ControlToValidate="tbxDescription" Display="Dynamic" 
                ErrorMessage="Descripción es Requerido." ValidationGroup="OnSave">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
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
                ValidationGroup="OnSave" ControlToValidate="ddlStatus" InitialValue="-1">*</asp:RequiredFieldValidator>
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