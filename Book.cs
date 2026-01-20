using System;

namespace Kotikirjasto
{
    public class Book
    {
        //instance variables 
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, int year, string genre)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} | {Author} | {Year} | {Genre}";
        }
    }
}