using Lab2;

var authors = new List<Author>
            {
                new Author(1, "George", "Orwell"),
                new Author(2, "Jane", "Austen"),
                new Author(3, "Mark", "Twain")
            };

var books = new List<Book>
            {
                new Book(1, "1984", 14.99m, 1),
                new Book(2, "Animal Farm", 9.99m, 1),
                new Book(3, "Pride and Prejudice", 12.50m, 2),
                new Book(4, "Emma", 11.25m, 2),
                new Book(5, "Adventures of Huckleberry Finn", 15.75m, 3)
            };

bool exit = false;

while (!exit)
{
    ShowMenu();
    Console.Write("Enter an option: ");
    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ListAllAuthors(authors);
            break;
        case "2":
            ListAllBooks(books, authors);
            break;
        case "3":
            ListBooksByAuthor(books, authors);
            break;
        case "4":
            AddNewBook(books, authors);
            break;
        case "5":
            Console.WriteLine("Exiting application.");
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    if (!exit)
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}

static void ShowMenu()
{
    Console.WriteLine("===== Bookstore Menu =====");
    Console.WriteLine("1. List all authors");
    Console.WriteLine("2. List all books");
    Console.WriteLine("3. List all books by a specific author");
    Console.WriteLine("4. Add a new book");
    Console.WriteLine("5. Exit");
    Console.WriteLine();
}

static void ListAllAuthors(List<Author> authors)
{
    Console.WriteLine("Authors:");
    foreach (var author in authors)
    {
        Console.WriteLine($"{author.Id}: {author.FullName}");
    }
}

static void ListAllBooks(List<Book> books, List<Author> authors)
{
    Console.WriteLine("Books:");
    foreach (var book in books)
    {
        var author = authors.FirstOrDefault(a => a.Id == book.AuthorId);
        string authorName = author != null ? author.FullName : "Unknown Author";

        Console.WriteLine($"{book.Id}: {book.Title} - {book.Price:C} (by {authorName})");
    }
}

static void ListBooksByAuthor(List<Book> books, List<Author> authors)
{
    Console.Write("Enter the Author ID: ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int authorId))
    {
        Console.WriteLine("Invalid Author ID.");
        return;
    }

    var author = authors.FirstOrDefault(a => a.Id == authorId);

    if (author == null)
    {
        Console.WriteLine("Author not found.");
        return;
    }

    var booksByAuthor = books.Where(b => b.AuthorId == authorId).ToList();

    if (booksByAuthor.Count == 0)
    {
        Console.WriteLine($"No books found for {author.FullName}.");
        return;
    }

    Console.WriteLine($"Books by {author.FullName}:");
    foreach (var book in booksByAuthor)
    {
        Console.WriteLine($"{book.Id}: {book.Title} - {book.Price:C}");
    }
}

static void AddNewBook(List<Book> books, List<Author> authors)
{
    Console.Write("Enter book title: ");
    string? title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Title cannot be empty.");
        return;
    }

    Console.Write("Enter book price: ");
    string? priceInput = Console.ReadLine();

    if (!decimal.TryParse(priceInput, out decimal price))
    {
        Console.WriteLine("Invalid price.");
        return;
    }

    Console.Write("Enter Author ID: ");
    string? authorInput = Console.ReadLine();

    if (!int.TryParse(authorInput, out int authorId))
    {
        Console.WriteLine("Invalid Author ID.");
        return;
    }

    var author = authors.FirstOrDefault(a => a.Id == authorId);
    if (author == null)
    {
        Console.WriteLine("Author not found. Cannot add book.");
        return;
    }

    int newId = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;

    var newBook = new Book(newId, title, price, authorId);
    books.Add(newBook);

    Console.WriteLine($"Book added: {newBook.Title} by {author.FullName} with ID {newBook.Id}.");
}
    