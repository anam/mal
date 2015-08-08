using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_LeavesRuleEmployeeProvider:DataAccessObject
{
	public SqlHR_LeavesRuleEmployeeProvider()
    {
    }


    public DataSet  GetAllHR_LeavesRuleEmployees()
    {
        DataSet HR_LeavesRuleEmployees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeavesRuleEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LeavesRuleEmployees);
            myadapter.Dispose();
            connection.Close();

            return HR_LeavesRuleEmployees;
        }
    }
	public DataSet GetHR_LeavesRuleEmployeePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_LeavesRuleEmployeePageWise", connection))
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


    public HR_LeavesRuleEmployee  GetHR_LeavesRuleEmployeeByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LeavesRuleEmployeeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_LeavesRuleEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_LeavesRuleEmployee  GetHR_LeavesRuleEmployeeByLeaveRuleID(int  leaveRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LeavesRuleEmployeeByLeaveRuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeaveRuleID", SqlDbType.NVarChar).Value = leaveRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_LeavesRuleEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_LeavesRuleEmployee()
    {
        DataSet HR_LeavesRuleEmployees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_LeavesRuleEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LeavesRuleEmployees);
            myadapter.Dispose();
            connection.Close();

            return HR_LeavesRuleEmployees;
        }
    }

    public DataSet   GetAllHR_LeavesRuleEmployeesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeavesRuleEmployeesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_LeavesRuleEmployee> GetHR_LeavesRuleEmployeesFromReader(IDataReader reader)
    {
        List<HR_LeavesRuleEmployee> hR_LeavesRuleEmployees = new List<HR_LeavesRuleEmployee>();

        while (reader.Read())
        {
            hR_LeavesRuleEmployees.Add(GetHR_LeavesRuleEmployeeFromReader(reader));
        }
        return hR_LeavesRuleEmployees;
    }

    public HR_LeavesRuleEmployee GetHR_LeavesRuleEmployeeFromReader(IDataReader reader)
    {
        try
        {
            HR_LeavesRuleEmployee hR_LeavesRuleEmployee = new HR_LeavesRuleEmployee
                (

                     DataAccessObject.IsNULL<int>(reader["LeavesRuleEmployeeID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["LeaveRuleID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_LeavesRuleEmployee;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_LeavesRuleEmployee  GetHR_LeavesRuleEmployeeByLeavesRuleEmployeeID(int  leavesRuleEmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LeavesRuleEmployeeByLeavesRuleEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeavesRuleEmployeeID", SqlDbType.Int).Value = leavesRuleEmployeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_LeavesRuleEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_LeavesRuleEmployee(HR_LeavesRuleEmployee hR_LeavesRuleEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_LeavesRuleEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeavesRuleEmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_LeavesRuleEmployee.EmployeeID;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = hR_LeavesRuleEmployee.LeaveRuleID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_LeavesRuleEmployee.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_LeavesRuleEmployee.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LeavesRuleEmployee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LeavesRuleEmployee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeavesRuleEmployeeID"].Value;
        }
    }

    public bool UpdateHR_LeavesRuleEmployee(HR_LeavesRuleEmployee hR_LeavesRuleEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_LeavesRuleEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeavesRuleEmployeeID", SqlDbType.Int).Value = hR_LeavesRuleEmployee.LeavesRuleEmployeeID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_LeavesRuleEmployee.EmployeeID;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = hR_LeavesRuleEmployee.LeaveRuleID;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = hR_LeavesRuleEmployee.LeaveRuleID;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = hR_LeavesRuleEmployee.LeaveRuleID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LeavesRuleEmployee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LeavesRuleEmployee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_LeavesRuleEmployee(int leavesRuleEmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_LeavesRuleEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeavesRuleEmployeeID", SqlDbType.Int).Value = leavesRuleEmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

