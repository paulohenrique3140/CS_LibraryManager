using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LibraryManager {
    internal class Client {

        public string Name { get; set; }
        public int Id { get; set; }
        public List<Book> borrowedBooks { get; set; }

        public Client(string name, int id) {
            Name = name;
            Id = id;
            borrowedBooks = new List<Book>();
        }

        public bool MakeLoan(int isbn, Library library) {
            Book bookToLoan = library.FindByIsbn(isbn);
            if (bookToLoan != null && bookToLoan.Availability) {
                borrowedBooks.Add(bookToLoan);
                return true;
            }
            return false;
        }

        public bool PerformReturn(int isbn) {
            foreach (Book x in borrowedBooks) {
                if (x.Isbn == isbn) {
                    borrowedBooks.Remove(x);
                    return true;
                }
            }
            return false;
        }

        public string ShowClientBookList() {
            StringBuilder sb = new StringBuilder();
            foreach (Book book in borrowedBooks) {
                sb.AppendLine(book.ToString());
            }
            return sb.ToString();
        }

        public static Client FindClientById(List<Client> client, int id) {
            foreach (Client x in client) {
                if (x.Id == id) {
                    return x;
                }
            }
            return null;
        }
    }
}


