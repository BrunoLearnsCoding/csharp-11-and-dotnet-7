using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace OOPClassLib.LibraryManagement;

public class Book
{
    private int _openingStock;
    private int _stockInHand;
    private List<User> _borrowedBy = new List<User>();
    public IReadOnlyCollection<User> BorrowedBy => _borrowedBy.AsReadOnly();
    public required string? Title { get; init; }
    public List<string> Authors = new List<string>();
    public string? ISBN { get; set; }
    public BookGenres Genres {get; set;}
    internal Library? Library { get; set; }
    public bool IsAvailible => _stockInHand > 0; 

    public void DisplayBookDetail()
    {
        System.Console.WriteLine($"{Title} by {GetAuthorsShortLine()}\nISBN: {ISBN}");
    }
    public void BorrowBook(User user)
    {
        if (IsAvailible) {
            if (_borrowedBy.Find(u => u == user) != null) {
                System.Console.WriteLine("You are trying to borrow a book twice from this library. It is against our terms and conditions.");
                return;
            }
            _stockInHand -= 1;
            _borrowedBy.Add(user);
            System.Console.WriteLine($"The book '{this.Title}' borrowd to {user.Name}");
            return;
        }
        System.Console.WriteLine($"The requested book '{this.Title} is unfortunatly not availible now.");

    }
    public void ReturnBook(User user) {
        if (_borrowedBy.Find(u => u == user) == null)
        {
            System.Console.WriteLine("You can't return this book to the library. This book is not borrowed by you from our library.");
            return;
        }
        _stockInHand += 1;
        _borrowedBy.Remove(user);
    }
    [SetsRequiredMembers]
    public Book(string title, int openingStock = 1)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("The book title could not be blank.", nameof(title));
        }
        Title = title;
        _openingStock = openingStock;
        _stockInHand = openingStock;
        Genres = BookGenres.None;
    }
    [SetsRequiredMembers]
    public Book(string title, string[] authors, int openingStock = 1) : this(title, openingStock)
    {
        Authors.AddRange(authors);
    }

    //public void ChangeTitle(string newTitle) {
    //    Title = newTitle;
    //}

    private string GetAuthorsShortLine()
    {
        if (Authors.Count == 1)
        {
            return Authors[0];
        }
        else if (Authors.Count == 0)
        {
            return "[No author]";
        }
        else {
            return $"{Authors[0]} and others.";
        }
    }
}