using CS_LibraryManager;
using System;

namespace CS_LibraryManager {
    class Program {
        static void Main(string[] args) {
            List<Client> clientList = new List<Client>();
            Library library = new Library();
            Client client = new Client();
            int mainMenuOption = 1;

            do {
                Console.WriteLine();
                Console.WriteLine("======== CS LIBRARY MANAGER ========");
                Console.WriteLine();
                Console.WriteLine("Menu\n\n[1] Library\n[2] Client\n[0] Exit");
                Console.Write("\nChoose an option: ");
                mainMenuOption = int.Parse(Console.ReadLine());
                switch (mainMenuOption) {
                    case 1:
                        Console.WriteLine("Hello Friend");
                        break;
                    default:
                        break;
                }
            } while (mainMenuOption != 0);
            


            /*Console.WriteLine("Book tests");
            Console.WriteLine();
            Book book = new Book("1984", "George Orwell", 1949, 139, true);
            Book book2 = new Book("1985", "George Orwell", 1949, 140, true);
            Console.WriteLine("Book 1: " + book);
            Console.WriteLine("Book 2: " + book2);
            Console.WriteLine();
            Console.WriteLine("Library + book tests");
            Library library = new Library();
            library.AddBook(book);
            library.AddBook(book2);
            Console.WriteLine("Collection: " + library.ShowCollection());

            book.Lend(139, library);
            
            Console.WriteLine("Book after lend: " + book);
            Console.WriteLine("Updated collection after lend: " + library.ShowCollection());
            Console.WriteLine("Available book list: " + library.ShowAvailableBooks());
            book.Return(139, library);
            Console.WriteLine("Book after return: " + book);
            Console.WriteLine("Updated collection after return: " + library.ShowCollection());
            Console.WriteLine("=================");
            Console.WriteLine("Client tests");
            Console.WriteLine();
            Console.WriteLine();
            Client client = new Client("Paulo", 12);
            Console.WriteLine("Client book list before make loan: " + client.ShowClientBookList());
            client.MakeLoan(139, library);
            Console.WriteLine("Client book list after make loan: " + client.ShowClientBookList());
            client.PerformReturn(139);
            Console.WriteLine("Updated client book list after return: " + client.ShowClientBookList());
            Console.WriteLine();
            Console.WriteLine("Test with Find Client By Id");
            Console.WriteLine("Collection: " + library.ShowCollection());
            List<Client> clientList = new List<Client>();
            clientList.Add(client);
            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());
            Client clientTest = new Client();
            clientTest = clientTest.FindClientById(clientList, id);
            clientTest.MakeLoan(139, library);
            clientTest.MakeLoan(140, library);
            Console.WriteLine("Client books after make loan: " + clientTest.ShowClientBookList());
            clientTest.PerformReturn(139);
            clientTest.PerformReturn(140);
            Console.WriteLine("Client books afget return books: " + clientTest.ShowClientBookList());*/

        }
    }
}
