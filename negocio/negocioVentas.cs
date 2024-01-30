using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Dao;

namespace negocio
{
    public  class negocioVentas
    {


        public bool agregarVenta(Ventas vn)
        {
            int cantFilas = 0;
            daoVentas dao = new daoVentas();
           cantFilas= dao.agregarVenta(vn);//no se valida el numero de venta no exista a comparacion de otros negocios ya que siempre es identity
        
            if (cantFilas == 1)
                return true;
            else
                return false;
        }
        public DataTable getTablaArticulosPorDetalle(Ventas ven)
        {

            daoDetalleVentas dao = new daoDetalleVentas();
            return dao.getTablaArticulosPorDetalle(ven);

        }
        public DataTable getTablaVentasUsuario(Cuenta cuen)
        {
          
            daoVentas dao = new daoVentas();
            return dao.getTablaVentasPorUsuario(cuen);
           
        }
        public DataTable getTablaVentas()
        {

            daoVentas dao = new daoVentas();
            return dao.getTablaVentas();

        }
        public DataTable GetTablaVentasFecha(int fechai, int fechaf) 
        {
            daoVentas dao = new daoVentas();
            return dao.FiltrarFecha(fechai,fechaf);
        }
        public DataTable getTablaVentasFiltros(string filtro)
        {

            daoVentas dao = new daoVentas();
            return dao.getTablaVentasFiltro(filtro);

        }

        public int getUltimoNroFactura()
        {
            daoVentas daoVen = new daoVentas();
            return daoVen.getUltimoNroFactura();
        }


        public DataTable getTablaDetalleVentasUsuario(Ventas ven)//necesito traer todos los detalles de venta de una venta 
            //el objeto detalle de venta tiene el registro de 1 detalle de ventas solo
        {

            daoDetalleVentas dao = new daoDetalleVentas();
            return dao.getTablaDetalleVentasPorUsuario(ven);

        }

        public bool agregarDetalleVenta(DetalleDeVenta detVen)
        {
            int cantFilas = 0;
            daoDetalleVentas dao = new daoDetalleVentas();
            cantFilas = dao.agregarDetalleVenta(detVen);//no validamos que ya exista el detalle de venta(nroFac+CodArt) lo cual seria logico porque
            //el nro de factura lo traigo con consulta siempre y el articulo debemos de validar desde la web que no se presione 2 veces el mismo

            if (cantFilas == 1)//solo comprobamos siempre que el registro haya sido agregado a la base
                return true;
            else
                return false;
        }



    }
}
