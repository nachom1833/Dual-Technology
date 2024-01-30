<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmarCompra.aspx.cs" Inherits="Vistas.Paginas.ConfirmarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
<div style="height:100px">

</div>
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="mb-">
       <span><label class="form-label">NúmeNúmero de tarjeta </label><asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNumeroTarjeta">*</asp:RequiredFieldValidator></span>
        <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNumeroTarjeta" ValidationExpression="^\d+" ErrorMessage="Ingrese un numero de tarjeta valido"></asp:RegularExpressionValidator>
    </div>
    <div class="mb-3">
       <span><label class="form-label">Nombre y apellido titular Tarjetabel><asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTitularTarjeta">*</asp:RequiredFieldValidator></span>
        <asp:TextBox ID="txtTitularTarjeta" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTitularTarjeta" ValidationExpression="[a-zA-Z\s]+$" ErrorMessage="Ingrese un nombre valido"></asp:RegularExpressionValidator>
    </div>
    <div class="mb-3">
        <span><label class="form-label">Código de seguridad</label><asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCvv">*</asp:RequiredFieldValidator></span>
        <asp:TextBox ID="txtCvv" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCvv" ValidationExpression="^\d+" ErrorMessage="Ingrese un Cvv valido"></asp:RegularExpressionValidator>
    </div>
    <div class="mb-3">
        <span><label class="form-label">DNI del titular de la tarjeta</label><asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDni">*</asp:RequiredFieldValidator></span>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDni" ValidationExpression="^\d+" ErrorMessage="Ingrese un DNI valido"></asp:RegularExpressionValidator>
    </div>
</div>
</div>
</div>
<div style="height:100px">

</div>
<div class="container mt-3">
    <div class="row">
        <div class="col-md-6 text-center" style="height: 38px">
            <asp:Button ID="btnConfirmarCompra" runat="server" OnClick="btnConfirmarCompra_Click" Text="Confirmar Compra" CssClass=" btn btn-danger" />
            &nbsp;<asp:Button ID="btnReconfirmar" runat="server" OnClick="btnReconfirmar_Click" Text="¿Confirmar?" Visible="False" CssClass=" btn btn-danger"/>
&nbsp;<asp:Button ID="btnCancelarConfirmacion" runat="server" OnClick="btnCancelarConfirmacion_Click" Text="Cancelar" Visible="False" CssClass="btn btn-primary" />
&nbsp;<asp:Label ID="lblCompraRealizada" runat="server" Text="Compra realizada con éxito" Visible="False"></asp:Label>
        </div>
        <div class="col-md-6 text-center">
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
        </div>
    </div>
</div>
<div style="height:100px">

</div>
    </label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
