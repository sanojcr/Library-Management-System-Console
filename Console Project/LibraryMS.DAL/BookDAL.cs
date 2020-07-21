using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;
using LibraryMS.Entity;
using LibraryMS.Exception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryMS.DAL
{
    
    public class BookDAL
    {
        //LIST USED TO STORE BOOK DETAILS =>DAL
        public static List<Book> books = new List<Book>();
        
        //RETURNING BOOKS FROM BOOK TABLE =>DAL
        public List<Book> GetAllBooksDAL()
        {
            return books;
        }
        //ADDING BOOKS INTO BOOK TABLE =>DAL
        public bool AddBooksDAL(int bookId, string bookName, string bookAuthor, int bookCopies)
        {
            bool isDone = false;
            try
            {
                Book addBook = new Book() { BookId = bookId, BookName = bookName, BookAuthor = bookAuthor, BookCopies = bookCopies };
                books.Add(addBook);
                isDone = true;

            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
            }
            return isDone;
        }
        //UPDATING BOOKS FROM BOOK TABLE =>DAL
        public bool UpdateBooksDAL(int bookId, string bookName, string bookAuthor, int bookCopies)
        {
            bool isDone = false;
            try
            {
                Book updateBook = books.Find(s => s.BookId == bookId);
                updateBook.BookName = bookName;
                updateBook.BookAuthor = bookAuthor;
                updateBook.BookCopies = bookCopies;
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
               
            }
            return isDone;
        }
        //REMOVING BOOKS FROM BOOK TABLE =>DAL
        public bool RemoveBooksDAL(int bookId)
        {
            bool isDone = false;
            try
            {
                Book removeBook = books.Find(s => s.BookId == bookId);
                books.Remove(removeBook);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
            }
            return isDone;
        }
    }

    
}
