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
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        NegocioArticulo Negart = new NegocioArticulo();
        DataTable DtArt = new DataTable();
        Articulo art = new Articulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTablaArticulos();
        }
        void cargarTablaArticulos()
        {
            DtArt = Negart.getTablaArticulos();
            CardRepeater.DataSource = DtArt;
            CardRepeater.DataBind();
        }
    }
}