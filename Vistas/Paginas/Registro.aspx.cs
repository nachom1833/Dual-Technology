using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using negocio;
namespace Vistas.Paginas
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Cuenta Cue = new Cuenta();
            Cue.NombreUsuario1 = tbUsuario.Text;
            Cue.Email1 = tbEmail.Text;
            Cue.Contraseña1 = tbContraseña.Text;
            NegocioCuenta RegCuen = new NegocioCuenta();
            int validar = RegCuen.RegistrarCuentaNueva(Cue);
            if (validar > 0)
            {
                
                Response.Redirect("inicioSesion.aspx");
            }
            else if (validar == 0)
            {
                lblMensaje.Text = "Existe una cuenta con ese nombre";

            }
            else { lblMensaje.Text = "Existe una cuenta con ese Email"; }

        }
    }
}