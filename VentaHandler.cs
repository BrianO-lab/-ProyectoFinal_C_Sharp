using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> GetProductosVendidoo()
        {
            List<Venta> resultado = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta vent = new Venta();

                                vent.Id = Convert.ToInt32(dataReader["Id"]);
                                vent.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                vent.Nombre = dataReader["Nombre"].ToString();
                                vent.Apellido = dataReader["Apellido"].ToString();
                                vent.Contrase�a = dataReader["Contrase�a"].ToString();
                                vent.Mail = dataReader["Mail"].ToString();

                                resultado.Add(vent);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }
    }
}