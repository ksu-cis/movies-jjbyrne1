using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public class MovieDatabase
    {
        private List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public MovieDatabase() {
            
            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        public List<Movie> All { get { return movies; } }

        public List<Movie> Search(string searchString)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Title != null && movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }

        public List<Movie> Filter(List<string> ratings)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating))
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }

        public List<Movie> SearchAndFilter(string searchString, List<string> ratings)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Title != null && movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    if (ratings.Contains(movie.MPAA_Rating)) movieList.Add(movie);
                }
            }
            return movieList;
        }
    }
}
