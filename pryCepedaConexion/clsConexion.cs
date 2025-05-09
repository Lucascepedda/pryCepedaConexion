using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCepedaConexion
{
    internal class clsConexion
    {
        private static string ConexionBD = "Server=.;Database=Comercio;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(ConexionBD);
            try
            {
                conexion.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al conectar: " + ex.Message);
            }

            return conexion;
        }
    }
}
