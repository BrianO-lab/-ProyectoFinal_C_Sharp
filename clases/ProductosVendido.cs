using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    internal class ProductosVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }

        public int IdProducto { get; set; }

        public int IdVenta { get; set; }
    }
}