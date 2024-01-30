<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicioSesion.aspx.cs" Inherits="Vistas.Paginas.inicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" ></script>
    <link  href="diseñoLogRegistro.css" rel="stylesheet" style: "text/css" />
</head>
<body class="bg-light">
    <div class="wrapper ">
        <div class="formcontent">
            <form id="formulario_loggin" runat="server">
                <div class="form-control">
                      <div class="col-md-6 text-center-mb-5">
                          <asp:Label class="h2" ID="lblInicieSesion" runat="server" Text="Inicie Sesion" cass= "heading-section"></asp:Label>
                      </div> 
                   <div>
                      
                       <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario" MaxLength="20" ></asp:TextBox>
                   </div>
                   <div>
                       
                       <asp:TextBox ID="tbContraseña" CssClass="form-control" runat="server" placeholder="Contraseña" TextMode="Password" MaxLength="20"></asp:TextBox>
                   </div>

                    <div>
                       <asp:Label ID="lblRegistro" runat="server" Text="No tenes Cuenta?"></asp:Label>
                        <asp:HyperLink ID="linkRegistro" runat="server" NavigateUrl="Registro.aspx">Registrate</asp:HyperLink>
                   </div>
                      <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                      <br />
                      <asp:Button ID="Iniciar" runat="server" OnClick="Iniciar_Click" Text="Iniciar" />
                    <div class="row">
                    </div>
                     <br/> 
                    </div>
               
            </form>
        </div>
    </div>
    
</body>
</html>
