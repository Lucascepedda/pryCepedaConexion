using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCepedaConexion
{
    internal class clsContacto
    {
        public void RegistrarContacto(string Nombre, string Apellido, string Telefono, string Correo, string Categoria)
        {
            using (SqlConnection conexion = clsConexion.ObtenerConexion())
            {
                try
                {
                    string query = "INSERT INTO Contactos (Nombre, Apellido, Telefono, Correo, Categoria) " +
                                   "VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Categoria)";

                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Apellido", Apellido);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@Categoria", Categoria);

                    int resultado = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error: " + ex.Message);
                }
            }
        }


        public void MostrarContactos(DataGridView dgvMostrar)
        {
            using (SqlConnection conexion = clsConexion.ObtenerConexion())
            {
                string query = "SELECT Id, Nombre, Apellido, Telefono, Correo, Categoria FROM Contactos";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMostrar.DataSource = dt;
            }
        }
    }
}

