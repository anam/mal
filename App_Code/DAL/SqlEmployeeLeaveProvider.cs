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

public class SqlEmployeeLeaveProvider:DataAccessObject
{
	public SqlEmployeeLeaveProvider()
    {
    }


    public bool DeleteEmployeeLeave(int employeeLeaveID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cuc_DeleteEmployeeLeave", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeLeaveID", SqlDbType.Int).Value = employeeLeaveID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<EmployeeLeave> GetAllEmployeeLeaves()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cuc_GetAllEmployeeLeaves", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployeeLeavesFromReader(reader);
        }
    }


    public List<EmployeeLeave> GetAllEmployeeLeavesByEmployeeID(string EmployeeID, string fromDate, string toDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cuc_GetAllEmployeeLeavesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
            command.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = fromDate;
            command.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = toDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployeeLeavesFromReader(reader);
        }
    }
    public List<EmployeeLeave> GetEmployeeLeavesFromReader(IDataReader reader)
    {
        List<EmployeeLeave> employeeLeaves = new List<EmployeeLeave>();

        while (reader.Read())
        {
            employeeLeaves.Add(GetEmployeeLeaveFromReader(reader));
        }
        return employeeLeaves;
    }

    public EmployeeLeave GetEmployeeLeaveFromReader(IDataReader reader)
    {
        try
        {
            EmployeeLeave employeeLeave = new EmployeeLeave
                (
                    (int)reader["EmployeeLeaveID"],
                    reader["EmployeeID"].ToString(),
                    (DateTime)reader["LeaveDate"],
                    (int)reader["LeaveTypeID"],
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["UpdatedBy"].ToString(),
                    (DateTime)reader["UpdateDate"],
                    (int)reader["RowStatusID"]
                );
            try {
                employeeLeave.EmployeeName = reader["EmployeeName"].ToString();
                employeeLeave.EmployeeNo = reader["EmployeeNo"].ToString();
                employeeLeave.LeaveName = reader["LeaveName"].ToString();
            }
            catch(Exception ex)
            {
            }
            return employeeLeave;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public EmployeeLeave GetEmployeeLeaveByID(int employeeLeaveID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cuc_GetEmployeeLeaveByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeLeaveID", SqlDbType.Int).Value = employeeLeaveID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetEmployeeLeaveFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertEmployeeLeave(EmployeeLeave employeeLeave)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cuc_InsertEmployeeLeave", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeLeaveID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeLeave.EmployeeID;
            cmd.Parameters.Add("@LeaveDate", SqlDbType.DateTime).Value = employeeLeave.LeaveDate;
            cmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = employeeLeave.LeaveTypeID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = employeeLeave.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = employeeLeave.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = employeeLeave.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = employeeLeave.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = employeeLeave.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployeeLeaveID"].Value;
        }
    }

    public bool UpdateEmployeeLeave(EmployeeLeave employeeLeave)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cuc_UpdateEmployeeLeave", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeLeaveID", SqlDbType.Int).Value = employeeLeave.EmployeeLeaveID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeLeave.EmployeeID;
            cmd.Parameters.Add("@LeaveDate", SqlDbType.DateTime).Value = employeeLeave.LeaveDate;
            cmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = employeeLeave.LeaveTypeID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = employeeLeave.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = employeeLeave.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = employeeLeave.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = employeeLeave.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = employeeLeave.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
