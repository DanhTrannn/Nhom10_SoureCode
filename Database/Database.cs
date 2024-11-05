using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataStructure;
using System.Threading;
namespace Database
{
    public class database
    {
        public string customerFilePath = "Customer.txt";
        public string movieFilePath = "Movies.txt";
        public string showTimeFilePath = "Showtime.txt";
        public void loadCustomerData(datastructure data)
        {
            if (File.Exists(customerFilePath))
            {
                var lines = File.ReadAllLines(customerFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        Customer tmp = new Customer();
                        tmp.id = (parts[0]);
                        tmp.name = (parts[1]);
                        tmp.email = (parts[2]);
                        tmp.phoneNumber = (parts[3]);
                        tmp.personalCode = (parts[4]);
                        data.Customers.Add(tmp);
                    }
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại file: " + customerFilePath);
            }
        }

        public void loadMovieData(datastructure data)
        {
            if(File.Exists(movieFilePath))
            {
                var lines = File.ReadAllLines(movieFilePath);
                foreach(var line in lines){ 
                    var parts = line.Split(',');
                    if(parts.Length == 4)
                    {
                        Movies tmp = new Movies();
                        tmp.movieID = (parts[0]);
                        tmp.movieName = (parts[1]);
                        tmp.genre = (parts[2]);
                        tmp.duration = (parts[3]);
                        data.Movies.Add(tmp);
                    }
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại file: " + movieFilePath);
            }
        }

        public void loadShowtimeData(datastructure data)
        {
            if (File.Exists(showTimeFilePath))
            {
                var lines = File.ReadAllLines(showTimeFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        ShowTime tmp = new ShowTime();
                        tmp.movieID = parts[0];
                        tmp.showDateTime = (DateTime.Parse(parts[1]));
                        tmp.hall = (parts[2]);
                        data.Showtimes.Add(tmp);
                    }
                }

            }
            else
            {
                Console.WriteLine("Không tồn tại file: " + showTimeFilePath);
            }
        }
        public void saveCustomerData(datastructure data)
        {
            using (var writer = new StreamWriter(customerFilePath))
            {
                foreach (var customer in data.Customers)
                {
                    writer.WriteLine($"{customer.id},{customer.name},{customer.email},{customer.phoneNumber},{customer.personalCode}");
                }
            }
        }

        public void saveMovieData(datastructure data)
        {
            using (var writer = new StreamWriter(movieFilePath))
            {
                foreach (var movie in data.Movies)
                {
                    writer.WriteLine($"{movie.movieID},{movie.movieName},{movie.genre},{movie.duration}");
                }
            }
        }

        public void saveShowtimeData(datastructure data)
        {
            using (var writer = new StreamWriter(showTimeFilePath))
            {
                foreach (var showtime in data.Showtimes)
                {
                    writer.WriteLine($"{showtime.movieID},{showtime.showDateTime},{showtime.hall}");
                }
            }
        }
    }
}
