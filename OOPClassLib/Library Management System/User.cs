
namespace OOPClassLib.LibraryManagement;
public class User {
    private List<Book> _borrowdBooks = new List<Book>();
    public string? Name { get; set; }
    public IReadOnlyCollection<Book> BorrowdBooks => _borrowdBooks.AsReadOnly();
    public void BorrowBook(Book book) {
        if (book.IsAvailible) {
            book.BorrowBook(this);
            _borrowdBooks.Add(book);
        }
        // book.ISBN = "sasas";
    }

}