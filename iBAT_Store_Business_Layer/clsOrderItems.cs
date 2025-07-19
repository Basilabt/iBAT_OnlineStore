using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsOrderItems
    {
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete = 3
        }

        public int orderItemsID {  get; set; }
        public int orderID { get; set; }
        public int productInventoryID { get; set; }
        public enMode mode { get; set; }
        public clsOrder order { get; set; }
        public clsProductInventory productInventory { get; set; }

        public clsOrderItems()
        {
            this.orderItemsID = -1;
            this.orderID = -1;
            this.productInventoryID = -1;
            this.mode = enMode.AddNew;
            this.order = null;
            this.productInventory = null;
        }

        private clsOrderItems(int orderItemsID, int orderID, int productInventoryID)
        {
            this.orderItemsID = orderItemsID;
            this.orderID = orderID;
            this.productInventoryID = productInventoryID;
            this.mode = enMode.Update;
            //this.order = clsOrder
            //this.productInventory = clsProductInventory
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
