using iBAT_Store_DataAccess_Layer;
using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsPerson
    {
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete = 3
        }

        public enum enGender
        {
            Male = 1 , Female = 2
        }

        public int personID {  get; set; }

        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email {  get; set; }        
        public enGender gender { get; set; }
        public enMode mode { get; set; }

        public clsPerson()
        {
            this.personID = -1;
            this.firstName ="" ;
            this.secondName = "";
            this.thirdName = "";
            this.lastName = "";
            this.phoneNumber = "";
            this.email = "";
            this.mode = enMode.AddNew;
        }

        private clsPerson(int personID , string firstName , string secondName , string thirdName , string lastName , string phoneNumber , string email , enGender gedner)
        {
            this.personID = personID;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gedner;
            this.mode = enMode.Update;
        }


        public bool save()
        {
            switch(this.mode)
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

        public static clsPerson getPersonByPersonID(clsPersonDTO personDTO)
        {
            if (clsPersonDataAccess.getPersonByPersonID(personDTO))
            {      
                return new clsPerson
                {
                    personID = personDTO.personID,
                    firstName = personDTO.firstName,
                    secondName = personDTO.secondName,
                    thirdName = personDTO.thirdName,
                    lastName = personDTO.lastName,
                    phoneNumber = personDTO.phoneNumber,
                    email = personDTO.email,
                    gender = (clsPerson.enGender)personDTO.gedner
                };
            }

            return null;
        }
      

    }
}
