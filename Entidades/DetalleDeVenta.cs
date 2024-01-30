using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleDeVenta
    {
        int numeroFactura;
        string codArt;
        private int Cant;
        private decimal PrecioUnitario;

        public DetalleDeVenta()
        {
        }
        public int NumeroFactura { get => numeroFactura; set => numeroFactura = value; }
        public string CodArt { get => codArt; set => codArt = value; }
        public int Cant1 { get => Cant; set => Cant = value; }
        public decimal PrecioUnitario1 { get => PrecioUnitario; set => PrecioUnitario = value; }
    }
}
