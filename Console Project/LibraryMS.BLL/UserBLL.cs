using System;
using System.Collections.Generic;
using LibraryMS.DAL;
using LibraryMS.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryMS.BLL
{
    public class UserBLL
    {
        //USER VALIDATION PART
        private bool UserValidation(User user)
        {
            bool userValid;

            if (user.UserId == 0 || user.UserId >= 100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid User id!!!, user id should be in between 1 to 100000");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.UserName.Length <= 3 || user.UserName.Length>30 )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid User name!!!, minimum 2 maximum 30 characters are allowed");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.UserName.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid User name!!!, name should not contains digit");
                Console.ForegroundColor = ConsoleColor.White;
                userValid = false;
            }
            else if (!(new Regex("([\\w\\.\\-_]+)?\\w+@[\\w-_]+(\\.\\w+){1,}").IsMatch(user.UserEmail)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Email!!!, email should be an email");
                Console.ForegroundColor = ConsoleColor.White;
                userValid = false;
            }
            else if (user.UserPassword.Length <= 7 || user.UserPassword.Length>15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Password!!!, minimum 8 maximum 15 characters are allowed");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else
            {
                userValid = true;
            }
            return userValid;
        }
        
        UserDAL userDAL = new UserDAL();

        //RETURNING USERS FROM USER TABLE =>BLL
        public List<User> GetAllUsersBLL()
        {
            List<User> users = userDAL.GetAllUserssDAL();
            return users;
        }
        //ADDING USER INTO USER TABLE =>BLLL 
        public void AddUsersBLL(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
               /* UserDAL userDAL = new UserDAL();*/
                bool isDone = userDAL.AddUsersDAL(user);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User added successfully...");
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
        //UPDATING USER FROM USER TABLE =>BLL
        public void UpdateUsersBLL(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
                UserDAL userDAL = new UserDAL();
                bool isDone = userDAL.UpdateUsersDAL(user);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User updated successfully...");
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
        //REMOVING USER FROM USER TABLE =>BLL
        public void RemoveUsersBLL(int userId)
        {
            if (userId == 0 || userId >= 100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid User Id...");
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                /*UserDAL userDAL = new UserDAL();*/
                bool isDone = userDAL.RemoveUsersDAL(userId);
                if (isDone)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User deleted successfully...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


               
        }


        //CODE USED FOR INDIVIDUAL USERS......

        //INDIVIDUAL USER LOGIN CREDENTIAL CHECKING =>BLL
        public bool UserLogin(string userEmail, string userPass)
        {
            UserDAL userDAL = new UserDAL();
            List<User> users = userDAL.GetAllUserssDAL();
            bool isDone = users.Exists(u => u.UserEmail == userEmail && u.UserPassword == userPass);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logged in successfully...");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Invalid Email Id or Password...");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
        //GET USER ID FROM USER TABLE =>BLL 
        public int GetUserIdBLL(string userEmail)
        {
            List<User> users = userDAL.GetAllUserssDAL();
            User user = users.Find(u => u.UserEmail == userEmail);
            return user.UserId;
        }
        //REQUEST BOOK TO BORROW =>BLL 
        public void RequestBookBLL(int bookId, int userId)
        {
            Book book = BookDAL.books.Find(b => b.BookId == bookId);
            if (book.BookCopies > 0)
            {
                bool isDone = userDAL.RequestBookDAL(bookId, userId);
                if (isDone)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Requested successfully...");
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
                Console.WriteLine("Sorry book is empty...");
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
                
        }
        //RETRIEVE REQUESTED BOOK FROM REQUESTED TABLE =>BLL 
        public List<RequestedBook> GetRequestBookBL()
        {
            return userDAL.GetRequestBookDAL();
        }
        //ACCEPT A BOOK REQUEST OF INDIVIDUAL USER =>BLL
        public void AcceptRequestBLL(int userId, int bookId)
        {
            bool isDone = userDAL.AcceptRequestDAL(userId,bookId);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Accepted successfully...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //RETRIEVE RECIEVED BOOKS FROM RECIEVED TABLE =>BLL
        public List<RecievedBook>GetRecievedBookBLL()
        {
            return userDAL.GetRecievedBookDAL();
        }
        //DELETE RECIEVED BOOK FROM RECIEVED TABLE =>DAL
        public void DeleteRecievedBLL(int bookId, int userId)
        {
            bool isDone = userDAL.DeleteRecievedDAL( bookId, userId);
            if (isDone)
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
        
    }
}
