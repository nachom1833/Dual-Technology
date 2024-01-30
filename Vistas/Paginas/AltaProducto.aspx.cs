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
    public partial class AltaProducto : System.Web.UI.Page
    {
        NegocioArticulo Negart = new NegocioArticulo();
        DataTable DtArt = new DataTable();
        Articulo art = new Articulo();



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                cargarTabla();

            }


        }


        public void cargarTabla()
        {
            if (Negart.ExisteArticuloBaja())
            {
                DtArt = Negart.getTablaArticulosBaja();
                LvProductosCONBAJA.DataSource = DtArt;
                LvProductosCONBAJA.DataBind();
            }
            else
            {
                Response.Redirect("PaginaPrincipal.aspx");
            }
        }
        protected void LvProductosCONBAJA_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            NegocioArticulo negArt = new NegocioArticulo();
            Articulo art = new Articulo();

            if (e.CommandName == "AltaProducto")
            {
                string codArticulo = (string)e.CommandArgument;
                art.CodigoDeArticulo1 = codArticulo;
                negArt.AltaArticulo(art);

            }


        }





        protected void DataPager1_PagePropertiesChanged(object sender, EventArgs e)
        {

            DataPager lvDataPager = (DataPager)LvProductosCONBAJA.FindControl("DataPager1");
            int startRowIndex = lvDataPager.StartRowIndex;
            int maxRows = lvDataPager.PageSize;
            lvDataPager.SetPageProperties(startRowIndex, maxRows, true);
            cargarTabla();



        }
    }
}
