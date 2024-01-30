using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        private string CodEnvio;
      
        private int codCuenta;
        private int NroFactura;
        private String NumeroTarjeta;
        private string Cvv;
        private string dnititular;
        private string DireccionDeVenta;
        private DateTime FechaDeEntrega;
        private DateTime FechaVenta;
        private decimal Total;

        public Ventas()
        {
        }

        public string CodEnvio1 { get => CodEnvio; set => CodEnvio = value; }
        public int CodCuenta { get => codCuenta; set => codCuenta = value; }
        public int NroFactura1 { get => NroFactura; set => NroFactura = value; }
        public string NumeroTarjeta1 { get => NumeroTarjeta; set => NumeroTarjeta = value; }
        public string Cvv1 { get => Cvv; set => Cvv = value; }
        public string Dnititular { get => dnititular; set => dnititular = value; }
        public string DireccionDeVenta1 { get => DireccionDeVenta; set => DireccionDeVenta = value; }
        public DateTime FechaDeEntrega1 { get => FechaDeEntrega; set => FechaDeEntrega = value; }
        public DateTime FechaVenta1 { get => FechaVenta; set => FechaVenta = value; }
        public decimal Total1 { get => Total; set => Total = value; }
    }
}
