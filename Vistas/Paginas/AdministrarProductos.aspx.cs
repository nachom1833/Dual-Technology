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
    public partial class AdministrarProductos : System.Web.UI.Page
    {
        NegocioArticulo Negart = new NegocioArticulo();
        DataTable DtArt = new DataTable();
        Articulo art = new Articulo();
        Cuenta cue = new Cuenta();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["objetoCuenta"] != null)
                {
                    cue = (Cuenta)Session["objetoCuenta"];

                }
                if (Request.QueryString["parametro1"] != null)
                {

                    cargarTablaConFiltro();
                }
                else
                {

                    cargarTabla();
                }
            }
        }

        public void cargarTablaConFiltro()
        {

            string descripcionAr = Request.QueryString["parametro1"];
            art.Descripcion1 = descripcionAr;
            DtArt = Negart.getTablaArticulosPorBusqueda(art);
            LvProductos.DataSource = DtArt;
            LvProductos.DataBind();
        }

        public void cargarTabla()
        {

            DtArt = Negart.getTablaArticulos();
            LvProductos.DataSource = DtArt;
            LvProductos.DataBind();
        }

        protected void LvProductos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if ("Actualizar" == e.CommandName)
            {
                ListViewItem item = (ListViewItem)e.Item;
                Button btn = (Button)item.FindControl("ButtonActualizar");
                Label lb = (Label)item.FindControl("lblCodArt");
                art.CodigoDeArticulo1 = lb.Text;
                TextBox tex = (TextBox)item.FindControl("Descripcion_Ar");
                art.Descripcion1 = tex.Text;
                Image im = (Image)item.FindControl("imgProducto");
                art.UrlImagen1 = im.ImageUrl;
                tex = (TextBox)item.FindControl("PrecioUnitario_Ar");
                art.PrecioUnitario1 = decimal.Parse(tex.Text);
                tex = (TextBox)item.FindControl("Stock");
                art.Stock1 = int.Parse(tex.Text);
                lb = (Label)item.FindControl("Categoria");

                if (Negart.actualizarArticulo(art))
                {
                    if (Negart.actualizarArticulo(art))
                    {
                        if (Request.QueryString["parametro1"] != null)
                        {
                            cargarTablaConFiltro();
                        }
                        else
                        {
                            cargarTabla();
                        }
                    }
                }
            }
        
            if ("Eliminar" == e.CommandName)
            {
                Label codigoArticuloLabel = (Label)e.Item.FindControl("lblCodArt");
                Articulo Art = new Articulo();
                Art.CodigoDeArticulo1 = codigoArticuloLabel.Text;
                Negart.eliminarArticulo(Art);
            }
           
        }


        protected void LvProductos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }




        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }
        protected void DataPager1_PagePropertiesChanged(object sender, EventArgs e)
        {

            DataPager lvDataPager = (DataPager)LvProductos.FindControl("DataPager1");
            int startRowIndex = lvDataPager.StartRowIndex;
            int maxRows = lvDataPager.PageSize;
            lvDataPager.SetPageProperties(startRowIndex, maxRows, true);
            if (Request.QueryString["parametro1"] != null)
            {
                cargarTablaConFiltro();
            }
            else
            {
                cargarTabla();
            }


        }
    }
}