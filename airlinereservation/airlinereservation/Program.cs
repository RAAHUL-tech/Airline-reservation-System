// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace airlineres
{
    public class airline
    {
        private string airlineId, source, destination, timearr;
        private int capacity;

        public airline()
        {
            airlineId = "";
            source = "";
            destination = "";
            timearr = "";
            capacity = 0;
        }
        public airline(string id, string s, string d, string time,int cap)
        {
            airlineId = id;
            source = s;
            destination = d;
            timearr = time;
            capacity=cap;
        }

        public string id
        {
            get { return airlineId; }
            set { airlineId = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public string Time
        {
            get { return timearr; }
            set { timearr = value; }
        }
        public void displayflight()
        {
            Console.WriteLine(airlineId + " "+source+ " "+destination+ " "+timearr+ " "+capacity);
        }
    }

    public class passengers
    {
        protected String name, type;
        public String start, end;
        protected int age;

        public passengers()
        {
            name = "";
            type = "";
            start = "";
            end = "";
            age = 0;
        }
        public void getdata()
        {
            Console.WriteLine("Enter your name :");
            name = Console.ReadLine();
            Console.WriteLine("Enter your age :");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the start place :");
            start = Console.ReadLine();
            Console.WriteLine("Enter the end place :");
            end = Console.ReadLine();
            Console.WriteLine("Enter the type :");
            type = Console.ReadLine();
        }

        
        
    }

    public class generatebill:passengers
    {
        private float basicpay, gst, accharge, foodcharge,total;

        public void getpay()
        {
            if(type.Equals("economy") && start.Equals("chennai") && end.Equals("delhi"))
            {
                basicpay=15000;
            }
            if (type.Equals("business") && start.Equals("chennai") && end.Equals("delhi"))
            {
                basicpay = 20000;
            }
            if (type.Equals("economy") && start.Equals("banglore") && end.Equals("kolkata"))
            {
                basicpay = 12000;
            }
            if (type.Equals("business") && start.Equals("banglore") && end.Equals("kolkata"))
            {
                basicpay = 17000;
            }
            if (type.Equals("economy") && start.Equals("chennai") && end.Equals("mumbai"))
            {
                basicpay = 11000;
            }
            if (type.Equals("business") && start.Equals("chennai") && end.Equals("mumbai"))
            {
                basicpay = 16000;
            }
            if (type.Equals("economy") && start.Equals("kolkata") && end.Equals("delhi"))
            {
                basicpay = 14000;
            }
            if (type.Equals("business") && start.Equals("kolkata") && end.Equals("delhi"))
            {
                basicpay = 21000;
            }
            if (type.Equals("economy") && start.Equals("mumbai") && end.Equals("chennai"))
            {
                basicpay = 14000;
            }
            if (type.Equals("business") && start.Equals("mumbai") && end.Equals("chennai"))
            {
                basicpay = 19000;
            }
        }
        public void calculate()
        {
            accharge = (float)0.15 * basicpay;
            gst = (float)0.1 * basicpay;
            foodcharge=(float)0.20*basicpay;
            total = basicpay + accharge + gst + foodcharge;
        }
        public void booking()
        {
            Console.WriteLine("Your total pay is :" + total);
        }
    }

    public class makepayment:generatebill
    {
        private string bankname,cardno, cvv, month, year;

        public void payment()
        {
            Console.WriteLine("Enter bank name :");
            bankname = Console.ReadLine();
            Console.WriteLine("Enter card no :");
            cardno = Console.ReadLine();
            Console.WriteLine("Enter cvv no :");
            cvv = Console.ReadLine();
            Console.WriteLine("Enter expiry month :");
            month = Console.ReadLine();
            Console.WriteLine("Enter expiry year :");
            year = Console.ReadLine();
            Console.WriteLine("Your payment is in progress...");
        }
        public void checkbank()
        {
            if(bankname.Equals("sbi") || bankname.Equals("icici") || bankname.Equals("canara"))
            {
                if (cardno.Equals("1234567812345678") && cvv.Equals("123") && month.Equals("03") && year.Equals("2027"))
                {
                    Console.WriteLine("Your Transacaction is successfull");
                    Random rnd = new Random(20);
                    Console.WriteLine("Your transaction id is :" + rnd.Next());
                }

            }
            
            else
            {
                Console.WriteLine("Something went wrong try again later...");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int count = 0;
            string choice;
           List<airline> airlines = new List<airline>();
           airlines.Add(new airline("KF-201","chennai","delhi","15.00hrs",90));
           airlines.Add(new airline("KF-202", "banglore", "kolkata", "11.00hrs",75));
           airlines.Add(new airline("KF-203", "chennai", "mumbai", "18.00hrs",120));
           airlines.Add(new airline("KF-204", "kolkata", "delhi", "07.00hrs",60));
           airlines.Add(new airline("KF-205", "mumbai", "chennai", "03.00hrs",50));
            Console.WriteLine("Welcome to #vimal airprts...");
            makepayment p = new makepayment();
            p.getdata();

            Console.WriteLine("Checking for flights...");
            foreach(airline a in airlines)
            {
                if(a.Source==p.start && a.Destination==p.end)
                {
                    Console.WriteLine("You have a flight " + a.id + " at " + a.Time);
                    a.Capacity--;
                    goto l1;
                }
                count++;
            }
            if(count==5)
            {
                Console.WriteLine("Sorry you don't have flights in the specified location.");
                Console.WriteLine("Try anather location..");
                goto exit;
            }
           l1: p.getpay();
            p.calculate();
            p.booking();
            Console.WriteLine("Would you like to make the payment :");
            choice = Console.ReadLine();
            if(choice.Equals("yes"))
            {
                p.payment();
                p.checkbank();
            }
            else
            {
                goto exit;
            }
        exit: Console.WriteLine("Thank you..");
        }
    }

}
