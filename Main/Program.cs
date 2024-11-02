using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using Database;
using Customer;
using Movies;
using Showtime;
using System.Security.Cryptography;
namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            datastructure data = new datastructure();
            database db = new database();
            db.loadCustomerData(data);
            db.loadMovieData(data);
            db.loadShowtimeData(data);

            CustomerManager customerManager = new CustomerManager(data);
            MoviesManager moviesManager = new MoviesManager(data);
            ShowtimeManager showtimeManager = new ShowtimeManager(data);
        }
    }
}
