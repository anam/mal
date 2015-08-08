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

public class SqlT_InstallmentProvider:DataAccessObject
{
	public SqlT_InstallmentProvider()
    {
    }


    public bool DeleteT_Installment(int t_InstallmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC__DeleteT_Installment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@T_InstallmentID", SqlDbType.Int).Value = t_InstallmentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<T_Installment> GetAllT_Installments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC__GetAllT_Installments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetT_InstallmentsFromReader(reader);
        }
    }


    public List<T_Installment> GetAllT_InstallmentsByStudentID(string StudentCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC__GetAllT_InstallmentsByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.Int).Value = StudentCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetT_InstallmentsFromReader(reader);
        }
    }
    public List<T_Installment> GetT_InstallmentsFromReader(IDataReader reader)
    {
        List<T_Installment> t_Installments = new List<T_Installment>();

        while (reader.Read())
        {
            t_Installments.Add(GetT_InstallmentFromReader(reader));
        }
        return t_Installments;
    }

    public T_Installment GetT_InstallmentFromReader(IDataReader reader)
    {
        try
        {
            T_Installment t_Installment = new T_Installment
                (
                    (int)reader["T_InstallmentID"],
                    reader["ID"].ToString(),
                    (DateTime)reader["Date"],
                    (decimal)reader["Amount"]
                );
            try
            {
                t_Installment.TotalAmount = (decimal)reader["TotalAmount"];
                t_Installment.PaidAmount = (decimal)reader["PaidAmount"];
            }
            catch (Exception ex)
            { }

            return t_Installment;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public T_Installment GetT_InstallmentByID(int t_InstallmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC__GetT_InstallmentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@T_InstallmentID", SqlDbType.Int).Value = t_InstallmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetT_InstallmentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertT_Installment(T_Installment t_Installment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC__InsertT_Installment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@T_InstallmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = t_Installment.ID;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = t_Installment.Date;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = t_Installment.Amount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@T_InstallmentID"].Value;
        }
    }

    public bool UpdateT_Installment(T_Installment t_Installment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC__UpdateT_Installment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@T_InstallmentID", SqlDbType.Int).Value = t_Installment.T_InstallmentID;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = t_Installment.ID;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = t_Installment.Date;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = t_Installment.Amount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
