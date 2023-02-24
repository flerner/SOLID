using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_I
{
    class InterfaceSegregation_Ok
    {
        //uncomment main for testing

        //static void Main(string[] args)
        //{
        //    Bill bill = new Bill(1000, 1, DateTime.Now);

        //    bill.Print();

        //    ElectronicBill eb = new ElectronicBill("qwe@rty.uiop", 2, DateTime.Now);
        //    eb.Print();
        //    eb.SendByEmail();
            
        //    Console.ReadKey();

            

        //}
        //so, if we divide the interfaces in two
        public interface Printable
        {
            void Print();

        }
        public interface Emailable
        {
            void SendByEmail();
        }
        public abstract class Document
        {
            public Document(DateTime date, int number)
            {
                Date = date;
                Number = number;
            }

            public DateTime Date { get; set; }
            public int Number { get; set; }



        }
        public class Bill : Document, Printable
        {
            public Bill(int total, int number, DateTime date): base(date, number)
            {
                Total = total;
            }

            public int Total { get; set; }
            public void Print()
            {
                Console.WriteLine($"Printing bill number {Number} with date {Date}");
            }

        }
        public class ElectronicBill : Document, Printable, Emailable
        {
            public ElectronicBill(string email, int number, DateTime date) : base(date, number)
            {
                Email = email;
            }
            public string Email { get; set; }
            public void Print()
            {
                Console.WriteLine($"Printing electronic bill number {Number} with date {Date}");
            }

            public void SendByEmail()
            {
                Console.WriteLine($"Sending by email electronic bill number {Number} with date {Date}");
            }
        }
    }
}
