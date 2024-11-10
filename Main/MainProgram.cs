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
using System.Runtime.InteropServices;

namespace main
{
    public class MainProgram
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
                    MovieManagement(moviesManager);
                }
                else if (choice == "3")
                {
                    ShowtimeManagement(showtimeManager);
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
                Console.WriteLine("||  1. Add Customer                  ||");
                Console.WriteLine("||  2. Edit Customer                 ||");
                Console.WriteLine("||  3. Delete Customer               ||");
                Console.WriteLine("||  4. Search Customer               ||");
                Console.WriteLine("||  5. Display All Customers         ||");
                Console.WriteLine("||  0. Back to Main Menu             ||");
                Console.WriteLine("======================================");
                Console.Write("Please select an option (0-5): ");
                string customerOptions = Console.ReadLine();
                if(customerOptions == "1")
                {
                    Console.Write("Enter Customer's ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Enter Customer's Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Customer's Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Customer's PhoneNumber: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Enter Customer's PersonalCode: ");
                    string personalCode = Console.ReadLine();
                    Customer customer = new Customer(id, name, email, phoneNumber, personalCode);
                    customerManager.AddCustomer(customer);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if(customerOptions == "2")
                {
                    Console.Write("Enter Customer's ID want to edit: ");
                    string id = Console.ReadLine();
                    Console.Write("Enter Customer's Name want to edit: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Customer's Email want to edit: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Customer's PhoneNumber want to edit: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Enter Customer's PersonalCode want to edit: ");
                    string personalCode = Console.ReadLine();
                    Customer updateCustomer = new Customer(id, name, email, phoneNumber, personalCode);
                    customerManager.UpdateCustomer(updateCustomer);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if(customerOptions == "3")
                {
                    Console.Write("Enter Customer's ID want to delete: ");
                    string id = Console.ReadLine();
                    customerManager.RemoveCustomer(id);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (customerOptions == "4")
                {
                    Console.Write("Enter Customer's PhoneNumber want to find: ");
                    string phonenumber = Console.ReadLine();
                    customerManager.FindCustomer(phonenumber);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (customerOptions == "5")
                {
                    customerManager.DisplayCustomer();
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if(customerOptions == "0")
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
        public static void MovieManagement(MovieManager movieManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("          MOVIE MANAGEMENT            ");
                Console.WriteLine("======================================");
                Console.WriteLine("||  1. Add Movie                     ||");
                Console.WriteLine("||  2. Edit Movie                    ||");
                Console.WriteLine("||  3. Delete Movie                  ||");
                Console.WriteLine("||  4. Search Movie                  ||");
                Console.WriteLine("||  5. Display All Movies            ||");
                Console.WriteLine("||  0. Back to Main Menu             ||");
                Console.WriteLine("======================================");
                Console.Write("Please select an option (0-5): ");
                string movieOptions = Console.ReadLine();
                if (movieOptions == "1")
                {
                    Console.Write("Enter Movie's ID: ");
                    string movieID = Console.ReadLine();
                    Console.Write("Enter Movie's name: ");
                    string movieName = Console.ReadLine();
                    Console.Write("Enter Movie's genre: ");
                    string movieGenre = Console.ReadLine();
                    Console.Write("Enter Movie's duration: ");
                    string movieDuration = Console.ReadLine();

                    Movies newMovie = new Movies(movieID, movieName, movieGenre, movieDuration);
                    movieManager.AddMovie(newMovie);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (movieOptions == "2")
                {
                    Console.Write("Enter Movie's ID want to update: ");
                    string movieID = Console.ReadLine();
                    Console.Write("Enter Movie's name want to update: ");
                    string movieName = Console.ReadLine();
                    Console.Write("Enter Movie's genre want to update: ");
                    string movieGenre = Console.ReadLine();
                    Console.Write("Enter Movie's duration want to update: ");
                    string movieDuration = Console.ReadLine();

                    Movies updatedMovies = new Movies(movieID, movieName, movieGenre, movieDuration);
                    movieManager.UpdateMovie(updatedMovies);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (movieOptions == "3")
                {
                    Console.Write("Enter Movie's ID want to remove: ");
                    string movieID = Console.ReadLine();

                    movieManager.RemoveMovie(movieID);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (movieOptions == "4")
                {
                    Console.Write("Enter Movie's name to find: ");
                    string movieName = Console.ReadLine().ToLower();
                    movieManager.FindMovie(movieName);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (movieOptions == "5")
                {
                    Console.WriteLine("List of movies: ");
                    movieManager.DisplayMovie();
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (movieOptions == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again!");
                }
            }
        }
        public static void ShowtimeManagement(ShowTimeManager showTimeManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("        SHOWTIME MANAGEMENT           ");
                Console.WriteLine("======================================");
                Console.WriteLine("||  1. Add Showtime                  ||");
                Console.WriteLine("||  2. Delete Showtime               ||");
                Console.WriteLine("||  3. Update Showtime               ||");
                Console.WriteLine("||  4. Display Showtimes             ||");
                Console.WriteLine("||  0. Back to Main Menu             ||");
                Console.WriteLine("======================================");
                Console.Write("Please select an option (0-4): ");
                string showTimeOptions = Console.ReadLine();
                if (showTimeOptions == "1")
                {
                    Console.Write("Enter Movie's ID: ");
                    string movieID = Console.ReadLine();
                    bool check = false;
                    DateTime myDateTime = DateTime.Now;
                    do
                    {
                        check = false;
                        Console.Write("Enter movie's date and time (witht format yyyy-MM-dd HH:mm:ss): ");
                        string input = Console.ReadLine();
                        try
                        {
                            myDateTime = DateTime.Parse(input);
                        }
                        catch (FormatException)
                        {
                            check = true;
                            Console.WriteLine("Date and time is invalid format!");
                        }
                    } while (check);

                    Console.Write("Enter movie's hall: ");
                    string movieHall = Console.ReadLine();
                    ShowTime newShowTime = new ShowTime(movieID, myDateTime, movieHall);
                    showTimeManager.AddShowTime(newShowTime);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (showTimeOptions == "2")
                {
                    Console.Write("Enter Movie's ID: ");
                    string movieID = Console.ReadLine();
                    showTimeManager.RemoveShowTime(movieID);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (showTimeOptions == "3")
                {
                    Console.Write("Enter movie's ID: ");
                    string movieID = Console.ReadLine();
                    bool check = false;
                    DateTime myDateTime = DateTime.Now;
                    do
                    {
                        check = false;
                        Console.Write("Enter Movie's Date and Time (format yyyy-MM-dd HH:mm:ss): ");
                        string input = Console.ReadLine();
                        try
                        {
                            myDateTime = DateTime.Parse(input);
                        }
                        catch (FormatException)
                        {
                            check = true;
                            Console.WriteLine("Date and time is invalid format!");
                        }
                    } while (check);

                    Console.Write("Enter movie's hall: ");
                    string movieHall = Console.ReadLine();
                    ShowTime newShowTime = new ShowTime(movieID, myDateTime, movieHall);
                    showTimeManager.UpdateShowTime(newShowTime);
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (showTimeOptions == "4")
                {
                    Console.WriteLine("List of showtime: ");
                    showTimeManager.DisplayShowTime();
                    Console.Write("Press Enter to continue: ");
                    Console.ReadLine();
                }
                else if (showTimeOptions == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again!");
                }
            }
        }
    }
}
