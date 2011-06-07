<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Browse.ascx.cs" Inherits="UserControls_Categories_Browse" %>
<a href="View.aspx?IdCategory=0">Crear Categoría</a>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Categories/View.aspx?IdCategory=", Eval("IdCategory")) %>' runat="server" id="EditRole">Editar</a>
            </td>   
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="AssignedToLabel" runat="server" 
                    Text='<%# FormatAssignedTo(Eval("AssignedTo")) %>' />
            </td>
            <td>
                <asp:Label ID="DefaultMailLabel" runat="server" 
                    Text='<%# Eval("DefaultMail") %>' />
            </td>
            <td>
                <asp:Label ID="AlternativeMailLabel" runat="server" 
                    Text='<%# Eval("AlternativeMail") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus")) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Categories/View.aspx?IdCategory=", Eval("IdCategory")) %>' runat="server" id="EditRole">Editar</a>
            </td>  
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="AssignedToLabel" runat="server" 
                    Text='<%# Eval("AssignedTo") %>' />
            </td>
            <td>
                <asp:Label ID="DefaultMailLabel" runat="server" 
                    Text='<%# Eval("DefaultMail") %>' />
            </td>
            <td>
                <asp:Label ID="AlternativeMailLabel" runat="server" 
                    Text='<%# Eval("AlternativeMail") %>' />
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
        <table runat="server" class="listviewheader">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                        <tr runat="server" style="">
                            <th runat="server" nowrap>
                                Acciones</th>
                            <th runat="server" nowrap>
                                Nombre</th>
                            <th runat="server" nowrap>
                                Asignada</th>
                            <th runat="server" nowrap>
                                E-mail</th>
                            <th runat="server" nowrap>
                                E-mail Alternativo</th>
                            <th runat="server" nowrap>
                                Estado</th>
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
                <asp:TextBox ID="IdCategoryTextBox" runat="server" 
                    Text='<%# Bind("IdCategory") %>' />
            </td>
            <td>
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            </td>
            <td>
                <asp:TextBox ID="AssignedToTextBox" runat="server" 
                    Text='<%# Bind("AssignedTo") %>' />
            </td>
            <td>
                <asp:TextBox ID="DefaultMailTextBox" runat="server" 
                    Text='<%# Bind("DefaultMail") %>' />
            </td>
            <td>
                <asp:TextBox ID="AlternativeMailTextBox" runat="server" 
                    Text='<%# Bind("AlternativeMail") %>' />
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
                <asp:Label ID="IdCategoryLabel" runat="server" 
                    Text='<%# Eval("IdCategory") %>' />
            </td>
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="AssignedToLabel" runat="server" 
                    Text='<%# Eval("AssignedTo") %>' />
            </td>
            <td>
                <asp:Label ID="DefaultMailLabel" runat="server" 
                    Text='<%# Eval("DefaultMail") %>' />
            </td>
            <td>
                <asp:Label ID="AlternativeMailLabel" runat="server" 
                    Text='<%# Eval("AlternativeMail") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# Eval("EntStatus") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetAll" TypeName="CoreLibrary.Category.Controller">
</asp:ObjectDataSource>
