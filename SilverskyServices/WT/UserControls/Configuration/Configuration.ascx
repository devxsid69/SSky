<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Configuration.ascx.cs" Inherits="WT_UserControls_Configuration_Configuration" %>
<style type="text/css" >
    @Import url("../../App_Themes/Default/Default.css");
</style>

<table>
    <tr>
        <td colspan="4">
            
            <asp:ListView ID="lvGlobalAttributes" runat="server" DataSourceID="odsGlobalAttributes">
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="lblIdGlobalAttribute" runat="server" 
                                Text='<%# Eval("IdGlobalAttribute") %>' Visible="false"/>
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxValue" runat="server" Text='<%# Eval("Value") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" 
                                Text='<%# Eval("Description") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="lblIdGlobalAttribute" runat="server" 
                                Text='<%# Eval("IdGlobalAttribute") %>' Visible="false" />
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>                            
                            <asp:TextBox ID="tbxValue" runat="server" Text='<%# Eval("Value") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" 
                                Text='<%# Eval("Description") %>' />
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
                                            </th>
                                        <th runat="server">
                                            Nombre</th>
                                        <th runat="server">
                                            Valor</th>
                                        <th runat="server">
                                            Descripción</th>
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
                            <asp:TextBox ID="IdGlobalAtributeTextBox" runat="server" 
                                Text='<%# Bind("IdGlobalAtribute") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# Bind("Value") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" 
                                Text='<%# Bind("Description") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="IdGlobalAtributeLabel" runat="server" 
                                Text='<%# Eval("IdGlobalAtribute") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server" 
                                Text='<%# Eval("Description") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            
            <asp:ObjectDataSource ID="odsGlobalAttributes" runat="server" 
                SelectMethod="GetConfiguration" TypeName="CoreLibrary.Configuration.Controller">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="IdApplication" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="TdLabels">
            &nbsp;</td>
        <td class="TdTextBoxes">
            <asp:Label ID="Label1" runat="server" Text="" SkinID="LabelError"></asp:Label>
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
                        
                    </td>
                </tr>
            </table>
        </td>
        <td class="TdValidators">
        </td>
        <td>
        </td>
    </tr>
</table>