namespace iBAT_Store.Model.Products
{
    public class clsPurchaseProductRequestDTO
    {
        public int accountID { get; set; }
        public int productInventoryID { get; set; }
        public int paymentMethodID { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string street { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string receiverPhoneNumber { get; set; }


    }
}
