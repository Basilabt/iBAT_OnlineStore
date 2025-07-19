using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBAT_Store_DataAccess_Layer
{
    public class clsPersonDataAccess
    {

        public static bool getPersonByPersonID(clsPersonDTO personDTO)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();


                    string cmd = "SP_GetPersonByPersonID";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(@"PersonID",personDTO.personID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;

                                personDTO.personID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                                personDTO.firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                personDTO.secondName = reader.GetString(reader.GetOrdinal("SecondName"));
                                personDTO.thirdName = reader.GetString(reader.GetOrdinal("ThirdName"));
                                personDTO.lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                personDTO.phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                personDTO.email = reader.GetString(reader.GetOrdinal("Email"));
                                personDTO.gedner = reader.GetInt32(reader.GetOrdinal("Gender"));

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

    }
}
