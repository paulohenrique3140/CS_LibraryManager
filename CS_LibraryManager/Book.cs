using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LibraryManager {
    internal class Book {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int Isbn { get; set;}
        public bool Availability { get; set; }

        public Book() { }

        public Book(string title, string author, int publicationYear, int isbn) {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Isbn = isbn;
            Availability = true;
        }

        public bool Lend(int isbn, Library library) {
            Book bookToLend = library.FindByIsbn(isbn);
            if(bookToLend != null && bookToLend.Availability) {
                bookToLend.Availability = false;
                return true;
            }
            return false;
        }

        public void Return(int isbn, Library library) {
            Book bookToReturn = library.FindByIsbn(isbn);
            if(bookToReturn != null && !bookToReturn.Availability) {
                bookToReturn.Availability = true;
            }
        }

        public override string ToString() {
            string availabilityStatus = Availability ? "Available" : "Unavailable";
            return "\nTitle: " + Title
                + " | Author: " + Author
                + " | Publication Year: " + PublicationYear
                + " | ISBN: " + Isbn
                + " | Availability: " + availabilityStatus;
        }
    }
}
