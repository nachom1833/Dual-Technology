using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using Entidades;
using System.Data;
namespace Vistas.Paginas
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        NegocioArticulo Negart = new NegocioArticulo();
        DataTable DtArt = new DataTable();
        Articulo art = new Articulo();
        Cuenta cue = new Cuenta();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if(Session["objetoCuenta"] !=null)
                {
                    cue = (Cuenta)Session["objetoCuenta"];

                 }
                //cargarTabla();

            }
                 CargarCuenta(); 

            habilitarMenuSegunUsurio();




        }

        public void habilitarMenuSegunUsurio()
        {
            if (Session["objetoCuenta"] != null && !cue.Admin1)
            {

                hpMisCompras.Visible = true;
                HpMiCuenta.Visible = true;
                HpIniciarSesion.Visible = false;
                lkCerrarSesion.Visible = true;
                HpRegistros.Visible = false;
                HpCarrito.Visible = true;
                hpAdministrarUsuarios.Visible = false;
                hpAgregarProducto.Visible = false;
                hpAdministrarProductos.Visible = false;
                hpAltaProducto.Visible = false;
            }

            if (Session["objetoCuenta"] != null && cue.Admin1)
            {
                hpAdministrarUsuarios.Visible = true;
                lkCerrarSesion.Visible = true;
                HpIniciarSesion.Visible = false;
                hpAgregarProducto.Visible = true;
                hpAdministrarProductos.Visible = true;
                HpCarrito.Visible = false;
                hpAltaProducto.Visible = true;
            }

            if (Session["objetoCuenta"] == null )
            {

                HpIniciarSesion.Visible = true;
                HpRegistros.Visible = false;
                hpAdministrarUsuarios.Visible = false;
                lkCerrarSesion.Visible = false;
                hpMisCompras.Visible = false;
                HpMiCuenta.Visible = false;
                HpCarrito.Visible = false;
                hpAgregarProducto.Visible = false;
                hpAdministrarProductos.Visible = false;
                hpAltaProducto.Visible = false;

            }


        }
        protected void lkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["objetoCuenta"] = null;
            lblUsuario.Text = "Inicie sesion";
            Response.Redirect("~/Paginas/PaginaPrincipal.aspx");
            habilitarMenuSegunUsurio();
         

        }
        void CargarCuenta()
        {
            if (Session["objetoCuenta"] != null)
            {
                cue = (Cuenta)Session["objetoCuenta"];
               lblUsuario.Text = cue.NombreUsuario1.ToString();
            }
            else
            {
                lblUsuario.Text = "Inicie Sesion";
            }
        }

      

     
        

        protected void linkBtnBusqueda_Click(object sender, EventArgs e)
        {
            string parametro1 = txtBusqueda.Text;
            string urlDestino = $"~/Paginas/Productos.aspx?parametro1={parametro1}";
            Response.Redirect(urlDestino);
           
        }
        protected void LinkPAGINAPRODUCTOS_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Productos.aspx");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
           

 }
    }
}