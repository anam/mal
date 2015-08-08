using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_JournalMasterProvider:DataAccessObject
{
	public SqlACC_JournalMasterProvider()
    {
    }


    public DataSet  GetAllACC_JournalMasters()
    {
        DataSet ACC_JournalMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_JournalMasters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalMasters);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalMasters;
        }
    }
	public DataSet GetACC_JournalMasterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalMasterPageWise", connection))
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


    public ACC_JournalMaster  GetACC_JournalMasterByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalMasterByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_JournalMaster()
    {
        DataSet ACC_JournalMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_JournalMaster", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalMasters);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalMasters;
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
    public List<ACC_JournalMaster> GetACC_JournalMastersFromReader(IDataReader reader)
    {
        List<ACC_JournalMaster> aCC_JournalMasters = new List<ACC_JournalMaster>();

        while (reader.Read())
        {
            aCC_JournalMasters.Add(GetACC_JournalMasterFromReader(reader));
        }
        return aCC_JournalMasters;
    }

    public ACC_JournalMaster GetACC_JournalMasterFromReader(IDataReader reader)
    {
        try
        {
            ACC_JournalMaster aCC_JournalMaster = new ACC_JournalMaster
                (

                     DataAccessObject.IsNULL<int>(reader["JournalMasterID"]),
                     DataAccessObject.IsNULL<string>(reader["JournalMasterName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_JournalMaster;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_JournalMaster  GetACC_JournalMasterByJournalMasterID(int  journalMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalMasterByJournalMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = journalMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_JournalMaster(ACC_JournalMaster aCC_JournalMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_JournalMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JournalMasterName", SqlDbType.NVarChar).Value = aCC_JournalMaster.JournalMasterName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_JournalMaster.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_JournalMaster.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_JournalMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_JournalMaster.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_JournalMaster.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JournalMasterID"].Value;
        }
    }

    public bool UpdateACC_JournalMaster(ACC_JournalMaster aCC_JournalMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_JournalMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = aCC_JournalMaster.JournalMasterID;
            cmd.Parameters.Add("@JournalMasterName", SqlDbType.NVarChar).Value = aCC_JournalMaster.JournalMasterName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_JournalMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_JournalMaster.UpdateDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_JournalMaster.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_JournalMaster(int journalMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_JournalMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Value = journalMasterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet SearchACC_AccountJournalMaster(int journalMasterID, DateTime startTime, DateTime endTime)
    {
        DataSet ACC_JournalMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SearchACC_AccountJournalMaster", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JournalMasterID", journalMasterID);
            command.Parameters.AddWithValue("@StartDate", startTime);
            command.Parameters.AddWithValue("@EndDate", endTime);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalMasters);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalMasters;
        }
    }
}

