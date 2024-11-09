using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;
using datastructure;
using System.IO;
using System.Diagnostics.Eventing.Reader;

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
            Console.WriteLine("Phim da duoc them thanh cong");
            db.saveMovieData(_data);
        }
        public void RemoveMovie(string id)
        {
            if (_data.Movies.size == 0)
            {
                Console.WriteLine("Danh sách phim rỗng, không thể xóa.");
                return;
            }

            // Tìm phim cần xóa
            Movies deleteMovie = _data.Movies.Find(m => m.movieID == id);

            // Kiểm tra nếu phim tồn tại
            if (!deleteMovie.Equals(default(Movies)))
            {
                // Xóa phim khỏi danh sách
                _data.Movies.Remove(m => m.movieID == id);
                Console.WriteLine("Phim da duoc xoa thanh cong!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Khong tim thay phim co ID: " + id);
            }
        }

        public void UpdateMovie(Movies updatedMovie)
        {
            bool updated = _data.Movies.Update(m => m.movieID == updatedMovie.movieID, updatedMovie);
            if (updated)
            {
                Console.WriteLine("Phim da duoc cap nhat thanh cong!");
                db.saveMovieData(_data);
            }
            else
            {
                Console.WriteLine("Khong tim thay phim co " + updatedMovie.movieID);
            }
        }
        public void DisplayMovie()
        {
            _data.Movies.Display();
        }
    }
}

