using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LibraryManager {
    internal class Library {
        public List<Book> Collection { get; private set; }

        public Library() { }
                
        public void AddBook(Book book) {
            Collection.Add(book);
        }

        public bool RemoveBook(int isbn) {
            Book bookToRemove = FindByIsbn(isbn);
                if(bookToRemove != null) {
                    Collection.Remove(bookToRemove);
                    return true;
                }
            return false;
        }

        public Book FindByIsbn(int isbn) {
            foreach (Book x in Collection) {
                if (x.Isbn == isbn) {
                    return x;
                }
            }
            return null;
        }

        public List<Book> ShowAvailableBooks() {
            List<Book> availableBooks = new List<Book>();
            foreach (Book x in Collection) {
                if (x.Availability) {
                    availableBooks.Add(x);
                }
            }
            return availableBooks;
        }

    }
}
