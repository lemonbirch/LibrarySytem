using Library_Sytem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class LibrarySystem
{
    private List<Book> books;
    private List<Borrower> borrowers;
    private List<BorrowRecord> borrowRecords;

    public LibrarySystem()
    {
        books = new List<Book>();
        borrowers = new List<Borrower>();
        borrowRecords = new List<BorrowRecord>();
        LoadData();
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Librarian Portal");
            Console.WriteLine("2. User Portal");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    LibrarianPortal();
                    break;
                case "2":
                    UserPortal();
                    break;
                case "3":
                    SaveData();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void LibrarianPortal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Librarian Portal");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Add Borrower");
            Console.WriteLine("4. Remove Borrower");
            Console.WriteLine("5. Issue Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. View All Books");
            Console.WriteLine("8. View All Borrowers");
            Console.WriteLine("9. View Borrowed Books");
            Console.WriteLine("10. Back to Main Menu");
            Console.Write("Enter your choice: ");

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
                    AddBorrower();
                    break;
                case "4":
                    RemoveBorrower();
                    break;
                case "5":
                    IssueBook();
                    break;
                case "6":
                    ReturnBook();
                    break;
                case "7":
                    ViewAllBooks();
                    break;
                case "8":
                    ViewAllBorrowers();
                    break;
                case "9":
                    ViewBorrowedBooks();
                    break;
                case "10":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void UserPortal()
    {
        Console.Write("Enter your borrower ID: ");
        int borrowerId;
        if (!int.TryParse(Console.ReadLine(), out borrowerId))
        {
            Console.WriteLine("Invalid borrower ID. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Borrower borrower = borrowers.FirstOrDefault(b => b.Id == borrowerId);
        if (borrower == null)
        {
            Console.WriteLine("Borrower not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {borrower.Name}!");
            Console.WriteLine("1. View Borrowed Books");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewBorrowedBooks(borrower);
                    break;
                case "2":
                    ViewAllBooks();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        Book book = new Book(books.Count + 1, title, author, isbn);
        books.Add(book);

        Console.WriteLine("Book added successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private void RemoveBook()
    {
        Console.Write("Enter book ID to remove: ");
        int bookId;
        if (!int.TryParse(Console.ReadLine(), out bookId))
        {
            Console.WriteLine("Invalid book ID. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Book book = books.FirstOrDefault(b => b.Id == bookId);
        if (book == null)
        {
            Console.WriteLine("Book not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        books.Remove(book);
        Console.WriteLine("Book removed successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private void AddBorrower()
    {
        Console.Write("Enter borrower name: ");
        string name = Console.ReadLine();
        Console.Write("Enter borrower email: ");
        string email = Console.ReadLine();

        Borrower borrower = new Borrower(borrowers.Count + 1, name, email);
        borrowers.Add(borrower);

        Console.WriteLine("Borrower added successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private void RemoveBorrower()
    {
        Console.Write("Enter borrower ID to remove: ");
        int borrowerId;
        if (!int.TryParse(Console.ReadLine(), out borrowerId))
        {
            Console.WriteLine("Invalid borrower ID. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Borrower borrower = borrowers.FirstOrDefault(b => b.Id == borrowerId);
        if (borrower == null)
        {
            Console.WriteLine("Borrower not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        borrowers.Remove(borrower);
        Console.WriteLine("Borrower removed successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private void IssueBook()
    {
        Console.Write("Enter book ID: ");
        int bookId;
        if (!int.TryParse(Console.ReadLine(), out bookId))
        {
            Console.WriteLine("Invalid book ID. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Book book = books.FirstOrDefault(b => b.Id == bookId);
        if (book == null)
        {
            Console.WriteLine("Book not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Book is not available. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter borrower ID: ");
        int borrowerId;
        if (!int.TryParse(Console.ReadLine(), out borrowerId))
        {
            Console.WriteLine("Invalid borrower ID. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Borrower borrower = borrowers.FirstOrDefault(b => b.Id == borrowerId);
        if (borrower == null)
        {
            Console.WriteLine("Borrower not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        book.IsAvailable = false;
        BorrowRecord record = new BorrowRecord(book.Id, borrower.Id, DateTime.Now);
        borrowRecords.Add(record);

        Console.WriteLine("Book issued successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private void ReturnBook()
    {
        Console.Write("Enter book ID: ");
        int bookId;
        if (!int.TryParse(Console.ReadLine(), out bookId))
        {
            Console.WriteLine("Invalid book ID. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Book book = books.FirstOrDefault(b => b.Id == bookId);
        if (book == null)
        {
            Console.WriteLine("Book not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        BorrowRecord record = borrowRecords.FirstOrDefault(r => r.BookId == bookId && r.ReturnDate == null);
        if (record == null)
        {
            Console.WriteLine("This book is not currently borrowed. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        book.IsAvailable = true;
        record.ReturnDate = DateTime.Now;

        Console.WriteLine("Book returned successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private void ViewAllBooks()
    {
        Console.WriteLine("All Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {book.IsAvailable}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ViewAllBorrowers()
    {
        Console.WriteLine("All Borrowers:");
        foreach (var borrower in borrowers)
        {
            Console.WriteLine($"ID: {borrower.Id}, Name: {borrower.Name}, Email: {borrower.Email}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ViewBorrowedBooks()
    {
        Console.WriteLine("Borrowed Books:");
        foreach (var record in borrowRecords.Where(r => r.ReturnDate == null))
        {
            Book book = books.FirstOrDefault(b => b.Id == record.BookId);
            Borrower borrower = borrowers.FirstOrDefault(b => b.Id == record.BorrowerId);
            Console.WriteLine($"Book: {book.Title}, Borrower: {borrower.Name}, Borrow Date: {record.BorrowDate}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ViewBorrowedBooks(Borrower borrower)
    {
        Console.WriteLine($"Books borrowed by {borrower.Name}:");
        foreach (var record in borrowRecords.Where(r => r.BorrowerId == borrower.Id && r.ReturnDate == null))
        {
            Book book = books.FirstOrDefault(b => b.Id == record.BookId);
            Console.WriteLine($"Book: {book.Title}, Borrow Date: {record.BorrowDate}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void LoadData()
    {
        // TODO: Implement data loading from files
    }

    private void SaveData()
    {
        // TODO: Implement data saving to files
    }
}
