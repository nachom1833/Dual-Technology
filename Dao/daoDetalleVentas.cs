using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class daoDetalleVentas
    {
        AccesoDatos acc = new AccesoDatos();
        public DataTable getTablaDetalleVentasPorUsuario(Ventas ven)
        {
            int nroFactura = ven.NroFactura1;
            DataTable tablaDetalleVentas = acc.ObtenerTabla("Detalle_Ventas", "select * from Detalle_Ventas WHERE Nro_Factura_Dv ='" + nroFactura + "'");
            return tablaDetalleVentas;
        }

       

        public int agregarDetalleVenta(DetalleDeVenta detVen)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroDetalleVentasAgregar(ref comando,detVen );
            return acc.EjecutarProcedimientoAlmacenado(comando, "spAgregarDetalleVenta");
        }

        public DataTable getTablaArticulosPorDetalle(Ventas ven)
        {
            int nroFactura = ven.NroFactura1;
            DataTable tablaArticulosPorDetalle = acc.ObtenerTabla("ArticulosPorDetalleVenta", "SELECT Descripcion_Ar,URL_IMG_Ar,PrecioUnitario_Ar,Cantidad_DV FROM ARTICULOS INNER JOIN DETALLE_VENTAS ON Cod_Art_Ar = Cod_Art_Dv  WHERE Nro_Factura_Dv = '" + nroFactura + "'");
            return tablaArticulosPorDetalle;
        }



        private void ArmarParametroDetalleVentasAgregar(ref SqlCommand Comando, DetalleDeVenta det)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CodArticulo", SqlDbType.VarChar);
            SqlParametros.Value = det.CodArt;
            SqlParametros = Comando.Parameters.Add("@NroFactura", SqlDbType.Int);
            SqlParametros.Value = det.NumeroFactura;
            SqlParametros = Comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
            SqlParametros.Value = det.PrecioUnitario1;
            SqlParametros = Comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = det.Cant1;


        }


    }
}
