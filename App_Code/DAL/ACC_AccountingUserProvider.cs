using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_AccountingUserProvider:DataAccessObject
{
	public SqlACC_AccountingUserProvider()
    {
    }


    public DataSet  GetAllACC_AccountingUsers()
    {
        DataSet ACC_AccountingUsers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_AccountingUsers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_AccountingUsers);
            myadapter.Dispose();
            connection.Close();

            return ACC_AccountingUsers;
        }
    }


    public DataSet GetAllACC_AccountingUsersOnlyBank()
    {
        DataSet ACC_AccountingUsers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_AccountingUsersOnlyBank", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_AccountingUsers);
            myadapter.Dispose();
            connection.Close();

            return ACC_AccountingUsers;
        }
    }

	public DataSet GetACC_AccountingUserPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_AccountingUserPageWise", connection))
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


    public ACC_AccountingUser  GetACC_AccountingUserByUserTypeID(int  userTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountingUserByUserTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserTypeID", SqlDbType.NVarChar).Value = userTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_AccountingUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }


    public DataSet GetACC_AccountingUserByUserTypeID(int userTypeID,bool isDataset)
    {
       
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_AccountingUserByUserTypeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserTypeID", userTypeID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public ACC_AccountingUser  GetACC_AccountingUserByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountingUserByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_AccountingUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_AccountingUser()
    {
        DataSet ACC_AccountingUsers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_AccountingUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_AccountingUsers);
            myadapter.Dispose();
            connection.Close();

            return ACC_AccountingUsers;
        }
    }
    public List<ACC_AccountingUser> GetACC_AccountingUsersFromReader(IDataReader reader)
    {
        List<ACC_AccountingUser> aCC_AccountingUsers = new List<ACC_AccountingUser>();

        while (reader.Read())
        {
            aCC_AccountingUsers.Add(GetACC_AccountingUserFromReader(reader));
        }
        return aCC_AccountingUsers;
    }

    public ACC_AccountingUser GetACC_AccountingUserFromReader(IDataReader reader)
    {
        try
        {
            ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser
                (

                     DataAccessObject.IsNULL<int>(reader["AccountingUserID"]),
                     DataAccessObject.IsNULL<string>(reader["AccountingUserName"]),
                     DataAccessObject.IsNULL<int>(reader["UserTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_AccountingUser;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_AccountingUser  GetACC_AccountingUserByAccountingUserID(int  accountingUserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountingUserByAccountingUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AccountingUserID", SqlDbType.Int).Value = accountingUserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_AccountingUserFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_AccountingUser(ACC_AccountingUser aCC_AccountingUser)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_AccountingUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountingUserID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AccountingUserName", SqlDbType.NVarChar).Value = aCC_AccountingUser.AccountingUserName;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = aCC_AccountingUser.UserTypeID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_AccountingUser.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_AccountingUser.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_AccountingUser.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_AccountingUser.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_AccountingUser.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AccountingUserID"].Value;
        }
    }

    public bool UpdateACC_AccountingUser(ACC_AccountingUser aCC_AccountingUser)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_AccountingUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountingUserID", SqlDbType.Int).Value = aCC_AccountingUser.AccountingUserID;
            cmd.Parameters.Add("@AccountingUserName", SqlDbType.NVarChar).Value = aCC_AccountingUser.AccountingUserName;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = aCC_AccountingUser.UserTypeID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_AccountingUser.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_AccountingUser.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_AccountingUser.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_AccountingUser(int accountingUserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_AccountingUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountingUserID", SqlDbType.Int).Value = accountingUserID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetACC_BankForChecks()
    {
        DataSet ACC_AccountingUsers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BankForChecks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_AccountingUsers);
            myadapter.Dispose();
            connection.Close();

            return ACC_AccountingUsers;
        }
    }
}

