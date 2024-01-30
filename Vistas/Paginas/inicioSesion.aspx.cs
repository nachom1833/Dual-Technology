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
    public partial class inicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Iniciar_Click(object sender, EventArgs e)
        {
            Cuenta cue = new Cuenta();
            cue.NombreUsuario1 = tbUsuario.Text;
            cue.Contraseña1 = tbContraseña.Text;    
            NegocioCuenta NegCue = new NegocioCuenta();
            cue = NegCue.ValidarInicioSesion(cue);
            if (cue.CodCuenta1 >= 1)
            {
                Session["ObjetoCuenta"] = cue;
                Response.Redirect("PaginaPrincipal.aspx");
            }
            else if (cue.CodCuenta1 == 0)
            {
                lblMensaje.Text = "La contraseña es incorrecta";
            }
            else { lblMensaje.Text = "El usuario es incorrecto"; }
        }
    }
}