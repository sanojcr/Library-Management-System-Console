using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Exception
{
    public class LibraryMSException:ApplicationException
    {
        //CUSTOM EXCEPTION HANDLING METHODS
        public LibraryMSException():base()
        {

        }
        public LibraryMSException(string message) : base(message)
        {
           
        }
        public LibraryMSException(string msg, FormatException InneException) : base(msg, InneException)
        {
            
        }
        
    }
}
