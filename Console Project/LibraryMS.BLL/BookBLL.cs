using System;
using LibraryMS.DAL;
using LibraryMS.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class BookBLL
    {
        //BOOK VALIDATION PART
        private bool BookValidation(int bookId, string bookName, string bookAuthor, int bookCopies)
        {
            bool bookValid;

            if (bookId==0 || bookId>=100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Book id!!!, book id should be in between 1 to 100000");
                Console.ForegroundColor = ConsoleColor.White;
                
                bookValid = false;
            }
            else if(bookName.Length <= 2 || bookName.Length>30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Book name!!!, minimum 3 maximum 30 characters are allowed");
                Console.ForegroundColor = ConsoleColor.White; 
                
                bookValid = false;
            }
            else if (bookName.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Book name!!!, name should not contains digits");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }

            else if (bookAuthor.Length <= 2 || bookAuthor.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Author name!!!, minimum 3 maximum 30 characters are allowed");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookAuthor.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Author name!!!, name should not contains digits");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }

            else if (bookCopies==0 || bookCopies>200)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Book copies!!!, book id should be in between 1 to 200");
                Console.ForegroundColor = ConsoleColor.White;
                
                bookValid = false;
            }
            else
            {
                bookValid=true;
            }
            return bookValid;
        }
        

        BookDAL dalBook = new BookDAL();
        //ADDING BOOK INTO BOOK TABLE =>BLL
        public void AddBookBLL(int bookId, string bookName, string bookAuthor, int bookCopies)
        {
            bool isValidated = BookValidation(bookId, bookName, bookAuthor, bookCopies);
            if (isValidated)
            {
                /*BookDAL dalBook = new BookDAL();*/
                bool isDone=dalBook.AddBooksDAL(bookId, bookName, bookAuthor, bookCopies);
                if (isDone==true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book added successfully...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White; 
            }
        }
        //UPDATING BOOK FROM BOOK TABLE =>BLL 
        public void UpdateBookBLL(int bookId, string bookName, string bookAuthor, int bookCopies)
        {
            bool isValidated = BookValidation(bookId, bookName, bookAuthor, bookCopies);
            if (isValidated)
            {
               /* BookDAL dalBook = new BookDAL();*/
                bool isDone=dalBook.UpdateBooksDAL(bookId, bookName, bookAuthor, bookCopies);
                if (isDone==true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book updated successfully...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //REMOVING BOOK FROM BOOK TABLE =>BLL
        public void RemoveBookBLL(int bookId)
        {
            if (bookId !=0 || bookId<= 100000)
            {
                /*BookDAL dalBook = new BookDAL();*/
                bool isDone= dalBook.RemoveBooksDAL(bookId);
                if (isDone==true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book deleted successfully...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Book id!!!");
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //RETURNING BOOKS FROM BOOK TABLE =>BLL
        public List<Book> GetAllBookBLL()
        {
           
            List<Book> books = dalBook.GetAllBooksDAL();
            return books;
        }

    }
}
