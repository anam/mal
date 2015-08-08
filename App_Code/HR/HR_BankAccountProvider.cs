using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_BankAccountProvider:DataAccessObject
{
	public SqlHR_BankAccountProvider()
    {
    }


    public DataSet  GetAllHR_BankAccounts()
    {
        DataSet HR_BankAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_BankAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BankAccounts);
            myadapter.Dispose();
            connection.Close();

            return HR_BankAccounts;
        }
    }
	public DataSet GetHR_BankAccountPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_BankAccountPageWise", connection))
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


    public HR_BankAccount  GetHR_BankAccountByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_BankAccountByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_BankAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_BankAccount()
    {
        DataSet HR_BankAccounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_BankAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BankAccounts);
            myadapter.Dispose();
            connection.Close();

            return HR_BankAccounts;
        }
    }

    public DataSet   GetAllHR_BankAccountsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_BankAccountsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_BankAccount> GetHR_BankAccountsFromReader(IDataReader reader)
    {
        List<HR_BankAccount> hR_BankAccounts = new List<HR_BankAccount>();

        while (reader.Read())
        {
            hR_BankAccounts.Add(GetHR_BankAccountFromReader(reader));
        }
        return hR_BankAccounts;
    }

    public HR_BankAccount GetHR_BankAccountFromReader(IDataReader reader)
    {
        try
        {
            HR_BankAccount hR_BankAccount = new HR_BankAccount
                (

                     DataAccessObject.IsNULL<int>(reader["BankAccountNoID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AccountName"]),
                     DataAccessObject.IsNULL<string>(reader["AccountNo"]),
                     DataAccessObject.IsNULL<string>(reader["BankName"]),
                     DataAccessObject.IsNULL<string>(reader["ContactPerson"]),
                     DataAccessObject.IsNULL<string>(reader["BankAddress"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_BankAccount;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_BankAccount  GetHR_BankAccountByBankAccountNoID(int  bankAccountNoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_BankAccountByBankAccountNoID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BankAccountNoID", SqlDbType.Int).Value = bankAccountNoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_BankAccountFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_BankAccount(HR_BankAccount hR_BankAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAccountNoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_BankAccount.EmployeeID;

            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = hR_BankAccount.AccountName;
            cmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = hR_BankAccount.AccountNo;

            cmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = hR_BankAccount.BankName;
            cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = hR_BankAccount.ContactPerson;
            cmd.Parameters.Add("@BankAddress", SqlDbType.NVarChar).Value = hR_BankAccount.BankAddress;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_BankAccount.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_BankAccount.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_BankAccount.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_BankAccount.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BankAccountNoID"].Value;
        }
    }

    public bool UpdateHR_BankAccount(HR_BankAccount hR_BankAccount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAccountNoID", SqlDbType.Int).Value = hR_BankAccount.BankAccountNoID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_BankAccount.EmployeeID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = hR_BankAccount.AccountName;
            cmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = hR_BankAccount.AccountNo;
            cmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = hR_BankAccount.BankName;
            cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = hR_BankAccount.ContactPerson;
            cmd.Parameters.Add("@BankAddress", SqlDbType.NVarChar).Value = hR_BankAccount.BankAddress;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_BankAccount.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_BankAccount.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_BankAccount(int bankAccountNoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAccountNoID", SqlDbType.Int).Value = bankAccountNoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

