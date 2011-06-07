<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Browse.ascx.cs" Inherits="UserControls_Users_Browse" %>
<a href="View.aspx?IdUser=0">Crear Usuario</a>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr style="" >
            <td>
                <a href='<%# string.Concat("../../Users/View.aspx?IdUser=", Eval("IdUser")) %>' runat="server" id="EditUser">Editar</a>
            </td>            
            <td>
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
            </td>            
            <td>
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
            </td>
            <td>
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
            </td>
            <td>
                <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>' />
            </td>
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Eval("CreatedOn","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Eval("ModifiedOn","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus"))%>' />
            </td>
            <td>
                <asp:Label ID="EntRoleLabel" runat="server" Text='<%# FormatRole(Eval("EntRole")) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <td>
                <a href='<%# string.Concat("../../Users/View.aspx?IdUser=", Eval("IdUser")) %>' runat="server" id="EditUser">Editar</a>
            </td>            
            <td>
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
            </td>            
            <td>
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
            </td>
            <td>
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
            </td>
            <td>
                <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>' />
            </td>
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Eval("CreatedOn","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Eval("ModifiedOn","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# FormatStatus(Eval("EntStatus"))%>' />
            </td>
            <td>
                <asp:Label ID="EntRoleLabel" runat="server" Text='<%# FormatRole(Eval("EntRole")) %>' />
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
                                Usuario</th>                            
                            <th runat="server" nowrap>
                                Nombre(s)</th>                            
                            <th runat="server" nowrap>
                                Apellido(s)</th>
                            <th runat="server" nowrap>
                                E-Mail</th>
                            <th runat="server" nowrap>
                                Creado</th>
                            <th runat="server" nowrap>
                                Modificado</th>
                            <th runat="server" nowrap>
                                Estado</th>
                            <th runat="server" nowrap>
                                Perfil</th>
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
                <asp:TextBox ID="IdUserTextBox" runat="server" Text='<%# Bind("IdUser") %>' />
            </td>
            <td>
                <asp:TextBox ID="UserNameTextBox" runat="server" 
                    Text='<%# Bind("UserName") %>' />
            </td>
            <td>
                <asp:TextBox ID="PasswordTextBox" runat="server" 
                    Text='<%# Bind("Password") %>' />
            </td>
            <td>
                <asp:TextBox ID="HashCodeTextBox" runat="server" 
                    Text='<%# Bind("HashCode") %>' />
            </td>
            <td>
                <asp:TextBox ID="FirstNameTextBox" runat="server" 
                    Text='<%# Bind("FirstName") %>' />
            </td>
            <td>
                <asp:TextBox ID="LastNameTextBox" runat="server" 
                    Text='<%# Bind("LastName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CreatedOnTextBox" runat="server" 
                    Text='<%# Bind("CreatedOn") %>' />
            </td>
            <td>
                <asp:TextBox ID="ModifiedOnTextBox" runat="server" 
                    Text='<%# Bind("ModifiedOn") %>' />
            </td>
            <td>
                <asp:TextBox ID="EntStatusTextBox" runat="server" 
                    Text='<%# Bind("EntStatus") %>' />
            </td>
            <td>
                <asp:TextBox ID="EntRoleTextBox" runat="server" Text='<%# Bind("EntRole") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IdUserLabel" runat="server" Text='<%# Eval("IdUser") %>' />
            </td>
            <td>
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
            </td>
            <td>
                <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
            </td>
            <td>
                <asp:Label ID="HashCodeLabel" runat="server" Text='<%# Eval("HashCode") %>' />
            </td>
            <td>
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
            </td>
            <td>
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
            </td>
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Eval("CreatedOn") %>' />
            </td>
            <td>
                <asp:Label ID="ModifiedOnLabel" runat="server" 
                    Text='<%# Eval("ModifiedOn") %>' />
            </td>
            <td>
                <asp:Label ID="EntStatusLabel" runat="server" Text='<%# Eval("EntStatus") %>' />
            </td>
            <td>
                <asp:Label ID="EntRoleLabel" runat="server" Text='<%# Eval("EntRole") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetUsers" TypeName="CoreLibrary.Security.MembershipController">
    <SelectParameters>
        <asp:Parameter Name="userName" Type="String" />
        <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
