using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductosVendidoHandler : DbHandler
    {
        public List<ProductosVendido> GetProductosVendido()
        {
            List<ProductosVendido> resultado = new List<ProductosVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductosVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductosVendido productosVendido = new ProductosVendido();

                                productosVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productosVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productosVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productosVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                resultado.Add(productosVendido);
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