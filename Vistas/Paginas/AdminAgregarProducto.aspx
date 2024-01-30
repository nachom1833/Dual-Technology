<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="AdminAgregarProducto.aspx.cs" Inherits="Vistas.Paginas.AdminAgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <div class="container mt-3">
    <div class="row justify-content-center">
        <div class="col-md-6">
            
            
            <span>ID de Categoría</span>
            <asp:DropDownList ID="DdlIdCategoria" runat="server"></asp:DropDownList>
            <br />
            <span>Descripción  <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ID="RequiredFieldValidator2" ControlToValidate="TxtDescripcion" ValidationGroup="ValCampo">*</asp:RequiredFieldValidator></span>
            <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="form-control" MaxLength="50" />
            
            <br />
            <span>URL de la Imagen <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ID="RequiredFieldValidator3" ControlToValidate="TxtUrl" ValidationGroup="ValCampo">*</asp:RequiredFieldValidator></span>
            <asp:TextBox ID="TxtUrl" runat="server" CssClass="form-control" MaxLength="100" />
            
            <br />
            <span>Stock <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtStock" ValidationGroup="ValCampo">*</asp:RequiredFieldValidator></span>
            <asp:TextBox ID="TxtStock" runat="server" CssClass="form-control" />
            
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^\d+"  ErrorMessage="ingrese un numero de stock valido" ControlToValidate="TxtStock"></asp:RegularExpressionValidator>
            <br />
            <span>Precio <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ID="RequiredFieldValidator4" ControlToValidate="TxtPrecio" ValidationGroup="ValCampo">*</asp:RequiredFieldValidator></span>
            <asp:TextBox ID="TxtPrecio" runat="server" CssClass="form-control" />
            
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtPrecio" ValidationExpression="^\d+(\,\d{2})?" ErrorMessage="Ingrese un numero valido"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click"  Text="Agregar" CssClass="btn btn-primary" ValidationGroup="ValCampo" />

            &nbsp;<asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="¿Agregar?" Visible="False" CssClass="btn btn-primary" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Visible="False" CssClass="btn btn-primary" />
&nbsp;<asp:Label ID="lblProductoAgregado" runat="server" Text="Producto agregado con éxito" Visible="False"></asp:Label>

            <br />
            <br />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
