using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsPaymentMethodDTO
    {
        public int paymentMethodID { get; set; }
        public int method { get; set; }
        public string description { get; set; }
    }
}
