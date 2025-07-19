using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer
{
    public class clsProductDataAccess
    {

        public static bool getProductByProductID(clsProductDTO productDTO)
        {
            bool isFound = false;
            
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetProductByProductID";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"ProductID", productDTO.productID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                productDTO.productID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                                productDTO.category = reader.GetString(reader.GetOrdinal("Category"));
                                productDTO.name = reader.GetString(reader.GetOrdinal("Name"));
                                productDTO.description = reader.GetString(reader.GetOrdinal("Description"));


                            }
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }


            return isFound;
        }

    }
}
