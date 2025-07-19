using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer
{
    public class clsOrderDataAccess
    {
        public static bool placeOrder(clsDeliveryLocationDTO deliveryLocationDTO , clsPaymentMethodDTO paymentMethodDTO , clsOrderDTO orderDTO , clsOrderItemsDTO orderItemsDTO)
        {
            int orderID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();


                    string cmd = "SP_PlaceOrder";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"Country",deliveryLocationDTO.country);
                        command.Parameters.AddWithValue(@"City", deliveryLocationDTO.city);
                        command.Parameters.AddWithValue(@"Area", deliveryLocationDTO.area);
                        command.Parameters.AddWithValue(@"Street", deliveryLocationDTO.street);
                        command.Parameters.AddWithValue(@"Latitude", deliveryLocationDTO.latitude);
                        command.Parameters.AddWithValue(@"Longitude", deliveryLocationDTO.longitude);
                        command.Parameters.AddWithValue(@"ReceiverPhoneNumber", deliveryLocationDTO.receiverPhoneNumber);
                        command.Parameters.AddWithValue(@"PaymentMethodID", paymentMethodDTO.paymentMethodID);
                        command.Parameters.AddWithValue(@"AccountID", orderDTO.accountID);
                        command.Parameters.AddWithValue(@"ProductInventoryID",orderItemsDTO.productInventoryID);


                        object result = command.ExecuteScalar();

                        if(result != null && int.TryParse(result.ToString() , out int newOrderID)) {
                            orderID = newOrderID;
                        }

                    }


                }




            } catch(Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }

            return orderID >= 1;
        }

        public static List<clsPlacedOrderDetailsDTO> getAccountOrdersByAccountID(clsAccountDTO accountDTO)
        {
            List<clsPlacedOrderDetailsDTO> list = new List<clsPlacedOrderDetailsDTO>();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetAccountOrdersByAccountID";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"AccountID",accountDTO.accountID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            while(reader.Read())
                            {

                                var order = new clsPlacedOrderDetailsDTO 
                                {
                                    // Order Info
                                    OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),
                                    OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    EstimatedDeliveryDate = reader.GetDateTime(reader.GetOrdinal("EstimatedDeliveryDate")),
                                    ActualDeliveryDate = reader.IsDBNull(reader.GetOrdinal("ActualDeliveryDate"))
                   ? (DateTime?)null
                   : reader.GetDateTime(reader.GetOrdinal("ActualDeliveryDate")),
                                    NumberOfLateDays = reader.IsDBNull(reader.GetOrdinal("NumberOfLateDays"))
                   ? (int?)null
                              : reader.GetInt32(reader.GetOrdinal("NumberOfLateDays")),

                                    // Delivery Info
                                    Country = reader.GetString(reader.GetOrdinal("Country")),
                                    City = reader.GetString(reader.GetOrdinal("City")),
                                    Area = reader.GetString(reader.GetOrdinal("Area")),
                                    Street = reader.GetString(reader.GetOrdinal("Street")),
                                    Latitude = reader.GetDouble(reader.GetOrdinal("Latitude")),
                                    Longitude = reader.GetDouble(reader.GetOrdinal("Longitude")),
                                    ReceiverPhoneNumber = reader.GetString(reader.GetOrdinal("ReceiverPhoneNumber")),

                                    // Payment Info
                                    PaymentMethod = reader.GetString(reader.GetOrdinal("PaymentMethod")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),

                                    // Product Inventory Info
                                    SKU = reader.GetString(reader.GetOrdinal("SKU")),
                                    Color = reader.GetString(reader.GetOrdinal("Color")),
                                    CapacityInGB = reader.IsDBNull(reader.GetOrdinal("CapacityInGB"))
                                     ? (int?)null
                                    : reader.GetInt32(reader.GetOrdinal("CapacityInGB")),
                                    PriceInJOD = reader.GetDecimal(reader.GetOrdinal("PriceInJOD")),
                                    StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),

                                    // Product Info
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                    ProductDescription = reader.GetString(reader.GetOrdinal("ProductDescription")),
                                    Category = reader.GetString(reader.GetOrdinal("Category"))
                                };


                                list.Add(order);
                            }

                        }



                    }

                }




            } catch(Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }




            return list;
        }

    }
}
