<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Browse.ascx.cs" Inherits="UserControls_Companies_Browse" %>
<a href="View.aspx?IdCompany=0">Crear Empresa</a>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Companies/View.aspx?IdCompany=", Eval("IdCompany")) %>' runat="server" id="EditRole">Editar</a>
            </td>            
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus")) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Companies/View.aspx?IdCompany=", Eval("IdCompany")) %>' runat="server" id="EditRole">Editar</a>
            </td>            
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus")) %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="">
            <tr>
                <td>
                    No se han devuelto datos.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                        <tr runat="server" style="">
                            <th runat="server">
                                Acciones</th>
                            <th runat="server">
                                Name</th>
                            <th runat="server">
                                Description</th>
                            <th runat="server">
                                EntStatus</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="">
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <EditItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Actualizar" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancelar" />
            </td>
            <td>
                <asp:TextBox ID="IdCompanyTextBox" runat="server" 
                    Text='<%# Bind("IdCompany") %>' />
            </td>
            <td>
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            </td>
            <td>
                <asp:TextBox ID="DescriptionTextBox" runat="server" 
                    Text='<%# Bind("Description") %>' />
            </td>
            <td>
                <asp:TextBox ID="EntStatusTextBox" runat="server" 
                    Text='<%# Bind("EntStatus") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IdCompanyLabel" runat="server" Text='<%# Eval("IdCompany") %>' />
            </td>
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# Eval("EntStatus") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetAll" TypeName="CoreLibrary.Company.Controller"></asp:ObjectDataSource>
