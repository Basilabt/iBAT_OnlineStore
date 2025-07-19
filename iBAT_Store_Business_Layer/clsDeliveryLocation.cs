using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsDeliveryLocation
    {   
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete = 3
        }

        public int deliveryLocationID {  get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string street {  get; set; }
        public double latitude { get; set; }
        public double longitude {  get; set; }
        public string receiverPhoneNumber {  get; set; }

        public enMode mode { get; set; }

        public clsDeliveryLocation()
        {
            this.deliveryLocationID = -1;
            this.country = "";
            this.area = "";
            this.city = "";
            this.street = "";
            this.latitude = -1;
            this.longitude = -1;
            this.receiverPhoneNumber = "";
            this.mode = enMode.AddNew;
        }

        private clsDeliveryLocation(int deliveryLocationID, string country, string city, string area, string street, double latitude, double longitude, string receiverPhoneNumber)
        {
            this.deliveryLocationID = deliveryLocationID;
            this.country = country;
            this.city = city;
            this.area = area;
            this.street = street;
            this.latitude = latitude;
            this.longitude = longitude;
            this.receiverPhoneNumber = receiverPhoneNumber;
            this.mode = enMode.Update; 
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

    }
}
