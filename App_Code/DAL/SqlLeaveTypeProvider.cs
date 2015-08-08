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

public class SqlLeaveTypeProvider:DataAccessObject
{
	public SqlLeaveTypeProvider()
    {
    }


    public bool DeleteLeaveType(int leaveTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_DeleteLeaveType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = leaveTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<LeaveType> GetAllLeaveTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetAllLeaveTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLeaveTypesFromReader(reader);
        }
    }
    public List<LeaveType> GetLeaveTypesFromReader(IDataReader reader)
    {
        List<LeaveType> leaveTypes = new List<LeaveType>();

        while (reader.Read())
        {
            leaveTypes.Add(GetLeaveTypeFromReader(reader));
        }
        return leaveTypes;
    }

    public LeaveType GetLeaveTypeFromReader(IDataReader reader)
    {
        try
        {
            LeaveType leaveType = new LeaveType
                (
                    (int)reader["LeaveTypeID"],
                    reader["LeaveName"].ToString()
                );
             return leaveType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LeaveType GetLeaveTypeByID(int leaveTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetLeaveTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = leaveTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLeaveTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLeaveType(LeaveType leaveType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_InsertLeaveType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LeaveName", SqlDbType.NVarChar).Value = leaveType.LeaveName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeaveTypeID"].Value;
        }
    }

    public bool UpdateLeaveType(LeaveType leaveType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_UpdateLeaveType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = leaveType.LeaveTypeID;
            cmd.Parameters.Add("@LeaveName", SqlDbType.NVarChar).Value = leaveType.LeaveName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
