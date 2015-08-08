using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_CUCCheckProvider:DataAccessObject
{
	public SqlACC_CUCCheckProvider()
    {
    }


    public DataSet  GetAllACC_CUCChecks()
    {
        DataSet ACC_CUCChecks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_CUCChecks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_CUCChecks);
            myadapter.Dispose();
            connection.Close();

            return ACC_CUCChecks;
        }
    }
	public DataSet GetACC_CUCCheckPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_CUCCheckPageWise", connection))
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


    public ACC_CUCCheck  GetACC_CUCCheckByBankAccountID(int  bankAccountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CUCCheckByBankAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BankAccountID", SqlDbType.NVarChar).Value = bankAccountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CUCCheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_CUCCheck  GetACC_CUCCheckByPaytoHeadID(int  paytoHeadID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CUCCheckByPaytoHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaytoHeadID", SqlDbType.NVarChar).Value = paytoHeadID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CUCCheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_CUCCheck  GetACC_CUCCheckByJournalID(int  journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CUCCheckByJournalID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalID", SqlDbType.NVarChar).Value = journalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CUCCheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_CUCCheck  GetACC_CUCCheckByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CUCCheckByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CUCCheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_CUCCheck()
    {
        DataSet ACC_CUCChecks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_CUCCheck", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_CUCChecks);
            myadapter.Dispose();
            connection.Close();

            return ACC_CUCChecks;
        }
    }
    public List<ACC_CUCCheck> GetACC_CUCChecksFromReader(IDataReader reader)
    {
        List<ACC_CUCCheck> aCC_CUCChecks = new List<ACC_CUCCheck>();

        while (reader.Read())
        {
            aCC_CUCChecks.Add(GetACC_CUCCheckFromReader(reader));
        }
        return aCC_CUCChecks;
    }

    public ACC_CUCCheck GetACC_CUCCheckFromReader(IDataReader reader)
    {
        try
        {
            ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck
                (

                     DataAccessObject.IsNULL<int>(reader["CUCCheckID"]),
                     DataAccessObject.IsNULL<string>(reader["CUCCheckName"]),
                     DataAccessObject.IsNULL<string>(reader["CUCCheckNo"]),
                     DataAccessObject.IsNULL<int>(reader["BankAccountID"]),
                     DataAccessObject.IsNULL<DateTime>(reader["CheckDate"]),
                     DataAccessObject.IsNULL<int>(reader["PaytoHeadID"]),
                     DataAccessObject.IsNULL<int>(reader["JournalID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Amount"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_CUCCheck;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_CUCCheck  GetACC_CUCCheckByCUCCheckID(int  cUCCheckID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CUCCheckByCUCCheckID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUCCheckID", SqlDbType.Int).Value = cUCCheckID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CUCCheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_CUCCheck(ACC_CUCCheck aCC_CUCCheck)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_CUCCheck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUCCheckID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CUCCheckName", SqlDbType.NVarChar).Value = aCC_CUCCheck.CUCCheckName;
            cmd.Parameters.Add("@CUCCheckNo", SqlDbType.NVarChar).Value = aCC_CUCCheck.CUCCheckNo;
            cmd.Parameters.Add("@BankAccountID", SqlDbType.Int).Value = aCC_CUCCheck.BankAccountID;
            cmd.Parameters.Add("@CheckDate", SqlDbType.DateTime).Value = aCC_CUCCheck.CheckDate;
            cmd.Parameters.Add("@PaytoHeadID", SqlDbType.Int).Value = aCC_CUCCheck.PaytoHeadID;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_CUCCheck.JournalID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_CUCCheck.Amount;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_CUCCheck.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_CUCCheck.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())); 
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_CUCCheck.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = aCC_CUCCheck.UpdatedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_CUCCheck.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CUCCheckID"].Value;
        }
    }

    public bool UpdateACC_CUCCheck(ACC_CUCCheck aCC_CUCCheck)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_CUCCheck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUCCheckID", SqlDbType.Int).Value = aCC_CUCCheck.CUCCheckID;
            cmd.Parameters.Add("@CUCCheckName", SqlDbType.NVarChar).Value = aCC_CUCCheck.CUCCheckName;
            cmd.Parameters.Add("@CUCCheckNo", SqlDbType.NVarChar).Value = aCC_CUCCheck.CUCCheckNo;
            cmd.Parameters.Add("@BankAccountID", SqlDbType.Int).Value = aCC_CUCCheck.BankAccountID;
            cmd.Parameters.Add("@CheckDate", SqlDbType.DateTime).Value = aCC_CUCCheck.CheckDate;
            cmd.Parameters.Add("@PaytoHeadID", SqlDbType.Int).Value = aCC_CUCCheck.PaytoHeadID;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_CUCCheck.JournalID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_CUCCheck.Amount;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = aCC_CUCCheck.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_CUCCheck.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = aCC_CUCCheck.UpdatedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_CUCCheck.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_CUCCheck(int cUCCheckID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_CUCCheck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUCCheckID", SqlDbType.Int).Value = cUCCheckID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

