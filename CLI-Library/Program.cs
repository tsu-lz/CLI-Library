using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

class Program{
    static List<Book> books = new List<Book>();
    static void Main(string[] args){
        while (true){
            Console.WriteLine("Library");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. View books");
            Console.WriteLine("3. Update a book");
            Console.WriteLine("4. Delete a book");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option");

            var input = Console.ReadLine();

            switch (input){
                case "1":
                    AddBook();
                    break;
                case "2":
                    ViewBooks();
                    break;
                case "3":
                    UpdateBook();
                    break;
                case "4":
                    DeleteBook();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddBook(){
        Console.WriteLine("Enter Book Title: ");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Author: ");
        string author = Console.ReadLine();

        Console.WriteLine("Enter year of Publication: ");
        int year;
        while (!int.TryParse(Console.ReadLine(), out year)){
            Console.WriteLine("Invalid year, please enter a valid number:");
        }
        int id = books.Count > 0 ? books.Max(book => book.Id) + 1 : 1;

        var book = new Book
        {
            Id = id,
            Title = title,
            Author = author,
            Year = year
        };

        books.Add(book);
        Console.WriteLine($"Book '{title}' has been added successfully");
    }

    static void ViewBooks(){
        if (books.Count == 0){
            Console.WriteLine("No books available");
            return;
        }
        Console.WriteLine("Available Books:");
        foreach (var book in books){
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
        }
    }

    static void UpdateBook(){
        Console.WriteLine("Enter the ID of the book to update: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id)){
            Console.Write("Invalid ID, please enter a valid number: ");
        }

        var book = books.FirstOrDefault(book => book.Id == id);
        if (book == null){
            Console.WriteLine("Book not found.");
            return;
        }

        Console.WriteLine("Enter new Title (leave empty to keep your current title): ");
        string title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title)){
            book.Title = title;
        }

        Console.WriteLine("Enter new Author (leave empty to keep current): ");
        string author = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(author)){
            book.Author = author;
        }

        Console.WriteLine("Enter new Year (leave empty to keep your current year): ");
        string yearInput = Console.ReadLine();
        if (int.TryParse(yearInput, out int year)){
            book.Year = year;
        }

        Console.WriteLine("Book updated successfully.");
    }

    static void DeleteBook(){
        Console.Write("Enter the ID of the book to delete:");
        int id;
        while(!int.TryParse(Console.ReadLine(), out id)){
            Console.Write("Invalid ID, please enter a valid number: ");
        }

        var book = books.FirstOrDefault(book => book.Id == id);
        if (book == null){
            Console.WriteLine("Book not found.");
            return;
        }
        
        books.Remove(book);
        Console.WriteLine($"Book '{book.Title}' deleted successfully");
    }
}