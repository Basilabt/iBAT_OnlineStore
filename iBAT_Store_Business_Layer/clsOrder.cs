using iBAT_Store_DataAccess_Layer;
using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsOrder
    {
        public enum enMode
        {
            AddNew = 1 ,Update = 2 , Delete = 3
        }

        public int orderID {  get; set; }
        public int accountID { get; set; }
        public int paymentID { get; set; }
        public int deliveryLocationID { get; set; }
        public DateOnly estimatedDeliveryDate { get; set; }
        public DateOnly actualDeliveryDate { get; set; }
        public int numberOfLateDays { get; set; }
        public enMode mode { get; set; }
        public clsAccount account { get; set; }
        public clsPayment payment { get; set; }
        public clsDeliveryLocation deliveryLocation { get; set; }


        public clsOrder()
        {
            this.orderID = -1;
            this.accountID = -1;
            this.paymentID = -1;
            this.deliveryLocationID = -1;
            this.estimatedDeliveryDate = DateOnly.MinValue;
            this.actualDeliveryDate = DateOnly.MinValue;
            this.numberOfLateDays = -1;
            this.mode = enMode.AddNew;
            this.account = null;
            this.payment = null;
            this.deliveryLocation = null;
        }

        private clsOrder(int orderID , int accountID , int paymentID , int deliveryLocationID , DateOnly estimatedDeliveryDate , DateOnly actualDeliveryDate , int numberOfLateDays)
        {
            this.orderID = orderID;
            this.accountID = accountID;
            this.paymentID = paymentID;
            this.deliveryLocationID = deliveryLocationID;
            this.estimatedDeliveryDate = estimatedDeliveryDate;
            this.actualDeliveryDate = actualDeliveryDate;
            this.numberOfLateDays = numberOfLateDays;
            this.mode = enMode.Update;
            //this.account = clsAccount
            //this.payment = clsPayment
            //this.deliveryLocation = clsDeliveryLocation
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

        public static bool placeOrder(clsDeliveryLocationDTO deliveryLocationDTO, clsPaymentMethodDTO paymentMethodDTO, clsOrderDTO orderDTO, clsOrderItemsDTO orderItemsDTO)
        {
            return clsOrderDataAccess.placeOrder(deliveryLocationDTO, paymentMethodDTO, orderDTO, orderItemsDTO);
        }

        public static List<clsPlacedOrderDetailsDTO> getAccountOrdersByAccountID(clsAccountDTO accountDTO)
        {
            return clsOrderDataAccess.getAccountOrdersByAccountID(accountDTO);
        }

    }
}
