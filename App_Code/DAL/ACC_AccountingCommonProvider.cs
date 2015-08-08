using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_AccountingCommonProvider:DataAccessObject
{
    public SqlACC_AccountingCommonProvider()
    {
    }


    public DataSet GetACC_DailyAssetOpeningNClosingBalance(DateTime fromDate, DateTime toDate,string userID)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_DailyAssetOpeningNClosingBalance", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);
                command.Parameters.AddWithValue("@UserID", userID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet COMN_ExecSQL(string sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("COMN_ExecSQL", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SQL", sql);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public bool ProcessACC_ProvidentFund(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_ProvidentFund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = aCC_Jounal.EmployPayRoleSalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }


    }

    public bool ProcessACC_JournalHistory(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_JournalHistory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = aCC_Jounal.EmployPayRoleSalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }


    }

    public bool ProcessACC_SecurityAmount(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_SecurityAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = aCC_Jounal.EmployPayRoleSalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }


    }


    public bool ProcessACC_AdvanceSalary(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_AdvanceSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = aCC_Jounal.SalaryOfDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool ProcessACC_FullTimeSalary(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_FullTimeSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_Jounal.JournalMasterID;
            cmd.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = aCC_Jounal.SalaryOfDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool ProcessACC_EPF(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_EPF", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_Jounal.JournalMasterID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool ProcessACC_CPF(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_CPF", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_Jounal.JournalMasterID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool ProcessACC_AdvanceSalaryFromEPF(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_AdvanceSalaryFromEPF", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool ProcessACC_AdvanceSalaryFromCPF(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_AdvanceSalaryFromCPF", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool ProcessACC_RefundCPF(string userID, ACC_Journal aCC_Jounal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ProcessACC_RefundCPF", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Jounal.Balance;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Jounal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Jounal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Jounal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Jounal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public string ProcessDataBackup()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("Create_DB_Backup", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds.Tables[0].Rows[0][0].ToString();
            }
        }
    }

    public void ProcessDataBackupAuto()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Create_Auto_DB_Backup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return;
        }
    }
}

