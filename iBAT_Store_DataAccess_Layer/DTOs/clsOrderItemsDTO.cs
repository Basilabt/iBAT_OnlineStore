using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsOrderItemsDTO
    {
        public int orderItemsID { get; set; }
        public int orderID { get; set; }
        public int productInventoryID { get; set; }
    }
}
