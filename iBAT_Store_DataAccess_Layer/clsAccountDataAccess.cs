using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer
{
    public class clsAccountDataAccess
    {

        public static bool getAccountByAccountID(clsAccountDTO accountDTO)
        {
            bool isFound = false;


            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetAccountByAccountID";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"AccountID", accountDTO.accountID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                accountDTO.accountID = reader.GetInt32(reader.GetOrdinal("AccountID"));
                                accountDTO.userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                accountDTO.loyaltyPoins = reader.GetInt32(reader.GetOrdinal("LoyaltyPoints"));
                                accountDTO.isActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                                accountDTO.creationDateTime = reader.GetDateTime(reader.GetOrdinal("CreationDateTime"));

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

        public static bool getAccountByUserID(clsUserDTO userDTO , clsAccountDTO accountDTO)
        {

            bool isFound = false;


            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetAccountByUserID";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"UserID", userDTO.userID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                accountDTO.accountID = reader.GetInt32(reader.GetOrdinal("AccountID"));
                                accountDTO.userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                accountDTO.loyaltyPoins = reader.GetInt32(reader.GetOrdinal("LoyaltyPoints"));
                                accountDTO.isActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                                accountDTO.creationDateTime = reader.GetDateTime(reader.GetOrdinal("CreationDateTime"));

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
