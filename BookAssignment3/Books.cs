using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAssignment3
{
    internal class Books
    {

class Book
    {
        public int bookId;
        public string bookName;
        public string language;
        public double price;
        public string author;
        public string publisher;
    }

    class BookRepository
    {
        public Book[] books = new Book[5];
        public int bookCount = 0;

        public void AddBook(Book book)
        {
                if (Array.Exists(books, b => b != null && b.bookId == book.bookId))
                {
                    Console.WriteLine($"Book with ID {book.bookId} already exists. Cannot add duplicate book.");
                }
                else
                {
                    if (bookCount < books.Length)
                    {
                        books[bookCount] = book;
                        bookCount++;
                    }
                    else
                    {
                        Console.WriteLine("Book repository is full!");
                    }
                }
        }

        public Book GetBookByName(string bookName)
        {
            foreach (Book book in books)
            {
                if (book != null && book.bookName == bookName)
                {
                    return book;
                }
            }
            return null;
        }

        public Book[] GetBooksByAuthor(string author)
        {
            Book[] result = new Book[books.Length];
            int count = 0;

            foreach (Book book in books)
            {
                if (book != null && book.author == author)
                {
                    result[count] = book;
                    count++;
                }
            }

            return result;
        }

        public Book[] GetBooksByPublisher(string publisher)
        {
            Book[] result = new Book[books.Length];
            int count = 0;

            foreach (Book book in books)
            {
                if (book != null && book.publisher == publisher)
                {
                    result[count] = book;
                    count++;
                }
            }

            return result;
        }

        public Book[] GetAllBooks()
        {
            return books;
        }
    }

    class Program
    {
        static void Main()
        {
            BookRepository bookRepository = new BookRepository();

            do
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Get Book By Name");
                Console.WriteLine("3. Get Books By Author");
                Console.WriteLine("4. Get Books By Publisher");
                Console.WriteLine("5. Get All Books");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter Your Choice:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Book
                        Book newBook = new Book();
                        Console.WriteLine("Enter Book Id:");
                        newBook.bookId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Book Name:");
                        newBook.bookName = Console.ReadLine();
                        Console.WriteLine("Enter Language:");
                        newBook.language = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        newBook.price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Author:");
                        newBook.author = Console.ReadLine();
                        Console.WriteLine("Enter Publisher:");
                        newBook.publisher = Console.ReadLine();
                        bookRepository.AddBook(newBook);
                        break;

                    case 2:
                        // Get Book By Name
                        Console.WriteLine("Enter Book Name:");
                        string bookName = Console.ReadLine();
                        Book book = bookRepository.GetBookByName(bookName);
                        if (book != null)
                        {
                            Console.WriteLine($"Book Id: {book.bookId}, Name: {book.bookName}, Language: {book.language}, Price: {book.price}, Author: {book.author}, Publisher: {book.publisher}");
                        }
                        else
                        {
                            Console.WriteLine("Book not found!");
                        }
                        break;

                    case 3:
                        // Get Books By Author
                        Console.WriteLine("Enter Author:");
                        string author = Console.ReadLine();
                        Book[] booksByAuthor = bookRepository.GetBooksByAuthor(author);
                        DisplayBooks(booksByAuthor);
                        break;

                    case 4:
                        // Get Books By Publisher
                        Console.WriteLine("Enter Publisher:");
                        string publisher = Console.ReadLine();
                        Book[] booksByPublisher = bookRepository.GetBooksByPublisher(publisher);
                        DisplayBooks(booksByPublisher);
                        break;

                    case 5:
                        // Get All Books
                        Book[] allBooks = bookRepository.GetAllBooks();
                        DisplayBooks(allBooks);
                        break;

                    case 6:
                        // Exit
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Try Again.");
                        break;
                }
            } while (true);
        }

        static void DisplayBooks(Book[] books)
        {
            foreach (Book b in books)
            {
                if (b != null)
                {
                    Console.WriteLine($"Book Id: {b.bookId}, Name: {b.bookName}, Language: {b.language}, Price: {b.price}, Author: {b.author}, Publisher: {b.publisher}");
                }
            }
        }
    }

}
}
