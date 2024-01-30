using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Categoria
    {
        private int  IdCategoria;
        private String Nombre;

        public Categoria()
        {
        }

        public Categoria(int idCategoria, string nombre)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
        }

        public void SetId (int id)
        {
            IdCategoria = id;
        }
        public int getId()
        {
            return IdCategoria;
        }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
    }
}
