using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ContactProvider:DataAccessObject
{
	public SqlSTD_ContactProvider()
    {
    }


    public DataSet  GetAllSTD_Contacts()
    {
        DataSet STD_Contacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Contacts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Contacts);
            myadapter.Dispose();
            connection.Close();

            return STD_Contacts;
        }
    }
	public DataSet GetSTD_ContactPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ContactPageWise", connection))
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


    public DataSet GetSTD_ContactByStudentID(string studentID, bool isDataSet)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("GetSTD_ContactByStudentID", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    
    public STD_Contact  GetSTD_ContactByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ContactByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ContactFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public STD_Contact  GetSTD_ContactByContactTypeID(int  contactTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ContactByContactTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContactTypeID", SqlDbType.NVarChar).Value = contactTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ContactFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_Contact()
    {
        DataSet STD_Contacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Contact", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Contacts);
            myadapter.Dispose();
            connection.Close();

            return STD_Contacts;
        }
    }

    public DataSet   GetAllSTD_ContactsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ContactsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Contact> GetSTD_ContactsFromReader(IDataReader reader)
    {
        List<STD_Contact> sTD_Contacts = new List<STD_Contact>();

        while (reader.Read())
        {
            sTD_Contacts.Add(GetSTD_ContactFromReader(reader));
        }
        return sTD_Contacts;
    }

    public STD_Contact GetSTD_ContactFromReader(IDataReader reader)
    {
        try
        {
            STD_Contact sTD_Contact = new STD_Contact
                (

                     DataAccessObject.IsNULL<int>(reader["ContactID"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["Name"]),
                     DataAccessObject.IsNULL<string>(reader["CellNo"]),
                     DataAccessObject.IsNULL<string>(reader["Occupation"]),
                     DataAccessObject.IsNULL<string>(reader["OfficeTel"]),
                     DataAccessObject.IsNULL<string>(reader["OfficeAddress"]),
                     DataAccessObject.IsNULL<int>(reader["ContactTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
            try
            {
                sTD_Contact.StudentName = DataAccessObject.IsNULL<string>(reader["StudentName"].ToString());
            }
            catch (Exception ex)
            {
            }
             return sTD_Contact;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Contact  GetSTD_ContactByContactID(int  contactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ContactByContactID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContactID", SqlDbType.Int).Value = contactID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ContactFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Contact(STD_Contact sTD_Contact)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_Contact.StudentID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = sTD_Contact.Name;
            cmd.Parameters.Add("@CellNo", SqlDbType.NVarChar).Value = sTD_Contact.CellNo;
            cmd.Parameters.Add("@Occupation", SqlDbType.NVarChar).Value = sTD_Contact.Occupation;
            cmd.Parameters.Add("@OfficeTel", SqlDbType.NVarChar).Value = sTD_Contact.OfficeTel;
            cmd.Parameters.Add("@OfficeAddress", SqlDbType.NVarChar).Value = sTD_Contact.OfficeAddress;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = sTD_Contact.ContactTypeID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Contact.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Contact.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_Contact.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_Contact.ModifiedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Contact.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ContactID"].Value;
        }
    }

    public bool UpdateSTD_Contact(STD_Contact sTD_Contact)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = sTD_Contact.ContactID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_Contact.StudentID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = sTD_Contact.Name;
            cmd.Parameters.Add("@CellNo", SqlDbType.NVarChar).Value = sTD_Contact.CellNo;
            cmd.Parameters.Add("@Occupation", SqlDbType.NVarChar).Value = sTD_Contact.Occupation;
            cmd.Parameters.Add("@OfficeTel", SqlDbType.NVarChar).Value = sTD_Contact.OfficeTel;
            cmd.Parameters.Add("@OfficeAddress", SqlDbType.NVarChar).Value = sTD_Contact.OfficeAddress;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = sTD_Contact.ContactTypeID;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = sTD_Contact.ContactTypeID;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = sTD_Contact.ContactTypeID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_Contact.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_Contact.ModifiedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Contact.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Contact(int contactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = contactID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteSTD_ContactByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ContactByStudentID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STD_Contact> GetSTD_ContactsByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ContactByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTD_ContactsFromReader(reader);

        }
    }
}

