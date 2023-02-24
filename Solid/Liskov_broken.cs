using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_L
{
    public class Liskov_broken
    {
        //descomentar main para probar

        //static void Main(string[] args)
        //{
        //    AbstractSale abstractSale = new Sale(12, "Felix", 0.40m);
        //    abstractSale.CalculateTaxes();
        //    abstractSale.Generate();
        //    Console.ReadKey();
        //}
        public abstract class AbstractSale
        {
            protected decimal amount;
            protected string customer;
            protected decimal taxes;

            public abstract void Generate();
            public abstract void CalculateTaxes();
        }
  
       public class Sale : AbstractSale
        {
            public Sale(decimal amount, string customer, decimal taxes)
            {
                this.amount = amount;
                this.customer = customer;
                this.taxes = taxes;
            }

            public override void CalculateTaxes()
            {
                Console.WriteLine("Se calculan los impuestos");
            }

            public override void Generate()
            {
                Console.WriteLine("Se genera la venta");
            }
        }
        //en este punto es en donde se rompe la regla de Liskov, ya que tenemos un campo extra que seria el impuesto...
        public class TaxFreeSale: AbstractSale
        {
            public TaxFreeSale(decimal amount, string customer)
            {
                this.amount = amount;
                this.customer = customer;
                this.taxes = 0;
            }

            public override void CalculateTaxes()
            {
                throw new NotImplementedException();
            }

            public override void Generate()
            {
                Console.WriteLine("Se genera la venta");
            }
        }
    }
}
