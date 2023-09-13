using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Oruscurso.Datos
{
    public class CONEXIONMAESTRA
    {
        //public static string conexion = @"Data source=DESKTOP-SJ9JMU9\SQLEXPRESS; Initial Catalog=ORUS369; Integrated Security=true";
        public static string conexion = Convert.ToString(Logica.Desencryptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
