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
   public class daoVentas
    {

        AccesoDatos acc = new AccesoDatos();
        public DataTable getTablaVentasPorUsuario(Cuenta cuenta)

        {
            int codCuenta = cuenta.CodCuenta1;
            DataTable tablaVentas = acc.ObtenerTabla("Ventas", "select Nro_Factura_V, Cod_Envio_V, Fecha_Venta_V,TotalVenta_V,Direccion_entrega_V from Ventas WHERE Cod_Cuenta_V ='" + codCuenta + "'");
            return tablaVentas;
        }
        public DataTable getTablaVentas()

        {
            DataTable tablaVentas = acc.ObtenerTabla("Ventas", "select Nro_Factura_V, Cod_Envio_V, Fecha_Venta_V,TotalVenta_V,Direccion_entrega_V from Ventas");
            return tablaVentas;
        }
        public DataTable getTablaVentasFiltro(string filtro)

        {
            DataTable tablaVentas = acc.ObtenerTabla("Ventas", "select Nro_Factura_V, Cod_Envio_V, Fecha_Venta_V,TotalVenta_V,Direccion_entrega_V from Ventas where Nro_Factura_V = '"+ filtro +"' ");
            return tablaVentas;
        }

        public int getUltimoNroFactura()
        {
            DataTable tablaDetalleVentas = acc.ObtenerTabla("Ventas", "SELECT TOP 1 Nro_Factura_V FROM VENTAS ORDER BY Nro_Factura_V DESC");
            int numeroFactura = Convert.ToInt32(tablaDetalleVentas.Rows[0][0].ToString());
            return numeroFactura;
        }

        public int agregarVenta(Ventas ven)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVentasAgregar(ref comando, ven);
            return acc.EjecutarProcedimientoAlmacenado(comando, "spAgregarVenta");
        }


        private void ArmarParametrosVentasAgregar(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@codCuenta", SqlDbType.Int);
            SqlParametros.Value = ven.CodCuenta;
            SqlParametros = Comando.Parameters.Add("@codEnvio", SqlDbType.VarChar);
            SqlParametros.Value = ven.CodEnvio1;
            SqlParametros = Comando.Parameters.Add("@TotalVenta", SqlDbType.Decimal);
            SqlParametros.Value = ven.Total1;
            SqlParametros = Comando.Parameters.Add("@DniTitular", SqlDbType.Char);
            SqlParametros.Value = ven.Dnititular;
            SqlParametros = Comando.Parameters.Add("@NumeroTarjeta", SqlDbType.VarChar);
            SqlParametros.Value = ven.NumeroTarjeta1;
            SqlParametros = Comando.Parameters.Add("@cvv", SqlDbType.VarChar);
            SqlParametros.Value = ven.Cvv1;
            SqlParametros = Comando.Parameters.Add("@direccion", SqlDbType.VarChar);//ojo que puede ser null hay que ver como enviarlo
            SqlParametros.Value = ven.DireccionDeVenta1;
        }
        public DataTable FiltrarFecha(int fechaInicio,int fechaFinal) 
        {
            DataTable tablaVentas = acc.ObtenerTabla("Ventas", "select Nro_Factura_V, Cod_Envio_V, Fecha_Venta_V, TotalVenta_V, Direccion_entrega_V from Ventas WHERE YEAR(Fecha_Venta_V) BETWEEN "+ fechaInicio + " AND "+ fechaFinal);
           return tablaVentas;
        }
    }
}
