using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Dao
{
    public class DaoCuentas
    {
        //falta modificar cuenta 
        AccesoDatos ds = new AccesoDatos();
        public Cuenta getCuenta(Cuenta cuen)
        {
            DataTable tabla = ds.ObtenerTabla("Cuenta", "Select * from CUENTAS where Cod_Cuenta_Cu = '" + cuen.CodCuenta1 + "'");
            cuen.CodCuenta1 = int.Parse(tabla.Rows[0][0].ToString());
            cuen.NombreUsuario1 = tabla.Rows[0][1].ToString();
            cuen.Email1 = tabla.Rows[0][2].ToString();
            cuen.Contraseña1 = tabla.Rows[0][3].ToString();
            cuen.Admin1 = bool.Parse(tabla.Rows[0][4].ToString());
            cuen.Estado1 = bool.Parse(tabla.Rows[0][5].ToString());
            return cuen;
        }


        public DataTable getCuentaUsuario(Cuenta cuen)
        {

            DataTable tablaCuentaUsuario = ds.ObtenerTabla("Cuenta", "Select * from CUENTAS where Cod_Cuenta_Cu = '" + cuen.CodCuenta1 + "'");
            return tablaCuentaUsuario;
        }
        public Cuenta getCuentaNom(Cuenta cuen)
        {
            DataTable tabla = ds.ObtenerTabla("Cuenta", "Select * from CUENTAS where Nombre_Usuario_Cu = '" + cuen.NombreUsuario1 + "'");
            cuen.CodCuenta1 = int.Parse(tabla.Rows[0][0].ToString());
            cuen.NombreUsuario1 = tabla.Rows[0][1].ToString();
            cuen.Email1 = tabla.Rows[0][2].ToString();
            cuen.Contraseña1 = tabla.Rows[0][3].ToString();
            cuen.Admin1 = bool.Parse(tabla.Rows[0][4].ToString());
            cuen.Estado1 = bool.Parse(tabla.Rows[0][5].ToString());
            return cuen;
        }

        public DataTable getTablaCuentas()
        {

            DataTable tabla = ds.ObtenerTabla("Cuenta", "Select * from CUENTAS where Cod_Cuenta_Cu <> 10");
            return tabla;
        }

        public int AltaBajaCuenta(Cuenta cuen)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDarAltaBajaCuenta(ref comando, cuen);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spBajaAltaCuenta");
        }

        private void ArmarParametrosDarAltaBajaCuenta(ref SqlCommand Comando, Cuenta cuen)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Cod_Cuenta_Cu", SqlDbType.Int);
            SqlParametros.Value = cuen.CodCuenta1;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = cuen.Estado1;
        }
        public Boolean existeCuenta(Cuenta cuenta)
        {
            String consulta = "Select Cod_Cuenta_Cu from cuentas where Cod_Cuenta_Cu='" + cuenta.CodCuenta1 + "'" + " and Estado = 1";
            return ds.Validar(consulta);
        }

        public Boolean existeNombreUsuario(Cuenta cuenta)
        {
            String consulta = "Select * from cuentas where Nombre_Usuario_Cu='" + cuenta.NombreUsuario1 + "'";
            return ds.Validar(consulta);
        }
        public Boolean ValidarEmail(Cuenta cuenta)
        {
            String consulta = "Select * from cuentas where Email_Cu='" + cuenta.Email1 + "'";
            return ds.Validar(consulta);
        }
        public Boolean ValidarContrasena(Cuenta cuenta)
        {
            String consulta = "Select * from cuentas where Contraseña_Cu='" + cuenta.Contraseña1 + "'";
            return ds.Validar(consulta);
        }

        public int RegistrarCuenta(Cuenta cuenta)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarCuenta(ref comando, cuenta);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCuenta");
        }

        private void ArmarParametrosAgregarCuenta(ref SqlCommand Comando, Cuenta cuenta)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Nombre_Usuario_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cuenta.NombreUsuario1;
            SqlParametros = Comando.Parameters.Add("@Email_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cuenta.Email1;
            SqlParametros = Comando.Parameters.Add("@Contraseña_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cuenta.Contraseña1;

        }

        public int ModificarCuenta(Cuenta cuenta)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosModificarCuenta(ref comando, cuenta);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarCuenta");
        }

        private void ArmarParametrosModificarCuenta(ref SqlCommand Comando, Cuenta cuenta)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Cod_Cuenta_Cu", SqlDbType.Int);
            SqlParametros.Value = cuenta.CodCuenta1;
            SqlParametros = Comando.Parameters.Add("@Nombre_Usuario_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cuenta.NombreUsuario1;
            SqlParametros = Comando.Parameters.Add("@Email_Usuario_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cuenta.Email1;
            SqlParametros = Comando.Parameters.Add("@Contraseña_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cuenta.Contraseña1;

        }

        public int ModificarAdmin(Cuenta cuenta)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosModificarAdmin(ref comando, cuenta);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAdminCuenta");
        }

        private void ArmarParametrosModificarAdmin(ref SqlCommand Comando, Cuenta cuenta)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Cod_Cuenta_Cu", SqlDbType.Int);
            SqlParametros.Value = cuenta.CodCuenta1;
            SqlParametros = Comando.Parameters.Add("@Admin_Cu", SqlDbType.Bit);
            SqlParametros.Value = cuenta.Admin1;



        }
        public int ModificarEstado(Cuenta cuenta)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosModificarAdmin(ref comando, cuenta);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarEstadoCuenta");
        }

        private void ArmarParametrosModificarEstado(ref SqlCommand Comando, Cuenta cuenta)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Cod_Cuenta_Cu", SqlDbType.Int);
            SqlParametros.Value = cuenta.CodCuenta1;
            SqlParametros = Comando.Parameters.Add("@NuevoEstado", SqlDbType.Bit);
            SqlParametros.Value = cuenta.Estado1;

        }
    }
}