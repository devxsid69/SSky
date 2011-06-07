<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Close.ascx.cs" Inherits="UserControls_Tickets_Close" %>
<style type="text/css" >
@Import url("../../App_Themes/Default/Default.css");
</style>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblOpenedBy" runat="server" Text="Abierto por:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:Label ID="lblOpenedByTxt" runat="server" Text=""></asp:Label>
        </td>
        <td width="10px" class="TdValidators">
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblCategory" runat="server" Text="Categoria:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:Label ID="lblCategoryTxt" runat="server" Text=""></asp:Label>
        </td>
        <td width="10px" class="TdValidators">
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblOpenedOn" runat="server" Text="Creado el:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:Label ID="lblOpenedOnTxt" runat="server" Text=""></asp:Label>
        </td>
        <td width="10px" class="TdValidators">
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
                SkinID="tbxDescriptionSKIN" ReadOnly="true"></asp:TextBox>
        </td>
        <td width="10px" class="TdValidators">
        </td>
        <td>
            &nbsp;
        </td>        
    </tr>
    <tr>
        <td class="TdLabels">
            <asp:Label ID="lblCloseDescription" runat="server" Text="Descripción de Cierre:"></asp:Label>
        </td>
        <td class="TdTextBoxes">
            <asp:TextBox ID="tbxCloseDescription" runat="server"  TextMode="MultiLine" 
                ValidationGroup="OnSave" Height="111px" Width="204px" 
                SkinID="tbxDescriptionSKIN"></asp:TextBox>
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
                        &nbsp;</td>
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