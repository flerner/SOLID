using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_L
{
    class Liskov_ok
    {
        static void Main(string[] args)
        {
            AbstractSaleWithTaxes abstractSale = new SaleWithTaxes(12, "Felix", 0.40m);
            abstractSale.CalculateTaxes();
            abstractSale.Generate();
            AbstractSale abstractSaleTaxFree = new TaxFreeSale(12, "Felix");
            abstractSale.Generate();

            
            Console.ReadKey();
        }
        public abstract class AbstractSale
        {
            protected string customer;
            protected decimal amount;

            public abstract void Generate();
        }
        public abstract class AbstractSaleWithTaxes: AbstractSale
        {
            protected decimal taxes;

            public abstract void CalculateTaxes();
        }

        public class SaleWithTaxes : AbstractSaleWithTaxes
        {
            public SaleWithTaxes(decimal amount, string customer, decimal taxes)
            {
                this.amount = amount;
                this.customer = customer;
                this.taxes = taxes;
            }

            public override void CalculateTaxes()
            {
                Console.WriteLine("Se calculaan los impuestos");
            }

            public override void Generate()
            {
                Console.WriteLine("Se genera la venta");
            }
        }
        //Ahora si se está cumpliendo ya que se plantea correctamente la jerarquía, en caso de no necesitar taxes, no dejamos ningun campo ni metodo sin implementar
        //sino que heredamos de una clase abstracta mas genérica.
        public class TaxFreeSale : AbstractSale
        {
            public TaxFreeSale(decimal amount, string customer)
            {
                this.amount = amount;
                this.customer = customer;
            }

            public override void Generate()
            {
                Console.WriteLine("Se genera la venta");
            }
        }
    }
}
