using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDeEnvio
    {
        private string CodigoEnvio;
        private string Descripcion;

        public TipoDeEnvio()
        {
        }

        public TipoDeEnvio(string codigoEnvio, string descripcion)
        {
            CodigoEnvio = codigoEnvio;
            Descripcion = descripcion;
        }

        public string CodigoEnvio1 { get => CodigoEnvio; set => CodigoEnvio = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
    }
}
