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
    public partial class AdminAgregarProducto : System.Web.UI.Page
    {
        NegocioArticulo Negart = new NegocioArticulo();
        NegocioCategoria negc = new NegocioCategoria();
        Articulo art = new Articulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDdl();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            btnCancelar.Visible = true;
   
        }
        protected void CargarDdl()
        {
            DataTable TipoProducto = negc.obtenerDDLCategoria();
            DdlIdCategoria.DataSource = TipoProducto;
            DdlIdCategoria.DataTextField = "NombreCategoria_Ct";
            DdlIdCategoria.DataValueField = "Id_Categoria_Ct";
            DdlIdCategoria.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //art.CodigoDeArticulo1 = txtCodigo.Text;
            art.Cate1 = int.Parse(DdlIdCategoria.SelectedValue);
            art.Descripcion1 = TxtDescripcion.Text;
            art.Stock1 = int.Parse(TxtStock.Text);
            art.UrlImagen1 = TxtUrl.Text;
            art.PrecioUnitario1 = decimal.Parse(TxtPrecio.Text);
            Negart.agregarArticulo(art);
            //txtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtStock.Text = "";
            TxtUrl.Text = "";
            TxtPrecio.Text = "";
            btnCancelar.Visible = false;
            btnConfirmar.Visible = false;
            lblProductoAgregado.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            btnConfirmar.Visible = false;
        }
    }
}