using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iBAT_Store_DataAccess_Layer;
using iBAT_Store_DataAccess_Layer.DTOs;

namespace iBAT_Store_Business_Layer
{
    public class clsAccount
    {
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete = 3
        }

        public int accountID {  get; set; }
        public int userID { get; set; }
        public int loyaltyPoints { get; set; }
        public bool isActive { get; set; }
        public DateTime creationDateTime { get; set; }
        public enMode mode { get; set; }

        public clsUser user { get; set; }

        public clsAccount()
        {
            this.accountID = -1;
            this.userID = -1;
            this.loyaltyPoints = -1;
            this.isActive = false;
            this.creationDateTime = DateTime.MinValue;  
            this.mode = enMode.AddNew;
            this.user = null;
               
        }

        private clsAccount(int accountID , int userID , int loyaltyPoints , bool isActive , DateTime creationDateTime)
        {
            this.accountID = accountID;
            this.userID = userID;
            this.loyaltyPoints = loyaltyPoints;
            this.isActive = isActive;
            this.creationDateTime = creationDateTime;
            this.mode = enMode.Update;
            this.user = clsUser.getUserByUserID(new clsUserDTO { userID = userID });

        }

        public bool save()
        {
            switch (this.mode)
            {

                case enMode.AddNew:
                    {
                        return false;
                    }

                case enMode.Update:
                    {
                        return false;
                    }

                case enMode.Delete:
                    {
                        return false;
                    }

            }

            return false;
        }

        // Static Methods

        public static clsAccount getAccountByAccountID(clsAccountDTO accountDTO)
        {
            if (clsAccountDataAccess.getAccountByAccountID(accountDTO))
            {
                return new clsAccount { accountID = accountDTO.accountID, userID = accountDTO.userID, loyaltyPoints = accountDTO.loyaltyPoins, isActive = accountDTO.isActive, creationDateTime = accountDTO.creationDateTime };
            }

            return null;
        }

        public static clsAccount getAccountByUserID(clsUserDTO userDTO)
        {
            clsAccountDTO accountDTO = new clsAccountDTO();

            if (clsAccountDataAccess.getAccountByUserID(userDTO,accountDTO))
            {
                return new clsAccount { accountID = accountDTO.accountID, userID = accountDTO.userID, loyaltyPoints = accountDTO.loyaltyPoins, isActive = accountDTO.isActive, creationDateTime = accountDTO.creationDateTime };
            }

            return null;
        }

    }
}
