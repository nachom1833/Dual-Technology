<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Vistas.Paginas.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <div class="container mt-5" style="text-align: left;">
        <div class="card">
            <div class="card-header">
                <h5 class="mb-0">Encontrá tu Producto</h5>
            </div>
            <div class="card-body ml-auto">
              
                <div class="form-group row">
                    <asp:Label runat="server" CssClass="col-sm-2 col-form-label" Text="Precios :"></asp:Label>
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Precio Menor A" ID="txtPrecioMin"></asp:TextBox>
                    </div>
                   
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Precio Mayor A" ID="txtPrecioMax"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                    <div class="col-sm-12 text-right">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Filtrar por precio" ID="btnFiltrarPrecio" OnClick="btnFiltrarPrecio_Click" />
                    </div>
                    </div>
                </div>         
                <div class="form-group row">
                    <asp:Label runat="server" CssClass="col-sm-2 col-form-label" Text="Categoría:"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFILTROcategorias">
                        
                        </asp:DropDownList>
                    </div>
                </div>

              
                <div class="form-group row">
                    <div class="col-sm-12 text-right">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Filtrar" ID="btnFiltrar" OnClick="btnFiltrar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Filtros" CssClass="btn btn-primary"/>
                        &nbsp;&nbsp;
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="display: flex; justify-content: center; align-items: center;">
             <asp:ListView ID="LvProductos" runat="server" GroupItemCount="3" OnItemCommand="LvProductos_ItemCommand" OnItemDataBound="LvProductos_ItemDataBound" OnPagePropertiesChanged="LvProductos_PagePropertiesChanged">
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
                    <td runat="server" style="">Descripcion_Ar:
                        <asp:TextBox ID="Descripcion_ArTextBox" runat="server" Text='<%# Bind("Descripcion_Ar") %>' />
                        <br />URL_IMG_Ar:
                        <asp:TextBox ID="URL_IMG_ArText" runat="server" Text='<%# Bind("URL_IMG_Ar") %>' />
                        <br />PrecioUnitario_Ar:
                        <asp:TextBox ID="PrecioUnitario_ArTextBox" runat="server" Text='<%# Bind("PrecioUnitario_Ar") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                  <ItemTemplate>
                    <td runat="server" style="width: 200px;">
                        <div class="card mb-4 shadow-sm">
                            <asp:Label ID="lblCodArt" runat="server" Text='<%# Eval("Cod_Art_Ar") %>' Visible="False" />
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("URL_IMG_Ar") %>' CssClass="card-img-top" />
                            <div class="card-body">
                                <h5 class="card-title"><asp:Label ID="Descripcion_ArLabel" runat="server" Text='<%# Eval("Descripcion_Ar") %>' /></h5>
                                <p class="card-text">Precio Unitario: <asp:Label ID="PrecioUnitario_ArLabel" runat="server" Text='<%# Eval("PrecioUnitario_Ar") %>' /></p>
                                <p class="card-text">Stock: <asp:Label ID="Stock" runat="server" Text='<%# Bind("Stock_Ar") %>' /></p>
                                <p class="card-text">Categoria: <asp:Label ID="Categoria" runat="server" Text='<%# Bind("Id_Categoria_Ar") %>' /></p>
                                <div class="d-flex justify-content-between align-items-center">
                                    <asp:Button ID="btnCarrito" runat="server" Text="Agregar al carrito" CommandName="AgregarCarrito" CommandArgument='<%# Eval("Cod_Art_Ar") %>' CssClass="btn btn-primary" />
                                    
                                </div>
                            </div>
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
                   <asp:DataPager ID="DataPager1" runat="server" PagedControlID="LvProductos" PageSize="9"   >
                            <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                      </asp:DataPager>
                               
                            </td>
                        </tr>
                    </table>    
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="">Descripcion_Ar:
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Descripcion_Ar") %>' />
                        <br />URL_IMG_Ar:
                        <asp:Label ID="URL_IMG_ArLabel" runat="server" Text='<%# Eval("URL_IMG_Ar") %>' />
                        <br />PrecioUnitario_Ar:
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("PrecioUnitario_Ar") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>

    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
