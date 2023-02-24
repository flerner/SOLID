using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_O
{
    class OpenClosed_Broken
    {
        //static void Main(string[] args)
        //{
        //    //Open for extension but closed for modification
        //    Drink drink = new Drink()
        //    {
        //        Name = "Felix",
        //        Type = "Scotish",
        //        Price= 100,
        //    };
        //    Drink drink2 = new Drink()
        //    {
        //        Name = "Felix",
        //        Type = "Belgium",
        //        Price = 150,
        //    };

        //    List<Drink> list = new List<Drink>();
        //    list.Add(drink);
        //    list.Add(drink2);

        //    Invoice invoice = new Invoice();

        //    Console.WriteLine(invoice.GetTotal(list));
        //    Console.ReadKey();
            
        //}
        public class Drink
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public decimal Price { get; set; }

        }
        public class Invoice
        {
            //Right here, if I'd want to add a new tax for a new type of drink I would have to add another if and I would be modificating an existing class.
            //That would break the Open/Closed principle.
            public decimal GetTotal(IEnumerable<Drink> lstDrink)
            {
                decimal total = 0;
                foreach(Drink drink in lstDrink)
                {
                    if (drink.Type == "Water")
                    {
                        total += drink.Price * 1.1m;
                    }else if (drink.Type == "Scotish")
                    {
                        total += drink.Price * 1.2m;
                    }else if(drink.Type == "Belgium")
                    {
                        total += drink.Price * 1.3m;
                    }
                    total += drink.Price;
                }
                return total;
            }
            
        }
    }
}
