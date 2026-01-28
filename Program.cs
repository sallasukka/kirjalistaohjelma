using System;
using System.Collections.Generic;
using System.IO;

namespace Kotikirjasto
{
    class Program
    {
        //create a list of books
        static List<Book> library = new List<Book>();
        static string filePath = "kirjat.txt";

        //main-method that asks user what they want 
        static void Main(string[] args)
        {
            //loads the previously saved book file if that exists
            LoadFromFile();

            while (true)
            {
                Console.WriteLine("\nHome library");
                Console.WriteLine("1. Add book.\n2. Delete book. \n3. Show all books. \n4. Show by genre. \n5. Search books. \n6. Save and exit.");
                Console.Write("Choose:");
                string? choice = Console.ReadLine();

                //user chooses option
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
        //method that adds a book to the list 
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
        //method that removes book from the list according to its number
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
            if (library == null)
            {
                Console.WriteLine("The list does not exist.");
            }
            else if (library.Count == 0) 
            {
                Console.WriteLine("The list is empty.");
            }
            else library.ForEach(k => Console.WriteLine(k));
        }

        static void ShowBooksByGenre()
        {
            if (library == null)
            {
               Console.WriteLine("Library is not initialized!");
               return;
            }

            Console.Write("What genre are you looking for? ");
            string genre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("You didn't enter a genre!");
                return; 
            }

            var found = library.Where(k => k != null && string.Equals(k.Genre, genre, StringComparison.OrdinalIgnoreCase)).ToList();

            if (found.Count == 0)
            { 
                Console.WriteLine("No books of this genre found!");
            }
            
            else found.ForEach(k => Console.WriteLine(k));
        }
        //searches books by title or author from the library
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
        //method that saves the books from library to file
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
        //method that loads all the books from the file to library
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