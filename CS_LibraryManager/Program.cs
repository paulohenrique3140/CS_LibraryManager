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
                                if (library.FindByIsbn(removeIsbn) != null) {
                                    library.RemoveBook(removeIsbn);
                                    Console.WriteLine("\nUpdated collection: \n" + library.ShowCollection());
                                }
                                else {
                                    Console.WriteLine($"\nISBN {removeIsbn} is not exists.");
                                }
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
                                        Console.WriteLine("\nDone! Check the client book list.");
                                    }
                                    else {
                                        Console.WriteLine("Client not found. Please, try again.");
                                    }
                                }
                                else {
                                    Console.WriteLine("Book's not found or unavailable.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("\n======== RETURNING A BOOK ========");
                                Console.Write("\nEnter the client ID: ");
                                int idReturn = int.Parse(Console.ReadLine());
                                if (client.FindClientById(clientList, idReturn) != null) {
                                    Console.WriteLine("\nClient book list: \n" + client.ShowClientBookList());
                                    Console.WriteLine("\nEnter the book isnb to return: ");
                                    int isbnReturn = int.Parse(Console.ReadLine());
                                    if (client.PerformReturn(isbnReturn)) {
                                        book.Return(isbnReturn, library);
                                        Console.WriteLine("\nDone!\nUpdated client book list: \n" + client.ShowClientBookList());
                                        Console.WriteLine("\nUpdated library available books in collection: \n"
                                            + library.ShowAvailableBooks());
                                    }
                                    else {
                                        Console.WriteLine("\nISBN {0} not found in the client book list" + isbnReturn);

                                    }
                                }
                                else {
                                    Console.WriteLine("Client with ID {0} not found" + idReturn);
                                }
                                break;
                            case 5:
                                Console.WriteLine("\n======== SEARCHING A BOOK BY ISBN ========");
                                Console.Write("\nEnter book ISBN: ");
                                int isbnToFind = int.Parse(Console.ReadLine());
                                if (library.FindByIsbn(isbnToFind) != null) {
                                    Console.WriteLine("\nResult: " + library.FindByIsbn(isbnToFind));
                                }
                                else {
                                    Console.WriteLine("\nBook's not found.");
                                }
                                break;
                            case 6:
                                Console.WriteLine("\n======== AVAILABLE BOOKS IN COLLECTION ========");
                                Console.WriteLine(library.ShowAvailableBooks());
                                break;
                            case 7:
                                Console.WriteLine("\n======== ALL LIBRARY COLLECTION ========");
                                Console.WriteLine(library.ShowCollection);
                                break;
                            default:
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
                                id = validateId(id, clientList);
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

        public static int validateId(int id, List<Client> clientList) {
            foreach (Client x in clientList) {
                while (x.Id == id) {
                    Console.Write("ID already exist, please enter another number: ");
                    id = int.Parse(Console.ReadLine());
                }
            }
            return id;
        }
    }
}
