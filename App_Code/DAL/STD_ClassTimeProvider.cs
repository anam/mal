using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassTimeProvider:DataAccessObject
{
	public SqlSTD_ClassTimeProvider()
    {
    }


    public DataSet  GetAllSTD_ClassTimes()
    {
        DataSet STD_ClassTimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassTimes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassTimes);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassTimes;
        }
    }
	public DataSet GetSTD_ClassTimePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassTimePageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_ClassTime()
    {
        DataSet STD_ClassTimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassTimes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassTimes);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassTimes;
        }
    }

    public DataSet   GetAllSTD_ClasssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClasssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassTime> GetSTD_ClassTimesFromReader(IDataReader reader)
    {
        List<STD_ClassTime> sTD_ClassTimes = new List<STD_ClassTime>();

        while (reader.Read())
        {
            sTD_ClassTimes.Add(GetSTD_ClassTimeFromReader(reader));
        }
        return sTD_ClassTimes;
    }

    public STD_ClassTime GetSTD_ClassTimeFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassTime sTD_ClassTime = new STD_ClassTime
                (

                     DataAccessObject.IsNULL<int>(reader["ClassTimeID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassTimeName"]),
                     DataAccessObject.IsNULL<decimal>(reader["Duration"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["Order"]),
                     DataAccessObject.IsNULL<int>(reader["ClassTimeGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["StartTime"]),
                     DataAccessObject.IsNULL<string>(reader["EndTime"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
            return sTD_ClassTime;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_ClassTime  GetSTD_ClassTimeByClassTimeID(int  classTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassTimeByClassTimeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassTimeID", SqlDbType.Int).Value = classTimeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_ClassTimeByClassTimeGroupID(int classTimegroupID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassTimeByClassTimeGroupID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassTimeGroupID", classTimegroupID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }


    }
    public int InsertSTD_ClassTime(STD_ClassTime sTD_ClassTime)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassTime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTimeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassTimeName", SqlDbType.NVarChar).Value = sTD_ClassTime.ClassTimeName;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = sTD_ClassTime.Duration;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassTime.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassTime.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassTime.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassTime.UpdateDate;
            cmd.Parameters.Add("@Order", SqlDbType.Int).Value = sTD_ClassTime.Order;
            cmd.Parameters.Add("@ClassTimeGroupID", SqlDbType.Int).Value = sTD_ClassTime.ClassTimeGroupID;
            cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = sTD_ClassTime.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = sTD_ClassTime.EndTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField5;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassTime.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassTimeID"].Value;
        }
    }

    public bool UpdateSTD_ClassTime(STD_ClassTime sTD_ClassTime)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassTime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTimeID", SqlDbType.Int).Value = sTD_ClassTime.ClassTimeID;
            cmd.Parameters.Add("@ClassTimeName", SqlDbType.NVarChar).Value = sTD_ClassTime.ClassTimeName;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = sTD_ClassTime.Duration;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassTime.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassTime.UpdateDate;
            cmd.Parameters.Add("@Order", SqlDbType.Int).Value = sTD_ClassTime.Order;
            cmd.Parameters.Add("@ClassTimeGroupID", SqlDbType.Int).Value = sTD_ClassTime.ClassTimeGroupID;
            cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = sTD_ClassTime.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = sTD_ClassTime.EndTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ClassTime.ExtraField5;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassTime.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool DeleteSTD_ClassTime(int classTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassTime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTimeID", SqlDbType.Int).Value = classTimeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

