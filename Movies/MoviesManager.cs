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
            _data.Movies.AddLast(movie);
            Console.WriteLine("Add movie success!");
            db.saveMovieData(_data);
        }
        public void RemoveMovie(string id)
        {
            if (_data.Movies.size == 0)
            {
                Console.WriteLine("Movie list is empty, can't remove");
                return;
            }

            // Tìm phim cần xóa
            Movies deleteMovie = _data.Movies.Find(m => m.movieID == id);

            // Kiểm tra nếu phim tồn tại
            if (!deleteMovie.Equals(default(Movies)))
            {
                // Xóa phim khỏi danh sách
                _data.Movies.Remove(m => m.movieID == id);
                Console.WriteLine("Movie is successfully deleted!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Movie " + id + " is not found!");
            }
        }

        public void UpdateMovie(Movies updatedMovie)
        {
            bool updated = _data.Movies.Update(m => m.movieID == updatedMovie.movieID, updatedMovie);
            if (updated)
            {
                Console.WriteLine("Movie is successfully updated!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Movie " + updatedMovie.movieID + " is not found!");
            }
        }
        public void DisplayMovie()
        {
            _data.Movies.Display();
        }
        public void FindMovie(string name)
        {
            Movies movieToFind = _data.Movies.Find(n => n.movieName == name);
            if (!movieToFind.Equals(default(Movies)))
            {
                Console.WriteLine("Movie has found!");
                Console.WriteLine(movieToFind);
            }
            else
            {
                Console.WriteLine("Movie is not found!");
            }
        }
    }
}

