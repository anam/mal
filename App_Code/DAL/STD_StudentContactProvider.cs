using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_StudentContactProvider:DataAccessObject
{
	public SqlSTD_StudentContactProvider()
    {
    }


    public DataSet  GetAllSTD_StudentContacts()
    {
        DataSet STD_StudentContacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_StudentContacts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_StudentContacts);
            myadapter.Dispose();
            connection.Close();

            return STD_StudentContacts;
        }
    }
	public DataSet GetSTD_StudentContactPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_StudentContactPageWise", connection))
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


    public STD_StudentContact  GetSTD_StudentContactBySudentID(string  sudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentContactBySudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SudentID", SqlDbType.NVarChar).Value = sudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_StudentContactFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_StudentContact  GetSTD_StudentContactByContactID(int  contactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentContactByContactID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContactID", SqlDbType.NVarChar).Value = contactID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_StudentContactFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_StudentContact()
    {
        DataSet STD_StudentContacts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_StudentContacts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_StudentContacts);
            myadapter.Dispose();
            connection.Close();

            return STD_StudentContacts;
        }
    }

    public DataSet   GetAllSTD_StudentContactsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_StudentContactsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_StudentContact> GetSTD_StudentContactsFromReader(IDataReader reader)
    {
        List<STD_StudentContact> sTD_StudentContacts = new List<STD_StudentContact>();

        while (reader.Read())
        {
            sTD_StudentContacts.Add(GetSTD_StudentContactFromReader(reader));
        }
        return sTD_StudentContacts;
    }

    public STD_StudentContact GetSTD_StudentContactFromReader(IDataReader reader)
    {
        try
        {
            STD_StudentContact sTD_StudentContact = new STD_StudentContact
                (

                     DataAccessObject.IsNULL<int>(reader["StudentContactID"]),
                     DataAccessObject.IsNULL<string>(reader["SudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ContactID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_StudentContact;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_StudentContact  GetSTD_StudentContactByStudentContactID(int  studentContactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentContactByStudentContactID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentContactID", SqlDbType.Int).Value = studentContactID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_StudentContactFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_StudentContact(STD_StudentContact sTD_StudentContact)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_StudentContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SudentID", SqlDbType.NVarChar).Value = sTD_StudentContact.SudentID;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = sTD_StudentContact.ContactID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_StudentContact.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_StudentContact.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_StudentContact.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_StudentContact.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@StudentContactID"].Value;
        }
    }

    public bool UpdateSTD_StudentContact(STD_StudentContact sTD_StudentContact)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_StudentContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentContactID", SqlDbType.Int).Value = sTD_StudentContact.StudentContactID;
            cmd.Parameters.Add("@SudentID", SqlDbType.NVarChar).Value = sTD_StudentContact.SudentID;
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = sTD_StudentContact.ContactID;
            //cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = sTD_StudentContact.ContactID;
            //cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = sTD_StudentContact.ContactID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_StudentContact.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_StudentContact.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_StudentContact(int studentContactID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_StudentContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentContactID", SqlDbType.Int).Value = studentContactID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

