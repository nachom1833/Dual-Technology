using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
using negocio;
namespace Vistas.Paginas
{
    public partial class Carrito : System.Web.UI.Page
    {
        int total;
        Cuenta cue = new Cuenta();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                total = 0;
                if (Session["ArticulosSeleccionados"] != null)
                {
                    btnVaciar.Visible = true; ;
                    lblTextTotal.Visible = true ;
                    lblTotalVenta.Visible = true;
                    lblMensaje.Visible = true;
                    DomicilioRB.Visible = true;
                    LocalRB.Visible = true;
                    CorreoRB.Visible = true;
                    lblDireccion.Visible = true;
                    txtDireccion.Visible = true;
                    btnComprar.Visible = true;
                    lblSinArticulos.Visible = false;
                    List<Articulo> articulosSeleccionados = new List<Articulo>();
                    articulosSeleccionados = (List<Articulo>)Session["ArticulosSeleccionados"];
                    DataTable tablaArticulosSeleccionados = crearTabla();

                    foreach (Articulo art in articulosSeleccionados)
                    {
                        agregarFila(tablaArticulosSeleccionados, art);

                    }

                    Session["TablaGRV"] = tablaArticulosSeleccionados;
                    grvCarrito.DataSource = tablaArticulosSeleccionados;
                    grvCarrito.DataBind();




                }

                else
                {
                    btnVaciar.Visible = false;
                    lblTextTotal.Visible = false;
                    lblTotalVenta.Visible = false;
                    lblMensaje.Visible = false;
                    DomicilioRB.Visible = false;
                    LocalRB.Visible = false;
                    CorreoRB.Visible = false;
                    lblDireccion.Visible = false;
                    txtDireccion.Visible = false;
                    btnComprar.Visible = false;
                    lblSinArticulos.Visible = true;
                }
            }
        }

        public int calcularTotal(GridView grv)
        {
            int total = 0;
            for (int i = 0; i < grv.Rows.Count; i++)
            {
                Label lblSubtotal = (Label)grv.Rows[i].Cells[4].FindControl("lblSubtotal");
                total = total + int.Parse(lblSubtotal.Text);


            }
            return total;
        }

        public List<int> cantidadesPorArticulo(GridView grv)
        {
            List<int> cantidadesPorArt = new List<int>();
            int cantidad;
            for (int i = 0; i < grv.Rows.Count; i++)
            {
                TextBox txtCantidad = (TextBox)grv.Rows[i].Cells[3].FindControl("txtCantidad");
                cantidad = int.Parse(txtCantidad.Text);
                cantidadesPorArt.Add(cantidad);

            }

            return cantidadesPorArt;

        }


        public DataTable crearTabla()
        {
            DataTable tablaArtSeleccionados = new DataTable();

            DataColumn columnaDescArt = new DataColumn("Descripcion", System.Type.GetType("System.String"));
            tablaArtSeleccionados.Columns.Add(columnaDescArt);
            DataColumn columnaURLIMG = new DataColumn("Producto", System.Type.GetType("System.String"));
            tablaArtSeleccionados.Columns.Add(columnaURLIMG);
            DataColumn columnaPrecio = new DataColumn("Precio", System.Type.GetType("System.Int32"));
            tablaArtSeleccionados.Columns.Add(columnaPrecio);


            return tablaArtSeleccionados;

        }

        public void agregarFila(DataTable tablaArt, Articulo art)
        {

            DataRow dr = tablaArt.NewRow();
            dr["descripcion"] = art.Descripcion1;
            dr["Producto"] = art.UrlImagen1;
            dr["precio"] = art.PrecioUnitario1;


            tablaArt.Rows.Add(dr);

        }

        protected void grvCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TextBox txtCant = (TextBox)e.Row.FindControl("txtCantidad");

            Label lblPrecio = (Label)e.Row.FindControl("lblPrecio");
            Label lblSubtotal = (Label)e.Row.FindControl("lblSubtotal");


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txtCant.Text = "1";
                lblSubtotal.Text = lblPrecio.Text;
                total = total + int.Parse(lblSubtotal.Text);


            }

            lblTotalVenta.Text = Convert.ToString(total);


        }

        protected void grvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvCarrito.Rows[rowIndex];

            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");


            if (e.CommandName == "disminuirCantidad")
            {
                if (Convert.ToInt32(txtCantidad.Text) > 1)
                {
                    txtCantidad.Text = Convert.ToString(int.Parse(txtCantidad.Text) - 1);

                }
            }


            if (e.CommandName == "aumentarCantidad")
            {

                txtCantidad.Text = Convert.ToString(int.Parse(txtCantidad.Text) + 1);

            }

            Label lblPrecio = (Label)row.FindControl("lblPrecio");
            Label lblSubtotal = (Label)row.FindControl("lblSubtotal");
            int subtotal = Convert.ToInt32(lblPrecio.Text) * Convert.ToInt32(txtCantidad.Text);
            lblSubtotal.Text = Convert.ToString(subtotal);

            lblTotalVenta.Text = Convert.ToString(calcularTotal(grvCarrito));



        }

        protected void grvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int indiceFila = e.RowIndex;
            DataTable tablaVinculada = (DataTable)Session["TablaGRV"];
            tablaVinculada.Rows.RemoveAt(indiceFila);
            grvCarrito.DataSource = tablaVinculada;
            grvCarrito.DataBind();

        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            Session["ArticulosSeleccionados"] = null;
            Session["TablaGRV"] = null;
            grvCarrito.DataSource = null;
            grvCarrito.DataBind();
            lblTotalVenta.Text = "0";
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {

            if (DomicilioRB.Checked && string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                lblError.Text = "<b>Por favor, ingrese su direccion</b>";
            }

            else if (CorreoRB.Checked && ddlCorreo.SelectedIndex == 0)
            {
                lblError.Text = "<b>Por favor, seleccione un puesto de correo</b>";
            }

            else
            {

                Session["ObjetoVenta"] = cargarVentaParaAgregar();
                Session["cantPorArt"] = cantidadesPorArticulo(grvCarrito);
                Response.Redirect("~/Paginas/ConfirmarCompra.aspx");
            }


        }

        public Ventas cargarVentaParaAgregar()
        {
            Ventas vn = new Ventas();
            vn.CodEnvio1 = CodigoEnvio();
            vn.Total1 = Convert.ToDecimal(lblTotalVenta.Text);

            if (DomicilioRB.Checked)
            {
                vn.DireccionDeVenta1 = txtDireccion.Text;
                return vn;
            }

            if (CorreoRB.Checked)
            {
                vn.DireccionDeVenta1 = ddlCorreo.SelectedValue;
                return vn;
            }

            if (LocalRB.Checked)
            {
                vn.DireccionDeVenta1 = txtDireccion.Text;
                return vn;
            }
            vn.DireccionDeVenta1 = null;
            return vn;

        }



        public string CodigoEnvio()
        {
            string codigoEnvio = null;
            if (DomicilioRB.Checked)
            {
                codigoEnvio = "En_D";

            }
            if (CorreoRB.Checked)
            {
                codigoEnvio = "En_C";

            }
            if (LocalRB.Checked)
            {
                codigoEnvio = "En_L";

            }
            return codigoEnvio;

        }

        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DomicilioRB.Checked)
            {
                txtDireccion.Attributes.Remove("readonly");
                lblDireccion.Visible = true;
                txtDireccion.Visible = true;
                lblError.Text = "";
                txtDireccion.Text = "";
                lblDireccion.Text = "Ingrese su Direccion: ";
            }
            else
            {
                lblError.Text = "";
                txtDireccion.Visible = false;
                lblDireccion.Visible = false;

            }

            if (CorreoRB.Checked)
            {
                lblError.Text = "";
                lblCorreo.Visible = true;
                ddlCorreo.Visible = true;
            }
            else
            {
                lblError.Text = "";
                lblCorreo.Visible = false;
                ddlCorreo.Visible = false;
            }

            if (LocalRB.Checked)
            {
                lblError.Text = "";
                txtDireccion.Attributes.Add("readonly", "readonly");
                lblDireccion.Visible = true;
                txtDireccion.Visible = true;
                lblDireccion.Text = "Nuestro local: ";
                txtDireccion.Text = "Av. Dr. Honorio Pueyrredón 1841, Buenos Aires";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PaginasFinal/PaginaPrincipal.aspx");
        }
        protected void ImgBtnUser_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["objetoCuenta"] != null)
            {
                Response.Redirect("Perfil.aspx");
            }
            else
            {
                Response.Redirect("inicioSesion.aspx");
            }

        }

        protected void ImgCarrito_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("~/PaginasSinRetocar/CarritoCompras.aspx");

        }

        protected void ImgBtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void ImgBtnBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            //NegocioArticulo neg = new NegocioArticulo();
            //Articulo art = new Articulo();
            // art.Descripcion1 = txtBusqueda.Text;
            // LvProductos.DataSource = neg.getTablaArticulosPorBusqueda(art);
            // LvProductos.DataBind();
        }
    }
}