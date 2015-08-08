using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_JobPostingProvider:DataAccessObject
{
	public SqlHR_JobPostingProvider()
    {
    }


    public DataSet  GetAllHR_JobPostings()
    {
        DataSet HR_JobPostings = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_JobPostings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobPostings);
            myadapter.Dispose();
            connection.Close();

            return HR_JobPostings;
        }
    }
    public DataSet GetHR_JobPostingByEmployeeID(string EmployeeID)
    {
        DataSet HR_JobPostings = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobPostingByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobPostings);
            myadapter.Dispose();
            connection.Close();

            return HR_JobPostings;
        }
    }
    
	public DataSet GetHR_JobPostingPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_JobPostingPageWise", connection))
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


    

    public HR_JobPosting  GetHR_JobPostingByDepartmentID(int  departmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobPostingByDepartmentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepartmentID", SqlDbType.NVarChar).Value = departmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobPostingFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_JobPosting  GetHR_JobPostingByDesignationID(int  designationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobPostingByDesignationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesignationID", SqlDbType.NVarChar).Value = designationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobPostingFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_JobPosting  GetHR_JobPostingBySupervisorID(string  supervisorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobPostingBySupervisorID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SupervisorID", SqlDbType.NVarChar).Value = supervisorID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobPostingFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_JobPosting()
    {
        DataSet HR_JobPostings = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_JobPosting", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobPostings);
            myadapter.Dispose();
            connection.Close();

            return HR_JobPostings;
        }
    }

    public DataSet   GetAllHR_JobPostingsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_JobPostingsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_JobPosting> GetHR_JobPostingsFromReader(IDataReader reader)
    {
        List<HR_JobPosting> hR_JobPostings = new List<HR_JobPosting>();

        while (reader.Read())
        {
            hR_JobPostings.Add(GetHR_JobPostingFromReader(reader));
        }
        return hR_JobPostings;
    }

    public HR_JobPosting GetHR_JobPostingFromReader(IDataReader reader)
    {
        try
        {
            HR_JobPosting hR_JobPosting = new HR_JobPosting
                (

                     DataAccessObject.IsNULL<int>(reader["JobPostingID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["DepartmentID"]),
                     DataAccessObject.IsNULL<int>(reader["DesignationID"]),
                     DataAccessObject.IsNULL<DateTime>(reader["JoinDate"]),
                     DataAccessObject.IsNULL<DateTime>(reader["EndDate"]),
                     DataAccessObject.IsNULL<string>(reader["PostingStatus"]),
                     DataAccessObject.IsNULL<string>(reader["JobLocation"]),
                     DataAccessObject.IsNULL<string>(reader["SupervisorID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_JobPosting;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_JobPosting  GetHR_JobPostingByJobPostingID(int  jobPostingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobPostingByJobPostingID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobPostingID", SqlDbType.Int).Value = jobPostingID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobPostingFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_JobPosting(HR_JobPosting hR_JobPosting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_JobPosting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobPostingID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_JobPosting.EmployeeID;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_JobPosting.DepartmentID;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = hR_JobPosting.DesignationID;
            cmd.Parameters.Add("@JoinDate", SqlDbType.DateTime).Value = hR_JobPosting.JoinDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hR_JobPosting.EndDate;
            cmd.Parameters.Add("@PostingStatus", SqlDbType.NVarChar).Value = hR_JobPosting.PostingStatus;
            cmd.Parameters.Add("@JobLocation", SqlDbType.NVarChar).Value = hR_JobPosting.JobLocation;
            cmd.Parameters.Add("@SupervisorID", SqlDbType.NVarChar).Value = hR_JobPosting.SupervisorID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_JobPosting.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_JobPosting.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobPosting.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobPosting.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobPostingID"].Value;
        }
    }

    public bool UpdateHR_JobPosting(HR_JobPosting hR_JobPosting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_JobPosting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobPostingID", SqlDbType.Int).Value = hR_JobPosting.JobPostingID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_JobPosting.EmployeeID;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_JobPosting.DepartmentID;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = hR_JobPosting.DesignationID;
            cmd.Parameters.Add("@JoinDate", SqlDbType.DateTime).Value = hR_JobPosting.JoinDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hR_JobPosting.EndDate;
            cmd.Parameters.Add("@PostingStatus", SqlDbType.NVarChar).Value = hR_JobPosting.PostingStatus;
            cmd.Parameters.Add("@JobLocation", SqlDbType.NVarChar).Value = hR_JobPosting.JobLocation;
            cmd.Parameters.Add("@SupervisorID", SqlDbType.NVarChar).Value = hR_JobPosting.SupervisorID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobPosting.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobPosting.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_JobPosting(int jobPostingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_JobPosting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobPostingID", SqlDbType.Int).Value = jobPostingID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

