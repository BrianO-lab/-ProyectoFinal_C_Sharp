using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Program
    {
        private static void Main(string[] arg)
        {
            ProductoHandler handler = new ProductoHandler();

            handler.GetProducto();
        }
    }
}