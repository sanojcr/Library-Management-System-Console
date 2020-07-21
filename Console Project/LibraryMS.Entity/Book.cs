using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Entity
{
    //BOOK CLASS
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookCopies { get; set; }
        public Book()
        {
            BookId = 0;
            BookName = string.Empty;
            BookAuthor = string.Empty;
            BookCopies = 0;
        }

    }
}
