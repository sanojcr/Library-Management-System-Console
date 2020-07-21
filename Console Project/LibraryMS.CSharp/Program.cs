using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Exception;
using System.Threading.Tasks;

namespace LibraryMS.CSharp
{
    class Program
    {
        //MAIN PROGRAM
        static void Main(string[] args)
        {
            bool logLoop = true;
            while (logLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome to ABC Library Management System");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 to login as Admin\n" +
                    "2) Press 2 to login as User\n" +
                    "3) Press 3 to exit");

                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            AdminPL adminPL = new AdminPL();
                            adminPL.AdminLogin();
                            break;
                        case 2:
                            UserPL userPL = new UserPL();
                            userPL.UserLogin();
                            break;
                        case 3:
                            logLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid input...");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    logLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
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
