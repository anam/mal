using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_CalenderHolidaysProvider:DataAccessObject
{
	public SqlHR_CalenderHolidaysProvider()
    {
    }


    public DataSet  GetAllHR_CalenderHolidayss()
    {
        DataSet HR_CalenderHolidayss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_CalenderHolidayss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_CalenderHolidayss);
            myadapter.Dispose();
            connection.Close();

            return HR_CalenderHolidayss;
        }
    }
	public DataSet GetHR_CalenderHolidaysPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_CalenderHolidaysPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_CalenderHolidays()
    {
        DataSet HR_CalenderHolidayss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_CalenderHolidayss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_CalenderHolidayss);
            myadapter.Dispose();
            connection.Close();

            return HR_CalenderHolidayss;
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
    public List<HR_CalenderHolidays> GetHR_CalenderHolidayssFromReader(IDataReader reader)
    {
        List<HR_CalenderHolidays> hR_CalenderHolidayss = new List<HR_CalenderHolidays>();

        while (reader.Read())
        {
            hR_CalenderHolidayss.Add(GetHR_CalenderHolidaysFromReader(reader));
        }
        return hR_CalenderHolidayss;
    }

    public HR_CalenderHolidays GetHR_CalenderHolidaysFromReader(IDataReader reader)
    {
        try
        {
            HR_CalenderHolidays hR_CalenderHolidays = new HR_CalenderHolidays
                (

                     DataAccessObject.IsNULL<int>(reader["HolyDayID"]),
                     DataAccessObject.IsNULL<string>(reader["HolyDayName"]),
                     DataAccessObject.IsNULL<DateTime>(reader["StartDate"]),
                     DataAccessObject.IsNULL<DateTime>(reader["EndDate"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_CalenderHolidays;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_CalenderHolidays  GetHR_CalenderHolidaysByHolyDayID(int  holyDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_CalenderHolidaysByHolyDayID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HolyDayID", SqlDbType.Int).Value = holyDayID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_CalenderHolidaysFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_CalenderHolidays(HR_CalenderHolidays hR_CalenderHolidays)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_CalenderHolidays", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HolyDayID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HolyDayName", SqlDbType.NVarChar).Value = hR_CalenderHolidays.HolyDayName;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.EndDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_CalenderHolidays.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_CalenderHolidays.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@HolyDayID"].Value;
        }
    }

    public bool UpdateHR_CalenderHolidays(HR_CalenderHolidays hR_CalenderHolidays)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_CalenderHolidays", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HolyDayID", SqlDbType.Int).Value = hR_CalenderHolidays.HolyDayID;
            cmd.Parameters.Add("@HolyDayName", SqlDbType.NVarChar).Value = hR_CalenderHolidays.HolyDayName;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.EndDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.EndDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.EndDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_CalenderHolidays.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_CalenderHolidays.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_CalenderHolidays(int holyDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_CalenderHolidays", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HolyDayID", SqlDbType.Int).Value = holyDayID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

