using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dao;
using Entidades;
namespace negocio
{
    public class NegocioCategoria
    {
        public DataTable obtenerDDLCategoria()
        {
            daoCategoria dc = new daoCategoria();
            return dc.obtenerDDLCategoria();
        }
        public DataTable ObtenerTablaCategoria(Categoria cate)
        {
            daoCategoria dc = new daoCategoria();
            return dc.getTablaCategoria(cate);
        }
    }
}
