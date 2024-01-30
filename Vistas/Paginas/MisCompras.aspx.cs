using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using negocio;
using System.Data;
namespace Vistas.Paginas
{
    public partial class MisCompras : System.Web.UI.Page
    {
        Cuenta cue = new Cuenta();
        negocioVentas negv = new negocioVentas();
        Ventas venta = new Ventas();
        decimal Monto=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                cargarCuenta();
                CargarVentas();
            }
            Session["nroFactura"] = null;
            CargarMonto();

        }

        void cargarCuenta()
        {
            if (Session["objetoCuenta"] != null)
            {
                cue = (Cuenta)Session["objetoCuenta"];
            }

        }

        public void CargarVentas()
        {
            GridViewReportes.DataSource = negv.getTablaVentasUsuario(cue);
            GridViewReportes.DataBind();

        }



        protected void GridViewReportes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EventoDetalles")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int nFactura))
                {
                    if (Session["nroFactura"] == null)
                    {
                        Session["nroFactura"] = nFactura;
                        Response.Redirect("~/Paginas/DetallesDeVentas.aspx");

                    }

                }

            }

        }
        protected void GridViewReportes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewReportes.PageIndex = e.NewPageIndex;
            cargarCuenta();
            CargarVentas();
            CargarMonto();
        }
        protected void CargarMonto() 
        {
            DataTable dt = negv.getTablaVentasUsuario(cue); ;
            foreach (DataRow fila in dt.Rows)
            {
                Monto += ((decimal)fila["TotalVenta_V"]);
            }
            LblTOtal.Text = "Ganancia Total = " + Monto;
        }
    }
}