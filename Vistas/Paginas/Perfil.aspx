<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vistas.Paginas.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <div style="height:100px"> </div>
    <div class="container">
    <div class="main-body">
          <div class="row gutters-sm">
            <div class="col-md-4 mb-3">
              <div class="card">
                <div class="card-body">
                  <div class="d-flex flex-column align-items-center text-center">
                    <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Admin" class="rounded-circle" width="150">
                    <div class="mt-3">
                      <h4><asp:Label ID="NombreDeUsuario" runat="server" Text="Kevin Paz"></asp:Label></h4>
                      <asp:Button ID="BtnCerrarSesion" runat="server"  class="btn btn-primary" Text="Cerrar Sesion" OnClick="BtnCerrarSesion_Click"/>
                      <asp:Button ID="BtnEliminarCuenta" runat="server"  class="btn btn-danger" Text="Eliminar cuenta" OnClick="BtnEliminarCuenta_Click"/>
                    &nbsp;<asp:Button ID="btnConfirmarEliminar" runat="server" OnClick="btnConfirmarEliminar_Click" Text="¿Seguro?" Visible="False" />
&nbsp;</div>
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-8">
              <div class="card mb-3">
                <div class="card-body">
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">User&nbsp; Name</h6>
                    </div>
                   <asp:TextBox CssClass="form-control me-2" ID="TxtNombreDeUsuario" runat="server" MaxLength="20"></asp:TextBox>
                  </div>
                  <hr>
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Email</h6>
                    </div>
                    <asp:TextBox CssClass="form-control me-2" ID="TxtEmail" runat="server" MaxLength="40" ></asp:TextBox>
                  </div>
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Contraseña
                          </h6>
                    </div>
                    <asp:TextBox CssClass="form-control me-2" ID="TxtContraseña" ReadOnly="true" runat="server" MaxLength="20"></asp:TextBox>
                  </div>
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Confirmar contraseña
                          <asp:Label ID="lblError" runat="server" Text="*" Visible="False"></asp:Label>
                        </h6>
                    </div>
                    <asp:TextBox CssClass="form-control me-2" ID="TxtConfirmarcontraseña" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                 
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Nueva contraseña</h6>
                    </div>
                  </div>
                      <asp:TextBox CssClass="form-control me-2" ID="TxtNuevaContraseña" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                  <div class="row">
                      <div style="height:5px"></div>
                    <div class="col-sm-12">
                        <asp:Button ID="btnEditar" CssClass="btn btn-info" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                    &nbsp;<asp:Button ID="btnConfirmarCambios" runat="server" OnClick="btnConfirmarCambios_Click" Text="¿Confirmar cambios?" Visible="False" CssClass="btn btn-info" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Visible="False" CssClass=" btn btn-danger"/>
&nbsp;<asp:Label ID="lblDatosCambiados" runat="server" Text="Cambio realizado con exito" Visible="False"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          </div>
        </div>
    </div>
    <div style="height:200px"> </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
