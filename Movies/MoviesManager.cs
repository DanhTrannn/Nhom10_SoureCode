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

        public void AddMovie(Movies movie)
        {
            _data.movies.AddLast(movie);
            Console.WriteLine("Movie is successfully added!");
            db.saveMovieData(_data);
        }
        public void RemoveMovie(string targetID)
        {
            if (_data.movies.size == 0)
            {
                Console.WriteLine("Movies list is empty, can't remove");
                return;
            }

            // Tìm phim cần xóa
            Movies deletedMovie = _data.movies.Find(mv => mv.movieID == targetID);

            // Kiểm tra nếu phim tồn tại
            if (!deletedMovie.Equals(default(Movies)))
            {
                // Xóa phim khỏi danh sách
                _data.movies.Remove(mv => mv.movieID == targetID);
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
            bool updated = _data.movies.Update(mv => mv.movieID == updatedMovie.movieID, updatedMovie);
            if (updated)
            {
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
            _data.movies.Display();
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
    }
}

