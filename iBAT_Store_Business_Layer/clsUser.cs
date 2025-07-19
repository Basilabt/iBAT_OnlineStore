using iBAT_Store_DataAccess_Layer;
using iBAT_Store_DataAccess_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsUser
    {
        public enum enMode
        {
            AddNew = 1, Update = 2, Delete = 3
        }

        public enum enGender
        {
            Male = 1, Female = 2
        }

        public int userID {  get; set; }
        public int personID {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public enMode mode { get; set; }

        public clsPerson person { get; set; }   

        public clsUser()
        {
            this.userID = -1;
            this.personID = -1;
            this.username = "";
            this.password = "";
            this.mode = enMode.AddNew;
            this.person = null;
        }

        private clsUser(int userID , int personID , string username , string password)
        {
            this.userID = userID;
            this.personID = personID;
            this.username = username;
            this.password = password;
            this.mode = enMode.Update;
            this.person = clsPerson.getPersonByPersonID(new clsPersonDTO { personID = personID});
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

        public static bool signInByUsernameAndPassword(clsUserDTO userDTO)
        {
            return clsUserDataAccess.signInByUsernameAndPassword(userDTO);
        }

        public static bool signUp(clsPersonDTO personDTO , clsUserDTO userDTO)
        {
            return clsUserDataAccess.signUp(personDTO , userDTO);
        }

        public static bool doesUsernameExist(clsUserDTO userDTO)
        {
            return clsUserDataAccess.doesUsernameExist(userDTO);    
        }

        public static clsUser getUserByUserID(clsUserDTO userDTO)
        {
            if (clsUserDataAccess.getUserByUserID(userDTO))
            {
                return new clsUser { userID = userDTO.userID, personID = userDTO.personID, username = userDTO.username, password = userDTO.password };
            }

            return null;
        }

        public static clsUser getUserByUsername(clsUserDTO userDTO)
        {
            if (clsUserDataAccess.getUserByUsername(userDTO))
            {
                return new clsUser { userID = userDTO.userID, personID = userDTO.personID, username = userDTO.username, password = userDTO.password };
            }

            return null;
        }

        public static bool updateUserInformation(clsPersonDTO personDTO , clsUserDTO userDTO)
        {
            return clsUserDataAccess.updateUserInformation(personDTO,userDTO);
        }

    }
}
