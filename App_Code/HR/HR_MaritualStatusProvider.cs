using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_MaritualStatusProvider:DataAccessObject
{
	public SqlHR_MaritualStatusProvider()
    {
    }


    public DataSet  GetAllHR_MaritualStatuss()
    {
        DataSet HR_MaritualStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_MaritualStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_MaritualStatuss);
            myadapter.Dispose();
            connection.Close();

            return HR_MaritualStatuss;
        }
    }
   
	public DataSet GetHR_MaritualStatusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_MaritualStatusPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_MaritualStatus()
    {
        DataSet HR_MaritualStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_MaritualStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_MaritualStatuss);
            myadapter.Dispose();
            connection.Close();

            return HR_MaritualStatuss;
        }
    }

    public DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeaveRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_MaritualStatus> GetHR_MaritualStatussFromReader(IDataReader reader)
    {
        List<HR_MaritualStatus> hR_MaritualStatuss = new List<HR_MaritualStatus>();

        while (reader.Read())
        {
            hR_MaritualStatuss.Add(GetHR_MaritualStatusFromReader(reader));
        }
        return hR_MaritualStatuss;
    }

    public HR_MaritualStatus GetHR_MaritualStatusFromReader(IDataReader reader)
    {
        try
        {
            HR_MaritualStatus hR_MaritualStatus = new HR_MaritualStatus
                (

                     DataAccessObject.IsNULL<int>(reader["MaritualStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["MaritualStatusName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_MaritualStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_MaritualStatus  GetHR_MaritualStatusByMaritualStatusID(int  maritualStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_MaritualStatusByMaritualStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = maritualStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_MaritualStatusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_MaritualStatus(HR_MaritualStatus hR_MaritualStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_MaritualStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MaritualStatusName", SqlDbType.NVarChar).Value = hR_MaritualStatus.MaritualStatusName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_MaritualStatus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_MaritualStatus.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_MaritualStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_MaritualStatus.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MaritualStatusID"].Value;
        }
    }

    public bool UpdateHR_MaritualStatus(HR_MaritualStatus hR_MaritualStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_MaritualStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = hR_MaritualStatus.MaritualStatusID;
            cmd.Parameters.Add("@MaritualStatusName", SqlDbType.NVarChar).Value = hR_MaritualStatus.MaritualStatusName;
            cmd.Parameters.Add("@MaritualStatusName", SqlDbType.NVarChar).Value = hR_MaritualStatus.MaritualStatusName;
            cmd.Parameters.Add("@MaritualStatusName", SqlDbType.NVarChar).Value = hR_MaritualStatus.MaritualStatusName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_MaritualStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_MaritualStatus.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_MaritualStatus(int maritualStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_MaritualStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = maritualStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

