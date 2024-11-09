using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using DataStructure;
using System.IO;
using System.Diagnostics.Eventing.Reader;

public class MovieManager
{
    private DataStructure _data;

    public MovieManager(DataStructure data)
    {
        _data = data;
    }

    public void AddMovie(Movie movie) => _data.Movies.Add(movie);
    public void RemoveMovie(string id) => _data.Movies.RemoveAll(m => m.Id == id);
    public void UpdateMovie(Movie updatedMovie)
    {
        for (int i = 0; i < _data.Movies.Count; i++)
        {
            if (_data.Movies[i].Id == updatedMovie.Id)
            {
                _data.Movies[i] = updatedMovie;
                break;
            }
        }
    }

    public void SaveMovies()
    {
        using (var writer = new StreamWriter(Database.movieFilePath))
        {
            foreach (var movie in _data.Movies)
            {
                writer.WriteLine($"{movie.Id},{movie.Title},{movie.Genre},{movie.Duration}");
            }
        }
    }

    public void LoadMovies()
    {
        if (File.Exists(Database.movieFilePath))
        {
            using (var reader = new Streamer(Databse.movieFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        var movie = new Movie(parts[0], parts[1], parts[2], parts[3]);
                        _data.Movies.Add(movie);
                    }
                }
            }
        }
    }
}

public static class Database
{
    public static string movieFilePath = "movíes.txt";
}
