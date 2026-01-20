using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kotikirjasto
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"{Title} | {Author} | {Year} | {Genre}";
        }
    }

    class Program
    {
        static List<Book> library = new List<Book>();
        static string filePath = "kirjat.txt";

        static void Main(string[] args)
        {
            LoadFromFile();

            while (true)
            {
                Console.WriteLine("\n📚 Kotikirjasto");
                Console.WriteLine("1. Lisää kirja");
                Console.WriteLine("2. Poista kirja");
                Console.WriteLine("3. Näytä kaikki kirjat");
                Console.WriteLine("4. Näytä kirjat genren mukaan");
                Console.WriteLine("5. Etsi kirja");
                Console.WriteLine("6. Tallenna ja poistu");

                Console.Write("Valinta: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        ShowAllBooks();
                        break;
                    case "4":
                        ShowBooksByGenre();
                        break;
                    case "5":
                        SearchBooks();
                        break;
                    case "6":
                        SaveToFile();
                        return;
                    default:
                        Console.WriteLine("Virheellinen valinta.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Kirjan nimi: ");
            string title = Console.ReadLine();

            Console.Write("Kirjoittaja: ");
            string author = Console.ReadLine();

            Console.Write("Julkaisuvuosi: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Genre: ");
            string genre = Console.ReadLine();

            library.Add(new Book
            {
                Title = title,
                Author = author,
                Year = year,
                Genre = genre
            });

            Console.WriteLine("Kirja lisätty!");
        }

        static void RemoveBook()
        {
            ShowAllBooks();
            Console.Write("Anna poistettavan kirjan numero: ");

            if (int.TryParse(Console.ReadLine(), out int index) &&
                index > 0 && index <= library.Count)
            {
                library.RemoveAt(index - 1);
                Console.WriteLine("Kirja poistettu.");
            }
            else
            {
                Console.WriteLine("Virheellinen numero.");
            }
        }

        static void ShowAllBooks()
        {
           
        }

        static void ShowBooksByGenre()
        {
            
        }

        static void SearchBooks()
        {
            
           
        }

        static void SaveToFile()
        {
           
        }

        static void LoadFromFile()
        {
           
            
        }
    }
}
