using Microsoft.IdentityModel.Tokens;

namespace iBAT_Store.Model.Products
{
    public class clsGetAllInventoryProductsResponseDTO
    {
        public int productInventoryID { get; set; }
        public int productID { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string sku {  get; set; }
        public Byte[] image { get; set; }
        public string color { get; set; }
        public int capacityInGB { get; set; }
        public decimal priceInJOD { get; set; }
        public int stockQuantity {  get; set; }

    }
}
