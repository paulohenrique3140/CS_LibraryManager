using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LibraryManager {
    internal class Client {

        public string Name { get; set; }
        public int Id { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Client() { }

        public Client(string name, int id) {
            Name = name;
            Id = id;
            BorrowedBooks = new List<Book>();
        }

        public bool MakeLoan(int isbn, Library library) {
            Book bookToLoan = library.FindByIsbn(isbn);
            if (bookToLoan != null && bookToLoan.Availability) {
                BorrowedBooks.Add(bookToLoan);
                return true;
            }
            return false;
        }

        public bool PerformReturn(int isbn) {
            foreach (Book x in BorrowedBooks) {
                if (x.Isbn == isbn) {
                    BorrowedBooks.Remove(x);
                    return true;
                }
            }
            return false;
        }

        public string ShowClientBookList() {
            StringBuilder sb = new StringBuilder();
            foreach (Book book in BorrowedBooks) {
                sb.AppendLine(book.ToString());
            }
            return sb.ToString();
        }

        public Client FindClientById(List<Client> clientList, int id) {
            foreach (Client x in clientList) {
                if (x.Id == id) {
                    return x;
                }
            }
            return null;
        }

        public override string ToString() {
            return "\nName: " + Name + "\nID: " + Id;
        }
    }
}


