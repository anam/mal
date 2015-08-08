using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLIB_PublisherProvider:DataAccessObject
{
	public SqlLIB_PublisherProvider()
    {
    }


    public DataSet  GetAllLIB_Publishers()
    {
        DataSet LIB_Publishers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_Publishers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Publishers);
            myadapter.Dispose();
            connection.Close();

            return LIB_Publishers;
        }
    }
	public DataSet GetLIB_PublisherPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_PublisherPageWise", connection))
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


    public DataSet  GetDropDownListAllLIB_Publisher()
    {
        DataSet LIB_Publishers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_Publishers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Publishers);
            myadapter.Dispose();
            connection.Close();

            return LIB_Publishers;
        }
    }

    public DataSet   GetAllLIB_BookIssuesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_BookIssuesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<LIB_Publisher> GetLIB_PublishersFromReader(IDataReader reader)
    {
        List<LIB_Publisher> lIB_Publishers = new List<LIB_Publisher>();

        while (reader.Read())
        {
            lIB_Publishers.Add(GetLIB_PublisherFromReader(reader));
        }
        return lIB_Publishers;
    }

    public LIB_Publisher GetLIB_PublisherFromReader(IDataReader reader)
    {
        try
        {
            LIB_Publisher lIB_Publisher = new LIB_Publisher
                (

                     DataAccessObject.IsNULL<int>(reader["PublisherID"]),
                     DataAccessObject.IsNULL<string>(reader["Address"]),
                     DataAccessObject.IsNULL<string>(reader["PublisherName"]),
                     DataAccessObject.IsNULL<string>(reader["Email"]),
                     DataAccessObject.IsNULL<string>(reader["Phone"]),
                     DataAccessObject.IsNULL<string>(reader["Mobile"]),
                     DataAccessObject.IsNULL<string>(reader["Country"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return lIB_Publisher;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LIB_Publisher  GetLIB_PublisherByPublisherID(int  publisherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_PublisherByPublisherID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PublisherID", SqlDbType.Int).Value = publisherID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_PublisherFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertLIB_Publisher(LIB_Publisher lIB_Publisher)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_Publisher", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PublisherID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = lIB_Publisher.Address;
            cmd.Parameters.Add("@PublisherName", SqlDbType.NVarChar).Value = lIB_Publisher.PublisherName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = lIB_Publisher.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lIB_Publisher.Phone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = lIB_Publisher.Mobile;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = lIB_Publisher.Country;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_Publisher.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_Publisher.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Publisher.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Publisher.ModifiedDate;
          connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PublisherID"].Value;
        }
    }

    public bool UpdateLIB_Publisher(LIB_Publisher lIB_Publisher)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLIB_Publisher", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PublisherID", SqlDbType.Int).Value = lIB_Publisher.PublisherID;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = lIB_Publisher.Address;
            cmd.Parameters.Add("@PublisherName", SqlDbType.NVarChar).Value = lIB_Publisher.PublisherName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = lIB_Publisher.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lIB_Publisher.Phone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = lIB_Publisher.Mobile;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = lIB_Publisher.Country;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Publisher.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Publisher.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteLIB_Publisher(int publisherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLIB_Publisher", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PublisherID", SqlDbType.Int).Value = publisherID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

