using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsPaymentMethod
    {
        public enum enMode
        {
            AddNew = 1 , Delete = 2 , Update = 3
        }

        public int paymentMethodID {  get; set; }
        public int method {  get; set; }
        public string description { get; set; }
        public enMode mode { get; set; }

        public clsPaymentMethod()
        {
            this.paymentMethodID = -1;
            this.method = - 1;
            this.description = "";
            this.mode = enMode.AddNew;

        }

        private clsPaymentMethod(int paymentMethodID, int method, string description)
        {
            this.paymentMethodID = paymentMethodID;
            this.method = method;
            this.description = description;
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

    }
}
