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
    public partial class Perfil : System.Web.UI.Page
    {
       Cuenta cue = new Cuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                if (Session["objetoCuenta"] != null)
                {
                    cue = (Cuenta)Session["objetoCuenta"];
                }

                NombreDeUsuario.Text = cue.NombreUsuario1;
                TxtNombreDeUsuario.Text = cue.NombreUsuario1;
                TxtEmail.Text = cue.Email1;
                TxtContraseña.Text = cue.Contraseña1;


            }
        }

        protected void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {
            btnConfirmarEliminar.Visible = false;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if(TxtContraseña.Text == TxtConfirmarcontraseña.Text)
            {

            btnConfirmarCambios.Visible = true;
            lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
            }

        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["ObjetoCuenta"] = null;
            Response.Redirect("PaginaPrincipal.aspx");
        }

     /*   protected void ValidarPW_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Cuenta cue = new Cuenta();
            cue = (Cuenta)Session["objetoCuenta"];
            if (cue.Contraseña1 == TxtContraseña.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }*/

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            btnConfirmarEliminar.Visible = false;
            Cuenta cue = new Cuenta();
            cue = (Cuenta)Session["ObjetoCuenta"];
            NegocioCuenta neo = new NegocioCuenta();
            neo.eliminarCuenta(cue);
            Session["ObjetoCuenta"] = null;
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            btnConfirmarCambios.Visible = false;
            cue = (Cuenta)Session["objetoCuenta"];
            cue.NombreUsuario1 = TxtNombreDeUsuario.Text;
            if (TxtNuevaContraseña.Text == "")
            {
                cue.Contraseña1 = TxtContraseña.Text;
            }
            else
            {
                cue.Contraseña1 = TxtNuevaContraseña.Text;
            }
            cue.Email1 = TxtEmail.Text;
            //if (TxtContraseña.Text == cue.Contraseña1 && TxtConfirmarcontraseña.Text == TxtContraseña.Text)
            // {
            //    lblPWIncorrecta.Visible = false;
            if (Session["objetoCuenta"] != null)
            {
                NegocioCuenta neo = new NegocioCuenta();
                neo.modificarCuenta(cue);
                TxtContraseña.Text = cue.Contraseña1;
                TxtNombreDeUsuario.Text = cue.NombreUsuario1;
                TxtEmail.Text = cue.Email1;
                lblDatosCambiados.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnConfirmarCambios.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}