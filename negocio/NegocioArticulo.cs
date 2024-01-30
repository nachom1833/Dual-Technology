using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Dao;

namespace negocio
{
    public class NegocioArticulo
    {
        
        public bool eliminarArticulo(Articulo Art)
        {
            daoArticulos dao = new daoArticulos();
            int op = dao.eliminarArticulo(Art);
            if (op == 1)
                return true;
            else
                return false;

        }
       

        public bool agregarArticulo(Articulo ar)
        {
            int cantFilas = 0;
            daoArticulos dao = new daoArticulos();
            cantFilas = dao.agregarArticulo(ar);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
       

        public bool actualizarArticulo(Articulo ar)
        {
            int cantFilas = 0;
            daoArticulos dao = new daoArticulos();
            if (dao.existeCodigoArticulo(ar) == true)
            {
                cantFilas = dao.actualizarArticulo(ar);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;

        }

       
        public DataTable getTablaArticulos()
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticulos();

        }

        public DataTable getTablaArticulosPorBusqueda(Articulo art)
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticuloPorDes(art);

        }
        public Articulo getArticuloPorCodigo(Articulo art)
        {
            daoArticulos daoArt = new daoArticulos();
            DataTable tablaArticulo=daoArt.getTablaArticuloPorCod(art);
            art.CodigoDeArticulo1= tablaArticulo.Rows[0][0].ToString();
            art.Cate1 = int.Parse(tablaArticulo.Rows[0][1].ToString());
            art.Descripcion1 = tablaArticulo.Rows[0][2].ToString();
            art.UrlImagen1 = tablaArticulo.Rows[0][3].ToString();
            art.Stock1 = int.Parse(tablaArticulo.Rows[0][4].ToString());
            art.PrecioUnitario1 = Convert.ToDecimal(tablaArticulo.Rows[0][5].ToString());
            art.estado1 = bool.Parse(tablaArticulo.Rows[0][6].ToString());
            return art;
        }
        public DataTable getTablaArticulosXCategoriaPorBusqueda(Articulo art)
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticuloXCategoriayDesc(art);

        }
        public DataTable getTablaArticulosXCATEGORIAFILTRO(Articulo art)
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticuloXCategoria(art);

        }
        public DataTable getTablaArticulosXPrecioMAYOR(Articulo art)
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticuloXPrecioMayor(art);

        }
        public DataTable getTablaArticulosXPrecioMenor(Articulo art)
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticuloXPrecioMenor(art);

        }

        public DataTable getTablaArticulosXPrecioMayorYmenor(Articulo artMen, Articulo artMay)
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticuloXPrecioMayoryMenor(artMen, artMay);

        }

        public DataTable getTablaArticulosBaja()
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticulosDeBaja();

        }

        public bool AltaArticulo(Articulo Art)
        {
            daoArticulos dao = new daoArticulos();
            int op = dao.AltaArticulo(Art);
            if (op == 1)
                return true;
            else
                return false;
        }
        public bool ExisteArticuloBaja()
        {
            daoArticulos dao = new daoArticulos();
            bool op = dao.existeArticuloDeBaja();
            if (op == true)
                return true;
            else
                return false;
        }
    }
}
