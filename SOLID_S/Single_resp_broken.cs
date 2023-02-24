using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_S
{
    public class Single_resp_broken
    {
        //descomentar main para probar

        //static void Main(string[] args)
        //{
        //    Factura f = new Factura(1, DateTime.Now, "Felix", "Lerner");


        //    Producto p1 = new Producto("Papas fritas", 100);
        //    Producto p2 = new Producto("Milanesas", 200);
        //    Producto p3 = new Producto("Salsa", 300);

        //    Items i1 = new Items(p1, 3);
        //    Items i2 = new Items(p2, 5);
        //    Items i3 = new Items(p3, 6);

        //    f.Items.Add(i1);
        //    f.Items.Add(i2);
        //    f.Items.Add(i3);

        //    Console.WriteLine(f.Total());
        //    Console.ReadKey();
        //}


        //podemos ver como en este ejemplo la clase Factura tiene campos que no le corresponden, como el nombre y apellido de un cliente. Por lo tanto aca
        //hay una ruptura de la regla "Single responsability"
        //Tambien hay una ruptura en el calculo del total, ya que esa responsabilidad podriamos derivarla a que cada item calcule su subtotal
        public class Factura
        {
            public Factura(int numero, DateTime fecha, string nombre, string apellido)
            {
                Numero = numero;
                Fecha = fecha;
                Nombre = nombre;
                Apellido = apellido;
                Items = new List<Items>();
            }

            public int Numero { get; set; }
            public DateTime Fecha { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public List<Items> Items { get; set; }

            public double Total()
            {
                double total = 0;
                foreach(Items i in Items)
                {
                    total += i.Cantidad * i.Producto.Precio;
                }
                return total;
            }

        }
        public class Items
        {
            public Items(Producto producto, int cantidad)
            {
                Producto = producto;
                Cantidad = cantidad;
            }

            public Producto Producto { get; set; }
            public int Cantidad { get; set; }
        }
        public class Producto
        {
            public Producto(string descripcion, double precio)
            {
                Descripcion = descripcion;
                Precio = precio;
            }

            public string Descripcion { get; set; }
            public double Precio { get; set; }

        }
    }
}
