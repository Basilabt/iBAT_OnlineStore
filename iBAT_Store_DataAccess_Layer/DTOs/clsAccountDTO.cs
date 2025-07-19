using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsAccountDTO
    {
        public int accountID { get; set; }
        public int userID { get; set; }
        public int loyaltyPoins { get; set; }
        public bool isActive { get; set; }
        public DateTime creationDateTime { get; set; }

    }
}
