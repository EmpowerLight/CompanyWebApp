using CompanyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompanyWebApp.Service
{
    public class AccessService
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand command;
        SqlDataReader reader;
        public Boolean AddNewUser(RegisterModel model) 
        {
            int result;
            try
            {
                command = new SqlCommand("sp_insert_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", model.Email);
                command.Parameters.AddWithValue("@password", HashService.hashPassword(model.Password));
                command.Parameters.AddWithValue("@contactNumber", model.ContactNumber);
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw;
            }finally
            {
                connection.Close();
            }
            

            return result > 0 ? true: false;
        }
        public Boolean LoginUser(LoginModel model)
        {
            string userEmail="", userPassword="";
            try
            {
                command = new SqlCommand("sp_select_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", model.Email);
                connection.Open();
                using(reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();
                        userEmail = reader["Email"].ToString();
                        userPassword = reader["Password"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }finally
            {
                connection.Close();
            }
            return model.Email == userEmail && HashService.VerifyPassword(model.Password, userPassword) ? true : false;
        }
    }
}