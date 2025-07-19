using Azure.Core;
using iBAT_Store_DataAccess_Layer;
using iBAT_Store_DataAccess_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_Business_Layer
{
    public class clsProduct
    {
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete = 3
        }

        public int productID {  get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public enMode mode { get; set; }


        public clsProduct()
        {
            this.productID = -1;
            this.category = "";
            this.name = "";
            this.description = "";
            this.mode = enMode.AddNew;
        }

        private clsProduct(int productID ,  string category, string name , string description)
        {
            this.productID = productID;
            this.category = category;
            this.name = name;
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

        // Static Methods

        public static clsProduct getProductByProductID(clsProductDTO productDTO)
        {
            if (clsProductDataAccess.getProductByProductID(productDTO))
            {
                return new clsProduct { productID = productDTO.productID, category = productDTO.category, name = productDTO.name, description = productDTO.description };
            }

            return null;
        }

    }
}
