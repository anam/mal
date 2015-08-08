using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLIB_AuthorProvider:DataAccessObject
{
	public SqlLIB_AuthorProvider()
    {
    }


    public DataSet  GetAllLIB_Authors()
    {
        DataSet LIB_Authors = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_Authors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Authors);
            myadapter.Dispose();
            connection.Close();

            return LIB_Authors;
        }
    }
	public DataSet GetLIB_AuthorPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_AuthorPageWise", connection))
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


    public DataSet  GetDropDownListAllLIB_Author()
    {
        DataSet LIB_Authors = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_Authors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Authors);
            myadapter.Dispose();
            connection.Close();

            return LIB_Authors;
        }
    }

    public DataSet   GetAllINV_StoresWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_StoresWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<LIB_Author> GetLIB_AuthorsFromReader(IDataReader reader)
    {
        List<LIB_Author> lIB_Authors = new List<LIB_Author>();

        while (reader.Read())
        {
            lIB_Authors.Add(GetLIB_AuthorFromReader(reader));
        }
        return lIB_Authors;
    }

    public LIB_Author GetLIB_AuthorFromReader(IDataReader reader)
    {
        try
        {
            LIB_Author lIB_Author = new LIB_Author
                (

                     DataAccessObject.IsNULL<int>(reader["AuthorID"]),
                     DataAccessObject.IsNULL<string>(reader["AuthorName"]),
                     DataAccessObject.IsNULL<string>(reader["Address"]),
                     DataAccessObject.IsNULL<string>(reader["Email"]),
                     DataAccessObject.IsNULL<string>(reader["Phone"]),
                     DataAccessObject.IsNULL<string>(reader["Mobile"]),
                     DataAccessObject.IsNULL<string>(reader["Country"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return lIB_Author;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LIB_Author  GetLIB_AuthorByAuthorID(int  authorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_AuthorByAuthorID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AuthorID", SqlDbType.Int).Value = authorID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_AuthorFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertLIB_Author(LIB_Author lIB_Author)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = lIB_Author.AuthorName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = lIB_Author.Address;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = lIB_Author.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lIB_Author.Phone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = lIB_Author.Mobile;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = lIB_Author.Country;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_Author.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_Author.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Author.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Author.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AuthorID"].Value;
        }
    }

    public bool UpdateLIB_Author(LIB_Author lIB_Author)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLIB_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = lIB_Author.AuthorID;
            cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = lIB_Author.AuthorName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = lIB_Author.Address;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = lIB_Author.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lIB_Author.Phone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = lIB_Author.Mobile;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = lIB_Author.Country;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Author.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Author.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteLIB_Author(int authorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLIB_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = authorID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

