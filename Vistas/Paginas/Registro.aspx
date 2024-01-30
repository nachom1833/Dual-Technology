<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vistas.Paginas.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" ></script>

</head>
<body class="bg-light">
    <div class="wrapper ">
        <div class="formcontent">
            <form id="formulario_loggin" runat="server">
                <div class="form-control">
                    
                      <div class="col-md-6 text-center-mb-5">
                          <asp:Label class="h2" ID="lblCreaTuCuenta" runat="server" Text="Registrate" cass= "heading-section"></asp:Label>
                      </div> 
                   
                     
                   <div>
                       <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario" MaxLength="20" ></asp:TextBox>
                   </div>
                    <div>
                       <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email" MaxLength="40" ></asp:TextBox>
                   </div>
                   <div>
                       <asp:TextBox ID="tbContraseña" CssClass="form-control" runat="server" placeholder="Contraseña" TextMode="Password" MaxLength="20"></asp:TextBox>
                   </div>
                    <div>
                       <asp:TextBox ID="tbContraseña2" CssClass="form-control" runat="server" placeholder="Repita Contraseña" TextMode="Password"  MaxLength="20"></asp:TextBox>
                   </div>

                 
                      <asp:Label ID="lblMensaje" runat="server"></asp:Label>

                 
                      <asp:CompareValidator ID="cmpContraseñas" runat="server" ControlToCompare="tbContraseña" ControlToValidate="tbContraseña2" ErrorMessage="*Las contraseñas no son iguales"></asp:CompareValidator>

                 
                     <br/> 
                    <div class="row">
                        <asp:Button ID="btnEnviar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-dark" OnClick="btnEnviar_Click"  />
                    </div>
                    </div>
               
            </form>
        </div>
        </div>
    
</body>
</html>
