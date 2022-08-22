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
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductosVendido prodVend = new ProductosVendido();

                                prodVend.Id = Convert.ToInt32(dataReader["Id"]);
                                prodVend.Stock = Convert.ToInt32(dataReader["Stock"]);
                                prodVend.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                prodVend.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                resultado.Add(prodVend);
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