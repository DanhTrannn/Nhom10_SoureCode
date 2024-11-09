using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datastructure;
using database;
using CustomersManager;
using MoviesManager;
using ShowtimeManager;
using System.Security.Cryptography;
namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataStructure data = new DataStructure();
            DataBase db = new DataBase();
            db.loadCustomerData(data);
            db.loadMovieData(data);
            db.loadShowtimeData(data);

            CustomerManager customerManager = new CustomerManager(data);
            MovieManager moviesManager = new MovieManager(data);
            ShowTimeManager showtimeManager = new ShowTimeManager(data);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("||=====================================||");
                Console.WriteLine("||                                      ||");
                Console.WriteLine("||   WELCOME TO MOVIE THEATER MANAGEMENT ||");
                Console.WriteLine("||               MAIN MENU                ||");
                Console.WriteLine("||                                         ||");
                Console.WriteLine("||------------------------------------------||");
                Console.WriteLine("||   1.Customer Management                 ||");
                Console.WriteLine("||   2.Movie Management                   ||");
                Console.WriteLine("||   3.Showtime Management               ||");
                Console.WriteLine("||   0.Exit                             ||");
                Console.WriteLine("||=====================================||");
                Console.Write("Please select an option (0-3): ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    CustomerManagement(customerManager);
                }
                else if (choice == "2")
                {
                    MovieManagement();
                }
                else if (choice == "3")
                {
                    ShowtimeManagement();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Program is closing..........");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again!");
                }
            }
        }
        public static void CustomerManagement(CustomerManager customerManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("         CUSTOMER MANAGEMENT         ");
                Console.WriteLine("======================================");
                Console.WriteLine("||  1.1.1 Add Customer               ||");
                Console.WriteLine("||  1.1.2 Edit Customer              ||");
                Console.WriteLine("||  1.1.3 Delete Customer            ||");
                Console.WriteLine("||  1.1.4 Search Customer            ||");
                Console.WriteLine("||  1.1.5 Display All Customers      ||");
                Console.WriteLine("||  0. Back to Main Menu             ||");
                Console.WriteLine("======================================");
                Console.Write("Please select an option (0-5): ");
                string CustomerChoice = Console.ReadLine();
                if(CustomerChoice == "1")
                {
                    Console.Write("Enter Customer's ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Enter Customer's Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Customer's Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Customer's PhoneNumber: ");
                    string phonenumber = Console.ReadLine();
                    Console.Write("Enter Customer's PersonalCode: ");
                    string personalCode = Console.ReadLine();
                    Customer customer = new Customer(id,name,email,phonenumber,personalCode);
                    customerManager.AddCustomer(customer);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if(CustomerChoice == "2")
                {
                    Console.Write("Enter Customer's ID want to edit: ");
                    string id = Console.ReadLine();
                    Console.Write("Enter Customer's Name want to edit: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Customer's Email want to edit: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Customer's PhoneNumber want to edit: ");
                    string phonenumber = Console.ReadLine();
                    Console.Write("Enter Customer's PersonalCode want to edit: ");
                    string personalCode = Console.ReadLine();
                    Customer updateCustomer = new Customer(id, name,email,phonenumber, personalCode);
                    customerManager.UpdateCustomer(updateCustomer);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if( CustomerChoice == "3")
                {
                    Console.Write("Enter Customer's ID want to delete: ");
                    string id = Console.ReadLine();
                    customerManager.RemoveCustomer(id);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (CustomerChoice == "4")
                {
                    Console.Write("Enter Customer's PhoneNumber want to find: ");
                    string phonenumber = Console.ReadLine();
                    customerManager.FindCustomer(phonenumber);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (CustomerChoice == "5")
                {
                    customerManager.DisplayCustomer();
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if(CustomerChoice== "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again!");
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
            }
        }
        public static void MovieManagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("       🎞 MOVIE MANAGEMENT           ");
                Console.WriteLine("======================================");
                Console.WriteLine("||  1.2.1 Add Movie                  ||");
                Console.WriteLine("||  1.2.2 Edit Movie                 ||");
                Console.WriteLine("||  1.2.3 Delete Movie               ||");
                Console.WriteLine("||  1.2.4 Search Movie               ||");
                Console.WriteLine("||  1.2.5 Display All Movies         ||");
                Console.WriteLine("||  0. Back to Main Menu             ||");
                Console.WriteLine("======================================");
                Console.Write("Please select an option (0-5): ");
            }
        }
        public static void ShowtimeManagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("       🕒 SHOWTIME MANAGEMENT        ");
                Console.WriteLine("======================================");
                Console.WriteLine("||  1.3.1 Add Showtime               ||");
                Console.WriteLine("||  1.3.2 Delete Showtime            ||");
                Console.WriteLine("||  1.3.3 Update Showtime            ||");
                Console.WriteLine("||  1.3.4 Display Showtimes          ||");
                Console.WriteLine("||  0. Back to Main Menu             ||");
                Console.WriteLine("======================================");
                Console.Write("👉 Please select an option (0-4): ");

            }
        }
    }
}
