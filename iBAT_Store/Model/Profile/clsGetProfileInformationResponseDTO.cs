namespace iBAT_Store.Model.Profile
{
    public class clsGetProfileInformationResponseDTO
    {
        public int personID {  get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }

        public string username { get; set; }
        public string phoneNumber {  get; set; }
        public string email {  get; set; }
        public int gender { get; set; }
        public int userID { get; set; }
        public int accountID {  get; set; }
        public int loyaltyPoints { get; set; }
        public bool isActive { get; set; }
        public DateTime creationDateTime { get; set; }
    }
}
