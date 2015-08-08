using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ShiftingWorkingDaysProvider:DataAccessObject
{
	public SqlHR_ShiftingWorkingDaysProvider()
    {
    }


    public DataSet  GetAllHR_ShiftingWorkingDayss()
    {
        DataSet HR_ShiftingWorkingDayss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ShiftingWorkingDayss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ShiftingWorkingDayss);
            myadapter.Dispose();
            connection.Close();

            return HR_ShiftingWorkingDayss;
        }
    }
	public DataSet GetHR_ShiftingWorkingDaysPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ShiftingWorkingDaysPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_ShiftingWorkingDays()
    {
        DataSet HR_ShiftingWorkingDayss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ShiftingWorkingDayss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ShiftingWorkingDayss);
            myadapter.Dispose();
            connection.Close();

            return HR_ShiftingWorkingDayss;
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
    public List<HR_ShiftingWorkingDays> GetHR_ShiftingWorkingDayssFromReader(IDataReader reader)
    {
        List<HR_ShiftingWorkingDays> hR_ShiftingWorkingDayss = new List<HR_ShiftingWorkingDays>();

        while (reader.Read())
        {
            hR_ShiftingWorkingDayss.Add(GetHR_ShiftingWorkingDaysFromReader(reader));
        }
        return hR_ShiftingWorkingDayss;
    }

    public HR_ShiftingWorkingDays GetHR_ShiftingWorkingDaysFromReader(IDataReader reader)
    {
        try
        {
            HR_ShiftingWorkingDays hR_ShiftingWorkingDays = new HR_ShiftingWorkingDays
                (

                     DataAccessObject.IsNULL<int>(reader["ShiftingWorkingDaysID"]),
                     DataAccessObject.IsNULL<string>(reader["ShiftingWorkingDaysName"]),
                     DataAccessObject.IsNULL<string>(reader["ShiftStartTime"]),
                     DataAccessObject.IsNULL<string>(reader["ShiftEndTime"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_ShiftingWorkingDays;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_ShiftingWorkingDays  GetHR_ShiftingWorkingDaysByShiftingWorkingDaysID(int  shiftingWorkingDaysID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ShiftingWorkingDaysByShiftingWorkingDaysID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ShiftingWorkingDaysID", SqlDbType.Int).Value = shiftingWorkingDaysID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ShiftingWorkingDaysFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_ShiftingWorkingDays(HR_ShiftingWorkingDays hR_ShiftingWorkingDays)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ShiftingWorkingDays", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftingWorkingDaysID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ShiftingWorkingDaysName", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ShiftingWorkingDaysName;
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ShiftStartTime;
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ShiftEndTime;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ShiftingWorkingDays.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ShiftingWorkingDays.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ShiftingWorkingDaysID"].Value;
        }
    }

    public bool UpdateHR_ShiftingWorkingDays(HR_ShiftingWorkingDays hR_ShiftingWorkingDays)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ShiftingWorkingDays", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftingWorkingDaysID", SqlDbType.Int).Value = hR_ShiftingWorkingDays.ShiftingWorkingDaysID;
            cmd.Parameters.Add("@ShiftingWorkingDaysName", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ShiftingWorkingDaysName;
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ShiftStartTime;
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ShiftEndTime;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.Description;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.Description;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.Description;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ShiftingWorkingDays.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ShiftingWorkingDays.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ShiftingWorkingDays(int shiftingWorkingDaysID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ShiftingWorkingDays", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftingWorkingDaysID", SqlDbType.Int).Value = shiftingWorkingDaysID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

