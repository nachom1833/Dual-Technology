<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarProductos.aspx.cs" Inherits="Vistas.Paginas.AdministrarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <div style="display: flex; justify-content: center; align-items: center;">
     <asp:ListView ID="LvProductos" runat="server" GroupItemCount="3" OnItemCommand="LvProductos_ItemCommand" OnItemDataBound="LvProductos_ItemDataBound">
                <EditItemTemplate>
                    
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No se han devuelto datos.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                </InsertItemTemplate>
                  <ItemTemplate>
                    <td runat="server" style="width: 400px;">
                        <div class="card mb-4 shadow-sm">
                            <asp:Label ID="lblCodArt" runat="server" Text='<%# Eval("Cod_Art_Ar") %>' Visible="False" />
                            <br />
                           <span>Descipcion  <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Descripcion_Ar">*</asp:RequiredFieldValidator> </span>  
                            <asp:TextBox ID="Descripcion_Ar" runat="server" Text='<%# Eval("Descripcion_Ar") %>' CssClass="form-control" />
                            <br />
                            <div class="text-center">
                                <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("URL_IMG_Ar") %>' CssClass="card-img-top" Height="200px" Width="100%" />
                            </div>
                            <br />
                            <span>Precio  <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="PrecioUnitario_Ar">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PrecioUnitario_Ar" ValidationExpression="^\d+(\,\d{2})?" ErrorMessage="*"></asp:RegularExpressionValidator></span>  
                            <asp:TextBox ID="PrecioUnitario_Ar" runat="server" Text='<%# Eval("PrecioUnitario_Ar") %>' CssClass="form-control" />
                            <br />
                            <span>Stock <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator"  ControlToValidate="Stock">*</asp:RequiredFieldValidator> <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Stock" ValidationExpression="^\d+" ErrorMessage="*"></asp:RegularExpressionValidator></span>
                            <asp:TextBox ID="Stock" runat="server" Text='<%# Bind("Stock_Ar") %>' CssClass="form-control" />
                            <br />
                            <spam>Categoria: <asp:Label ID="Categoria" runat="server" Text='<%# Bind("Id_Categoria_Ar") %>' /></spam>
                            <br />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" AutoPostBack="true" CssClass="btn btn-danger" />
                            <asp:Button ID="ButtonActualizar" CssClass="btn btn-primary" runat="server" CommandName="Actualizar" Text="Actualizar" />
                        </div>
                    </td>
                </ItemTemplate>
        <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                   <asp:DataPager ID="DataPager1" runat="server" PagedControlID="LvProductos" PageSize="9" OnPreRender="DataPager1_PagePropertiesChanged" >
                            <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                      </asp:DataPager>
                               
                            </td>
                        </tr>
                    </table>    
                </LayoutTemplate>
                <SelectedItemTemplate>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
