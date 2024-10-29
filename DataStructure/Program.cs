using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public struct customer
    {
        private string id;
        private string name;
        private string email;
        private string phoneNumber;
        private string personalCode;
        public customer(string id, string name, string email, string phoneNumber, string personalCode)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.personalCode = personalCode;
        }
        public void setID(string id)
        {
            this.id = id;
        }
        public string getId()
        {
            return this.id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return this.email;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public string getPhoneNumber()
        {
            return this.phoneNumber;
        }
        public void setPersonalCode(string personalCode)
        {
            this.personalCode = personalCode;
        }
        public string getPersonalCode()
        {
            return this.personalCode;
        }
    }


    public struct movies
    {
        private string movieID;
        private string movieName;
        private string genre;
        private string duration;

        public movies(string movieID, string movieName, string genre, string duration)
        {
            this.movieID = movieID;
            this.movieName = movieName;
            this.genre = genre;
            this.duration = duration;
        }

        public void setMovieID(string movieID)
        {
            this.movieID = movieID;
        }
        public String getMovieID()
        {
            return this.movieID;
        }
        public void setMovieName(String movieName)
        {
            this.movieName = movieName;
        }
        public string getMovieName()
        {
            return this.movieName;
        }
        public void setGenre(String genre)
        {
            this.genre = genre;
        }
        public string getGenre()
        {
            return this.genre;
        }

        public void setDuration(String duration)
        {
            this.duration = duration;
        }
        public string getDuration()
        {
            return this.duration;
        }
    }


    public struct showtime
    {
        private string movieID;
        private string show;
        private string hall;

        public showtime(string movieID, string show, string hall)
        {
            this.movieID = movieID;
            this.show = show;
            this.hall = hall;
        }

        public void setMovieID(string MovieID)
        {
            this.movieID = MovieID;
        }
        public string getMovieID()
        {
            return this.movieID;
        }

        public void setShow(String show)
        {
            this.show = show;
        }
        public string getShow()
        {
            return this.show;
        }
        public void setHall(String hall)
        {
            this.hall = hall;
        }
        public string getHall()
        {
            return this.hall;
        }
    }
    public class datastructure
    {
        public List<customer> Customers = new List<customer>();
        public List<movies> Movies = new List<movies>();
        public List<showtime> Showtimes = new List<showtime>();
    }
}
