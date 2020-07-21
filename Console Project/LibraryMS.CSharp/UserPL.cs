using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Entity;
using LibraryMS.BLL;
using System.Threading.Tasks;
using LibraryMS.Exception;

namespace LibraryMS.CSharp
{
    class UserPL
    {
        private User user = new User();
        //USER MENU
        private void GetUserMenu()
        {
            Console.WriteLine("1) Press 1 to add a user\n" +
                "2) Press 2 to update a user\n" +
                "3) Press 3 to delete a user\n" +
                "4) Press 4 to show all user\n" +
                "5) Press 5 to exit");
        }
        //ADD USER INTO USER TABLE
        private void AddUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter user details..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User Id: ");
                user.UserId = int.Parse(Console.ReadLine());
                Console.Write("User Name: ");
                user.UserName = Console.ReadLine();
                Console.Write("User Email: ");
                user.UserEmail = Console.ReadLine();
                Console.Write("User Password: ");
                user.UserPassword = Console.ReadLine();
                UserBLL userBLL = new UserBLL();
                userBLL.AddUsersBLL(user);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //UPDATE USER FROM USER TABLE
        private void UpdateUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter user details..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User Id: ");
                user.UserId = int.Parse(Console.ReadLine());
                Console.Write("User Name: ");
                user.UserName = Console.ReadLine();
                Console.Write("User Email: ");
                user.UserEmail = Console.ReadLine();
                Console.Write("User Password: ");
                user.UserPassword = Console.ReadLine();
                UserBLL userBLL = new UserBLL();
                userBLL.UpdateUsersBLL(user);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //REMOVE USER FROM USER TABLE
        private void RemoveUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter user details..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User Id: ");
                int userId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.RemoveUsersBLL(userId);
            }
            catch (LibraryMSException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }*/
        }
        //RETRIEVE USERS FROM USER TABLE
        private void GetAllUser()
        {
            List<User> users = new List<User>();
            UserBLL userBLL = new UserBLL();
            users = userBLL.GetAllUsersBLL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------Users-List---------------------------");

            Console.WriteLine("--Id-----Name---------------Email------------------Password-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (User user in users)
            {
                Console.WriteLine("  " + user.UserId + "\t" + user.UserName + "\t " + user.UserEmail + "\t" + user.UserPassword);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //COMPLETE USER SECTION
        public void UserSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome-to-User-Section-------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool userLoop = true;
            while (userLoop == true)
            {
                try
                {
                    GetUserMenu();
                    int userCase = int.Parse(Console.ReadLine());
                    switch (userCase)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            UpdateUser();
                            break;
                        case 3:
                            RemoveUser();
                            break;
                        case 4:
                            GetAllUser();
                            break;
                        case 5:
                            Console.WriteLine();
                            userLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry try agian once!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }



        //CODES USED FOR INDIVIDUAL USER.....

        //INDIVIDUAL USER LOGIN CREDENTIAL CHECKING
        public void UserLogin()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("User-Login-----------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Email Id: ");
                string userEmail = Console.ReadLine();
                Console.Write("Password: ");
                string userPass = Console.ReadLine();
                UserBLL userBLL = new UserBLL();
                bool isDone = userBLL.UserLogin(userEmail, userPass);
                if (isDone)
                {
                    int userId = userBLL.GetUserIdBLL(userEmail);
                    UserHomeSection(userId);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }

        }
        //INDIVIDUAL USER HOME MENU
        private void GetUserHomeMenu()
        {
            Console.Write("1) Press 1 to show books section\n" +
                "2) Press 2 to show request section\n" +
                "3) Press 3 to show recieve section\n" +
                "4) Press 4 to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("logout");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        //INDIVIDUAL USER HOME SCREEN
        private void UserHomeSection(int userId)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome-to-User-Section--------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool userLoop = true;
            while (userLoop == true)
            {
                try
                {
                    GetUserHomeMenu();
                    int userCase = int.Parse(Console.ReadLine());
                    switch (userCase)
                    {
                        case 1:
                            BookPL bookPL = new BookPL();
                            bookPL.GetAllBook();
                            break;
                        case 2:
                            RequestSection(userId);
                            break;
                        case 3:
                            RecieveSection(userId);
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out successfully..\nTada have a nice day...");
                            Console.ForegroundColor = ConsoleColor.White;
                            userLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry try agian once!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }
        //REQUEST BOOK MENU
        private void RequestSection(int userId)
        {
            bool reqLoop = true;
            while (reqLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome-to-Request-Section--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 to rise a book request\n" +
                        "2) Press 2 to show requested books\n" +
                        "3) Press 3 to exit");
                    int reqCase = int.Parse(Console.ReadLine());
                    switch (reqCase)
                    {
                        case 1:
                            RequestBook(userId);
                            break;
                        case 2:
                            GetUserRequestBook(userId);
                            break;
                        case 3:
                            Console.WriteLine("");
                            reqLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry try agian once!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }
        //REQUEST A BOOK TO BORROW BY INDIVIDUAL USER
        private void RequestBook(int userId)
        {
            try
            {
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.RequestBookBLL(bookId, userId);
            }
            catch (LibraryMSException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }*/

        }
        //RETRIEVE REQUESTED BOOKS OF INDIVIDUAL USER FROM REQUEST TABLE
        private void GetUserRequestBook(int userId)
        {
            UserBLL userBLL = new UserBLL();
            List<RequestedBook> requestedBooks = userBLL.GetRequestBookBL();
            List<RequestedBook> requestedBooksUser = requestedBooks.FindAll(s => s.UserId == userId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------Requested-Book-List-----------------\n" +
                              "--Book-Id---Book-Name---------Date-Requiested--------");

            Console.ForegroundColor = ConsoleColor.White;
            foreach (RequestedBook requested in requestedBooksUser)
            {
                Console.WriteLine("  " + requested.BookId + "\t" + requested.BookName + "\t\t" + requested.DateRequested.ToShortDateString());
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //RECIECE BOOK MENU
        private void RecieveSection(int userId)
        {
            bool recLoop = true;
            while (recLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome-to-Recieved-Section--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 to delete a recieved book\n" +
                        "2) Press 2 to show recieved books\n" +
                        "3) Press 3 to exit");
                    int recCase = int.Parse(Console.ReadLine());
                    switch (recCase)
                    {
                        case 1:
                            DeleteReieve(userId);
                            break;
                        case 2:
                            GetUserRecievedBook(userId);
                            break;
                        case 3:
                            Console.WriteLine("");
                            recLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (LibraryMSException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry try agian once!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        //RETRIEVE RECIEVED BOOKS OF INDIVIDUAL USER FROM RECIEVED TABLE
        private void GetUserRecievedBook(int userId)
        {
            UserBLL userBLL = new UserBLL();
            List<RecievedBook> recievedBooks = userBLL.GetRecievedBookBLL();
            List<RecievedBook> recievedBooksUser = recievedBooks.FindAll(s => s.UserId == userId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------Recieved-Book-List-----------------\n" +
                              "--Book-Id---Book-Name---------Date-Recieved----------");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (RecievedBook recieved in recievedBooksUser)
            {
                Console.WriteLine("  " + recieved.BookId + "\t" + recieved.BookName + "\t\t" + recieved.DateRecieved.ToShortDateString());
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //RETRIEVE REQUESTED BOOKS FROM REQUEST TABLE
        public void GetRequestBook()
        {
            UserBLL userBLL = new UserBLL();
            List<RequestedBook> requestedBooks = userBLL.GetRequestBookBL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------User+Book-Requested-List------------------------\n" +
                              "--Book-Id---Book-Name-------Date-Requested--------User-Id---User-Name-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (RequestedBook requested in requestedBooks)
            {
                Console.WriteLine(" " + requested.BookId + "\t" + requested.BookName + "\t"
                    + requested.DateRequested.ToShortDateString() + "\t" + requested.UserId + "\t" + requested.UserName);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //RETRIEVE RECIEVED BOOKS FROM RECIEVED TABLE
        public void GetRecievedBook()
        {
            UserBLL userBLL = new UserBLL();
            List<RecievedBook> recievedBooks = userBLL.GetRecievedBookBLL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------User+Book-Recieved-List-------------------------\n" +
                              "--Book-Id---Book-Name-------Date-Accepted---------User-Id---User-Name-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (RecievedBook recieved in recievedBooks)
            {
                Console.WriteLine(" " + recieved.BookId + "\t" + recieved.BookName + "\t"
                    + recieved.DateRecieved.ToShortDateString() + "\t" + recieved.UserId + "\t" + recieved.UserName);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }
        //DELETE A RECIEVED BOOK FROM RECIEVED TABLE
        private void DeleteReieve(int userId)
        {
            try
            {
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.DeleteRecievedBLL(bookId, userId);

            }
            catch (LibraryMSException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }*/
        }
    }
}
