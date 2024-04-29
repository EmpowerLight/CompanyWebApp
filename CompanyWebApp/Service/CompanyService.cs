using CompanyWebApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
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
                foreach(DataRow reader in dt.Rows)
                {
                    list.Add(new CompanyModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CompanyName = reader["CompanyName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]),
                        MobileNumber = Convert.ToInt32(reader["MobileNumber"])
                    });
                }
            }
            catch(Exception e)
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
                command.Parameters.AddWithValue("@attachment", data.Attachment);
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
                command.Parameters.AddWithValue("@attachment", data.Attachment);
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

        public List<WholeCompanyModel> WholeDetails(DateTime date)
        {
            List<WholeCompanyModel> list = new List<WholeCompanyModel> ();      
            
            try
            {
                command = new SqlCommand("sp_detail_whole", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@date", date);
                connection.Open();
                command.ExecuteNonQuery();
                adapter = new SqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);

                foreach(DataRow d in dt.Rows)
                {
                    CompanyModel company = new CompanyModel
                    {
                        Id = Convert.ToInt32(d["Id"]),
                        CompanyName = d["CompanyName"].ToString(),
                        Email = d["Email"].ToString(),
                        PhoneNumber = Convert.ToInt32(d["PhoneNumber"]),
                        MobileNumber = Convert.ToInt32(d["MobileNumber"])
                    };

                    CompanyInfoModel companyInfoModel = new CompanyInfoModel
                    {
                        Cid = Convert.ToInt32(d["Cid"]),
                        DateOfInstallation = Convert.ToDateTime(d["DateOfInstallation"]),
                        DateOfRenew = Convert.ToDateTime(d["DateOfRenew"]),
                        DisplayMessage = d["DisplayMessage"].ToString(),
                        Remarks = d["Remarks"].ToString(),
                        Attachment = d["Attachment"].ToString(),
                        Id = Convert.ToInt32(d["Id"])
                    };

                    WholeCompanyModel wholeCompanyModel = new WholeCompanyModel
                    {
                        Company = company,
                        CompanyInfo = companyInfoModel
                    };

                    list.Add(wholeCompanyModel);

                }
            }catch(Exception e)
            {
                throw;
            }finally
            {
                connection.Close();
            }
            return list;
        }
        
        public List<WholeCompanyModel> WholeDetailsFromName(string name)
        {
            List<WholeCompanyModel> list = new List<WholeCompanyModel>();
            try
            {
                command = new SqlCommand("sp_detail_name", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name);
                connection.Open();
                command.ExecuteNonQuery();
                adapter = new SqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow d in dt.Rows)
                {
                    CompanyModel company = new CompanyModel
                    {
                        Id = Convert.ToInt32(d["Id"]),
                        CompanyName = d["CompanyName"].ToString(),
                        Email = d["Email"].ToString(),
                        PhoneNumber = Convert.ToInt32(d["PhoneNumber"]),
                        MobileNumber = Convert.ToInt32(d["MobileNumber"])
                    };

                    CompanyInfoModel companyInfoModel = new CompanyInfoModel
                    {
                        Cid = Convert.ToInt32(d["Cid"]),
                        DateOfInstallation = Convert.ToDateTime(d["DateOfInstallation"]),
                        DateOfRenew = Convert.ToDateTime(d["DateOfRenew"]),
                        DisplayMessage = d["DisplayMessage"].ToString(),
                        Remarks = d["Remarks"].ToString(),
                        Attachment = d["Attachment"].ToString(),
                        Id = Convert.ToInt32(d["Id"])
                    };

                    WholeCompanyModel wholeCompanyModel = new WholeCompanyModel
                    {
                        Company = company,
                        CompanyInfo = companyInfoModel
                    };

                    list.Add(wholeCompanyModel);

                }
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            
            
            return list;
        }

        public Boolean makePayment(PaymentModel model)
        {
            int result = 0, result1 = 0;
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                string query = "INSERT INTO Payment (PaymentType, PaymentDate, Cid) VALUES (@PaymentType, @PaymentDate, @Cid)";
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@PaymentType", model.PaymentType);
                    command.Parameters.AddWithValue("@PaymentDate", model.PaymentDate);
                    command.Parameters.AddWithValue("@Cid", model.Cid);
                    result = command.ExecuteNonQuery();
                }

                query = "UPDATE Companies_Infos SET DateOfInstallation = @dateOfInstallation, DateOfRenew = @dateOfRenew WHERE Cid = @cid";
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@dateOfInstallation", model.PaymentDate.AddYears(1));
                    command.Parameters.AddWithValue("@dateOfRenew", model.PaymentDate);
                    command.Parameters.AddWithValue("@cid", model.Cid);
                    result1 = command.ExecuteNonQuery();
                }

                // Commit the transaction if both commands succeed
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            // Return true if both commands succeed, otherwise false
            return (result > 0 && result1 > 0);
        }

        public List<WholeCompanyModel> getAboutExpireCompany()
        {
            List<WholeCompanyModel> list = new List<WholeCompanyModel>();
            try
            {
                command = new SqlCommand("sp_whole_companies", connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);

                foreach(DataRow d in dt.Rows)
                {
                    if (d["DateOfInstallation"] != DBNull.Value && d["DateOfRenew"] != DBNull.Value)
                    {
                        DateTime dateOfinst = Convert.ToDateTime(d["DateOfInstallation"]);

                        DateTime oneMonthafter = DateTime.Now.AddMonths(1);

                        if (oneMonthafter == dateOfinst || oneMonthafter >= dateOfinst)
                        {
                            list.Add(new WholeCompanyModel
                            {
                                Company = new CompanyModel
                                {

                                    Id = Convert.ToInt32(d["Id"]),
                                    CompanyName = d["CompanyName"].ToString(),
                                    Email = d["Email"].ToString(),
                                    PhoneNumber = Convert.ToInt32(d["PhoneNumber"]),
                                    MobileNumber = Convert.ToInt32(d["MobileNumber"])
                                },
                                CompanyInfo = new CompanyInfoModel
                                {
                                    Cid = Convert.ToInt32(d["Cid"]),
                                    DateOfInstallation = Convert.ToDateTime(d["DateOfInstallation"]),
                                    DateOfRenew = Convert.ToDateTime(d["DateOfRenew"]),
                                    DisplayMessage = d["DisplayMessage"].ToString(),
                                    Remarks = d["Remarks"].ToString(),
                                    Attachment = d["Attachment"].ToString(),
                                    Id = Convert.ToInt32(d["Id"])
                                }

                            });
                        }
                    }
                    
                    
                }
            }catch(Exception) {
                throw;
            }finally
            {
                connection.Close();
            }
            return list;
        }
    }
}