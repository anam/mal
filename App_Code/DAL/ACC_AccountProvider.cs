using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_AccountProvider:DataAccessObject
{
	public SqlACC_AccountProvider()
    {
    }


    public DataSet  GetAllACC_Accounts()
    {
        DataSet ACC_Accounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_Accounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Accounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_Accounts;
        }
    }

    public DataSet GetAllTypesACC_Accounts()
    {
        DataSet ACC_Accounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllTypesACC_Accounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Accounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_Accounts;
        }
    }

	public DataSet GetACC_AccountPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_AccountPageWise", connection))
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


    public ACC_Account  GetACC_AccountBySubBasicAccountID(int  subBasicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountBySubBasicAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubBasicAccountID", SqlDbType.NVarChar).Value = subBasicAccountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_AccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetACC_AccountBySubBasicAccountID(int subBasicAccountID,bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_AccountBySubBasicAccountID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SubBasicAccountID", subBasicAccountID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetACC_AccountByBasicAccountID(int BasicAccountID, bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_AccountByBasicAccountID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BasicAccountID", BasicAccountID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }




    public ACC_Account  GetACC_AccountByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_AccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_Account()
    {
        DataSet ACC_Accounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_Account", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Accounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_Accounts;
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
    public List<ACC_Account> GetACC_AccountsFromReader(IDataReader reader)
    {
        List<ACC_Account> aCC_Accounts = new List<ACC_Account>();

        while (reader.Read())
        {
            aCC_Accounts.Add(GetACC_AccountFromReader(reader));
        }
        return aCC_Accounts;
    }

    public ACC_Account GetACC_AccountFromReader(IDataReader reader)
    {
        try
        {
            ACC_Account aCC_Account = new ACC_Account
                (

                     DataAccessObject.IsNULL<int>(reader["AccountID"]),
                     DataAccessObject.IsNULL<string>(reader["AccountName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["SubBasicAccountID"]),
                     DataAccessObject.IsNULL<string>(reader["AccountCode"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
            try
            {
                aCC_Account.BasicAccountID = DataAccessObject.IsNULL<int>(reader["BasicAccountID"]);
            }
            catch (Exception ex)
            { }

             return aCC_Account;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List<ACC_Account> GetACC_AccountsFromReader1(IDataReader reader)
    {
        List<ACC_Account> aCC_Accounts = new List<ACC_Account>();

        while (reader.Read())
        {
            aCC_Accounts.Add(GetACC_AccountFromReader1(reader));
        }
        return aCC_Accounts;
    }

    public ACC_Account GetACC_AccountFromReader1(IDataReader reader)
    {
        try
        {
            ACC_Account aCC_Account = new ACC_Account
                (

                     DataAccessObject.IsNULL<int>(reader["AccountID"])                   
                );
            return aCC_Account;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ACC_Account  GetACC_AccountByAccountID(int  accountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountByAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_AccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_Account(ACC_Account aCC_Account)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_Account", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = aCC_Account.AccountName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_Account.Description;
            cmd.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Value = aCC_Account.SubBasicAccountID;
            cmd.Parameters.Add("@AccountCode", SqlDbType.NVarChar).Value = aCC_Account.AccountCode;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Account.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Account.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Account.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Account.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Account.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AccountID"].Value;
        }
    }

    public bool UpdateACC_Account(ACC_Account aCC_Account)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_Account", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = aCC_Account.AccountID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = aCC_Account.AccountName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_Account.Description;
            cmd.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Value = aCC_Account.SubBasicAccountID;
            cmd.Parameters.Add("@AccountCode", SqlDbType.NVarChar).Value = aCC_Account.AccountCode;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Account.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Account.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Account.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Account.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Account.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_Account(int accountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_Account", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<ACC_Account> ViewAllACC_JournalsByDateRange(DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountJournalByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACC_AccountsFromReader1(reader);
        }
    }

    public List<ACC_Account> GetAllAccountBySubBasicAccountID(int subBasicAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountBySubBasicAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubBasicAccountID", SqlDbType.Int).Value = subBasicAccountID;           
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACC_AccountsFromReader(reader);
        }
    }
}

