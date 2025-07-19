using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer
{
    public class clsUserDataAccess
    {
        public static bool signInByUsernameAndPassword(clsUserDTO userDTO)
        {
            bool isSucceed = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();


                    string cmd = "SP_SignInByUsernameAndPassword";

                    using(SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"Username",userDTO.username);
                        command.Parameters.AddWithValue(@"Password", userDTO.password);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isSucceed = true;                              
                            }


                        }
                    }
                }



            } catch(Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");

            } finally
            {
                // Log Login Attempt
            }




            return isSucceed;
        }

        public static bool signUp(clsPersonDTO personDTO , clsUserDTO userDTO)
        {
            bool isSucceed = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();


                    string cmd = "SP_SignUp";
                    using(SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@FirstName", personDTO.firstName);
                        command.Parameters.AddWithValue("@SecondName", personDTO.secondName);
                        command.Parameters.AddWithValue("@ThirdName", personDTO.thirdName);
                        command.Parameters.AddWithValue("@LastName", personDTO.lastName);
                        command.Parameters.AddWithValue("@PhoneNumber", personDTO.phoneNumber);
                        command.Parameters.AddWithValue("@Email", personDTO.email);
                        command.Parameters.AddWithValue("@Gender", personDTO.gedner);
                        command.Parameters.AddWithValue("@Username", userDTO.username);
                        command.Parameters.AddWithValue("@Password", userDTO.password);

                        
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newAccountID) && newAccountID > 0)
                        {
                            isSucceed = true;
                        }


                    }


                }


            } catch(Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }





            return isSucceed;
        }

        public static bool doesUsernameExist(clsUserDTO userDTO)
        {
            bool isExist = false;

            try
            {

                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();


                    string cmd = "SP_DoesUsernameExist";
                    using (SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"Username", userDTO.username);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                isExist = true;
                            }
                        }
                    }
                }


            } catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }

            return isExist;
        }

        public static bool getUserByUserID(clsUserDTO userDTO)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetUserByUserID";
                    using(SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"UserID",userDTO.userID);
                        
                        using(SqlDataReader reader =command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;

                                userDTO.personID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                                userDTO.username = reader.GetString(reader.GetOrdinal("Username"));
                                userDTO.password = reader.GetString(reader.GetOrdinal("Password"));

                            }
                        }
                    }
                }

            } catch(Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }



            return isFound;
        }

        public static bool getUserByUsername(clsUserDTO userDTO)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetUserByUsername";
                    using(SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"Username",userDTO.username);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if(reader.Read())
                            {
                                isFound = true;

                                userDTO.userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                userDTO.personID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                                userDTO.username = reader.GetString(reader.GetOrdinal("Username"));
                                userDTO.password = reader.GetString (reader.GetOrdinal("Password"));
                            }
                        }
                    }
                }



            } catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }




            return isFound;
        }

        public static bool updateUserInformation(clsPersonDTO personDTO , clsUserDTO userDTO)
        {
            int numberOfAffectedRows = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string cmd = "SP_UpdateUserInformation";
                    using(SqlCommand command = new SqlCommand (cmd,connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@PersonID", personDTO.personID);
                        command.Parameters.AddWithValue("@UserID", userDTO.userID);
                        command.Parameters.AddWithValue("@FirstName", personDTO.firstName);
                        command.Parameters.AddWithValue("@SecondName", personDTO.secondName);
                        command.Parameters.AddWithValue("@ThirdName", personDTO.thirdName);
                        command.Parameters.AddWithValue("@LastName", personDTO.lastName);
                        command.Parameters.AddWithValue("@PhoneNumber", personDTO.phoneNumber);
                        command.Parameters.AddWithValue("@Email", personDTO.email);
                        command.Parameters.AddWithValue("@Gender", personDTO.gedner);
                        command.Parameters.AddWithValue("@Username", userDTO.username);
                        command.Parameters.AddWithValue("@Password", userDTO.password);

                        numberOfAffectedRows = command.ExecuteNonQuery();

                 
                    }
                }

            } catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }



            return numberOfAffectedRows >= 1;
        }

    }
}
