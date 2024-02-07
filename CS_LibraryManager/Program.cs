using System;

namespace CS_LibraryManager {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Book test");
            Console.WriteLine();
            Book book = new Book("1984", "George Orwell", 1949, 139, true);
            Book book2 = new Book("1985", "George Orwell", 1949, 139, true);
            Library library = new Library();
            library.AddBook(book);
            library.AddBook(book2);
            Console.WriteLine(library.ShowCollection());

            book.Lend(139);
            Console.WriteLine(book);
            Console.WriteLine(library.ShowCollection());
        }
    }
}
