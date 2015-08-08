using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_RemarkProvider:DataAccessObject
{
	public SqlCOMN_RemarkProvider()
    {
    }


    public DataSet  GetAllCOMN_Remarks()
    {
        DataSet COMN_Remarks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Remarks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Remarks);
            myadapter.Dispose();
            connection.Close();

            return COMN_Remarks;
        }
    }
	public DataSet GetCOMN_RemarkPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_RemarkPageWise", connection))
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

    public DataSet GetCOMN_RemarkPageWiseByID(int pageIndex, int PageSize, out int recordCount,string id)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_RemarkPageWiseByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id.Trim());
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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


    public COMN_Remark  GetCOMN_RemarkByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_RemarkByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_RemarkFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllCOMN_Remark()
    {
        DataSet COMN_Remarks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Remark", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Remarks);
            myadapter.Dispose();
            connection.Close();

            return COMN_Remarks;
        }
    }
    public List<COMN_Remark> GetCOMN_RemarksFromReader(IDataReader reader)
    {
        List<COMN_Remark> cOMN_Remarks = new List<COMN_Remark>();

        while (reader.Read())
        {
            cOMN_Remarks.Add(GetCOMN_RemarkFromReader(reader));
        }
        return cOMN_Remarks;
    }

    public COMN_Remark GetCOMN_RemarkFromReader(IDataReader reader)
    {
        try
        {
            COMN_Remark cOMN_Remark = new COMN_Remark
                (

                     DataAccessObject.IsNULL<int>(reader["RemarkID"]),
                     DataAccessObject.IsNULL<string>(reader["RemarkName"]),
                     DataAccessObject.IsNULL<string>(reader["Remark"]),
                     DataAccessObject.IsNULL<DateTime>(reader["RemarkDate"]),
                     DataAccessObject.IsNULL<string>(reader["WhoReported"]),
                     DataAccessObject.IsNULL<string>(reader["WhoDid"]),
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
             return cOMN_Remark;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_Remark  GetCOMN_RemarkByRemarkID(int  remarkID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_RemarkByRemarkID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RemarkID", SqlDbType.Int).Value = remarkID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_RemarkFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_Remark(COMN_Remark cOMN_Remark)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_Remark", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RemarkID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RemarkName", SqlDbType.NVarChar).Value = cOMN_Remark.RemarkName;
            cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = cOMN_Remark.Remark;
            cmd.Parameters.Add("@RemarkDate", SqlDbType.DateTime).Value = cOMN_Remark.RemarkDate;
            cmd.Parameters.Add("@WhoReported", SqlDbType.NVarChar).Value = cOMN_Remark.WhoReported;
            cmd.Parameters.Add("@WhoDid", SqlDbType.NVarChar).Value = cOMN_Remark.WhoDid;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_Remark.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_Remark.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_Remark.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cOMN_Remark.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_Remark.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RemarkID"].Value;
        }
    }

    public bool UpdateCOMN_Remark(COMN_Remark cOMN_Remark)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_Remark", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RemarkID", SqlDbType.Int).Value = cOMN_Remark.RemarkID;
            cmd.Parameters.Add("@RemarkName", SqlDbType.NVarChar).Value = cOMN_Remark.RemarkName;
            cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = cOMN_Remark.Remark;
            cmd.Parameters.Add("@RemarkDate", SqlDbType.DateTime).Value = cOMN_Remark.RemarkDate;
            cmd.Parameters.Add("@WhoReported", SqlDbType.NVarChar).Value = cOMN_Remark.WhoReported;
            cmd.Parameters.Add("@WhoDid", SqlDbType.NVarChar).Value = cOMN_Remark.WhoDid;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = cOMN_Remark.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_Remark.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cOMN_Remark.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_Remark.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_Remark(int remarkID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_Remark", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RemarkID", SqlDbType.Int).Value = remarkID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

