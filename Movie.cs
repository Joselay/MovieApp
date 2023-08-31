using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystemManagement
{
    public class Movie
    {
        public int movie_id { get; set; }
        public int user_id { get; set; }
        public int director_id { get; set; }
        public string description { get; set; }
        public decimal rating { get; set; }
        public int duration { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public byte[] movie_image { get; set; }
        public string quality { get; set; }
        public Movie(byte[] movie_image)
        {
            this.movie_image = movie_image;
        }
        public Movie(string title, string description, byte[] movie_image)
        {
            this.title = title;
            this.description = description;
            this.movie_image = movie_image;
        }
        public Movie(int movie_id, string title, string release_date)
        {
            this.movie_id = movie_id;
            this.title = title;
            this.release_date = release_date;
        }
        public Movie(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
        public Movie(int movie_id, int user_id, int director_id, string description, decimal rating, int duration, string release_date, string title, string quality)
        {
            this.movie_id = movie_id;
            this.user_id = user_id;
            this.director_id = director_id;
            this.description = description;
            this.rating = rating;
            this.duration = duration;
            this.release_date = release_date;
            this.title = title;
            this.quality = quality;
        }

        public Movie(int movie_id, int user_id, int director_id, string description, string title, byte[] movie_image)
        {
            this.movie_id = movie_id;
            this.user_id = user_id;
            this.director_id = director_id;
            this.description = description;
            this.title = title;
            this.movie_image = movie_image;
        }

    }
}
