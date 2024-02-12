using OOPClassLib.LibraryManagement;

namespace Library_Management_System;

class Program
{
    static void Main(string[] args)
    {
        var library = CreateLibrary();
        DisplayBooks(library.ListOfBooks);
        var bookToBorrow = library.ListOfBooks.First(b=>b.Title == "The Bee Sting");
        var user = library.ListOfUsers.First(u=>u.Name=="Ann Ulm");
        if (bookToBorrow is not null) {
            bookToBorrow.BorrowBook(user);
        }

        DisplayBooks(library.GetCrimeBooks());
    }

    private static void DisplayBooks(IEnumerable<Book> books)
    {
        foreach (var book in books) {
            book.DisplayBookDetail();
        }
    }

    private static Library CreateLibrary() {
        var library = new Library() {Name = "Manhatan Central Library"};
        library.AddBook(new Book("The Bee Sting", new[] {"Paul Murray"}) {
            Genres = BookGenres.Crime | BookGenres.YoungAdult
         });
        library.AddBook(new Book("Chain-Gang All-Stars", new[] {"Nana Kwame Adjei-Brenyah"}) {
            Genres = BookGenres.Romance | BookGenres.Adventure
        });
        library.AddBook(new Book("Eastbound", new[] {"Maylis de Kerangal"}) {
            Genres = BookGenres.ContemporaryFiction | BookGenres.Crime | BookGenres.Mystery
        });
        library.AddBook(new Book("The Fraud", new[] {"Zadie Smith"}) {
            Genres = BookGenres.Cookbooks | BookGenres.Dystopian
        });
        library.AddBook(new Book("North Woods", new[] {"Daniel Mason"}) {
            Genres = BookGenres.Classics | BookGenres.Biography | BookGenres.Crime
        });
        library.AddBook(new Book("The Best Minds", new[] {"Jonathan Rosen"}) {
            Genres = BookGenres.Adventure | BookGenres.ScienceFiction | BookGenres.Travel
        });
        library.AddBook(new Book("The BeBottoms Up and the Devil Laughs", new[] {"Kerry Howley"}){
            Genres = BookGenres.Romance | BookGenres.Fantasy | BookGenres.History
        });
        library.AddBook(new Book("Fire Weather", new[] {"John Vaillant"}) {
            Genres = BookGenres.Crime | BookGenres.Dystopian
        });
        library.AddBook(new Book("Whiteout", new[] {"Dhonielle Clayton", "Tiffany D. Jackson", "Nic Stone", "Angie Thomas", "Ashley Woodfolk", "Nicola Yoon"}) {
            Genres = BookGenres.LGBTQ
        });
        library.AddUser(new User() {Name = "Dadiv Sibon"});
        library.AddUser(new User() {Name = "Patrik Henderson"});
        library.AddUser(new User() {Name = "Ann Ulm"});
        library.AddUser(new User() {Name = "Tedd Pink"});
        library.AddUser(new User() {Name = "Freddy Camel"});

        return library;

    }


}
