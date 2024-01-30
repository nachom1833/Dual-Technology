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
    public class NegocioCuenta
    {

        public bool DarAltaCuenta(Cuenta cuen)
        {

            DaoCuentas dao = new DaoCuentas();
            if(!cuen.Estado1)
            {
                int op = dao.AltaBajaCuenta(cuen);
                if (op == 1)
                    return true;
                else
                    return false;

            }
            return false;
            

        }
        public bool eliminarCuenta(Cuenta cuen)
        {

            DaoCuentas dao = new DaoCuentas();
            if (cuen.Estado1)
            {
                int op = dao.AltaBajaCuenta(cuen);
                if (op == 1)
                    return true;
                else
                    return false;


            }
            return false;
            

        }

        public bool modificarCuenta(Cuenta cuen)
        {

            DaoCuentas dao = new DaoCuentas();
                int op = dao.ModificarCuenta(cuen);
            if (op == 1)
                return true;
            else
                return false;

        }
        public bool modificarAdmin(Cuenta cuen)
        {

            DaoCuentas dao = new DaoCuentas();
            int op = dao.ModificarAdmin(cuen);
            if (op == 1)
                return true;
            else
                return false;

        }


        //no funciona todavia
        public Cuenta getCuenta(Cuenta cuen)
        {
            Cuenta cuenta = new Cuenta();
            DaoCuentas cue = new DaoCuentas();
            cuenta=cue.getCuenta(cuen);

            return cuenta;
        }
        public Cuenta getCuentaNom(Cuenta cuen)
        {
            Cuenta cuenta = new Cuenta();
            DaoCuentas cue = new DaoCuentas();
            cuenta = cue.getCuentaNom(cuen);

            return cuenta;
        }

        public DataTable getTablaCuenta()
        {
            DaoCuentas dc = new DaoCuentas();
            
            return dc.getTablaCuentas();
        }

        public int RegistrarCuentaNueva(Cuenta cue)
        {
            DaoCuentas RegLog = new DaoCuentas();

            if (RegLog.existeNombreUsuario(cue) != true)
            {
                if (RegLog.ValidarEmail(cue) != true)
                {
                    if (RegLog.RegistrarCuenta(cue) > 0)
                    {
                        return 1;
                    }
                }
                return -1;
            }
            return 0;
        }

        public Cuenta ValidarInicioSesion(Cuenta cue) 
        {
            string contra = cue.Contraseña1;
            DaoCuentas reg = new DaoCuentas();

            if (reg.existeNombreUsuario(cue))
            {
                cue = reg.getCuentaNom(cue);
                if (cue.Estado1 == true) 
                { 
                    if (cue.Contraseña1.CompareTo(contra) == 0)
                    {
                       return cue;
                    }
                    cue.CodCuenta1 = 0;
                    return cue; 
                }//bug logico
            }
            cue.CodCuenta1 = -1;
            return cue;
        }


    }
}