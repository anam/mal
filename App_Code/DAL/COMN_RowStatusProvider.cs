using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_RowStatusProvider:DataAccessObject
{
	public SqlCOMN_RowStatusProvider()
    {
    }


    public DataSet  GetAllCOMN_RowStatuss()
    {
        DataSet COMN_RowStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_RowStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_RowStatuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_RowStatuss;
        }
    }
	public DataSet GetCOMN_RowStatusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_RowStatusPageWise", connection))
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


    public DataSet  GetDropDownLisAllCOMN_RowStatus()
    {
        DataSet COMN_RowStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_RowStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_RowStatuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_RowStatuss;
        }
    }

    public DataSet   GetAllACC_VouchersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_VouchersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<COMN_RowStatus> GetCOMN_RowStatussFromReader(IDataReader reader)
    {
        List<COMN_RowStatus> cOMN_RowStatuss = new List<COMN_RowStatus>();

        while (reader.Read())
        {
            cOMN_RowStatuss.Add(GetCOMN_RowStatusFromReader(reader));
        }
        return cOMN_RowStatuss;
    }

    public COMN_RowStatus GetCOMN_RowStatusFromReader(IDataReader reader)
    {
        try
        {
            COMN_RowStatus cOMN_RowStatus = new COMN_RowStatus
                (

                     DataAccessObject.IsNULL<int>(reader["RowStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["RowStatusName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return cOMN_RowStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_RowStatus  GetCOMN_RowStatusByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_RowStatusByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_RowStatusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_RowStatus(COMN_RowStatus cOMN_RowStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_RowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RowStatusName", SqlDbType.NVarChar).Value = cOMN_RowStatus.RowStatusName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_RowStatus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_RowStatus.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_RowStatus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_RowStatus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RowStatusID"].Value;
        }
    }

    public bool UpdateCOMN_RowStatus(COMN_RowStatus cOMN_RowStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_RowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_RowStatus.RowStatusID;
            cmd.Parameters.Add("@RowStatusName", SqlDbType.NVarChar).Value = cOMN_RowStatus.RowStatusName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_RowStatus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_RowStatus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_RowStatus(int rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_RowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = rowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

