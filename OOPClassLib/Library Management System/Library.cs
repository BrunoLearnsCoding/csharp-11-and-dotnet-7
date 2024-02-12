namespace OOPClassLib.LibraryManagement;

public class Library {
    private List<Book> _listOfBooks = new List<Book>();
    private List<User> _listOfUsers = new List<User>();
    public string? Name { get; set; }
    public IReadOnlyCollection<Book> ListOfBooks => _listOfBooks.AsReadOnly();
    public IReadOnlyCollection<User> ListOfUsers => _listOfUsers.AsReadOnly();
    public void AddBook(Book book) {
        book.Library = this;
        _listOfBooks.Add(book);
    }
    public void AddUser(User user) {
        _listOfUsers.Add(user);
    }

    public IEnumerable<Book> GetCrimeBooks() {
        return _listOfBooks.FindAll(b=> b.Genres.HasFlag(BookGenres.Crime));
    }

}