<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Vistas.Paginas.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <div class="d-flex justify-content-center align-items-center">
         
    <h1 class="display-6">Ingrese N° de factura</h1>
    </div>
    <div class="d-flex justify-content-center align-items-center">
     <asp:LinkButton ID="linkBtnFiltro" runat="server" OnClick="linkBtnFiltro_Click" ><asp:Literal runat="server" Text="<i class='bi bi-search'></i>" /></asp:LinkButton><asp:TextBox ID="TxtFiltro" CssClass="form-control me-3" runat="server"></asp:TextBox></div><div style="width:150px">
     <asp:RegularExpressionValidator ID="REV" runat="server" ControlToValidate="TxtFiltro" ValidationExpression="^\d+" ErrorMessage="Ingrese un numero de factura valido"></asp:RegularExpressionValidator><div class="row">
         <div class="mb-4">
     <asp:Button ID="BTnrestaurar"  class="btn btn-primary" runat="server" Text="Sacar Filtro" OnClick="BTnrestaurar_Click" /></div>
         </div>
    </div>
    <div class="row">
    <div class="col-6">
        <h1 class="display-6">Fecha de inicio<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\d+"  ErrorMessage="*" ControlToValidate="TxtFiltrarFechaInicio"></asp:RegularExpressionValidator></h1><asp:TextBox ID="TxtFiltrarFechaInicio" CssClass="form-control me-3" runat="server" MaxLength="4"></asp:TextBox></div><div class="col-6">
        <h1 class="display-6">Fecha limite<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^\d+"  ErrorMessage="*" ControlToValidate="TxtFiltrarFechaFinal"></asp:RegularExpressionValidator></h1><asp:TextBox ID="TxtFiltrarFechaFinal" CssClass="form-control me-3" runat="server" MaxLength="4"></asp:TextBox></div><div class="mb-4">
     
    </div>

    </div>
    <div class="mb-4">
    <asp:Button ID="Btnfecha"  class="btn btn-primary" runat="server" Text="Filtrar por fecha" OnClick="Btnfecha_Click" /><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ingrese una fecha valida" ControlToCompare="TxtFiltrarFechaInicio" ControlToValidate="TxtFiltrarFechaFinal" Type="Integer" Operator="GreaterThan"></asp:CompareValidator></div><div class="row mb-4">

         <div class="col-lg-8">
              <asp:GridView ID="GridViewReportes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridViewReportes_RowCommand" PageSize="5" AllowPaging="true" OnPageIndexChanging="GridViewReportes_PageIndexChanging"><Columns>
                     <asp:TemplateField HeaderText="Facturas">
                         <ItemTemplate>
                             <div class="row">
                                 <div class="col-lg-4">
                                     <span class="mt-0 mb-1">NRO FATURA : </span><asp:Label ID="LblNumeroDeFactura" runat="server" class="mt-0 mb-1"><%# Eval("Nro_Factura_V") %></asp:Label><br /><span class="mt-0 mb-1">MONTO : </span><asp:Label ID="LblMonto" runat="server" class="mt-0 mb-1"><%# Eval("TotalVenta_V") %></asp:Label><br /><br /></div><div class="col-lg-8 text-end">
                                     <div class="media-body">
                                         <asp:Label runat="server" ID="LblFecha" class="mt-0 mb-1"><%# Eval("Fecha_Venta_V") %></asp:Label><br /><br /><br /><asp:Button ID="BtnVerDetalle" runat="server" class="btn btn-primary" Text="Ver detalles de compra" CommandName="EventoDetalles" CommandArgument='<%# Eval("Nro_Factura_V") %>' />
                                     </div>
                                 </div>
                             </div>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
              </asp:GridView>
         </div>
     </div>
    <asp:Label ID="LblTOtal" runat="server" CssClass="h1" Text=""></asp:Label></asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
