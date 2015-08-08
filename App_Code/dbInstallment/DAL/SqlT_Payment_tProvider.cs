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

public class SqlT_Payment_tProvider:DataAccessObject
{
	public SqlT_Payment_tProvider()
    {
    }


    public bool DeleteT_Payment_t(int t_Payment_tID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_db_DeleteT_Payment_t", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@T_Payment_tID", SqlDbType.Int).Value = t_Payment_tID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<T_Payment_t> GetAllT_Payment_ts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_db_GetAllT_Payment_ts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetT_Payment_tsFromReader(reader);
        }
    }
    public List<T_Payment_t> GetT_Payment_tsFromReader(IDataReader reader)
    {
        List<T_Payment_t> t_Payment_ts = new List<T_Payment_t>();

        while (reader.Read())
        {
            t_Payment_ts.Add(GetT_Payment_tFromReader(reader));
        }
        return t_Payment_ts;
    }

    public T_Payment_t GetT_Payment_tFromReader(IDataReader reader)
    {
        try
        {
            T_Payment_t t_Payment_t = new T_Payment_t
                (
                    (int)reader["T_Payment_tID"],
                    reader["ID"].ToString(),
                    reader["Date"].ToString(),
                    reader["Amount"].ToString()
                );
             return t_Payment_t;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public T_Payment_t GetT_Payment_tByID(int t_Payment_tID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_db_GetT_Payment_tByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@T_Payment_tID", SqlDbType.Int).Value = t_Payment_tID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetT_Payment_tFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertT_Payment_t(T_Payment_t t_Payment_t)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_db_InsertT_Payment_t", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@T_Payment_tID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = t_Payment_t.ID;
            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = t_Payment_t.Date;
            cmd.Parameters.Add("@Amount", SqlDbType.NVarChar).Value = t_Payment_t.Amount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@T_Payment_tID"].Value;
        }
    }

    public bool UpdateT_Payment_t(T_Payment_t t_Payment_t)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_db_UpdateT_Payment_t", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@T_Payment_tID", SqlDbType.Int).Value = t_Payment_t.T_Payment_tID;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = t_Payment_t.ID;
            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = t_Payment_t.Date;
            cmd.Parameters.Add("@Amount", SqlDbType.NVarChar).Value = t_Payment_t.Amount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
