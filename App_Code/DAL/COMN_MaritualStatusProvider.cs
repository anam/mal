using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_MaritualStatusProvider:DataAccessObject
{
	public SqlCOMN_MaritualStatusProvider()
    {
    }


    public DataSet  GetAllCOMN_MaritualStatuss()
    {
        DataSet COMN_MaritualStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_MaritualStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_MaritualStatuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_MaritualStatuss;
        }
    }
	public DataSet GetCOMN_MaritualStatusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_MaritualStatusPageWise", connection))
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


    public DataSet  GetDropDownListAllCOMN_MaritualStatus()
    {
        DataSet COMN_MaritualStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_MaritualStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_MaritualStatuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_MaritualStatuss;
        }
    }

    public DataSet   GetAllCOMN_CitiesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_CitiesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<COMN_MaritualStatus> GetCOMN_MaritualStatussFromReader(IDataReader reader)
    {
        List<COMN_MaritualStatus> cOMN_MaritualStatuss = new List<COMN_MaritualStatus>();

        while (reader.Read())
        {
            cOMN_MaritualStatuss.Add(GetCOMN_MaritualStatusFromReader(reader));
        }
        return cOMN_MaritualStatuss;
    }

    public COMN_MaritualStatus GetCOMN_MaritualStatusFromReader(IDataReader reader)
    {
        try
        {
            COMN_MaritualStatus cOMN_MaritualStatus = new COMN_MaritualStatus
                (

                     DataAccessObject.IsNULL<int>(reader["MaritualStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["MaritualStatusName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            //cOMN_MaritualStatus.RowStatusID = DataAccessObject.IsNULL<int>(reader["RowStatusID"]);
             return cOMN_MaritualStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_MaritualStatus  GetCOMN_MaritualStatusByMaritualStatusID(int  maritualStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_MaritualStatusByMaritualStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = maritualStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_MaritualStatusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_MaritualStatus(COMN_MaritualStatus cOMN_MaritualStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_MaritualStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MaritualStatusName", SqlDbType.NVarChar).Value = cOMN_MaritualStatus.MaritualStatusName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_MaritualStatus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_MaritualStatus.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_MaritualStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_MaritualStatus.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MaritualStatusID"].Value;
        }
    }

    public bool UpdateCOMN_MaritualStatus(COMN_MaritualStatus cOMN_MaritualStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_MaritualStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = cOMN_MaritualStatus.MaritualStatusID;
            cmd.Parameters.Add("@MaritualStatusName", SqlDbType.NVarChar).Value = cOMN_MaritualStatus.MaritualStatusName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_MaritualStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_MaritualStatus.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_MaritualStatus(int maritualStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_MaritualStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = maritualStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

