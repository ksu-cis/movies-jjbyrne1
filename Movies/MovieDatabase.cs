﻿using System;
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
    public static class MovieDatabase
    {
        private static List<Movie> moviesList;

        public static List<Movie> All
        {
            get
            {
                if (moviesList == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        moviesList = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return moviesList;
            }
        }

        public static List<Movie> Search(List<Movie> movies, string searchString)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Title != null && movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(movie);
                }
            }
            return results;
        }

        public static List<Movie> FilterbyMPAA(List<Movie> movies, List<string> ratings)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating))
                {
                    results.Add(movie);
                }
            }
            return results;
        }

        public static List<Movie> FilterbyMinIMDBRating(List<Movie> movies, float minRating)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (minRating <= movie.IMDB_Rating)
                {
                    results.Add(movie);
                }
            }
            return results;
        }
        public static List<Movie> FilterbyMaxIMDBRating(List<Movie> movies, float maxRating)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (maxRating >= movie.IMDB_Rating)
                {
                    results.Add(movie);
                }
            }
            return results;
        }
    }
}
