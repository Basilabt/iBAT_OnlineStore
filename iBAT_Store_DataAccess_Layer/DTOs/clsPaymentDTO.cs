using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsPaymentDTO
    {
        public int paymentID { get; set; }
        public int paymentMethodID { get; set; }
        public decimal amount { get; set; }
    }
}
