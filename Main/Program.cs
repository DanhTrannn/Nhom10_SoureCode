using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datastructure;
using database;
using Customer;
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
        }
    }
}
