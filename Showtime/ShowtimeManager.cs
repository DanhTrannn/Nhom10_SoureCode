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
        public void AddShowTime(ShowTime newShowTime)
        {
            _data.showtimes.AddLast(newShowTime);
            _data.undo.Push(new UndoAction("Add", newShowTime));
            Console.WriteLine("Showtime is successfully added!");
            db.saveShowtimeData(_data);
        }

        public void RemoveShowTime(string targetID)
        {
            if (_data.showtimes.size == 0)
            {
                Console.WriteLine("Showtimes list is empty, can't remove!");
                return;
            }
            // Truyền vào một biểu thức lambda để xác định phần tử st trong dslk showtimes có thuộc tính movieID trùng với ID cần tìm
            ShowTime deletedShowTime = _data.showtimes.Find(st => st.movieID == targetID);
            if (!deletedShowTime.Equals(null))
            {
                _data.showtimes.Remove(s => s.movieID == targetID);
                _data.undo.Push(new UndoAction("Remove", deletedShowTime));
                Console.WriteLine("Showtime is successfully removed!");
                db.saveShowtimeData(_data);
            }
            else
            {
                Console.WriteLine("Showtime with ID " + targetID + " is not found!");
            }
        }

        public void UpdateShowTime(ShowTime newShowTime)
        {
            ShowTime oldShowTime = _data.showtimes.Find(st => st.movieID == newShowTime.movieID);
            bool updated = _data.showtimes.Update(st => st.movieID == newShowTime.movieID, newShowTime);
            if (updated)
            {
                Console.WriteLine("Showtime is updated!");
                _data.undo.Push(new UndoAction("Update", oldShowTime));
                db.saveShowtimeData(_data);
            }
            else
            {
                Console.WriteLine("Showtime with ID " + newShowTime.movieID + " is not found!");
            }
        }

        public void DisplayShowTime()
        {
            _data.showtimes.Display();
        }
        public void undo()
        {
            if( _data.undo.Count() > 0)
            {
                UndoAction lastAction = _data.undo.Pop();
                if (lastAction.action.Equals("Add"))
                {
                    _data.showtimes.Remove(st => st.movieID == lastAction.oldshowtime.movieID);
                    Console.WriteLine("Undo success");
                }
                else if (lastAction.action.Equals("Remove"))
                {
                    _data.showtimes.AddLast(lastAction.oldshowtime);
                    Console.WriteLine("Undo success");
                }
                else if (lastAction.action.Equals("Update"))
                {
                    _data.showtimes.Update(st => st.movieID == lastAction.oldshowtime.movieID, lastAction.oldshowtime);
                    Console.WriteLine("Undo success");
                }
                db.saveShowtimeData(_data);
            }
            else
            {
                Console.WriteLine("No action");
            }
        }
    }
}