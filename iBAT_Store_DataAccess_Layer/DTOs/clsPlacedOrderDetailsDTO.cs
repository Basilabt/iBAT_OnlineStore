using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsPlacedOrderDetailsDTO
    {
        // Order Info
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }  // Nullable for undelivered
        public int? NumberOfLateDays { get; set; }         // Nullable for early/incomplete

        // Delivery Info
        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReceiverPhoneNumber { get; set; }

        // Payment Info
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        // Product Inventory Info
        public string SKU { get; set; }
        public string Color { get; set; }
        public int? CapacityInGB { get; set; }             // Nullable if not all products have this
        public decimal PriceInJOD { get; set; }
        public int StockQuantity { get; set; }

        // Product Info
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
    }
}
