using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ContactProvider:DataAccessObject
{
	public SqlHR_ContactProvider()
    {
    }


    public DataSet  GetAllHR_Contacts()
    {
        DataSet HR_Contacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Contacts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Contacts);
            myadapter.Dispose();
            connection.Close();

            return HR_Contacts;
        }
    }
    //
    public DataSet GetHR_ContactByEmployeeID(string EmployeeID)
    {
        DataSet HR_Contacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ContactByEmployeeID", connection);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Contacts);
            myadapter.Dispose();
            connection.Close();

            return HR_Contacts;
        }
    }
	public DataSet GetHR_ContactPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ContactPageWise", connection))
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

    public DataSet  GetDropDownLisAllHR_Contact()
    {
        DataSet HR_Contacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Contact", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Contacts);
            myadapter.Dispose();
            connection.Close();

            return HR_Contacts;
        }
    }

    public DataSet   GetAllHR_ContactsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ContactsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<HR_Contact> GetHR_ContactsFromReader(IDataReader reader)
    {
        List<HR_Contact> hR_Contacts = new List<HR_Contact>();

        while (reader.Read())
        {
            hR_Contacts.Add(GetHR_ContactFromReader(reader));
        }
        return hR_Contacts;
    }

    public HR_Contact GetHR_ContactFromReader(IDataReader reader)
    {
        try
        {
            HR_Contact hR_Contact = new HR_Contact
                (

                     DataAccessObject.IsNULL<int>(reader["ContactID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["CurrentAddress"]),
                     DataAccessObject.IsNULL<string>(reader["PermanentAddress"]),
                     DataAccessObject.IsNULL<string>(reader["Telephone"]),
                     DataAccessObject.IsNULL<string>(reader["Mobile"]),
                     DataAccessObject.IsNULL<string>(reader["Email"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Contact;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Contact  GetHR_ContactByContactID(int  contactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ContactByContactID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContactID", SqlDbType.Int).Value = contactID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ContactFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_Contact GetHR_ContactObjectByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ContactByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_ContactFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertHR_Contact(HR_Contact hR_Contact)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Contact.EmployeeID;
            cmd.Parameters.Add("@CurrentAddress", SqlDbType.NVarChar).Value = hR_Contact.CurrentAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = hR_Contact.PermanentAddress;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = hR_Contact.Telephone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = hR_Contact.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = hR_Contact.Email;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Contact.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Contact.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Contact.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Contact.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ContactID"].Value;
        }
    }

    public bool UpdateHR_Contact(HR_Contact hR_Contact)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = hR_Contact.ContactID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Contact.EmployeeID;
            cmd.Parameters.Add("@CurrentAddress", SqlDbType.NVarChar).Value = hR_Contact.CurrentAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = hR_Contact.PermanentAddress;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = hR_Contact.Telephone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = hR_Contact.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = hR_Contact.Email;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Contact.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Contact.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Contact(int contactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = contactID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

