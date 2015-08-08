using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_JournalHistoryProvider:DataAccessObject
{
	public SqlACC_JournalHistoryProvider()
    {
    }


    public DataSet  GetAllACC_JournalHistories()
    {
        DataSet ACC_JournalHistories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_JournalHistories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalHistories);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalHistories;
        }
    }
	public DataSet GetACC_JournalHistoryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalHistoryPageWise", connection))
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


    public ACC_JournalHistory  GetACC_JournalHistoryByHeadID(int  headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalHistoryByHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadID", SqlDbType.NVarChar).Value = headID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalHistoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_JournalHistory  GetACC_JournalHistoryByJournalMasterID(int  journalMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalHistoryByJournalMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalMasterID", SqlDbType.NVarChar).Value = journalMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalHistoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_JournalHistory  GetACC_JournalHistoryByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalHistoryByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalHistoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_JournalHistory()
    {
        DataSet ACC_JournalHistories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_JournalHistory", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalHistories);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalHistories;
        }
    }
    public List<ACC_JournalHistory> GetACC_JournalHistoriesFromReader(IDataReader reader)
    {
        List<ACC_JournalHistory> aCC_JournalHistories = new List<ACC_JournalHistory>();

        while (reader.Read())
        {
            aCC_JournalHistories.Add(GetACC_JournalHistoryFromReader(reader));
        }
        return aCC_JournalHistories;
    }

    public ACC_JournalHistory GetACC_JournalHistoryFromReader(IDataReader reader)
    {
        try
        {
            ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory
                (

                     DataAccessObject.IsNULL<int>(reader["JournalID"]),
                     DataAccessObject.IsNULL<int>(reader["HeadID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Debit"]),
                     DataAccessObject.IsNULL<decimal>(reader["Credit"]),
                     DataAccessObject.IsNULL<int>(reader["JournalMasterID"]),
                     DataAccessObject.IsNULL<string>(reader["JournalVoucherNo"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"]),
                     DataAccessObject.IsNULL<DateTime>(reader["HistoryDate"]),
                     DataAccessObject.IsNULL<string>(reader["HistoryBy"].ToString())
                );
             return aCC_JournalHistory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_JournalHistory  GetACC_JournalHistoryByJournalID(int  journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalHistoryByJournalID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalID", SqlDbType.Int).Value = journalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalHistoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_JournalHistory(ACC_JournalHistory aCC_JournalHistory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_JournalHistory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_JournalHistory.JournalID;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_JournalHistory.HeadID;
            cmd.Parameters.Add("@Debit", SqlDbType.Decimal).Value = aCC_JournalHistory.Debit;
            cmd.Parameters.Add("@Credit", SqlDbType.Decimal).Value = aCC_JournalHistory.Credit;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_JournalHistory.JournalMasterID;
            cmd.Parameters.Add("@JournalVoucherNo", SqlDbType.NVarChar).Value = aCC_JournalHistory.JournalVoucherNo;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_JournalHistory.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_JournalHistory.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_JournalHistory.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_JournalHistory.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_JournalHistory.RowStatusID;
            cmd.Parameters.Add("@HistoryDate", SqlDbType.DateTime).Value = aCC_JournalHistory.HistoryDate;
            cmd.Parameters.Add("@HistoryBy", SqlDbType.NVarChar).Value = aCC_JournalHistory.HistoryBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JournalID"].Value;
        }
    }

    public bool UpdateACC_JournalHistory(ACC_JournalHistory aCC_JournalHistory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_JournalHistory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_JournalHistory.JournalID;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_JournalHistory.HeadID;
            cmd.Parameters.Add("@Debit", SqlDbType.Decimal).Value = aCC_JournalHistory.Debit;
            cmd.Parameters.Add("@Credit", SqlDbType.Decimal).Value = aCC_JournalHistory.Credit;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_JournalHistory.JournalMasterID;
            cmd.Parameters.Add("@JournalVoucherNo", SqlDbType.NVarChar).Value = aCC_JournalHistory.JournalVoucherNo;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_JournalHistory.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_JournalHistory.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_JournalHistory.RowStatusID;
            cmd.Parameters.Add("@HistoryDate", SqlDbType.DateTime).Value = aCC_JournalHistory.HistoryDate;
            cmd.Parameters.Add("@HistoryBy", SqlDbType.NVarChar).Value = aCC_JournalHistory.HistoryBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_JournalHistory(int journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_JournalHistory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = journalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

