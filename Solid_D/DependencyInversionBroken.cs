using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Solid_D.DependencyInversionBroken;

namespace Solid_D
{
    class DependencyInversionBroken
    {
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
        //This is a class that depends on another low level class and not depend on a abstraction. Thats why this is breaking the Dependency Inversion rule.
        public class Printer
        {
            public void Print(Bill bill)
            {
                Console.WriteLine($"Printing bill {bill.Number} of date {bill.Date} and adress {bill.Address}");
            }
            public void Print(Passport passport)
            {
                Console.WriteLine($"Printing passport {passport.Number} of name {passport.Name}");
            }
            public void Print(Paycheck paycheck)
            {
                Console.WriteLine($"Printing paycheck of file {paycheck.File} and a total of {paycheck.Total}");
            }
        }
        public abstract class Document
        {
            protected Document(DateTime date, int number)
            {
                Date = date;
                Number = number;
            }

            public DateTime Date { get; set; }
            public int Number { get; set; }

        }

        public class Bill : Document
        {
            public Bill(DateTime date, int number, string address) : base(date, number)
            {
                Address = address;
            }
            public string Address { get; set; }
        }
        public class Passport : Document
        {
            public string Name { get; set; }
            public Passport(DateTime date, int number, string name) : base(date, number)
            {
                Name = name;
            }
        }
        public class Paycheck
        {
            public string File { get; set; }
            public double Total { get; set; }

            public Paycheck(string file, double total)
            {
                File = file;
                Total = total;
            }
        }

       
    }
}
