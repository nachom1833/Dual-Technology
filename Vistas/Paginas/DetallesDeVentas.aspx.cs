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
    public partial class DetallesDeVentas : System.Web.UI.Page
    {
        decimal MontoTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioVentas negVen = new negocioVentas();
            Ventas ven = new Ventas();
            if (!IsPostBack)
            {
                if (Session["nroFactura"] != null)
                {
                    int nroFactura = (int)Session["nroFactura"];
                    ven.NroFactura1 = nroFactura;
                }



                GridView1.DataSource = negVen.getTablaArticulosPorDetalle(ven);
                GridView1.DataBind();

                DataTable dt = negVen.getTablaArticulosPorDetalle(ven); ;
                foreach (DataRow fila in dt.Rows)
                {
                    decimal Total = ((decimal)fila["PrecioUnitario_Ar"]);
                    int cant = ((int)fila["Cantidad_DV"]);
                    MontoTotal += Total * cant;
                }
                Label1.Text = ("Monto Total : " + MontoTotal);


            }

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
        }
    }
}