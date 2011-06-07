<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Browse.ascx.cs" Inherits="UserControls_Roles_Browse" %>
<a href="View.aspx?IdRole=0">Crear Role</a>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Roles/View.aspx?IdRole=", Eval("IdRole")) %>' runat="server" id="EditRole">Editar</a>
            </td>
            
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="RoleCodeLabel" runat="server" Text='<%# Eval("RoleCode") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus"))%>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Roles/View.aspx?IdRole=", Eval("IdRole")) %>' runat="server" id="EditRole">Editar</a>
            </td>
            
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="RoleCodeLabel" runat="server" Text='<%# Eval("RoleCode") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus"))%>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table id="Table1" runat="server" style="">
            <tr>
                <td>
                    No se han devuelto datos.</td>
            </tr>
        </table>
    </EmptyDataTemplate>    
    <LayoutTemplate>
        <table id="Table2" runat="server" class="listviewheader">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                        <tr id="Tr2" runat="server" style="">
                            <th id="Th6" runat="server" nowrap>
                                Acciones
                            </th>
                            <th id="Th1" runat="server" nowrap>
                                Rol</th>
                            <th id="Th2" runat="server" nowrap>
                                Código</th>
                            <th id="Th3" runat="server" nowrap>
                                Descripción</th>
                            <th id="Th4" runat="server" nowrap>
                                Estado</th>
                            
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
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
    <EditItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Actualizar" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancelar" />
            </td>
            <td>
                <asp:TextBox ID="IdRoleTextBox" runat="server" Text='<%# Bind("IdRole") %>' />
            </td>
            <td>
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            </td>
            <td>
                <asp:TextBox ID="RoleCodeTextBox" runat="server" 
                    Text='<%# Bind("RoleCode") %>' />
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
                <asp:Label ID="IdRoleLabel" runat="server" Text='<%# Eval("IdRole") %>' />
            </td>
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="RoleCodeLabel" runat="server" Text='<%# Eval("RoleCode") %>' />
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
    SelectMethod="GetAllRoles" TypeName="CoreLibrary.Security.RoleController"></asp:ObjectDataSource>
