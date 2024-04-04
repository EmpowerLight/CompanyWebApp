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
    public class CompanyService
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dt;
        public List<CompanyModel> ListCompany()
        {
            List<CompanyModel> list = new List<CompanyModel>();
            try
            {
                command = new SqlCommand("sp_select", connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow d in dt.Rows)
                {
                    list.Add(new CompanyModel
                    {
                        Id = Convert.ToInt32(d["Id"]),
                        CompanyName = d["CompanyName"].ToString(),
                        Email = d["Email"].ToString(),
                        PhoneNumber = Convert.ToInt32(d["PhoneNumber"]),
                        MobileNumber = Convert.ToInt32(d["MobileNumber"])
                    });
                }
            } catch(Exception e)
            {
                throw;
            }
            return list;
        }

        public Boolean CreateCompany(CompanyModel data)
        {
            int result;
            try
            {
                command = new SqlCommand("sp_insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@companyName", data.CompanyName);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@phoneNumber", data.PhoneNumber);
                command.Parameters.AddWithValue("@mobileNumber", data.MobileNumber);
                connection.Open();
                result = command.ExecuteNonQuery();
            }catch(Exception e)
            {
                throw;
            }finally
            {
                connection.Close();
            }
            return result > 0 ? true : false;
        }

        public Boolean UpdateCompany(CompanyModel data)
        {
            int result;
            try
            {
                command = new SqlCommand("sp_update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@companyName", data.CompanyName);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@phoneNumber", data.PhoneNumber);
                command.Parameters.AddWithValue("@mobileNumber", data.MobileNumber);
                command.Parameters.AddWithValue("@id", data.Id);
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
            return result > 0 ? true : false;
        }

        public Boolean DeleteCompany(CompanyModel data)
        {
            int result;
            try
            {
                command = new SqlCommand("sp_delete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", data.Id);
                connection.Open();
                result = command.ExecuteNonQuery();
            } catch(Exception e)
            {
                throw;
            }finally
            {
                connection.Close();
            }
            return result > 0 ? true : false;
        }

        public List<CompanyInfoModel> ListCompanyInfo()
        {
            List<CompanyInfoModel> list = new List<CompanyInfoModel>();
            try
            {
                command = new SqlCommand("sp_ci_select", connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);

                foreach(DataRow d in dt.Rows)
                {
                    list.Add(new CompanyInfoModel
                    {
                        Cid = Convert.ToInt32(d["Cid"]),
                        DateOfInstallation = Convert.ToDateTime(d["DateOfInstallation"]),
                        DateOfRenew = Convert.ToDateTime(d["DateOfRenew"]),
                        DisplayMessage = d["DisplayMessage"].ToString(),
                        Remarks = d["Remarks"].ToString(),
                        Attachment = d["Attachment"].ToString(),
                        Id = Convert.ToInt32(d["Id"])
                    });
                }

            }catch(Exception e)
            {
                throw;
            }
            return list;
        }

        public Boolean CreateCompanyInfo(CompanyInfoModel data)
        {
            int result;
            try
            {
                command = new SqlCommand("sp_ci_insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dateOfInstallation", data.DateOfInstallation);
                command.Parameters.AddWithValue("@dateOfRenew", data.DateOfRenew);
                command.Parameters.AddWithValue("@displayMessage", data.DisplayMessage);
                command.Parameters.AddWithValue("@remarks", data.Remarks);
                command.Parameters.AddWithValue("@attachment", "File Name");
                command.Parameters.AddWithValue("@id", data.Id);
                connection.Open();
                result = command.ExecuteNonQuery();

            }catch(Exception e)
            {
                throw;
            }finally
            {
                connection.Close();
            }
            return result > 0 ? true : false;
        }

        public Boolean UpdateCompanyInfo(CompanyInfoModel data)
        {
            int result;
            try
            {
                command = new SqlCommand("sp_ci_update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dateOfInstallation", data.DateOfInstallation);
                command.Parameters.AddWithValue("@dateOfRenew", data.DateOfRenew);
                command.Parameters.AddWithValue("@displayMessage", data.DisplayMessage);
                command.Parameters.AddWithValue("@remarks", data.Remarks);
                command.Parameters.AddWithValue("@attachment", "File Name");
                command.Parameters.AddWithValue("@id", data.Id);
                command.Parameters.AddWithValue("@cid", data.Cid);
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
            return result > 0 ? true : false;
        }

        public Boolean DeleteCompanyInfo(CompanyInfoModel data)
        {
            int result;
            try
            {
                command = new SqlCommand("sp_ci_delete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cid", data.Cid);
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return result > 0 ? true : false;
        }
    }
}