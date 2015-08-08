using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_PaymentStatusProvider:DataAccessObject
{
	public SqlCOMN_PaymentStatusProvider()
    {
    }


    public DataSet  GetAllCOMN_PaymentStatuss()
    {
        DataSet COMN_PaymentStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_PaymentStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_PaymentStatuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_PaymentStatuss;
        }
    }
	public DataSet GetCOMN_PaymentStatusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_PaymentStatusPageWise", connection))
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


    public COMN_PaymentStatus  GetCOMN_PaymentStatusByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_PaymentStatusByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_PaymentStatusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllCOMN_PaymentStatus()
    {
        DataSet COMN_PaymentStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_PaymentStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_PaymentStatuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_PaymentStatuss;
        }
    }
    public List<COMN_PaymentStatus> GetCOMN_PaymentStatussFromReader(IDataReader reader)
    {
        List<COMN_PaymentStatus> cOMN_PaymentStatuss = new List<COMN_PaymentStatus>();

        while (reader.Read())
        {
            cOMN_PaymentStatuss.Add(GetCOMN_PaymentStatusFromReader(reader));
        }
        return cOMN_PaymentStatuss;
    }

    public COMN_PaymentStatus GetCOMN_PaymentStatusFromReader(IDataReader reader)
    {
        try
        {
            COMN_PaymentStatus cOMN_PaymentStatus = new COMN_PaymentStatus
                (

                     DataAccessObject.IsNULL<int>(reader["PaymentStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["PaymentStatusName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return cOMN_PaymentStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_PaymentStatus  GetCOMN_PaymentStatusByPaymentStatusID(int  paymentStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_PaymentStatusByPaymentStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaymentStatusID", SqlDbType.Int).Value = paymentStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_PaymentStatusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_PaymentStatus(COMN_PaymentStatus cOMN_PaymentStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_PaymentStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaymentStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PaymentStatusName", SqlDbType.NVarChar).Value = cOMN_PaymentStatus.PaymentStatusName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_PaymentStatus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_PaymentStatus.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_PaymentStatus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_PaymentStatus.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_PaymentStatus.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PaymentStatusID"].Value;
        }
    }

    public bool UpdateCOMN_PaymentStatus(COMN_PaymentStatus cOMN_PaymentStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_PaymentStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaymentStatusID", SqlDbType.Int).Value = cOMN_PaymentStatus.PaymentStatusID;
            cmd.Parameters.Add("@PaymentStatusName", SqlDbType.NVarChar).Value = cOMN_PaymentStatus.PaymentStatusName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_PaymentStatus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_PaymentStatus.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_PaymentStatus.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_PaymentStatus(int paymentStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_PaymentStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaymentStatusID", SqlDbType.Int).Value = paymentStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

