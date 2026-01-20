using System;
using System.Collections.Generic;
using System.IO;

namespace Kotikirjasto
{
    class Program
    {
        static List<Book> library = new List<Book>();
        static string filePath = "kirjat.txt";

        static void Main(string[] args)
        {
            LoadFromFile();

            while (true)
            {
                Console.WriteLine("\nHome library");
                Console.WriteLine("1. Add book.\n2. Delete book. \n3. Show all books. \n4. Show by genre. \n5. Search books. \n6. Save and exit.");
                Console.Write("Choose:");
                string? choice = Console.ReadLine();

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
                        Console.WriteLine("Wrong choice.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Book title: ");
            string? title = Console.ReadLine();

            Console.Write("Author: ");
            string? author = Console.ReadLine();

            Console.Write("Publication year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Genre: ");
            string? genre = Console.ReadLine();

            library.Add(new Book(title, author, year, genre));

            Console.WriteLine("Book added!");
        }

        static void RemoveBook()
        {
            ShowAllBooks();
            Console.Write("Give number of book: ");

            if (int.TryParse(Console.ReadLine(), out int index) &&
                index > 0 && index <= library.Count)
            {
                library.RemoveAt(index - 1);
                Console.WriteLine("Book deleted.");
            }
            else
            {
                Console.WriteLine("Choose another number.");
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
            Console.WriteLine("Search book by title or author:");
            string? search = Console.ReadLine();
            bool found = false;

            foreach (Book book in library)
            {
                if (book.Title.ToLower().Contains(search?.ToLower() ?? "") ||
                    (book.Author.ToLower().Contains(search?.ToLower() ?? "")))
                {
                    Console.WriteLine(book.ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Book or author not found.");
            }
        }

        static void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Book book in library)
                {
                    writer.WriteLine($"{book.Title},{book.Author},{book.Year},{book.Genre}");
                }
            }
            Console.WriteLine("Books saved!");
        }

        static void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        library.Add(new Book(parts[0], parts[1], int.Parse(parts[2]), parts[3]));
                    }
                }
            }
        }
    }
}