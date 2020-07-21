using System;
using System.Collections.Generic;
using System.Linq;
using LibraryMS.Exception;
using LibraryMS.Entity;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.DAL
{
    public class UserDAL
    {
        //LIST TO STORE USER DETAILS
        private static List<User> users = new List<User>();
        
        //RETURNING USERS FROM USER TABLE =>DAL
        public List<User> GetAllUserssDAL()
        {
            return users;
        }
        //ADDING USER INTO USER TABLE =>DAL 
        public bool AddUsersDAL(User user)
        {
            bool isDone = false;
            try
            {
                User addUser = new User()
                {
                  UserId=user.UserId,
                  UserEmail=user.UserEmail,
                  UserName=user.UserName,
                  UserPassword=user.UserPassword  
                };
                users.Add(addUser);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
               
            }
            return isDone;
        }
        //UPDATING USER FROM USER TABLE =>DAL
        public bool UpdateUsersDAL(User user)
        {
            bool isDone = false;
            try
            {
                User updateUser = users.Find(s => s.UserId == user.UserId);
                updateUser.UserEmail = user.UserEmail;
                updateUser.UserName = user.UserName;
                updateUser.UserPassword = user.UserPassword;
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
               
            }
            return isDone;
        }
        //REMOVING USER FROM USER TABLE =>DAL
        public bool RemoveUsersDAL(int userId)
        {
            bool isDone = false;
            try
            {
                User removeUser = users.Find(s => s.UserId == userId);

                users.Remove(removeUser);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
                
            }
            return isDone;
        }

        //LIST USED TO STORE REQUESTED BOOK DETAILS
        public static List<RequestedBook> requestedBooks = new List<RequestedBook>();
        //LIST USED TO STORE RECIEVED BOOK DETAILS
        public static List<RecievedBook> recievedBooks = new List<RecievedBook>();
        
        //CODE USED FOR INDIVIDUAL USERS......
        //REQUEST BOOK TO BORROW =>DAL
        public bool RequestBookDAL(int bookId, int userId)
        {
            bool isDone = false;
            try
            {
                User user = users.Find(u => u.UserId == userId);
                Book book = BookDAL.books.Find(b => b.BookId == bookId);
                book.BookCopies = book.BookCopies - 1;
                requestedBooks.Add(new RequestedBook()
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    DateRequested = DateTime.Now.Date,
                    UserId = user.UserId,
                    UserName = user.UserName
                });
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
                
            }
            return isDone;
        }
        //RETRIEVE REQUESTED BOOKS FROM REQUEST TABLE =>DAL
        public List<RequestedBook> GetRequestBookDAL()
        {
            return requestedBooks;
        }
        //ACCEPT A BOOK REQUEST OF INDIVIDUAL USER =>DAL
        public bool AcceptRequestDAL(int userId, int bookId)
        {
            bool isDone = false;
            try
            {
                RequestedBook requestBook = requestedBooks.Find(r => r.UserId == userId && r.BookId == bookId);
                RecievedBook recievedBook = new RecievedBook()
                {
                    BookId = requestBook.BookId,
                    BookName = requestBook.BookName,
                    DateRecieved = DateTime.Now.Date,
                    UserId = requestBook.UserId,
                    UserName = requestBook.UserName
                };
                recievedBooks.Add(recievedBook);
                requestedBooks.Remove(requestBook);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
               
            }
            return isDone;
        }
        //RETRIEVE RECIEVED BOOKS FROM RECIEVED TABLE =>DAL
        public List<RecievedBook> GetRecievedBookDAL()
        {
            return recievedBooks;
        }
        //DELETE RECIEVED BOOK FROM RECIEVED TABLE =>DAL
        public bool DeleteRecievedDAL(int bookId, int userId)
        {
            bool isDone = false;
            try
            {
                RecievedBook delRecievedBook = recievedBooks.Find(d => d.BookId == bookId && d.UserId == userId);
                recievedBooks.Remove(delRecievedBook);
                Book book = BookDAL.books.Find(b => b.BookId == bookId);
                book.BookCopies = book.BookCopies + 1;
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
