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
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();

                                resultado.Add(producto);
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