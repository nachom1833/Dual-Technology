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
    public class negocio
    {

        public bool eliminarArticulo(string codArticulo)
        {
           
            daoArticulos dao = new daoArticulos();
            Articulo ar = new Articulo();
            ar.CodigoDeArticulo1 = codArticulo;
            int op = dao.eliminarArticulo(ar);
            if (op == 1)
                return true;
            else
                return false;
          
        }
        //no funciona todavia

        public bool agregarArticulo()
        {
            int cantFilas = 0;
            Articulo ar = new Articulo();
            cargarArticuloParaAgregar(ar);
            daoArticulos dao = new daoArticulos();
            if (dao.existeCodigoArticulo(ar) == false)
            {
                cantFilas = dao.agregarArticulo(ar);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
        //no funciona todavia

        public bool actualizarArticulo()
        {
            int cantFilas = 0;
            Articulo ar = new Articulo();
            cargarArticuloParaActualizar(ar);
           
   
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

        public Articulo cargarArticuloParaActualizar(Articulo ar)
        {

           
           
            /*
            if (txtactualizarDesc.Text!=""){
              ar.Descripcion1= txtActualizarDesc.Text;

              }
            if (txtactualizarIdCate.Text!=""){
                ar.Cate1 = txtActualizarIdCate;
            y asi  con los que faltan sin el codigode articulo

              }*/
            

            return ar;

        }

        public Articulo cargarArticuloParaAgregar(Articulo ar)
        {
            //si o si debemos validar con controles de validacion que todos los campos esten llenos para agregar
            //distinto es de modificar en cual el codigo de articulo nunca lo damos para cambiar, pero si uno o todos los campos restantes

            /*
            //ar.CodigoDeArticulo1 = txtAgregarArtCod.Text;
            ar.Descripcion1 = txtAgregarArtDesc.Text;
            ar.Cate1 = txtAgregarArtCate.Text;
            ar.PrecioUnitario1 = int.Parse(txtAgregarArtPrecio.text);
            ar.Stock1 = int.Parse(txtAgregarArtStock.Text);*/


            return ar;

        }
        public DataTable getTablaArticulos()
        {
            daoArticulos daoArt = new daoArticulos();
            return daoArt.getTablaArticulos();
            
        }

}
}
