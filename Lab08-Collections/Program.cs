using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lab08_Collections.Classes;

namespace Lab08_Collections
{
    class Program
    {
        public static Library<Book> Library { get; set; }

        public static List<Book> BookBag { get; set; }

        static void Main(string[] args)
        {
            Library = new Library<Book>();
            BookBag = new List<Book>();

            LoadBooks();
            UserInterface();
        }

        static void UserInterface()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();

                Console.WriteLine("Welcome to Phil's lending library!");
                Console.WriteLine("Please pick an option: ");
                Console.WriteLine("1) View All Books");
                Console.WriteLine("2) Add New Book");
                Console.WriteLine("3) Borrow a Book");
                Console.WriteLine("4) Return a Book");
                Console.WriteLine("5) View Book Bag");
                Console.WriteLine("6) Exit");

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.Clear();

                        OutputBooks();

                        break;
                        /*
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please enter the following details: ");
                        Console.Write("Book Title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Author First Name: ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine();
                        */

                    case "3":
                        Console.Clear();

                        Dictionary<int, string> books = new Dictionary<int, string>();
                        Console.WriteLine("Which book would you like to borrow? Please only select the number.");
                        int counter = 1;
                        foreach (Book book in Library)
                        {
                            books.Add(counter, book.Title);
                            Console.WriteLine($"{counter++}. {book.Title} - {book.Author.FirstName} {book.Author.LastName}");
                        }

                        string response = Console.ReadLine();
                        int.TryParse(response, out int selection);
                        books.TryGetValue(selection, out string borrowtitle);
                        Borrow(borrowtitle);
                        break;
                    case "4":
                        ReturnBook();
                        break;
                    case "5":
                        Console.Clear();

                        foreach (Book book in BookBag)
                        {
                            Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
                        }
                        break;
                    case "6":
                        exit = true;
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Sorry, this is an invalid option...");
                        break;
                }

            }
        }

        static void AddABook(string title, string firstName, string lastName, int numberOfPages)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author() { FirstName = firstName, LastName = lastName },
                NumberOfPages = numberOfPages,
                Genre = Genre.Romance
            };

            Library.Add(book);
        }

        static void OutputBooks()
        {
            int counter = 1;
            foreach (Book book in Library)
            {
                Console.WriteLine($"{counter++}.{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
            }
        }

        static void LoadBooks()
        {
            Book a = new Book
            {
                Title = "Pride and Prejudice",
                Author = new Author() { FirstName = "Jane", LastName = "Austen" },
                Genre = Genre.Romance
            };

            Book b = new Book
            {
                Title = "1984",
                Author = new Author() { FirstName = "George", LastName = "Orwell" },
                Genre = Genre.Drama
            };

            Book c = new Book
            {
                Title = "The Hobbit",
                Author = new Author() { FirstName = "J.R.R.", LastName = "Tolkien" },
                Genre = Genre.Fantasy
            };

            Book d = new Book
            {
                Title = "The Lion, the Witch and the Wardrobe",
                Author = new Author() { FirstName = "C.S.", LastName = "Lewis" },
                Genre = Genre.Fantasy
            };

            Book e = new Book
            {
                Title = "Jane Eyre",
                Author = new Author() { FirstName = "Charlotte", LastName = "Bronte" },
                Genre = Genre.Drama
            };

            Library.Add(a);
            Library.Add(b);
            Library.Add(c);
            Library.Add(d);
            Library.Add(e);

        }

        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return?");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");
            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.Add(returnedBook);
        }

        public static Book Borrow(string title)
        {
            Book borrowedBook = null;
            foreach (Book book in Library)
            {
                if (book.Title == title)
                {
                    borrowedBook = book;
                    BookBag.Add(Library.Remove(borrowedBook));
                    break;
                }
            }
            return borrowedBook;
        }
    }
}
