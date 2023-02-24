using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Solid_D.DependencyInversionBroken;
using static Solid_D.DependencyInversionOk;

namespace Solid_D
{
    class DependencyInversionOk
    {
        //Uncomment main for testing

        //static void Main(string[] args)
        //{
        //    Bill bill = new Bill(DateTime.Now, 1, "EverGreen Road");
        //    Passport passport = new Passport(DateTime.Now, 2, "Felix");
        //    Paycheck paycheck = new Paycheck("Im a file", 10000);

        //    Printer printer = new Printer();
        //    printer.Print(bill);
        //    printer.Print(passport);
        //    printer.Print(paycheck);
        //    Console.ReadKey();
        //}
        //lets create an interface to fix the dependency

        public interface Printable
        {
            void Print();
        }

        //Now each class knows how to print itself, so from this class just call the method Print() and if we want to add another class we dont need to touch this one
        //we just need to implement the interface Printable.
        public class Printer 
        {
            public void Print(Printable printable)
            {
                printable.Print();
            }
        }
        public abstract class Document : Printable
        {
            protected Document(DateTime date, int number)
            {
                Date = date;
                Number = number;
            }

            public DateTime Date { get; set; }
            public int Number { get; set; }

            public abstract void Print();
          
        }

        public class Bill : Document
        {
            public Bill(DateTime date, int number, string address) : base(date, number)
            {
                Address = address;
            }
            public string Address { get; set; }

            public override void Print()
            {
                Console.WriteLine($"Printing bill {Number} of date {Date} and adress {Address}");
            }
        }
        public class Passport : Document
        {
            public string Name { get; set; }
            public Passport(DateTime date, int number, string name) : base(date, number)
            {
                Name = name;
            }

            public override void Print()
            {
                Console.WriteLine($"Printing passport {Number} of name {Name}");
            }
        }
        public class Paycheck: Printable
        {
            public string File { get; set; }
            public double Total { get; set; }

            public Paycheck(string file, double total)
            {
                File = file;
                Total = total;
            }

            public void Print()
            {
                Console.WriteLine($"Printing paycheck of file {File} and a total of {Total}");
            }
        }

       
    }
}
