using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlAccountProvider:DataAccessObject
{
	public SqlAccountProvider()
    {
    }


    public bool DeleteAccount(int accountID)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUCTEST_DeleteAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Account> GetAllAccounts()
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand command = new SqlCommand("CUCTEST_GetAllAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAccountsFromReader(reader);
        }
    }

    public List<Account> CUCTEST_GetAmountByS_ID(string s_id)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand command = new SqlCommand("CUCTEST_GetAmountByS_ID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@S_ID", SqlDbType.NVarChar).Value = s_id;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAccountsFromReader(reader);
        }
    }

    public List<Account> GetAccountsFromReader(IDataReader reader)
    {
        List<Account> accounts = new List<Account>();

        while (reader.Read())
        {
            accounts.Add(GetAccountFromReader(reader));
        }
        return accounts;
    }

    public Account GetAccountFromReader(IDataReader reader)
    {
        try
        {
            Account account = new Account
                (
                    reader["S_id"].ToString(),
                    (int)reader["Received_date"],
                    (decimal)reader["Received_amount"],
                    reader["Bank_acc_no"].ToString(),
                    reader["Bank_name"].ToString(),
                    (int)reader["Issue_date"],
                    (int)reader["Honour_date"]
                );
             return account;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Account GetAccountByID(int accountID)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand command = new SqlCommand("CUCTEST_GetAccountByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAccountFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAccount(Account account)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUCTEST_InsertAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@S_id", SqlDbType.NVarChar).Value = account.S_id;
            cmd.Parameters.Add("@Received_date", SqlDbType.Int).Value = account.Received_date;
            cmd.Parameters.Add("@Received_amount", SqlDbType.Money).Value = account.Received_amount;
            cmd.Parameters.Add("@Bank_acc_no", SqlDbType.NVarChar).Value = account.Bank_acc_no;
            cmd.Parameters.Add("@Bank_name", SqlDbType.NVarChar).Value = account.Bank_name;
            cmd.Parameters.Add("@Issue_date", SqlDbType.Int).Value = account.Issue_date;
            cmd.Parameters.Add("@Honour_date", SqlDbType.Int).Value = account.Honour_date;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AccountID"].Value;
        }
    }

    public bool UpdateAccount(Account account)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUCTEST_UpdateAccount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@S_id", SqlDbType.NVarChar).Value = account.S_id;
            cmd.Parameters.Add("@Received_date", SqlDbType.Int).Value = account.Received_date;
            cmd.Parameters.Add("@Received_amount", SqlDbType.Money).Value = account.Received_amount;
            cmd.Parameters.Add("@Bank_acc_no", SqlDbType.NVarChar).Value = account.Bank_acc_no;
            cmd.Parameters.Add("@Bank_name", SqlDbType.NVarChar).Value = account.Bank_name;
            cmd.Parameters.Add("@Issue_date", SqlDbType.Int).Value = account.Issue_date;
            cmd.Parameters.Add("@Honour_date", SqlDbType.Int).Value = account.Honour_date;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
