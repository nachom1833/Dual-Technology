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
    public class daoCategoria
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable obtenerDDLCategoria()
        {
            DataTable tabla = ds.ObtenerTabla("CATEGORIA", "SELECT Id_Categoria_Ct, NombreCategoria_Ct FROM CATEGORIA");
            return tabla;
        }
        public DataTable getTablaCategoria(Categoria cate)
        {
            int categoria = cate.getId();
            DataTable tablaArticulos = ds.ObtenerTabla("Articulos", "SELECT * FROM Articulos WHERE Id_Categoria_Ar = " + categoria);
            return tablaArticulos;
        }
    }
}
