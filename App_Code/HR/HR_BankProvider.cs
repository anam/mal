using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_BankProvider:DataAccessObject
{
	public SqlHR_BankProvider()
    {
    }


    public DataSet GetAllHR_BankAccounts()
    {
        DataSet HR_Banks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_BankAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Banks);
            myadapter.Dispose();
            connection.Close();

            return HR_Banks;
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


    public HR_BankAccount GetHR_BankAccountByEmployeeID(string employeeID)
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

    public DataSet GetDropDownListAllHR_BankAccount()
    {
        DataSet HR_Banks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_BankAccount", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Banks);
            myadapter.Dispose();
            connection.Close();

            return HR_Banks;
        }
    }

    public DataSet GetAllHR_BankAccountsWithRelation()
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
        List<HR_BankAccount> hR_Banks = new List<HR_BankAccount>();

        while (reader.Read())
        {
            hR_Banks.Add(GetHR_BankAccountFromReader(reader));
        }
        return hR_Banks;
    }

    public HR_BankAccount GetHR_BankAccountFromReader(IDataReader reader)
    {
        try
        {
            HR_BankAccount hR_Bank = new HR_BankAccount
                (

                     DataAccessObject.IsNULL<int>(reader["BankAccountNoID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AccountName"]),
                     DataAccessObject.IsNULL<string>(reader["AccountNo"]),
                     DataAccessObject.IsNULL<string>(reader["BankName"]),
                     DataAccessObject.IsNULL<string>(reader["BankAddress"]),
                     DataAccessObject.IsNULL<string>(reader["ContactPerson"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Bank;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_BankAccount GetHR_BankAccountByBankAccountNoID(int bankAccountNoID)
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

    public int InsertHR_BankAccount(HR_BankAccount hR_Bank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAccountNoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Bank.EmployeeID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = hR_Bank.AccountName;
            cmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = hR_Bank.BankName;
            cmd.Parameters.Add("@BankAddress", SqlDbType.NVarChar).Value = hR_Bank.BankAddress;
            cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = hR_Bank.ContactPerson;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Bank.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Bank.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Bank.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Bank.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BankAccountNoID"].Value;
        }
    }

    public bool UpdateHR_BankAccount(HR_BankAccount hR_Bank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_BankAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BankAccountNoID", SqlDbType.Int).Value = hR_Bank.BankAccountNoID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Bank.EmployeeID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = hR_Bank.AccountName;
            cmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = hR_Bank.BankName;
            cmd.Parameters.Add("@BankAddress", SqlDbType.NVarChar).Value = hR_Bank.BankAddress;
            cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = hR_Bank.ContactPerson;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Bank.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Bank.ModifiedDate;
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

