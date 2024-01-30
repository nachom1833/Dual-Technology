using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuenta
    {
        private int CodCuenta;
        private String NombreUsuario;
        private String Email;
        private String Contraseña;
        private bool Admin;
        private bool Estado;

        public Cuenta()
        {

        }

        public int CodCuenta1 { get => CodCuenta; set => CodCuenta = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
        public bool Admin1 { get => Admin; set => Admin = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
        
        public string NombreUsuario1 { get => NombreUsuario; set => NombreUsuario = value; }
        
    }
}
