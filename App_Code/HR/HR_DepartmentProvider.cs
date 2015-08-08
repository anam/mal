using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_DepartmentProvider:DataAccessObject
{
	public SqlHR_DepartmentProvider()
    {
    }


    public DataSet  GetAllHR_Departments()
    {
        DataSet HR_Departments = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Departments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Departments);
            myadapter.Dispose();
            connection.Close();

            return HR_Departments;
        }
    }
	public DataSet GetHR_DepartmentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_DepartmentPageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_Department()
    {
        DataSet HR_Departments = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Department", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Departments);
            myadapter.Dispose();
            connection.Close();

            return HR_Departments;
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
    public List<HR_Department> GetHR_DepartmentsFromReader(IDataReader reader)
    {
        List<HR_Department> hR_Departments = new List<HR_Department>();

        while (reader.Read())
        {
            hR_Departments.Add(GetHR_DepartmentFromReader(reader));
        }
        return hR_Departments;
    }

    public HR_Department GetHR_DepartmentFromReader(IDataReader reader)
    {
        try
        {
            HR_Department hR_Department = new HR_Department
                (

                     DataAccessObject.IsNULL<int>(reader["DepartmentID"]),
                     DataAccessObject.IsNULL<string>(reader["DepartmentName"]),
                     DataAccessObject.IsNULL<string>(reader["JobLocation"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Department;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Department  GetHR_DepartmentByDepartmentID(int  departmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_DepartmentByDepartmentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_DepartmentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Department(HR_Department hR_Department)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = hR_Department.DepartmentName;
            cmd.Parameters.Add("@JobLocation", SqlDbType.NVarChar).Value = hR_Department.JobLocation;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_Department.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Department.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Department.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Department.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Department.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DepartmentID"].Value;
        }
    }


    public bool UpdateHR_Department(HR_Department hR_Department)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_Department.DepartmentID;
            cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = hR_Department.DepartmentName;
            cmd.Parameters.Add("@JobLocation", SqlDbType.NVarChar).Value = hR_Department.JobLocation;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_Department.Description;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Department.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Department.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Department(int departmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

