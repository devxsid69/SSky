<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="UserControls_Tickets_View" %>
<style type="text/css" >
@Import url("../../App_Themes/Default/Default.css");
</style>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblCategory" runat="server" Text="Categoria:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlCategory" runat="server" 
                DataSourceID="ObjectDataSource1" DataTextField="Name" 
                DataValueField="IdCategory" AutoPostBack="True" 
                onselectedindexchanged="ddlCategory_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetAllDDL" TypeName="CoreLibrary.Category.Controller">
            </asp:ObjectDataSource>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Categoria es requerido." ValidationGroup="OnSave" 
                ControlToValidate="ddlCategory" InitialValue="-1">*</asp:RequiredFieldValidator>
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
            <asp:TextBox ID="tbxDescription" runat="server"  TextMode="MultiLine" 
                ValidationGroup="OnSave" Height="111px" Width="204px" 
                SkinID="tbxDescriptionSKIN"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Descripción es requerida." ValidationGroup="OnSave" 
                ControlToValidate="tbxDescription">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="AssignedTo" runat="server" Text="Asignado a:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxAssignedTo" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </td>
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
            <asp:Label ID="lblPriority" runat="server" Text="Prioridad:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:DropDownList ID="ddlPrioridad" runat="server">
                <asp:ListItem Value="1">Baja</asp:ListItem>
                <asp:ListItem Value="2">Media</asp:ListItem>
                <asp:ListItem Value="3">Alta</asp:ListItem>
                <asp:ListItem Value="-1" Selected="True">Selecciona...</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="10px" class="TdValidators">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="Prioridad es requerida." ValidationGroup="OnSave" 
                ControlToValidate="ddlPrioridad" InitialValue="-1">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;</td>
        <td class="TdTextBoxes">
            <asp:Label ID="lblError" runat="server" SkinID="LabelError" Text=""></asp:Label>
        </td>
        <td width="10px" class="TdValidators">
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