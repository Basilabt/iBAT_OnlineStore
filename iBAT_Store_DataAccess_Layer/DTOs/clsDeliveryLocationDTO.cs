using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsDeliveryLocationDTO
    {
        public int deliveryLocationID { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string street { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string receiverPhoneNumber { get; set; }
    }
}
