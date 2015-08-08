using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_BankAccountProvider:DataAccessObject
{
	public SqlACC_BankAccountProvider()
    {
    }


    public DataSet  GetAllACC_BankAccounts()
    {
        DataSet ACC_BankAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_BankAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_BankAccounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_BankAccounts;
        }
    }
	public DataSet GetACC_BankAccountPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_BankAccountPageWise", connection))
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


    public ACC_BankAccount  GetACC_BankAccountByBankID(int  bankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BankAccountByBankID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BankID", SqlDbType.NVarChar).Value = bankID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_BankAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_BankAccount  GetACC_BankAccountByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BankAccountByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_BankAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_BankAccount()
    {
        DataSet ACC_BankAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_BankAccount", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_BankAccounts);
            myadapter.Dispose();
            connection.Close();

            return ACC_BankAccounts;
        }
    }

    public DataSet   GetAllACC_BankAccountsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_BankAccountsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_BankAccount> GetACC_BankAccountsFromReader(IDataReader reader)
    {
        List<ACC_BankAccount> aCC_BankAccounts = new List<ACC_BankAccount>();

        while (reader.Read())
        {
            aCC_BankAccounts.Add(GetACC_BankAccountFromReader(reader));
        }
        return aCC_BankAccounts;
    }

    public ACC_BankAccount GetACC_BankAccountFromReader(IDataReader reader)
    {
        try
        {
            ACC_BankAccount aCC_BankAccount = new ACC_BankAccount
                (

                     DataAccessObject.IsNULL<int>(reader["BankAcountID"]),
                     DataAccessObject.IsNULL<string>(reader["BankAccountName"]),
                     DataAccessObject.IsNULL<string>(reader["AccountNo"]),
                     DataAccessObject.IsNULL<int>(reader["BankID"]),
                     DataAccessObject.IsNULL<string>(reader["BranchNOtherDetails"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_BankAccount;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_BankAccount  GetACC_BankAccountByBankAcountID(int  bankAcountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_BankAccountByBankAcountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BankAcountID", SqlDbType.Int).Value = bankAcountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_BankAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_BankAccount(ACC_BankAccount aCC_BankAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAcountID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BankAccountName", SqlDbType.NVarChar).Value = aCC_BankAccount.BankAccountName;
            cmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = aCC_BankAccount.AccountNo;
            cmd.Parameters.Add("@BankID", SqlDbType.Int).Value = aCC_BankAccount.BankID;
            cmd.Parameters.Add("@BranchNOtherDetails", SqlDbType.NText).Value = aCC_BankAccount.BranchNOtherDetails;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_BankAccount.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_BankAccount.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_BankAccount.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_BankAccount.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_BankAccount.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BankAcountID"].Value;
        }
    }

    public bool UpdateACC_BankAccount(ACC_BankAccount aCC_BankAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAcountID", SqlDbType.Int).Value = aCC_BankAccount.BankAcountID;
            cmd.Parameters.Add("@BankAccountName", SqlDbType.NVarChar).Value = aCC_BankAccount.BankAccountName;
            cmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = aCC_BankAccount.AccountNo;
            cmd.Parameters.Add("@BankID", SqlDbType.Int).Value = aCC_BankAccount.BankID;
            cmd.Parameters.Add("@BranchNOtherDetails", SqlDbType.NText).Value = aCC_BankAccount.BranchNOtherDetails;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = aCC_BankAccount.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_BankAccount.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_BankAccount.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_BankAccount.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_BankAccount(int bankAcountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAcountID", SqlDbType.Int).Value = bankAcountID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

