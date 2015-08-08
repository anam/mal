using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_HeadUserProvider:DataAccessObject
{
	public SqlACC_HeadUserProvider()
    {
    }


    public DataSet  GetAllACC_HeadUsers()
    {
        DataSet ACC_HeadUsers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_HeadUsers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_HeadUsers);
            myadapter.Dispose();
            connection.Close();

            return ACC_HeadUsers;
        }
    }
	public DataSet GetACC_HeadUserPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_HeadUserPageWise", connection))
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


    public ACC_HeadUser  GetACC_HeadUserByHeadID(int  headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadUserByHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadID", SqlDbType.NVarChar).Value = headID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetACC_HeadUserByUserIDnUserTypeIDnAccountID(string userID, int userTypeID, int accountID)
    {
        
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_HeadUserByUserIDnUserTypeIDnAccountID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@UserTypeID", userTypeID);
                command.Parameters.AddWithValue("@AccountID", accountID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }

    public ACC_HeadUser GetACC_HeadUserByUserID(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadUserByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetACC_HeadUserFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public ACC_HeadUser  GetACC_HeadUserByUserTypeID(int  userTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadUserByUserTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserTypeID", SqlDbType.NVarChar).Value = userTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_HeadUser  GetACC_HeadUserByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadUserByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_HeadUser()
    {
        DataSet ACC_HeadUsers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_HeadUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_HeadUsers);
            myadapter.Dispose();
            connection.Close();

            return ACC_HeadUsers;
        }
    }

    public DataSet   GetAllACC_HeadUsersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_HeadUsersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_HeadUser> GetACC_HeadUsersFromReader(IDataReader reader)
    {
        List<ACC_HeadUser> aCC_HeadUsers = new List<ACC_HeadUser>();

        while (reader.Read())
        {
            aCC_HeadUsers.Add(GetACC_HeadUserFromReader(reader));
        }
        return aCC_HeadUsers;
    }

    public ACC_HeadUser GetACC_HeadUserFromReader(IDataReader reader)
    {
        try
        {
            ACC_HeadUser aCC_HeadUser = new ACC_HeadUser
                (

                     DataAccessObject.IsNULL<int>(reader["HeadUserID"]),
                     DataAccessObject.IsNULL<string>(reader["HeadUserName"]),
                     DataAccessObject.IsNULL<int>(reader["HeadID"]),
                     DataAccessObject.IsNULL<string>(reader["UserID"]),
                     DataAccessObject.IsNULL<int>(reader["UserTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_HeadUser;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_HeadUser  GetACC_HeadUserByHeadUserID(int  headUserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadUserByHeadUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadUserID", SqlDbType.Int).Value = headUserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_HeadUser(ACC_HeadUser aCC_HeadUser)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_HeadUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadUserID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HeadUserName", SqlDbType.NVarChar).Value = aCC_HeadUser.HeadUserName;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_HeadUser.HeadID;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = aCC_HeadUser.UserID;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = aCC_HeadUser.UserTypeID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_HeadUser.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_HeadUser.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_HeadUser.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_HeadUser.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_HeadUser.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@HeadUserID"].Value;
        }
    }

    public bool UpdateACC_HeadUser(ACC_HeadUser aCC_HeadUser)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_HeadUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadUserID", SqlDbType.Int).Value = aCC_HeadUser.HeadUserID;
            cmd.Parameters.Add("@HeadUserName", SqlDbType.NVarChar).Value = aCC_HeadUser.HeadUserName;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_HeadUser.HeadID;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = aCC_HeadUser.UserID;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = aCC_HeadUser.UserTypeID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_HeadUser.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_HeadUser.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_HeadUser.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_HeadUser(int headUserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_HeadUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadUserID", SqlDbType.Int).Value = headUserID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

