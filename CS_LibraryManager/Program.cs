using System;

namespace CS_LibraryManager {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Book test");
            Console.WriteLine();
            Book book = new Book("1984", "George Orwell", 1949, 139, true);
            Library library = new Library();
            library.AddBook(book);
            Console.WriteLine(library.Collection);




        }
    }
}
