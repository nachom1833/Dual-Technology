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
    public partial class Productos : System.Web.UI.Page
    {
        NegocioArticulo Negart = new NegocioArticulo();
        NegocioCategoria NegCat = new NegocioCategoria();
        DataTable DtArt = new DataTable();
        DataTable DtArtAux = new DataTable();
        Articulo art = new Articulo();
        Cuenta cue = new Cuenta();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarDDLfiltroCategorias();
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
                Session["ArticulosSeleccionados"] = null;
            }

            if (Request.QueryString["venta"] != null)
            {
                LvProductos.DataSource = null;
                LvProductos.DataBind();
                Session["ArticulosSeleccionados"] = null;
                Response.Redirect("~/Paginas/PaginaPrincipal.aspx");

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

        public void cargarDDLfiltroCategorias()
        {

            ddlFILTROcategorias.DataSource = NegCat.obtenerDDLCategoria();
            ddlFILTROcategorias.DataTextField = "NombreCategoria_Ct";
            ddlFILTROcategorias.DataValueField = "Id_Categoria_Ct";
            ddlFILTROcategorias.DataBind();
        }



        public void cargarTabla()
        {

            DtArt = Negart.getTablaArticulos();
            LvProductos.DataSource = DtArt;
            LvProductos.DataBind();
        }

        protected void LvProductos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "AgregarCarrito")
            {
                if (Session["ObjetoCuenta"] == null)
                {
                    Response.Redirect("~/Paginas/inicioSesion.aspx");
                }
                string codArt = e.CommandArgument.ToString();
                art.CodigoDeArticulo1 = codArt;
                
                Articulo artSeleccionado = Negart.getArticuloPorCodigo(art);

                List<Articulo> articulosSeleccionados = Session["ArticulosSeleccionados"] as List<Articulo>;

                if (articulosSeleccionados == null)
                {
                    // crea una nueva lista si no existe en la sesion
                    articulosSeleccionados = new List<Articulo>();
                }

                // checkea si el articulo seleccionado ya existe en la lista
                Articulo existeArticulo =
                    articulosSeleccionados.FirstOrDefault(a => a.CodigoDeArticulo1 == artSeleccionado.CodigoDeArticulo1);

                if (existeArticulo == null)
                {
                    articulosSeleccionados.Add(artSeleccionado);
                }
                // actualiza la variable session
                Session["ArticulosSeleccionados"] = articulosSeleccionados;

            }




        }


        protected void LvProductos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (Session["objetoCuenta"] != null)
            {
                cue = (Cuenta)Session["objetoCuenta"];


                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    if (cue.Admin1 == true)
                    {
                        Button btnCarrito = (Button)e.Item.FindControl("btnCarrito");

                        if (btnCarrito != null)
                            btnCarrito.Visible = false;
                    }
                }
            }
            else
            {
                Button btnCarrito = (Button)e.Item.FindControl("btnCarrito");

                if (btnCarrito != null)
                    btnCarrito.Visible = false;
            }
        }




        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }
        



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Session["parametro1"] = null;
            DataTable tablafiltrada = new DataTable();
            Articulo Art = new Articulo();
            //filtro por categoria
            string idCate = ddlFILTROcategorias.SelectedValue;
            int idCategoria = Convert.ToInt32(idCate);
            art.setCategoria(idCategoria);
            tablafiltrada = Negart.getTablaArticulosXCATEGORIAFILTRO(art);
            DtArtAux = Negart.getTablaArticulosXCATEGORIAFILTRO(art);
            LvProductos.DataSource = tablafiltrada;
            LvProductos.DataBind();

            Session["hayFiltro"] = DtArtAux;
        }

        protected void btnFiltrarPrecio_Click(object sender, EventArgs e)
        {
            DataTable tablafiltrada = new DataTable();
            Articulo Art = new Articulo();
            Session["parametro1"] = null;
            //filtro por precios


            if (!string.IsNullOrWhiteSpace(txtPrecioMin.Text) && string.IsNullOrWhiteSpace(txtPrecioMax.Text))
            {
                decimal precioMin = Convert.ToDecimal(txtPrecioMin.Text);
                Art.PrecioUnitario1 = precioMin;
                tablafiltrada = Negart.getTablaArticulosXPrecioMenor(Art);
                DtArtAux = Negart.getTablaArticulosXPrecioMenor(Art);
                LvProductos.DataSource = tablafiltrada;
                LvProductos.DataBind();



            }

            if (!string.IsNullOrWhiteSpace(txtPrecioMax.Text) && string.IsNullOrWhiteSpace(txtPrecioMin.Text))
            {
                decimal precioMax = Convert.ToDecimal(txtPrecioMax.Text);
                Art.PrecioUnitario1 = precioMax;

                tablafiltrada = Negart.getTablaArticulosXPrecioMAYOR(Art);
                DtArtAux = Negart.getTablaArticulosXPrecioMAYOR(Art);
                LvProductos.DataSource = tablafiltrada;
                LvProductos.DataBind();





            }

            if (!string.IsNullOrWhiteSpace(txtPrecioMax.Text) && !string.IsNullOrWhiteSpace(txtPrecioMin.Text))
            {
                Articulo artMen = new Articulo();
                Articulo artMay = new Articulo();
                artMen.PrecioUnitario1 = Convert.ToDecimal(txtPrecioMin.Text);
                artMay.PrecioUnitario1 = Convert.ToDecimal(txtPrecioMax.Text);

                tablafiltrada = Negart.getTablaArticulosXPrecioMayorYmenor(artMen, artMay);
                DtArtAux = Negart.getTablaArticulosXPrecioMayorYmenor(artMen, artMay);
                LvProductos.DataSource = tablafiltrada;
                LvProductos.DataBind();



            }
            if (!string.IsNullOrWhiteSpace(txtPrecioMin.Text) || !string.IsNullOrWhiteSpace(txtPrecioMax.Text))
            {
            Session["hayFiltro"] = DtArtAux;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioMin.Text) || string.IsNullOrWhiteSpace(txtPrecioMax.Text))
            {
                cargarTabla();
            }
        }

        protected void LvProductos_PagePropertiesChanged(object sender, EventArgs e)
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
                if (Session["hayFiltro"] != null && Session["hayFiltro"] is DataTable)
                {
                    LvProductos.DataSource = (DataTable)Session["hayFiltro"];
                    LvProductos.DataBind();
                }
                else
                {
                    cargarTabla();
                }

            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Session["hayFiltro"] = null;
            cargarTabla();
        }
    }
}