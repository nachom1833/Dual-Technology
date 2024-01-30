using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulo
    {
        private String CodigoDeArticulo;
        private int Cate;
        private Categoria cate = new Categoria();
        private String Descripcion;
        private string UrlImagen;
        private int Stock;
        private decimal PrecioUnitario;
        private bool estado;

        public Articulo()
        {
        }
        /*
        public Articulo(string codigoDeArticulo, Categoria cate, string descripcion, string urlImagen, int stock, decimal precioUnitario)
        {
            CodigoDeArticulo = codigoDeArticulo;
            Cate = Cate;
            Descripcion = descripcion;
            UrlImagen = urlImagen;
            Stock = stock;
            PrecioUnitario = precioUnitario;
        }*/

        public string CodigoDeArticulo1 { get => CodigoDeArticulo; set => CodigoDeArticulo = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string UrlImagen1 { get => UrlImagen; set => UrlImagen = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public decimal PrecioUnitario1 { get => PrecioUnitario; set => PrecioUnitario = value; }

        public int Cate1 { get => Cate; set => Cate = value; }
        public void setCategoria(int c) 
        {
            cate.SetId(c);
        }
        public int getCategoria()
        {
            return cate.getId();
        }
        public bool estado1 { get => estado; set => estado = value; }

    }
}
