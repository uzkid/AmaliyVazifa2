using System;

public class Book
{
    // Private fields
    private string _author;
    private decimal _price;

    // Property for book name (readonly, initialized via constructor)
    public string Name { get; }

    // Properties for author and price
    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set
        {
            if (value >= 0) // Ensuring price is non-negative
            {
                _price = value;
            }
            else
            {
                throw new ArgumentException("Price cannot be negative.");
            }
        }
    }

    // Constructor to initialize the book name
    public Book(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Book name cannot be empty.");
        }
        Name = name;
    }

    // Additional methods
    public void DisplayDetails()
    {
        Console.WriteLine($"Book Name: {Name}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Price: {_price:C}");
    }

    public void ApplyDiscount(decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentException("Discount percentage must be between 0 and 100.");
        }
        _price -= _price * (percentage / 100);
        Console.WriteLine($"Discount applied. New Price: {_price:C}");
    }
}

// Using the Book class
class Program
{
    static void Main(string[] args)
    {
        // Creating a Book object
        Book myBook = new Book("C# Programming");

        // Setting property values
        myBook.Author = "John Doe";
        myBook.Price = 29.99m;

        // Displaying book details
        myBook.DisplayDetails();

        // Applying a discount
        myBook.ApplyDiscount(10);

        // Displaying updated details
        myBook.DisplayDetails();
    }
}

