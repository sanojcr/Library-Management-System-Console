using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Entity
{
    //ADMIN CLASS
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public Admin()
        {
            AdminId = 0;
            AdminName = string.Empty;
            AdminEmail = string.Empty;
            AdminPassword = string.Empty;
        }
    }
}
