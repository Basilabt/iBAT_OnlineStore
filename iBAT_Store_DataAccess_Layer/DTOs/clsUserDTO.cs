using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsUserDTO
    {
        public int userID { get; set; }
        public int personID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
       
    }
}
