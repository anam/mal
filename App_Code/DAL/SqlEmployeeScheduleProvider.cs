using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlEmployeeScheduleProvider:DataAccessObject
{
	public SqlEmployeeScheduleProvider()
    {
    }


    public bool DeleteEmployeeSchedule(int employeeScheduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeScheduleID", SqlDbType.Int).Value = employeeScheduleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<EmployeeSchedule> GetAllEmployeeSchedules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSchedules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployeeSchedulesFromReader(reader);
        }
    }

    public List<EmployeeSchedule> GetAllEmployeeSchedulesWithHistory()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSchedulesWithHistory", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployeeSchedulesFromReader(reader);
        }
    }


    public List<EmployeeSchedule> GetAllEmployeeSchedulesByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSchedulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", employeeID);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployeeSchedulesFromReader(reader);
        }
    }

    public List<EmployeeSchedule> GetAllEmployeeSchedulesByEmployeeIDWithHistory(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSchedulesByEmployeeIDWithHistory", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", employeeID);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployeeSchedulesFromReader(reader);
        }
    }

    public List<EmployeeSchedule> GetEmployeeSchedulesFromReader(IDataReader reader)
    {
        List<EmployeeSchedule> employeeSchedules = new List<EmployeeSchedule>();

        while (reader.Read())
        {
            employeeSchedules.Add(GetEmployeeScheduleFromReader(reader));
        }
        return employeeSchedules;
    }

    public EmployeeSchedule GetEmployeeScheduleFromReader(IDataReader reader)
    {
        try
        {
            EmployeeSchedule employeeSchedule = new EmployeeSchedule
                (
                    (int)reader["EmployeeScheduleID"],
                    reader["EmployeeID"].ToString(),
                    (int)reader["ClassDayID"],
                    reader["StartTime"].ToString(),
                    reader["EndTime"].ToString(),
                    (int)reader["RowStatusID"],
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["UpdatedBy"].ToString(),
                    (DateTime)reader["UpdateDate"]
                );

            try
            {
                employeeSchedule.ClassDay = reader["ClassDay"].ToString();
            }
            catch(Exception ex)
            {
               
            }
             return employeeSchedule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public EmployeeSchedule GetEmployeeScheduleByID(int employeeScheduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeScheduleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeScheduleID", SqlDbType.Int).Value = employeeScheduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetEmployeeScheduleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertEmployeeSchedule(EmployeeSchedule employeeSchedule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployeeSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeScheduleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.UniqueIdentifier).Value = employeeSchedule.EmployeeID;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = employeeSchedule.ClassDayID;
            cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = employeeSchedule.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = employeeSchedule.EndTime;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = employeeSchedule.RowStatusID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.UniqueIdentifier).Value = employeeSchedule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = employeeSchedule.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = employeeSchedule.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = employeeSchedule.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployeeScheduleID"].Value;
        }
    }

    public bool UpdateEmployeeSchedule(EmployeeSchedule employeeSchedule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeScheduleID", SqlDbType.Int).Value = employeeSchedule.EmployeeScheduleID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeSchedule.EmployeeID;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = employeeSchedule.ClassDayID;
            cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = employeeSchedule.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = employeeSchedule.EndTime;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = employeeSchedule.RowStatusID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = employeeSchedule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = employeeSchedule.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = employeeSchedule.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = employeeSchedule.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }

        
    }
}
