﻿# LibrarySytem
# Library Management System

## Overview
This Library Management System is a console-based application written in C# that helps manage the day-to-day operations of a library. It provides separate portals for librarians and users, allowing for efficient management of books, borrowers, and borrowing records.

## Features

### For Librarians:
- Add and remove books
- Add and remove borrowers
- Issue and return books
- View all books, borrowers, and borrowed books
- Search for books
- Calculate late fees

### For Users:
- View borrowed books
- View all available books
- Search for books
- View personal late fees

### System Features:
- Data persistence between runs
- User authentication
- Error handling and input validation

## Setup and Installation

1. Ensure you have .NET Core SDK installed on your machine.
2. Clone this repository to your local machine.
3. Navigate to the project directory in your terminal.
4. Run `dotnet build` to compile the project.
5. Run `dotnet run` to start the application.

## Usage

### First-time Setup
When you run the program for the first time, you'll need to set up at least one librarian account. The system will prompt you to create this account.

### Logging In
- Librarian accounts should start with "lib_" (e.g., "lib_john")
- User accounts are created by librarians and use the borrower's name as the username

### Librarian Portal
Access the Librarian Portal by selecting option 1 from the main menu and logging in with a librarian account. From here, you can:
1. Add Book
2. Remove Book
3. Add Borrower
4. Remove Borrower
5. Issue Book
6. Return Book
7. View All Books
8. View All Borrowers
9. View Borrowed Books
10. Search Books


### User Portal
Access the User Portal by selecting option 2 from the main menu and logging in with a user account. From here, you can:
1. View Borrowed Books
2. View All Books
3. Search Books

   
## Contributing
Feel free to fork this project and submit pull requests with any improvements or additional features you'd like to see implemented.

## License
This project is open source and available under the MIT License.
