using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_BasicAccountProvider:DataAccessObject
{
	public SqlACC_BasicAccountProvider()
    {
    }


    public DataSet  GetAllACC_BasicAccounts()
    {
        DataSet ACC_BasicAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_BasicAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_BasicAccounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_BasicAccounts;
        }
    }
	public DataSet GetACC_BasicAccountPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_BasicAccountPageWise", connection))
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


    public ACC_BasicAccount  GetACC_BasicAccountByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BasicAccountByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_BasicAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_BasicAccount()
    {
        DataSet ACC_BasicAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_BasicAccount", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_BasicAccounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_BasicAccounts;
        }
    }

    public DataSet   GetAllACC_AccountsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_AccountsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_BasicAccount> GetACC_BasicAccountsFromReader(IDataReader reader)
    {
        List<ACC_BasicAccount> aCC_BasicAccounts = new List<ACC_BasicAccount>();

        while (reader.Read())
        {
            aCC_BasicAccounts.Add(GetACC_BasicAccountFromReader(reader));
        }
        return aCC_BasicAccounts;
    }

    public ACC_BasicAccount GetACC_BasicAccountFromReader(IDataReader reader)
    {
        try
        {
            ACC_BasicAccount aCC_BasicAccount = new ACC_BasicAccount
                (

                     DataAccessObject.IsNULL<int>(reader["BasicAccountID"]),
                     DataAccessObject.IsNULL<string>(reader["BasicAccountCode"]),
                     DataAccessObject.IsNULL<string>(reader["BasicAccountName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_BasicAccount;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_BasicAccount  GetACC_BasicAccountByBasicAccountID(int  basicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BasicAccountByBasicAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BasicAccountID", SqlDbType.Int).Value = basicAccountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_BasicAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_BasicAccount(ACC_BasicAccount aCC_BasicAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_BasicAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BasicAccountID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BasicAccountCode", SqlDbType.NVarChar).Value = aCC_BasicAccount.BasicAccountCode;
            cmd.Parameters.Add("@BasicAccountName", SqlDbType.NVarChar).Value = aCC_BasicAccount.BasicAccountName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_BasicAccount.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_BasicAccount.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_BasicAccount.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_BasicAccount.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_BasicAccount.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_BasicAccount.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BasicAccountID"].Value;
        }
    }

    public bool UpdateACC_BasicAccount(ACC_BasicAccount aCC_BasicAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_BasicAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BasicAccountID", SqlDbType.Int).Value = aCC_BasicAccount.BasicAccountID;
            cmd.Parameters.Add("@BasicAccountCode", SqlDbType.NVarChar).Value = aCC_BasicAccount.BasicAccountCode;
            cmd.Parameters.Add("@BasicAccountName", SqlDbType.NVarChar).Value = aCC_BasicAccount.BasicAccountName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_BasicAccount.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_BasicAccount.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_BasicAccount.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_BasicAccount.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_BasicAccount(int basicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_BasicAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BasicAccountID", SqlDbType.Int).Value = basicAccountID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

