using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;
using datastructure;
namespace ShowtimeManager
{
    public class ShowTimeManager
    {
        private DataStructure _data;
        private DataBase db;

        public ShowTimeManager(DataStructure data)
        {
            this._data = data;
            db = new DataBase();
        }


        public void AddShowTime(ShowTime newShowtime)
        {
            _data.Showtimes.AddLast(newShowtime);
            Console.WriteLine("Add showtime success!");
            db.saveShowtimeData(_data);
        }

        public void RemoveShowTime(string data)
        {
            ShowTime DeleteShowTime = _data.Showtimes.Find(s => s.movieID == data);
            if (!DeleteShowTime.Equals(null))
            {
                _data.Showtimes.Remove(s => s.movieID == data);
                Console.WriteLine("Show time is removed success!");
                db.saveShowtimeData(_data);
            }
            else
            {
                Console.WriteLine("Show time ID is not found!" + data);
            }
        }

        public void UpdateShowTime(ShowTime newShowtime)
        {
            bool updated = _data.Showtimes.Update(s => s.movieID == newShowtime.movieID, newShowtime);
            if (updated)
            {
                Console.WriteLine("Showtime is updated!");
                db.saveShowtimeData(_data);
            }
            else
            {
                Console.WriteLine("Showtime " + newShowtime.movieID + " is not found!");
            }
        }

        public void DisplayShowTime()
        {
            _data.Showtimes.Display();
        }
    }
}