using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer.DTOs
{
    public class clsProductDTO
    {
        public int productID { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
