using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductoHandler : DbHandler
    {
        public List<Producto> GetProducto()
        {
            List<Producto> resultado = new List<Producto>();

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
                                Producto Prod = new Producto();

                                Prod.Id = Convert.ToInt32(dataReader["Id"]);
                                Prod.Descripciones = dataReader["Descripciones"].ToString();
                                Prod.Costo = Convert.ToDouble(dataReader["Costo"]);
                                Prod.PrecioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);
                                Prod.Stock = Convert.ToInt32(dataReader["Stock"]);
                                Prod.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                resultado.Add(Prod);
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