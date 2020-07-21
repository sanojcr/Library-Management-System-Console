using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.BLL;
using System.Threading.Tasks;
using LibraryMS.Exception;

namespace LibraryMS.CSharp
{
    public class AdminPL
    {
        //INDIVIDUAL ADMIN LOGIN CREDENTIAL CHECKING
        public void AdminLogin()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Admin-Login-----------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Email Id: ");
                string adminEmail = Console.ReadLine();
                Console.Write("Password: ");
                string adminPass = Console.ReadLine();
                AdminBLL adminBLL = new AdminBLL();
                bool isDone = adminBLL.AdminLogin(adminEmail, adminPass);
                if (isDone)
                {
                    AdminSection();
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
        //ADMIN MENU
        private void GetAdminMenu()
        {
            Console.Write("1) Press 1 to show book section\n" +
                "2) Press 2 to show user section\n" +
                "3) Press 3 to show request section\n" +
                "4) Press 4 to show accepted section\n" +
                "5) Press 5 to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("logout");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        //ADMIN COMPLETE SECTION
        private void AdminSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome-to-Admin-Section--------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool adminLoop = true;
            while (adminLoop == true)
            {
                try
                {
                    GetAdminMenu();
                    int adminCase = int.Parse(Console.ReadLine());
                    switch (adminCase)
                    {
                        case 1:
                            BookPL bookSection = new BookPL();
                            bookSection.BookSection();
                            break;
                        case 2:
                            UserPL userSection = new UserPL();
                            userSection.UserSection();
                            break;
                        case 3:
                            RequestedSection();
                            break;
                        case 4:
                            RecievedSection();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out successfully..\nTada have a nice day...");
                            Console.ForegroundColor = ConsoleColor.White;
                            adminLoop = false;
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
        //ACCEPT A BOOK REQUEST
        public void AcceptRequest()
        {
            try
            {
                Console.Write("User Id: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.AcceptRequestBLL(userId, bookId);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }

        }
        //ADMIN REQUESTED BOOKS MENU
        private void RequestedSection()
        {
            bool reqLoop = true;
            while (reqLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome-to-Request-Section--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 to show all book request\n" +
                        "2) Press 2 to accept requested books\n" +
                        "3) Press 3 to exit");
                    int reqCase = int.Parse(Console.ReadLine());
                    switch (reqCase)
                    {
                        case 1:
                            UserPL userPL = new UserPL();
                            userPL.GetRequestBook();
                            break;
                        case 2:
                            AcceptRequest();
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
        //DELETE A ACCEPTED BOOK
        public void DeleteRecieved()
        {
            try
            {
                Console.Write("User Id: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.DeleteRecievedBLL(bookId, userId);

            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input...");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch (LibraryMSException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
                /*throw new LibraryMSException("Some unknown exception is occured..");*/
            }
        }
        //ADMIN RECIEVED BOOK MENU
        private void RecievedSection()
        {
            bool recLoop = true;
            while (recLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome-to-Accepted-Section--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 to show all book accepted\n" +
                        "2) Press 2 to takeback accepted books\n" +
                        "3) Press 3 to exit");
                    int recCase = int.Parse(Console.ReadLine());
                    switch (recCase)
                    {
                        case 1:
                            UserPL userPL = new UserPL();
                            userPL.GetRecievedBook();
                            break;
                        case 2:
                            DeleteRecieved();
                            break;
                        case 3:
                            Console.WriteLine();
                            recLoop = false;
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
    }
}
