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
    
    public class daoArticulos
    {
        AccesoDatos acc = new AccesoDatos();
        public DataTable getTablaArticulos()
        {       
            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "select * from Articulos where Estado_Ar = 1");
            return tablaArticulos;
         }

        public DataTable getTablaArticuloPorCod(Articulo art)
        {
            string codArt = art.CodigoDeArticulo1;
            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "select * from Articulos where Cod_Art_Ar = '" + codArt + "'");
            return tablaArticulos;
        }


        public DataTable getTablaArticuloPorDes(Articulo art)
        {
            string descripcion = art.Descripcion1;
            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE Descripcion_Ar LIKE '%" + descripcion + "%'");
            return tablaArticulos;
        }
        public DataTable getTablaArticuloXCategoriayDesc(Articulo art)
        {
            string descripcion = art.Descripcion1;
            int categoria = art.Cate1;
            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE Descripcion_Ar LIKE '%" + descripcion + "%'AND Id_Categoria_Ar = " + categoria);
            return tablaArticulos;
        }

        public DataTable getTablaArticuloXPrecioMayor(Articulo art)
        {

            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE PrecioUnitario_Ar > " + art.PrecioUnitario1);
            return tablaArticulos;
        }

        public DataTable getTablaArticuloXPrecioMenor(Articulo art)
        {

            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE PrecioUnitario_Ar < " + art.PrecioUnitario1);
            return tablaArticulos;

        }


        public DataTable getTablaArticuloXPrecioMayoryMenor(Articulo artMen, Articulo artMay)
        {

            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE PrecioUnitario_Ar < " + artMen.PrecioUnitario1 + "AND PrecioUnitario_Ar >" + artMay.PrecioUnitario1);
            return tablaArticulos;
        }



        public DataTable getTablaArticuloXCategoria(Articulo art)
        {
            string descripcion = art.Descripcion1;
            int categoria = art.getCategoria();
            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE Id_Categoria_Ar = " + categoria);
            return tablaArticulos;
        }
        public int eliminarArticulo(Articulo art)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosArticulosEliminar(ref comando, art);
            return acc.EjecutarProcedimientoAlmacenado(comando, "spBajaArticulo");
           
        }

        public Boolean existeCodigoArticulo(Articulo art)
        {
            String consulta = "Select * from articulos where Cod_Art_Ar='" + art.CodigoDeArticulo1 + "'";
            return acc.Validar(consulta);
        }

        public int agregarArticulo(Articulo art)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosArticulosAgregar(ref comando, art);
             return acc.EjecutarProcedimientoAlmacenado(comando, "spAgregarArticulo");
        }

        public int actualizarArticulo(Articulo art)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosArticulosModificar(ref comando, art);
            return acc.EjecutarProcedimientoAlmacenado(comando, "spActualizarArticulo");
        }
        private void ArmarParametrosArticulosModificar(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CodArticulo", SqlDbType.Int);
            SqlParametros.Value = art.CodigoDeArticulo1;
            SqlParametros = Comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            SqlParametros.Value = art.Descripcion1;
            SqlParametros = Comando.Parameters.Add("@stock", SqlDbType.Int);
            SqlParametros.Value = art.Stock1;
            SqlParametros = Comando.Parameters.Add("@precioUnitario", SqlDbType.Decimal);
            SqlParametros.Value = art.PrecioUnitario1;

        }



        private void ArmarParametrosArticulosEliminar(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODIGO_ARTICULO", SqlDbType.Char);
            SqlParametros.Value = art.CodigoDeArticulo1;
        }

        private void ArmarParametrosArticulosAgregar(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id_Categoria", SqlDbType.Int);
            SqlParametros.Value = art.Cate1;
            SqlParametros = Comando.Parameters.Add("@Decripcion", SqlDbType.VarChar);
            SqlParametros.Value = art.Descripcion1;
            SqlParametros = Comando.Parameters.Add("@UrlImagen", SqlDbType.VarChar);
            SqlParametros.Value = art.UrlImagen1;
            SqlParametros = Comando.Parameters.Add("@STOCK", SqlDbType.Int);
            SqlParametros.Value = art.Stock1;
            SqlParametros = Comando.Parameters.Add("@PRECIO_UNITARIO", SqlDbType.Decimal);
            SqlParametros.Value = art.PrecioUnitario1;

        }
        public DataTable getTablaArticulosDeBaja()
        {
            DataTable tablaArticulos = acc.ObtenerTabla("Articulos", "select * from Articulos where Estado_Ar = 0");
            return tablaArticulos;
        }

        private void ArmarParametrosArticulosAlta(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@codArticulo", SqlDbType.Char);
            SqlParametros.Value = art.CodigoDeArticulo1;
        }
        public int AltaArticulo(Articulo art)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosArticulosAlta(ref comando, art);
            return acc.EjecutarProcedimientoAlmacenado(comando, "spAltaArticulo");

        }

        public Boolean existeArticuloDeBaja()
        {
            String consulta = "Select * from articulos where Estado_Ar ='0'";
            return acc.Validar(consulta);
        }




    }
}
