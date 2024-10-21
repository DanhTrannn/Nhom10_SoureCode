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
    public class LoadData
    {
        string customerFilePath = "Customer.txt";
        string movieFilePath = "Movies.txt";
        string showTimeFilePath = "Showtime.txt";
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
                        customer tmp = new customer();
                        tmp.setID(parts[0]);
                        tmp.setName(parts[1]);
                        tmp.setEmail(parts[2]);
                        tmp.setPhoneNumber(parts[3]);
                        tmp.setCCCD(parts[4]);
                        data.Customers.Add(tmp);
                    }
                }
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
                        movies tmp = new movies();
                        tmp.setMovieID(parts[0]);
                        tmp.setMovieName(parts[1]);
                        tmp.setGenre(parts[2]);
                        tmp.setDuration(parts[3]);
                        data.Movies.Add(tmp);
                    }
                }

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
                        showtime tmp = new showtime();
                        tmp.setMovieID(parts[0]);
                        tmp.setShow(parts[1]);
                        tmp.setHall(parts[2]);
                        data.Showtimes.Add(tmp);
                    }
                }

            }
        }
    }
}
