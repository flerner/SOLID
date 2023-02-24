using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_O
{
    class OpenClosed_Ok
    {
        //So, now if I want to add a new type of drink, I just create a new class implementing the IDrink interface, and that's it, I dont need to modify the existing class.
        static void Main(string[] args)
        {
            //Open for extension but closed for modification
            Beer beer = new Beer()
            {
                Name = "Scotish",
                Price = 120,
                Invoice = 1.2m
            };
            Water water = new Water()
            {
                Name = "Delicious water",
                Price = 100,
                Invoice = 1.1m
            };

            List<IDrink> drinks = new List<IDrink>();
            drinks.Add(beer);
            drinks.Add(water);

            Invoice invoice = new Invoice();

            Console.WriteLine(invoice.GetTotal(drinks));
            Console.ReadKey();
            

        }
        public interface IDrink
        {
            string Name { get; set; }
            decimal Price { get; set; }
            decimal Invoice { get; set; }
            decimal GetPrice();

        }
        public class Beer : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }

            public decimal GetPrice()
            {
                return Price * Invoice;
            }
        }
        public class Water : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal GetPrice()
            {
                return Price * Invoice;
            }
        }
        public class Invoice
        {
            
            public decimal GetTotal(IEnumerable<IDrink> lstDrink)
            {
                decimal total = 0;
                foreach (IDrink drink in lstDrink)
                {
                    total += drink.GetPrice();
                }
                return total;
            }

        }
    }
}
