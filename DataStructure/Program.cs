using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace datastructure
{
    // Linked List build tay
    public struct Customer
    {
        public string id;
        public string name;
        public string email;
        public string phoneNumber;
        public string personalCode;
        public Customer(string id, string name, string email, string phoneNumber, string personalCode)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.personalCode = personalCode;
        }
    }


    public struct Movies
    {
        public string movieID;
        public string movieName;
        public string genre;
        public string duration;

        public Movies(string movieID, string movieName, string genre, string duration)
        {
            this.movieID = movieID;
            this.movieName = movieName;
            this.genre = genre;
            this.duration = duration;
        }

    }


    public struct ShowTime
    {
        public string movieID;
        public DateTime showDateTime;
        public string hall;

        public ShowTime(string movieID, DateTime showDateTime, string hall)
        {
            this.movieID = movieID;
            this.showDateTime = showDateTime;
            this.hall = hall;
        }
    }
    public class DataStructure
    {
        public LinkedList<Customer> Customers = new LinkedList<Customer>();
        public LinkedList<Movies> Movies = new LinkedList<Movies>();
        public LinkedList<ShowTime> Showtimes = new LinkedList<ShowTime>();
    }
}
