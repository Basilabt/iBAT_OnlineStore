namespace iBAT_Store.Model.Profile
{
    public class clsUpdateProfileInformationRequestDTO
    {
        public int personID { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public int userID { get; set; }
        public int accountID { get; set; }
    }
}
