using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_SubBasicAccountProvider:DataAccessObject
{
	public SqlACC_SubBasicAccountProvider()
    {
    }


    public DataSet  GetAllACC_SubBasicAccounts()
    {
        DataSet ACC_SubBasicAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_SubBasicAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_SubBasicAccounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_SubBasicAccounts;
        }
    }
	public DataSet GetACC_SubBasicAccountPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_SubBasicAccountPageWise", connection))
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


    public DataSet GetACC_SubBasicAccountByBasicAccountIDDataset(int basicAccountID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_SubBasicAccountByBasicAccountID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BasicAccountID", basicAccountID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public ACC_SubBasicAccount  GetACC_SubBasicAccountByBasicAccountID(int  basicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_SubBasicAccountByBasicAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BasicAccountID", SqlDbType.NVarChar).Value = basicAccountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_SubBasicAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_SubBasicAccount  GetACC_SubBasicAccountByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_SubBasicAccountByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_SubBasicAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_SubBasicAccount()
    {
        DataSet ACC_SubBasicAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_SubBasicAccount", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_SubBasicAccounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_SubBasicAccounts;
        }
    }

    public DataSet   GetAllACC_SubBasicAccountsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_SubBasicAccountsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_SubBasicAccount> GetACC_SubBasicAccountsFromReader(IDataReader reader)
    {
        List<ACC_SubBasicAccount> aCC_SubBasicAccounts = new List<ACC_SubBasicAccount>();

        while (reader.Read())
        {
            aCC_SubBasicAccounts.Add(GetACC_SubBasicAccountFromReader(reader));
        }
        return aCC_SubBasicAccounts;
    }

    public ACC_SubBasicAccount GetACC_SubBasicAccountFromReader(IDataReader reader)
    {
        try
        {
            ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount
                (

                     DataAccessObject.IsNULL<int>(reader["SubBasicAccountID"]),
                     DataAccessObject.IsNULL<string>(reader["SubBasicAccountCode"]),
                     DataAccessObject.IsNULL<string>(reader["SubBasicAccountName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["BasicAccountID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_SubBasicAccount;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_SubBasicAccount  GetACC_SubBasicAccountBySubBasicAccountID(int  subBasicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_SubBasicAccountBySubBasicAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Value = subBasicAccountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_SubBasicAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_SubBasicAccount(ACC_SubBasicAccount aCC_SubBasicAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_SubBasicAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubBasicAccountCode", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.SubBasicAccountCode;
            cmd.Parameters.Add("@SubBasicAccountName", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.SubBasicAccountName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_SubBasicAccount.Description;
            cmd.Parameters.Add("@BasicAccountID", SqlDbType.Int).Value = aCC_SubBasicAccount.BasicAccountID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_SubBasicAccount.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_SubBasicAccount.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_SubBasicAccount.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SubBasicAccountID"].Value;
        }
    }

    public bool UpdateACC_SubBasicAccount(ACC_SubBasicAccount aCC_SubBasicAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_SubBasicAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Value = aCC_SubBasicAccount.SubBasicAccountID;
            cmd.Parameters.Add("@SubBasicAccountCode", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.SubBasicAccountCode;
            cmd.Parameters.Add("@SubBasicAccountName", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.SubBasicAccountName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_SubBasicAccount.Description;
            cmd.Parameters.Add("@BasicAccountID", SqlDbType.Int).Value = aCC_SubBasicAccount.BasicAccountID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_SubBasicAccount.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_SubBasicAccount.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_SubBasicAccount.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_SubBasicAccount(int subBasicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_SubBasicAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Value = subBasicAccountID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<ACC_SubBasicAccount> GetACC_SubBasicAccountsFromReader1(IDataReader reader)
    {
        List<ACC_SubBasicAccount> aCC_SubBasicAccounts = new List<ACC_SubBasicAccount>();

        while (reader.Read())
        {
            aCC_SubBasicAccounts.Add(GetACC_SubBasicAccountFromReader1(reader));
        }
        return aCC_SubBasicAccounts;
    }

    public ACC_SubBasicAccount GetACC_SubBasicAccountFromReader1(IDataReader reader)
    {
        try
        {
            ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount
                (

                     DataAccessObject.IsNULL<int>(reader["SubBasicAccountID"])                    
                );
            return aCC_SubBasicAccount;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<ACC_SubBasicAccount> GetACC_SubBasicAccountsFromReader2(IDataReader reader)
    {
        List<ACC_SubBasicAccount> aCC_SubBasicAccounts = new List<ACC_SubBasicAccount>();

        while (reader.Read())
        {
            aCC_SubBasicAccounts.Add(GetACC_SubBasicAccountFromReader2(reader));
        }
        return aCC_SubBasicAccounts;
    }

    public ACC_SubBasicAccount GetACC_SubBasicAccountFromReader2(IDataReader reader)
    {
        try
        {
            ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount
                (

                     DataAccessObject.IsNULL<int>(reader["SubBasicAccountID"]),
                     DataAccessObject.IsNULL<int>(reader["BasicAccountID"])
                );
            return aCC_SubBasicAccount;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<ACC_SubBasicAccount> ViewACC_BasicAccountStatementsByDateRange(DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BasicStateMentByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACC_SubBasicAccountsFromReader1(reader);
        }
    }

    public List<ACC_SubBasicAccount> ViewACC_IncomeStatementsByDateRange(DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_IncomeStateMentByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACC_SubBasicAccountsFromReader2(reader);
        }
    }

    public List<ACC_SubBasicAccount> ViewACC_BalanceSheetByDateRange(DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BalanceSheetByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACC_SubBasicAccountsFromReader2(reader);
        }
    }
}

