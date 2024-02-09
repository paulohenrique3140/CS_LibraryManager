using CS_LibraryManager;
using System;

namespace CS_LibraryManager {
    class Program {
        static void Main(string[] args) {
            List<Client> clientList = new List<Client>();
            Library library = new Library();
            Client client = new Client();
            Book book = new Book();
            int mainMenuOption = 1;

            do {
                Console.WriteLine();
                Console.WriteLine("======== CS LIBRARY MANAGER ========");
                Console.WriteLine();
                Console.WriteLine("Menu\n\n[1] Library\n[2] Client\n[0] Exit");
                Console.Write("\nChoose an option: ");
                mainMenuOption = int.Parse(Console.ReadLine());
                mainMenuOption = validateOption(mainMenuOption, 2);
                switch (mainMenuOption) {
                    case 1:
                        Console.WriteLine("\n======== LIBRARY ========");
                        Console.WriteLine();
                        Console.WriteLine("Menu\n\n[1] Add book\n[2] Remove book" +
                            "\n[3] Checking out a book\n[4] Returning a book" +
                            "\n[5] Find book by ISBN\n[6] Show available books\n[7] Show all collection" +
                            "\n[0] Return to main menu");
                        Console.Write("\nChoose an option: ");
                        int libraryOption = int.Parse(Console.ReadLine());
                        libraryOption = validateOption(libraryOption, 7);
                        switch (libraryOption) {
                            case 1:
                                Console.WriteLine("\n======== ADDING A BOOK TO COLLECTION ========");
                                Console.WriteLine();
                                Console.Write("Title: ");
                                string title = Console.ReadLine();
                                Console.Write("Author: ");
                                string author = Console.ReadLine();
                                Console.Write("Publication Year: ");
                                int publicationYear = int.Parse(Console.ReadLine());
                                Console.Write("ISBN: ");
                                int isbn = int.Parse(Console.ReadLine());
                                isbn = validateIsbn(isbn, library);
                                library.AddBook(new Book(title, author, publicationYear, isbn));
                                break;
                            case 2:
                                Console.WriteLine("\n======== REMOVING A BOOK FROM COLLECTION ========");
                                Console.WriteLine("\nCollection: \n" + library.ShowCollection());
                                Console.Write("Enter ISBN book to remove: ");
                                int removeIsbn = int.Parse(Console.ReadLine());
                                library.RemoveBook(removeIsbn);
                                Console.WriteLine("\nUpdated collection: \n" + library.ShowCollection());
                                break;
                            case 3:
                                Console.WriteLine("\n======== CHECKING OUT A BOOK ========");
                                Console.WriteLine("\nCollection: \n" + library.ShowCollection());
                                Console.Write("Enter the ISBN of the desired book: ");
                                int lendIsbn = int.Parse(Console.ReadLine());
                                Console.Write("Enter the Client ID: ");
                                int clientId = int.Parse(Console.ReadLine());
                                if (library.FindByIsbn(lendIsbn) != null && library.FindByIsbn(lendIsbn).Availability) {
                                    if (client.FindClientById != null) {
                                        client = client.FindClientById(clientList, clientId);
                                        client.MakeLoan(lendIsbn, library);
                                        book.Lend(lendIsbn, library);
                                    }
                                    else {
                                        Console.WriteLine("Client not found. Please, try again.");
                                    }
                                }
                                else {
                                    Console.WriteLine("Book's not found or unavailable.");
                                }
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n======== CLIENT ========");
                        Console.WriteLine();
                        Console.WriteLine("Menu\n\n[1] Add client\n[2] Find client by ID" +
                            "\n[3] Show client book list\n[0] Return to main menu");
                        Console.Write("\nChoose an option: ");
                        int clientOption = int.Parse(Console.ReadLine());
                        clientOption = validateOption(clientOption, 3);
                        switch (clientOption) {
                            case 1:
                                Console.WriteLine("\n======== ADDING A CLIENT TO REGISTER ========");
                                Console.WriteLine();
                                Console.Write("Name: ");
                                string name = Console.ReadLine();
                                Console.Write("ID: ");
                                int id = int.Parse(Console.ReadLine());
                                clientList.Add(new Client(name, id));
                                break;
                            case 2:
                                Console.WriteLine("\n======== SEARCHING A CLIENT BY ID ========");
                                Console.Write("Enter client ID: ");
                                int clientIdToFind = int.Parse(Console.ReadLine());
                                if (client.FindClientById(clientList, clientIdToFind) != null) {
                                    client = client.FindClientById(clientList, clientIdToFind);
                                    Console.WriteLine(client);
                                }
                                else {
                                    Console.WriteLine("\nClient's not found.");
                                }

                                break;
                            case 3:
                                Console.WriteLine("\n======== CLIENT BOOK LIST ========");
                                Console.Write("Enter client ID: ");
                                int clientToBookList = int.Parse(Console.ReadLine());
                                Client foundClient = client.FindClientById(clientList, clientToBookList);
                                if (foundClient != null) {
                                    Console.WriteLine(foundClient.ShowClientBookList());
                                }
                                else {
                                    Console.WriteLine("\nClient's not found.");
                                }
                                break;

                            default:
                                break;
                        }
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

        public static int validateOption(int option, int limit) {
            while (option < 0 || option > limit) {
                Console.Write("\nInvalid option. Try again: ");
                option = int.Parse(Console.ReadLine());
            }
            return option;
        }

        public static int validateIsbn(int isbn, Library library) {
            foreach (Book x in library.Collection) {
                while (x.Isbn == isbn) {
                    Console.Write("ISBN already exist, please enter another number: ");
                    isbn = int.Parse(Console.ReadLine());
                }
            }
            return isbn;
        }
    }
}
