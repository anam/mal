using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_JournalInfoForDeleteProvider:DataAccessObject
{
	public SqlACC_JournalInfoForDeleteProvider()
    {
    }


    public DataSet  GetAllACC_JournalInfoForDeletes()
    {
        DataSet ACC_JournalInfoForDeletes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_JournalInfoForDeletes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalInfoForDeletes);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalInfoForDeletes;
        }
    }
	public DataSet GetACC_JournalInfoForDeletePageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalInfoForDeletePageWise", connection))
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


    public DataSet GetACC_JournalInfoForDeleteByJournalMasterID(int journalMasterID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_JournalInfoForDeleteByJournalMasterID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@JournalMasterID", journalMasterID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public ACC_JournalInfoForDelete  GetACC_JournalInfoForDeleteByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalInfoForDeleteByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalInfoForDeleteFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_JournalInfoForDelete()
    {
        DataSet ACC_JournalInfoForDeletes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_JournalInfoForDelete", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_JournalInfoForDeletes);
            myadapter.Dispose();
            connection.Close();

            return ACC_JournalInfoForDeletes;
        }
    }
    public List<ACC_JournalInfoForDelete> GetACC_JournalInfoForDeletesFromReader(IDataReader reader)
    {
        List<ACC_JournalInfoForDelete> aCC_JournalInfoForDeletes = new List<ACC_JournalInfoForDelete>();

        while (reader.Read())
        {
            aCC_JournalInfoForDeletes.Add(GetACC_JournalInfoForDeleteFromReader(reader));
        }
        return aCC_JournalInfoForDeletes;
    }

    public ACC_JournalInfoForDelete GetACC_JournalInfoForDeleteFromReader(IDataReader reader)
    {
        try
        {
            ACC_JournalInfoForDelete aCC_JournalInfoForDelete = new ACC_JournalInfoForDelete
                (

                     DataAccessObject.IsNULL<int>(reader["JournalID"]),
                     DataAccessObject.IsNULL<string>(reader["TableNameValue"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_JournalInfoForDelete;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_JournalInfoForDelete  GetACC_JournalInfoForDeleteByJournalID(int  journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_JournalInfoForDeleteByJournalID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JournalID", SqlDbType.Int).Value = journalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_JournalInfoForDeleteFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_JournalInfoForDelete(ACC_JournalInfoForDelete aCC_JournalInfoForDelete)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_JournalInfoForDelete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_JournalInfoForDelete.JournalID;
            cmd.Parameters.Add("@TableNameValue", SqlDbType.NText).Value = aCC_JournalInfoForDelete.TableNameValue;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_JournalInfoForDelete.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_JournalInfoForDelete.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_JournalInfoForDelete.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JournalID"].Value;
        }
    }

    public bool UpdateACC_JournalInfoForDelete(ACC_JournalInfoForDelete aCC_JournalInfoForDelete)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_JournalInfoForDelete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = aCC_JournalInfoForDelete.JournalID;
            cmd.Parameters.Add("@TableNameValue", SqlDbType.NText).Value = aCC_JournalInfoForDelete.TableNameValue;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_JournalInfoForDelete.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_JournalInfoForDelete.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_JournalInfoForDelete.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_JournalInfoForDelete(int journalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_JournalInfoForDelete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalID", SqlDbType.Int).Value = journalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

