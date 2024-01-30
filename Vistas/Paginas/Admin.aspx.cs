using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using negocio;

namespace Vistas.Paginas
{
    public partial class Admin : System.Web.UI.Page
    {
        Cuenta cue = new Cuenta();
        negocioVentas negv = new negocioVentas();
        Ventas venta = new Ventas();
        decimal Monto=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                DataTable dt = negv.getTablaVentas();
                GridViewReportes.DataSource = dt;
                GridViewReportes.DataBind();
            }
            Session["nroFactura"] = null;
            MontoTotal();
            LblTOtal.Text = "Ganancia Total = " + Monto;
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

        protected void linkBtnFiltro_Click(object sender, EventArgs e)
        {
            string Filtro = TxtFiltro.Text;
            DataTable dt = negv.getTablaVentasFiltros(Filtro);
            GridViewReportes.DataSource = dt;
            GridViewReportes.DataBind();
            MontoTotal(Filtro);
            LblTOtal.Text = "Ganancia Total = " + Monto;
        }

        protected void BTnrestaurar_Click(object sender, EventArgs e)
        {
            DataTable dt = negv.getTablaVentas();
            GridViewReportes.DataSource = dt;
            GridViewReportes.DataBind();
            MontoTotal();
            LblTOtal.Text = "Ganancia Total = " + Monto;
        }
        protected void MontoTotal() 
        {
            Monto = 0;
            DataTable dt = negv.getTablaVentas();
            foreach (DataRow fila in dt.Rows)
            {
                Monto += ((decimal)fila["TotalVenta_V"]);
            }
        }
        protected void MontoTotal(String Filtro)
        {
            Monto = 0;
            DataTable dt = negv.getTablaVentasFiltros(Filtro);
            foreach (DataRow fila in dt.Rows)
            {
                Monto += ((decimal)fila["TotalVenta_V"]);
            }
        }

        protected void GridViewReportes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
                GridViewReportes.PageIndex = e.NewPageIndex;
                DataTable dt = negv.getTablaVentas();
                GridViewReportes.DataSource = dt;
                GridViewReportes.DataBind();
        }

        protected void Btnfecha_Click(object sender, EventArgs e)
        {
            int fechai = int.Parse(TxtFiltrarFechaInicio.Text);
            int fechaf = int.Parse(TxtFiltrarFechaFinal.Text);
            DataTable dt = negv.GetTablaVentasFecha(fechai,fechaf);
            GridViewReportes.DataSource = dt;
            GridViewReportes.DataBind();
            TxtFiltrarFechaInicio.Text = "";
            TxtFiltrarFechaFinal.Text = "";

        }
    }
}