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
    public partial class ConfirmarCompra : System.Web.UI.Page
    {
        Cuenta cuen = new Cuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
                lblCompraRealizada.Visible = false;
                cuen = (Cuenta)Session["ObjetoCuenta"];
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            btnReconfirmar.Visible = true;
            btnCancelarConfirmacion.Visible = true;
            btnCancelar.Visible = false;
        }
        public int cantPorArt(int pos, List<int> cantidadPorArt)
        {
            if (Session["cantPorArt"] != null)
            {
                return cantidadPorArt[pos];
            }
            return -1;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Productos.aspx");
        }

        protected void btnReconfirmar_Click(object sender, EventArgs e)
        {
            if (Session["ObjetoVenta"] != null)
            {
                Ventas ven = new Ventas();
                ven = (Ventas)Session["ObjetoVenta"];
                negocioVentas negVentas = new negocioVentas();
                ven.NumeroTarjeta1 = txtNumeroTarjeta.Text;
                ven.Dnititular = txtTitularTarjeta.Text;
                ven.Cvv1 = txtCvv.Text;
                ven.CodCuenta = cuen.CodCuenta1;
                Session["ObjetoVenta"] = ven;
                if (negVentas.agregarVenta(ven))
                {


                }
            }



            if (Session["ArticulosSeleccionados"] != null)
            {

                List<Articulo> articulosSelec = new List<Articulo>();
                articulosSelec = (List<Articulo>)Session["ArticulosSeleccionados"];

                List<int> cantidadPorArticulo = (List<int>)Session["cantPorArt"];
                int cantArtSelecc = articulosSelec.Count;

                DetalleDeVenta detVen = new DetalleDeVenta();
                Articulo art = new Articulo();

                negocioVentas negVen = new negocioVentas();

                for (int i = 0; i < cantArtSelecc; i++)
                {
                    art = articulosSelec[i];
                    detVen.CodArt = art.CodigoDeArticulo1;
                    detVen.PrecioUnitario1 = art.PrecioUnitario1;
                    detVen.Cant1 = cantPorArt(i, cantidadPorArticulo);
                    detVen.NumeroFactura = negVen.getUltimoNroFactura();
                    negVen.agregarDetalleVenta(detVen);
                }

                lblCompraRealizada.Visible = true;
                btnReconfirmar.Visible = false;
                btnCancelarConfirmacion.Visible = false;
                btnCancelar.Visible = true;
               
            }
        }

        protected void btnCancelarConfirmacion_Click(object sender, EventArgs e)
        {
            btnCancelarConfirmacion.Visible = false;
            btnReconfirmar.Visible = false;
            btnCancelar.Visible = true;
        }
    }
}
