using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsOrderDTO
    {
        public int orderID { get; set; }
        public int accountID { get; set; }
        public int paymentID { get; set; }
        public int deliveryLocationID { get; set; }
        public DateOnly estimatedDeliveryDate { get; set; }
        public DateOnly actualDeliveryDate { get; set; }
        public int numberOfLateDays { get; set; }
    }
}
