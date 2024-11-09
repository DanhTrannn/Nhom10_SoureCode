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
            Console.WriteLine("Phim đã được thêm thành công.");
        }
        public void RemoveMovie(string id)
        {
            var node = _data.Movies.First;
            while (node != null)
            {
                if (node.Value.movieID == id)
                {
                    _data.Movies.Remove(node);
                    Console.WriteLine("Phim đã được xóa thành công.");
                    db.saveMovieData(_data);
                    return;
                }
                node = node.Next;
            }
            Console.WriteLine("Không tìm thấy phim với ID đã cho.");
        }

        public void UpdateMovie(Movies updatedMovie)
        {

        }
    }
}

