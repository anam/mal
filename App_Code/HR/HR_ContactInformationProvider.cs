using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ContactInformationProvider:DataAccessObject
{
	public SqlHR_ContactInformationProvider()
    {
    }


    public DataSet  GetAllHR_ContactInformations()
    {
        DataSet HR_ContactInformations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ContactInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ContactInformations);
            myadapter.Dispose();
            connection.Close();

            return HR_ContactInformations;
        }
    }
	public DataSet GetHR_ContactInformationPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ContactInformationPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize",  PageSize );
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
                return ds;
            }
        }
    }


    public HR_ContactInformation  GetHR_ContactInformationByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ContactInformationByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ContactInformationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_ContactInformation()
    {
        DataSet HR_ContactInformations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ContactInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ContactInformations);
            myadapter.Dispose();
            connection.Close();

            return HR_ContactInformations;
        }
    }

    public DataSet   GetAllHR_ContactInformationsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ContactInformationsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_ContactInformation> GetHR_ContactInformationsFromReader(IDataReader reader)
    {
        List<HR_ContactInformation> hR_ContactInformations = new List<HR_ContactInformation>();

        while (reader.Read())
        {
            hR_ContactInformations.Add(GetHR_ContactInformationFromReader(reader));
        }
        return hR_ContactInformations;
    }

    public HR_ContactInformation GetHR_ContactInformationFromReader(IDataReader reader)
    {
        try
        {
            HR_ContactInformation hR_ContactInformation = new HR_ContactInformation
                (

                     DataAccessObject.IsNULL<int>(reader["ContactInformationID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["CurrentAddress"]),
                     DataAccessObject.IsNULL<string>(reader["ParmanentAddress"]),
                     DataAccessObject.IsNULL<string>(reader["Email"]),
                     DataAccessObject.IsNULL<string>(reader["Telephone"]),
                     DataAccessObject.IsNULL<string>(reader["Mobile"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_ContactInformation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_ContactInformation  GetHR_ContactInformationByContactInformationID(int  contactInformationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ContactInformationByContactInformationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContactInformationID", SqlDbType.Int).Value = contactInformationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ContactInformationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_ContactInformation(HR_ContactInformation hR_ContactInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ContactInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactInformationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ContactInformation.EmployeeID;
            cmd.Parameters.Add("@CurrentAddress", SqlDbType.NVarChar).Value = hR_ContactInformation.CurrentAddress;
            cmd.Parameters.Add("@ParmanentAddress", SqlDbType.NVarChar).Value = hR_ContactInformation.ParmanentAddress;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = hR_ContactInformation.Email;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = hR_ContactInformation.Telephone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = hR_ContactInformation.Mobile;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ContactInformation.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ContactInformation.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ContactInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ContactInformation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ContactInformationID"].Value;
        }
    }

    public bool UpdateHR_ContactInformation(HR_ContactInformation hR_ContactInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ContactInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactInformationID", SqlDbType.Int).Value = hR_ContactInformation.ContactInformationID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ContactInformation.EmployeeID;
            cmd.Parameters.Add("@CurrentAddress", SqlDbType.NVarChar).Value = hR_ContactInformation.CurrentAddress;
            cmd.Parameters.Add("@ParmanentAddress", SqlDbType.NVarChar).Value = hR_ContactInformation.ParmanentAddress;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = hR_ContactInformation.Email;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = hR_ContactInformation.Telephone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = hR_ContactInformation.Mobile;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = hR_ContactInformation.Mobile;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = hR_ContactInformation.Mobile;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ContactInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ContactInformation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ContactInformation(int contactInformationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ContactInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactInformationID", SqlDbType.Int).Value = contactInformationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

