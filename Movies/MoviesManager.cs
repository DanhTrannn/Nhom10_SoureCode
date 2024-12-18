using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;
using datastructure;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace MoviesManager
{
    public class MovieManager
    {
        private DataStructure _data;
        private DataBase db;
        public MovieManager(DataStructure data)
        {
            _data = data;
            db = new DataBase();
        }
        public void AddMovie(Movies newMovie)
        {
            Movies check = _data.movies.Find(mv => mv.movieID == newMovie.movieID);
            if (check.Equals(default(Movies)))
            {
                _data.movies.AddLast(newMovie);
                _data.undo.Push(new UndoAction("Add", newMovie));
                Console.WriteLine("Movie is successfully added!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Have movies'ID " + newMovie.movieID + " can't add new, only update");
            }
        }
        public void RemoveMovie(string targetID)
        {
            if (_data.movies.size == 0)
            {
                Console.WriteLine("Movies list is empty, can't remove");
                return;
            }
            Movies deletedMovie = _data.movies.Find(mv => mv.movieID == targetID);
            if (!deletedMovie.Equals(default(Movies)))
            {
                _data.movies.Remove(mv => mv.movieID == targetID);
                _data.undo.Push(new UndoAction("Remove",deletedMovie));
                Console.WriteLine("Movie is successfully deleted!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Movie with ID " + targetID + " is not found!");
            }
        }

        public void UpdateMovie(Movies updatedMovie)
        {
            Movies oldMovie = _data.movies.Find(mv => mv.movieID == updatedMovie.movieID);
            bool updated = _data.movies.Update(mv => mv.movieID == updatedMovie.movieID, updatedMovie);
            if (updated)
            {
                _data.undo.Push(new UndoAction("Update", oldMovie));
                Console.WriteLine("Movie is successfully updated!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Movie with ID" + updatedMovie.movieID + " is not found!");
            }
        }
        public void DisplayMovie()
        {
            if (_data.movies.size > 0)
            {
                _data.movies.Display();
            }
            else
            {
                Console.WriteLine("Nothing to display, please add new movie!");
            }
        }
        public void FindMovie(string targetName)
        {
            Movies movieToFind = _data.movies.Find(mv => mv.movieName == targetName);

            if (!movieToFind.Equals(default(Movies)))
            {
                Console.WriteLine("Movie is found!");
                Console.WriteLine(movieToFind);
            }
            else
            {
                Console.WriteLine("Movie with name " + targetName + " is not found!");
            }
        }
        public void FindShowTimeByMovieName(string movieName)
        {
            if(_data.movies.size == 0)
            {
                Console.WriteLine("Movies list is empty!");
                return;
            }
            string movieID = "";
            Node<Movies> tmp = _data.movies.head;
            while(tmp != null)
            {
                if(tmp.data.movieName.ToLower() == movieName.ToLower())
                {
                    movieID = tmp.data.movieID;
                    break;
                }
                tmp = tmp.next;
            }
            if (!movieID.Equals(""))
            {
                if (_data.showtimes.size == 0)
                {
                    Console.WriteLine("Not found any showtime has movie name: " + movieName);
                }
                else
                {
                    Node<ShowTime> current = _data.showtimes.head;
                    while (current != null)
                    {
                        if (current.data.movieID.Equals(movieID))
                        {
                            Console.WriteLine(current.data);
                        }
                        current = current.next;
                    }
                }
            }
            else
            {
                Console.WriteLine("Not found any movie has name: " + movieName);
            }
        }
        public void undo()
        {
            if(_data.undo.Count() > 0)
            {
                UndoAction lastAction = _data.undo.Pop();
                if(lastAction.action.Equals("Add"))
                {
                    _data.movies.Remove(mv => mv.movieID == lastAction.oldmovie.movieID);
                    Console.WriteLine("Undo successfully!");
                }
                else if(lastAction.action.Equals("Remove"))
                {
                    _data.movies.AddLast(lastAction.oldmovie);
                    Console.WriteLine("Undo successfully!");
                }
                else if(lastAction.action.Equals("Update"))
                {
                    bool updated = _data.movies.Update(mv => mv.movieID == lastAction.oldmovie.movieID, lastAction.oldmovie);
                    if (updated)
                    {
                        Console.WriteLine("Undo successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }
    }
}

