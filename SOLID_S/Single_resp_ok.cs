using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_S
{
    public class Single_resp_ok
    {
        //descomentar main para probar

        //static void Main(string[] args)
        //{
        //    Cliente c = new Cliente("Felix", "Lerner");
        //    Factura f = new Factura(1, DateTime.Now, c);

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

        //En esta refactorizacion cambiamos los campos nombre y apellido por una clase cliente, ahora esa clase tiene la responsabilidad de tener esos campos.
        //Ademas transferimos la responsabilidad de calcular el subtotal de cada item a la clase Item.
        public class Factura
        {
            public Factura(int numero, DateTime fecha, Cliente cliente)
            {
                Numero = numero;
                Fecha = fecha;
                Cliente = cliente;
                Items = new List<Items>();
            }

            public int Numero { get; set; }
            public DateTime Fecha { get; set; }
            public Cliente Cliente { get; set; }
            public List<Items> Items { get; set; }

            public double Total()
            {
                double total = 0;
                foreach (Items i in Items)
                {
                    total += i.Subtotal();
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

            public double Subtotal()
            {
                return Producto.Precio * Cantidad;
            }
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

        public class Cliente
        {
            public Cliente(string nombre, string apellido)
            {
                Nombre = nombre;
                Apellido = apellido;
            }

            public string Nombre { get; set; }
            public string Apellido { get; set;}
        }
    }

}
