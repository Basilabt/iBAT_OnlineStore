using iBAT_Store_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iBAT_Store_DataAccess_Layer.DTOs;
using System.Data;

namespace iBAT_Store_Business_Layer
{
    public class clsProductInventory
    {
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete =  3
        }

        public int productInventoryID {  get; set; }

        public int productID { get; set; }
        public string sku {  get; set; }
        public Byte[] image {  get; set; }
        public string color { get; set; }
        public int capacityInGB { get; set; }
        public decimal priceInJOD { get; set; }
        public int stockQuantity {  get; set; }
        public enMode mode {  get; set; }
        public clsProduct product { get; set; }

        public clsProductInventory()
        {
            this.productInventoryID = -1;
            this.sku = "";
            this.image = null;
            this.color = "";
            this.capacityInGB = -1;
            this.productInventoryID = -1;
            this.stockQuantity = -1;
            this.mode = enMode.AddNew;
        }

        private clsProductInventory(int productInventoryID , int productID , string sku , Byte[] image , string color , int capacityInGB , int priceInJOD , int stockQuantity)
        {
            this.productInventoryID = productInventoryID;
            this.productID = productID;
            this.sku = sku;
            this.image = image;
            this.color = color;
            this.capacityInGB = capacityInGB;
            this.priceInJOD = priceInJOD;
            this.stockQuantity = stockQuantity;
            this.mode = enMode.Update;
            this.product = clsProduct.getProductByProductID(new clsProductDTO { productID = productID });
        }

        public void loadCompositeObjects()
        {
            this.product = clsProduct.getProductByProductID(new clsProductDTO { productID = this.productID });
        }

        // Static Methods

        public static List<clsProductInventory> getProductsInventoryAsObjectList()
        {
            List<clsProductInventoryDTO> dtoList = clsProductInventoryDataAccess.getProductsInventoryAsDTOList();
              

            List<clsProductInventory> list = new List<clsProductInventory>();
            foreach(clsProductInventoryDTO item in dtoList)
            {
                clsProductInventory productInventory = new clsProductInventory();

                productInventory.mode = enMode.Update;
                productInventory.productID = item.productID;
                productInventory.sku = item.sku;
                productInventory.image = item.image;
                productInventory.color = item.color;
                productInventory.capacityInGB = item.capacityInGB;
                productInventory.priceInJOD = item.priceInJOD;
                productInventory.stockQuantity = item.stockQuantity;

                productInventory.loadCompositeObjects();

                list.Add(productInventory);
            }

            return list;
        }


        public static List<clsProductInventory> getProductsInventoryOfCategoryAsObjectList(clsProductDTO productDTO)
        {
            List<clsProductInventoryDTO> dtoList = clsProductInventoryDataAccess.getProductsInventoryOfCategoryAsDTOList(productDTO);


            List<clsProductInventory> list = new List<clsProductInventory>();
            foreach (clsProductInventoryDTO item in dtoList)
            {
                clsProductInventory productInventory = new clsProductInventory();

                productInventory.mode = enMode.Update;
                productInventory.productID = item.productID;
                productInventory.sku = item.sku;
                productInventory.image = item.image;
                productInventory.color = item.color;
                productInventory.capacityInGB = item.capacityInGB;
                productInventory.priceInJOD = item.priceInJOD;
                productInventory.stockQuantity = item.stockQuantity;

                productInventory.loadCompositeObjects();

                list.Add(productInventory);
            }

            return list;
        }


    }
}
