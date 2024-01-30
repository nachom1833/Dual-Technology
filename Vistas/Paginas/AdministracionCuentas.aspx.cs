using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using negocio;
using Entidades;

namespace Vistas.Paginas
{
    public partial class AdministracionCuentas : System.Web.UI.Page
    {
        NegocioCuenta nc = new NegocioCuenta();
        Cuenta cue = new Cuenta();
        DataTable DtCuenta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTablaUsuarios();
            }
        }
        void cargarTablaUsuarios()
        {
            DataTable dtUser = new DataTable();
            dtUser = nc.getTablaCuenta();
            LvCuentas.DataSource = dtUser;
            LvCuentas.DataBind();
        }

        protected void LvCuentas_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            CheckBox che = (CheckBox)e.Item.FindControl("Admin_CuCheckBox");
            CheckBox che2 = (CheckBox)e.Item.FindControl("EstadoCheckBox");
            if (che.Checked == true)
            {
                e.Item.FindControl("BtnDarAdmin").Visible = false;
            }
            else
            {
                e.Item.FindControl("BtnQuitarAdmin").Visible = false;
            }
            if (che2.Checked == true)
            {
                e.Item.FindControl("BtnDarAlta").Visible = false;
            }
            else
            {
                e.Item.FindControl("BtnEliminarCuenta").Visible = false;
            }
        }
        protected void LvCuentas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Dar")
            {
                CargarCuenta(ref e, true);
                nc.modificarAdmin(cue);
            }
            if (e.CommandName == "Quitar")
            {
                CargarCuenta(ref e, false);
                nc.modificarAdmin(cue);
            }
            if (e.CommandName == "Eliminar")
            {
                CargarEstado(ref e, true);
                nc.eliminarCuenta(cue);
            }
            if (e.CommandName == "DarDeAlta")
            {
                CargarEstado(ref e, false);
                nc.DarAltaCuenta(cue);
            }
            Response.Redirect("AdministracionCuentas.aspx");
        }
        protected void DataPager1_PagePropertiesChanged(object sender, EventArgs e)
        {
            DataPager lvDataPager = (DataPager)LvCuentas.FindControl("DataPager1");
            int startRowIndex = lvDataPager.StartRowIndex;
            int maxRows = lvDataPager.PageSize;
            lvDataPager.SetPageProperties(startRowIndex, maxRows, true);
            cargarTablaUsuarios();
        }
        protected void CargarCuenta(ref ListViewCommandEventArgs e, bool DarQuitar)
        {
            Label lb = (Label)e.Item.FindControl("Cod_Cuenta_CuLabel1");
            cue.CodCuenta1 = int.Parse(lb.Text);
            cue.Admin1 = DarQuitar;

        }
        protected void CargarEstado(ref ListViewCommandEventArgs e, bool NuevoEstado)
        {
            Label lb = (Label)e.Item.FindControl("Cod_Cuenta_CuLabel1");
            cue.CodCuenta1 = int.Parse(lb.Text);
            cue.Estado1 = NuevoEstado;

        }
    }
}