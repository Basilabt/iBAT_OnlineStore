using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsPayment
    {
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete = 3
        }

        public int paymentID {  get; set; }
        public int paymentMethodID { get; set; }
        public decimal amount { get; set; }
        public enMode mode { get; set; }
        public clsPaymentMethod paymentMethod { get; set; }

        public clsPayment()
        {
            this.paymentID = -1;
            this.paymentMethodID = -1;  
            this.amount = 0;
            this.mode = enMode.AddNew;
            this.paymentMethod = null;
        }

        private clsPayment(int paymentID , int paymentMethodID , decimal amount)
        {
            this.paymentID = paymentID;
            this.paymentMethodID = paymentMethodID;
            this.amount = amount;
            this.mode = enMode.Update;
            //this.paymentMethod = clsPaymentMethod.  Load the paymentMethod Object.
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

    }
}
