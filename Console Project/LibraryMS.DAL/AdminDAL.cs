using System;
using System.Collections.Generic;
using LibraryMS.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.DAL
{
    public class AdminDAL
    {
        
        //LIST USED TO STORE ADMINS DETAILS
        private static List<Admin> admins = new List<Admin>()
        {
            new Admin()
            {
                AdminId=1,AdminName="Sanoj C R",AdminEmail="sanoj@gmail.com",AdminPassword="123123"
            },
        };
        //RETURNING ADMIN FROM ADMIN TABLE =>DAL
        public List<Admin> GetAllAdminsDAL()
        {
            return admins;
        }
    }
}
