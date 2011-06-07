<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Browse.ascx.cs" Inherits="UserControls_Tickets_Browse" %>
<a href="View.aspx?IdTicket=0">Crear Ticket</a>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr style="">
            <%--<td>
                <a href='<%# string.Concat("../../Tickets/View.aspx?IdTicket=", Eval("IdTicket")) %>' runat="server" id="EditTicket">Editar</a>
            </td>--%>
            <td>
                <asp:Label ID="IdTicketLabel" runat="server" 
                    Text='<%# Eval("IdTicket") %>' />
            </td>
            <td>
                <asp:Label ID="CategoryLabel" runat="server" 
                    Text='<%# FormatCategory(Eval("Category")) %>' />
            </td>
            <td>
                <asp:Label ID="IdAssignedToLabel" runat="server" 
                    Text='<%# FormatAssignedTo(Eval("AssignedTo")) %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Eval("CreatedOn","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="ClosedOnByUserLabel" runat="server" 
                    Text='<%# Eval("ClosedOnByUser","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="IdTicketStatusLabel" runat="server" 
                    Text='<%# Eval("TicketStatus") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <%--<td>
                <a href='<%# string.Concat("../../Tickets/View.aspx?IdTicket=", Eval("IdTicket")) %>' runat="server" id="EditTicket">Editar</a>
            </td>--%>
            <td>
                <asp:Label ID="IdTicketLabel" runat="server" 
                    Text='<%# Eval("IdTicket")%>' />
            </td>
            <td>
                <asp:Label ID="CategoryLabel" runat="server" 
                    Text='<%# FormatCategory(Eval("Category")) %>' />
            </td>
            <td>
                <asp:Label ID="IdAssignedToLabel" runat="server" 
                    Text='<%# FormatAssignedTo(Eval("AssignedTo")) %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Eval("CreatedOn","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="ClosedOnByUserLabel" runat="server" 
                    Text='<%# Eval("ClosedOnByUser","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="IdTicketStatusLabel" runat="server" 
                    Text='<%# Eval("TicketStatus") %>' />
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
                                Folio</th>
                            <th runat="server" nowrap>
                                Categoría</th>
                            <th runat="server" nowrap>
                                Asignado a</th>
                            <th runat="server" nowrap>
                                Descripción</th>
                            <th runat="server" nowrap>
                                Creado</th>
                            <th runat="server" nowrap>
                                Cerrado</th>
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
                <asp:TextBox ID="IdTicketTextBox" runat="server" 
                    Text='<%# Bind("IdTicket") %>' />
            </td>
            <td>
                <asp:TextBox ID="IdCategoryTextBox" runat="server" 
                    Text='<%# Bind("IdCategory") %>' />
            </td>
            <td>
                <asp:TextBox ID="IdAssignedToTextBox" runat="server" 
                    Text='<%# Bind("IdAssignedTo") %>' />
            </td>
            <td>
                <asp:TextBox ID="DescriptionTextBox" runat="server" 
                    Text='<%# Bind("Description") %>' />
            </td>
            <td>
                <asp:TextBox ID="CreatedOnTextBox" runat="server" 
                    Text='<%# Bind("CreatedOn") %>' />
            </td>
            <td>
                <asp:TextBox ID="ClosedOnByUserTextBox" runat="server" 
                    Text='<%# Bind("ClosedOnByUser") %>' />
            </td>
            <td>
                <asp:TextBox ID="IdTicketStatusTextBox" runat="server" 
                    Text='<%# Bind("IdTicketStatus") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IdTicketLabel" runat="server" Text='<%# Eval("IdTicket") %>' />
            </td>
            <td>
                <asp:Label ID="IdCategoryLabel" runat="server" 
                    Text='<%# Eval("IdCategory") %>' />
            </td>
            <td>
                <asp:Label ID="IdAssignedToLabel" runat="server" 
                    Text='<%# Eval("IdAssignedTo") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
            <td>
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Eval("CreatedOn") %>' />
            </td>
            <td>
                <asp:Label ID="ClosedOnByUserLabel" runat="server" 
                    Text='<%# Eval("ClosedOnByUser") %>' />
            </td>
            <td>
                <asp:Label ID="IdTicketStatusLabel" runat="server" 
                    Text='<%# Eval("IdTicketStatus") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetAllByIdCompany" TypeName="CoreLibrary.Ticket.Controller">
    <SelectParameters>
        <asp:ControlParameter ControlID="HiddenIdCompany" DefaultValue="0" Name="ID" 
            PropertyName="Value" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

    <input id="HiddenIdCompany" type="hidden" runat="server" />


