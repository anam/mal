
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_JournalProvider:DataAccessObject
{
	public SqlACC_JournalProvider()
    {
    }


    public DataSet  GetAllACC_Journals()
    {
        DataSet ACC_Journals = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_Journals", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Journals);
            myadapter.Dispose();
            connection.Close();

            return ACC_Journals;
        }
    }
	public DataSet GetACC_JournalPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalPageWise", connection))
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

    public DataSet GetACC_JournalByHeadIDDataset(int headID, string dateFrom, string dateTo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalByHeadID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@HeadID", headID);
                command.Parameters.Add("@DateFrom", SqlDbType.NVarChar).Value = dateFrom;
                command.Parameters.Add("@DateTo", SqlDbType.NVarChar).Value = dateTo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetACC_JournalByHeadIDDatasetByAll(int basicAccountID, int subBasicAccountID, int accountID, int headID, string dateFrom, string dateTo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalByHeadIDByAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BasicAccountID", basicAccountID);
                command.Parameters.AddWithValue("@SubBasicAccountID", subBasicAccountID);
                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@HeadID", headID);
                command.Parameters.Add("@DateFrom", SqlDbType.NVarChar).Value = dateFrom;
                command.Parameters.Add("@DateTo", SqlDbType.NVarChar).Value = dateTo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetACC_JournalByHeadIDDatasetByAllByUserIDStudentFees(int basicAccountID, int subBasicAccountID, int accountID, string userID, int userTypeID, string dateFrom, string dateTo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalByHeadIDByAllByUserIDStudentFees", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BasicAccountID", basicAccountID);
                command.Parameters.AddWithValue("@SubBasicAccountID", subBasicAccountID);
                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@UserTypeID", userTypeID);
                command.Parameters.Add("@DateFrom", SqlDbType.NVarChar).Value = dateFrom;
                command.Parameters.Add("@DateTo", SqlDbType.NVarChar).Value = dateTo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetACC_JournalByHeadIDDatasetByAllByUserID(int basicAccountID, int subBasicAccountID, int accountID, string userID, int userTypeID, string dateFrom, string dateTo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalByHeadIDByAllByUserID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BasicAccountID", basicAccountID);
                command.Parameters.AddWithValue("@SubBasicAccountID", subBasicAccountID);
                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@UserTypeID", userTypeID);
                command.Parameters.Add("@DateFrom", SqlDbType.NVarChar).Value = dateFrom;
                command.Parameters.Add("@DateTo", SqlDbType.NVarChar).Value = dateTo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public ACC_Journal  GetACC_JournalByHeadID(int  headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalByHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadID", SqlDbType.NVarChar).Value = headID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_Journal  GetACC_JournalByJournalMasterID(int  journalMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalByJournalMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalMasterID", SqlDbType.NVarChar).Value = journalMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_Journal  GetACC_JournalByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_Journal()
    {
        DataSet ACC_Journals = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_Journal", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Journals);
            myadapter.Dispose();
            connection.Close();

            return ACC_Journals;
        }
    }

    public DataSet   GetAllACC_JournalsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_JournalsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_Journal> GetACC_JournalsFromReader(IDataReader reader)
    {
        List<ACC_Journal> aCC_Journals = new List<ACC_Journal>();

        while (reader.Read())
        {
            aCC_Journals.Add(GetACC_JournalFromReader(reader));
        }
        return aCC_Journals;
    }

    public ACC_Journal GetACC_JournalFromReader(IDataReader reader)
    {
        try
        {
            ACC_Journal aCC_Journal = new ACC_Journal
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
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
            aCC_Journal.HeadName = DataAccessObject.IsNULL<string>(reader["HeadName"].ToString());
             return aCC_Journal;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_Journal  GetACC_JournalByJournalID(int  journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalByJournalID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalID", SqlDbType.Int).Value = journalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_Journal(ACC_Journal aCC_Journal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_Journal", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_Journal.HeadID;
            cmd.Parameters.Add("@Debit", SqlDbType.Decimal).Value = aCC_Journal.Debit;
            cmd.Parameters.Add("@Credit", SqlDbType.Decimal).Value = aCC_Journal.Credit;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_Journal.JournalMasterID;
            cmd.Parameters.Add("@JournalVoucherNo", SqlDbType.NVarChar).Value = aCC_Journal.JournalVoucherNo;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Journal.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Journal.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Journal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Journal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Journal.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JournalID"].Value;
        }
    }

    public bool UpdateACC_Journal(ACC_Journal aCC_Journal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_Journal", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_Journal.JournalID;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_Journal.HeadID;
            cmd.Parameters.Add("@Debit", SqlDbType.Decimal).Value = aCC_Journal.Debit;
            cmd.Parameters.Add("@Credit", SqlDbType.Decimal).Value = aCC_Journal.Credit;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_Journal.JournalMasterID;
            cmd.Parameters.Add("@JournalVoucherNo", SqlDbType.NVarChar).Value = aCC_Journal.JournalVoucherNo;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Journal.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Journal.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Journal.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_Journal(int journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_Journal", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = journalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    //public DataSet ViewAllACC_JournalsByAccountID(int accountID, DateTime startDate, DateTime endDate)
    //{
    //    DataSet ACC_Journals = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetACC_AccountJournalByAccountID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountID;
    //        command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
    //        command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        myadapter.Fill(ACC_Journals);
    //        myadapter.Dispose();
    //        connection.Close();

    //        return ACC_Journals;
    //    }
    //}

    public List<ACC_Journal> ViewAllACC_JournalsByAccountID(int accountID, DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AccountJournalByAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountID;
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACC_JournalsFromReader(reader);
        }
    }

    public DataSet GetACC_JournalsByJournalMasterID(int journalMasterID)
    {
        DataSet ACC_JournalMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalByJournalMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JournalMasterID", journalMasterID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalMasters);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalMasters;
        }
    }

    public DataSet GetACC_VoucherByJournalMasterID(int journalMasterID)
    {
        DataSet ACC_JournalMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherByJournalMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JournalMasterID", journalMasterID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalMasters);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalMasters;
        }
    }

    public DataSet GetACC_JournalForTransactionByDateRange(DateTime startDate, DateTime endDate,string addedBy)
    {
        DataSet ACC_JournalMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalForDailyTransactionByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
            command.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalMasters);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalMasters;
        }
    }
}


