using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLIB_BookIssueProvider:DataAccessObject
{
	public SqlLIB_BookIssueProvider()
    {
    }


    public DataSet  GetAllLIB_BookIssues()
    {
        DataSet LIB_BookIssues = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_BookIssues", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_BookIssues);
            myadapter.Dispose();
            connection.Close();

            return LIB_BookIssues;
        }
    }

    public DataSet GetLIB_BookIssuePageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_BookIssuePageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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

    public DataSet GetLIB_IssueBooksBySearchString(string searchSQLString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_IssueBooksBySearchString", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SearchSQLString", SqlDbType.NVarChar).Value = searchSQLString;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public LIB_BookIssue  GetLIB_BookIssueByBookID(int  bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookIssueByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.NVarChar).Value = bookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_BookIssueFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public LIB_BookIssue  GetLIB_BookIssueByIssedToID(string  issedToID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookIssueByIssedToID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IssedToID", SqlDbType.NVarChar).Value = issedToID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_BookIssueFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllLIB_BookIssue()
    {
        DataSet LIB_BookIssues = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_BookIssues", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_BookIssues);
            myadapter.Dispose();
            connection.Close();

            return LIB_BookIssues;
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
    public List<LIB_BookIssue> GetLIB_BookIssuesFromReader(IDataReader reader)
    {
        List<LIB_BookIssue> lIB_BookIssues = new List<LIB_BookIssue>();

        while (reader.Read())
        {
            lIB_BookIssues.Add(GetLIB_BookIssueFromReader(reader));
        }
        return lIB_BookIssues;
    }

    public LIB_BookIssue GetLIB_BookIssueFromReader(IDataReader reader)
    {
        try
        {
            LIB_BookIssue lIB_BookIssue = new LIB_BookIssue
                (

                     DataAccessObject.IsNULL<int>(reader["BookIssueID"]),
                     DataAccessObject.IsNULL<int>(reader["BookID"]),
                     DataAccessObject.IsNULL<string>(reader["IssedToID"].ToString()),
                     DataAccessObject.IsNULL<bool>(reader["IsStudent"]),
                     DataAccessObject.IsNULL<DateTime>(reader["IssueDate"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ReturnDate"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return lIB_BookIssue;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LIB_BookIssue  GetLIB_BookIssueByBookIssueID(int  bookIssueID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookIssueByBookIssueID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookIssueID", SqlDbType.Int).Value = bookIssueID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_BookIssueFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }
    //InsertLIB_BookReceive
    public int InsertLIB_BookReceive(LIB_BookIssue lIB_BookIssue)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_BookReceive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookIssueID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = lIB_BookIssue.BookID;
            cmd.Parameters.Add("@IssedToID", SqlDbType.NVarChar).Value = lIB_BookIssue.IssedToID;
            cmd.Parameters.Add("@IsStudent", SqlDbType.Bit).Value = lIB_BookIssue.IsStudent;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = lIB_BookIssue.IssueDate;
            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = lIB_BookIssue.ReturnDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_BookIssue.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_BookIssue.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_BookIssue.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_BookIssue.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BookIssueID"].Value;
        }
    }
    public int InsertLIB_BookIssue(LIB_BookIssue lIB_BookIssue)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_BookIssue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookIssueID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = lIB_BookIssue.BookID;
            cmd.Parameters.Add("@IssedToID", SqlDbType.NVarChar).Value = lIB_BookIssue.IssedToID;
            cmd.Parameters.Add("@IsStudent", SqlDbType.Bit).Value = lIB_BookIssue.IsStudent;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = lIB_BookIssue.IssueDate;
            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = lIB_BookIssue.ReturnDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_BookIssue.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_BookIssue.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_BookIssue.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_BookIssue.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BookIssueID"].Value;
        }
    }

    public bool UpdateLIB_BookIssue(LIB_BookIssue lIB_BookIssue)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLIB_BookIssue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookIssueID", SqlDbType.Int).Value = lIB_BookIssue.BookIssueID;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = lIB_BookIssue.BookID;
            cmd.Parameters.Add("@IssedToID", SqlDbType.NVarChar).Value = lIB_BookIssue.IssedToID;
            cmd.Parameters.Add("@IsStudent", SqlDbType.Bit).Value = lIB_BookIssue.IsStudent;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = lIB_BookIssue.IssueDate;
            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = lIB_BookIssue.ReturnDate;
            //cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = lIB_BookIssue.ReturnDate;
            //cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = lIB_BookIssue.ReturnDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_BookIssue.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_BookIssue.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteLIB_BookIssue(int bookIssueID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLIB_BookIssue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookIssueID", SqlDbType.Int).Value = bookIssueID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

