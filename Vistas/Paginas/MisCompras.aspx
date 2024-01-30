<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="Vistas.Paginas.MisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
     <div class="row mb-4">
         <div class="col-lg-8">
                <asp:GridView ID="GridViewReportes" runat="server" PageSize="5" AllowPaging="true" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridViewReportes_RowCommand" OnPageIndexChanging="GridViewReportes_PageIndexChanging" >                 <Columns>
                     <asp:TemplateField HeaderText="Producto">
                         <ItemTemplate>
                             <div class="row">
                                 <div class="col-lg-4">
                                     <span class="mt-0 mb-1">NRO FATURA : </span><asp:Label ID="LblNumeroDeFactura" runat="server" class="mt-0 mb-1"><%# Eval("Nro_Factura_V") %></asp:Label>
                                     <br />
                                     <span class="mt-0 mb-1">MONTO : </span><asp:Label ID="LblMonto" runat="server" class="mt-0 mb-1"><%# Eval("TotalVenta_V") %></asp:Label> 
                                     <br />
                                     <br />
                                 </div>
                                 <div class="col-lg-8 text-end">
                                     <div class="media-body">
                                         <asp:Label runat="server" ID="LblFecha" class="mt-0 mb-1"><%# Eval("Fecha_Venta_V") %></asp:Label>
                                         <br />
                                         <br />
                                         <br />
                                         <asp:Button ID="BtnVerDetalle" runat="server" class="btn btn-primary" Text="Ver detalles de compra" CommandName="EventoDetalles" CommandArgument='<%# Eval("Nro_Factura_V") %>' />
                                     </div>
                                 </div>
                             </div>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <PagerSettings Mode="NumericFirstLast" Position="Bottom" PageButtonCount="5" />
              </asp:GridView>
         </div>
    <asp:Label ID="LblTOtal" runat="server" CssClass="h1" Text=""></asp:Label>
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
