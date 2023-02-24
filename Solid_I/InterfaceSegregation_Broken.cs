using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_I
{
    class InterfaceSegregation_Broken
    {
        // uncomment main for testing

        //static void Main(string[] args)
        //{
        //    Bill bill = new Bill(1000, 1, DateTime.Now);

        //    //here the program break so you should put a trycatch, but the program is messy
        //    bill.SendByEmail();
        //}
        public interface Sendable
        {
            void Print();
            void SendByEmail();
        }
        public abstract class Document : Sendable
        {
            public Document(DateTime date, int number)
            {
                Date = date;
                Number = number;
            }

            public DateTime Date { get; set; }
            public int Number { get; set; }

            public abstract void SendByEmail();
            public abstract void Print();

        }
        public class Bill : Document
        {
            public Bill(int total, int number, DateTime date): base(date, number)
            {
                Total = total;
            }

            public int Total { get; set; }
            public override void Print()
            {
                Console.WriteLine($"Printing bill number {Number} with date {Date}");
            }

            public override void SendByEmail()
            {
                //this method is not suported by Bill
                //Here is where the Interface Segregation is broken, because it is implementing a method that shouldnt be here.
                throw new NotImplementedException();
            }
        }
        public class ElectronicBill : Document
        {
            public ElectronicBill(string email, int number, DateTime date) : base(date, number)
            {
                Email = email;
            }
            public string Email { get; set; }
            public override void Print()
            {
                Console.WriteLine($"Printing electronic bill number {Number} with date {Date}");
            }

            public override void SendByEmail()
            {
                Console.WriteLine($"Sending by email electronic bill number {Number} with date {Date}");
            }
        }
    }
}
