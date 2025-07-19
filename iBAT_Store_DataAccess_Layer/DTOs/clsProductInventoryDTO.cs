using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsProductInventoryDTO
    {
        public int productInventoryID { get; set; }
        public int productID { get; set; }
        public string sku { get; set; }
        public Byte[] image { get; set; }
        public string color { get; set; }
        public int capacityInGB { get; set; }
        public decimal priceInJOD { get; set; }
        public int stockQuantity { get; set; }
    }
}
