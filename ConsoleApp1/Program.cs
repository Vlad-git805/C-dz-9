using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public enum Genre
    {
        Horor = 1, comedy, cartoon, romance, drama, noGenre = 0
    }

    public class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int CuontOfFilms { get; set; }

        public Director(string FirstName, string LasttName, int CuontOfFilms)
        {
            this.FirstName = FirstName;
            this.LasttName = LasttName;
            this.CuontOfFilms = CuontOfFilms;
        }

        public object Clone()
        {
            Director copy = (Director)this.MemberwiseClone();
            return copy;
        }

        public override string ToString()
        {
            return $"Name {FirstName}\n" +
                   $"Surname {LasttName} \n" +
                   $"Cuont of films {CuontOfFilms} \n";

        }
    }

    public class Movie : IComparable<Movie>, ICloneable
    {
        public string Title { get; set; }
        public Director director { get; set; }
        public string Country { get; set; }
        public Genre genre { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public object Clone()
        {
            Movie copy = (Movie)this.MemberwiseClone();

            //copy.director = new Director(this.director.FirstName, this.director.LasttName, this.director.CuontOfFilms);
            copy.director = (Director)director.Clone();
            return copy;
        }

        public int CompareTo(Movie other)
        {
            return this.Year.CompareTo(other.Year);
        }

        public override string ToString()
        {
            return $"Title {Title}\n" +
                   $"Director {director}\n" +
                   $"Country {Country}\n" +
                   $"Genre {genre}\n" +
                   $"Year {Year}\n" +
                   $"Rating {Rating}\n";

        }
    }

    public class Сinema : IEnumerable
    {
        public string Address { get; set; }
        public Movie[] movie;

        public Сinema()
        {
            Address = "no adres";
            movie = new Movie[]
            {
                new Movie()
                {
                    Title = "1",
                    director = new Director("Vlad", "Zhomyruk", 10),
                    Country = "Ykrainian",
                    genre = (Genre)1,
                    Year = 2010,
                    Rating = 1000000,
                },
                new Movie()
                {
                    Title = "2",
                    director = new Director("lol", "kek", 10),
                    Country = "Ykrainian",
                    genre = (Genre)2,
                    Year = 1995,
                    Rating = 15000000,
                },
                new Movie()
                {
                    Title = "3",
                    director = new Director("vas9", "fleksivnuk", 10),
                    Country = "Ykrainian",
                    genre = (Genre)3,
                    Year = 2018,
                    Rating = 50000,
                }
            };
        }


        public Сinema(string Address) : this()
        {
            this.Address = Address;
        }

        public void Sort()
        {
            Array.Sort(movie);
        }

        public void Sort(IComparer<Movie> comparer)
        {
            Array.Sort(movie, comparer);
        }

        public IEnumerator GetEnumerator()
        {
            return movie.GetEnumerator();
        }
    }

    class CompareByRating : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    class CompareByYear : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
