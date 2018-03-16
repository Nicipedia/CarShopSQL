using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }


        private static bool MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Car Shop!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a car to inventory");
            Console.WriteLine("2) View inventory");
            Console.WriteLine("3) Exit");
            string result = Console.ReadLine();
            if (result == "1")
            {
                AddInventory();
                return true;
            }
            else if (result == "2")
            {
                DataAccess db = new DataAccess();
                db.GetCarInv(); 
                Console.Write("Press Any Key to Return to Main Menu");
                Console.ReadLine();
                return true;
            }
            else if (result == "3")
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        private static void AddInventory()
        {
            Console.Clear();

            var carsShop = new Cars();
            StringBuilder carList = new StringBuilder();

            Console.Write("Enter a make of a car: ");
            carsShop.Make = (Console.ReadLine());
            carList.Append(carsShop.Make);

            Console.Write("Enter a model for the car: ");
            carsShop.Model = (Console.ReadLine());
            carList.Append(carsShop.Model);

            Console.Write("Enter a colour for the car: ");
            carsShop.Colour = (Console.ReadLine());
            carList.Append(carsShop.Colour);

            Console.Write("Enter the price of the car: ");
            string inputValue = (Console.ReadLine());
            try
            {
                carsShop.Price = Convert.ToDouble(inputValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Number.", inputValue);
                carList.Clear();
                Console.Write("Press Any Key to Return to Main Menu");
                Console.ReadLine();
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", inputValue);
            }
            ;
            try
            {
                string totalValue = string.Format("{0:C}", carsShop.Price);
                carList.Append(totalValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unknown Format");
            }


            Console.Write("The value of the commission is as follows: ");
            carsShop.Comm = GetCommission(carsShop.Price);
            try
            {
                string totalComm = string.Format("{0:C}", carsShop.Comm);
                carList.Append(totalComm);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unknown Format");
            }
            Console.Write("The Net Value of the Car is: ");
            carsShop.netValue = GetNetValue(carsShop.Price, carsShop.Comm);
            try
            {
                string totalNetValue = string.Format("{0:C}", carsShop.netValue);
                carList.Append(totalNetValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unknown Format");
            }

            Console.WriteLine("The following will be added to inventory: ");
            Console.WriteLine(carList);
            DataAccess db = new DataAccess();

            db.InsertCar(carsShop);

            Console.Write("Press Any Key to Continue");
            Console.ReadLine();


        }
        private static double GetCommission(double value)

        {
            double Comm = value * 0.025;
            Console.WriteLine(Comm);
            return Comm;
        }

        private static double GetNetValue(double value, double comm)
        {
            double netValue = value - comm;
            Console.WriteLine(netValue);
            return netValue;
        }

    }
}
