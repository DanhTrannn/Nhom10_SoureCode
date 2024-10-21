using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataStructure;
namespace Database
{
    public class SaveData
    {
        string customerFilePath = "Customer.txt";
        string movieFilePath = "Movies.txt";
        string showTimeFilePath = "Showtime.txt";
        public void saveCustomerData(datastructure data)
        {
            using (var writer = new StreamWriter(customerFilePath))
            {
                foreach(var customer in data.Customers)
                {
                    writer.WriteLine($"{customer.getId()},{customer.getName()},{customer.getEmail()},{customer.getPhoneNumber()},{customer.getCCCD()}");
                }
            }
        }

        public void saveMovieData(datastructure data)
        {
            using (var writer = new StreamWriter(movieFilePath))
            {
                foreach (var movie in data.Movies)
                {
                    writer.WriteLine($"{movie.getMovieID()},{movie.getMovieName()},{movie.getGenre()},{movie.getDuration()}");
                }
            }
        }

        public void saveShowtimeData(datastructure data)
        {
            using(var  writer = new StreamWriter(showTimeFilePath))
            {
                foreach(var showtime in data.Showtimes)
                {
                    writer.WriteLine($"{showtime.getMovieID()},{showtime.getShow()},{showtime.getHall()}");
                }
            }
        }
    }
}
