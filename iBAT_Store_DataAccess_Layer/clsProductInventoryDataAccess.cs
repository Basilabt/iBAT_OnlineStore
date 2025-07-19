using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace iBAT_Store_DataAccess_Layer
{
    public class clsProductInventoryDataAccess
    {
      
        public static List<clsProductInventoryDTO> getProductsInventoryAsDTOList()
        {
            List<clsProductInventoryDTO> list = new List<clsProductInventoryDTO>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetAllInventoryProducts";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                while(reader.Read())
                                {
                                    clsProductInventoryDTO dto = new clsProductInventoryDTO
                                    {
                                        productInventoryID = reader.GetInt32(reader.GetOrdinal("ProductInventoryID")),
                                        productID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                        sku = reader["SKU"].ToString(),
                                        image = reader["Image"] == DBNull.Value ? null : (byte[])reader["Image"],
                                        color = reader["Color"].ToString(),
                                        capacityInGB = reader.GetInt32(reader.GetOrdinal("CapacityInGB")),
                                        priceInJOD = reader.GetDecimal(reader.GetOrdinal("PriceInJOD")),
                                        stockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity"))
                                    };

                                    list.Add(dto);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }


            return list;
        }

        public static List<clsProductInventoryDTO> getProductsInventoryOfCategoryAsDTOList(clsProductDTO productDTO)
        {
            List<clsProductInventoryDTO> list = new List<clsProductInventoryDTO>();


            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                string cmd = "SP_GetAllInventoryProductsOfCategory";
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    Console.WriteLine($"DEBUG: DataAccess Category =  {productDTO.category}");
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"Category",productDTO.category);


                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                            while (reader.Read())
                            {
                                

                                clsProductInventoryDTO dto = new clsProductInventoryDTO
                                {
                                    productInventoryID = reader.GetInt32(reader.GetOrdinal("ProductInventoryID")),
                                    productID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                    sku = reader["SKU"].ToString(),
                                    image = reader["Image"] == DBNull.Value ? null : (byte[])reader["Image"],
                                    color = reader["Color"].ToString(),
                                    capacityInGB = reader.GetInt32(reader.GetOrdinal("CapacityInGB")),
                                    priceInJOD = reader.GetDecimal(reader.GetOrdinal("PriceInJOD")),
                                    stockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity"))
                                };

                                list.Add(dto);
                            }
                        
                    }


                }


            }

            return list;
        }

    }
}
