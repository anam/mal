using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_JobResponsibilityProvider:DataAccessObject
{
	public SqlHR_JobResponsibilityProvider()
    {
    }


    public DataSet  GetAllHR_JobResponsibilities()
    {
        DataSet HR_JobResponsibilities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_JobResponsibilities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobResponsibilities);
            myadapter.Dispose();
            connection.Close();

            return HR_JobResponsibilities;
        }
    }
	public DataSet GetHR_JobResponsibilityPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_JobResponsibilityPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_JobResponsibility()
    {
        DataSet HR_JobResponsibilities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_JobResponsibilities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobResponsibilities);
            myadapter.Dispose();
            connection.Close();

            return HR_JobResponsibilities;
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
    public List<HR_JobResponsibility> GetHR_JobResponsibilitiesFromReader(IDataReader reader)
    {
        List<HR_JobResponsibility> hR_JobResponsibilities = new List<HR_JobResponsibility>();

        while (reader.Read())
        {
            hR_JobResponsibilities.Add(GetHR_JobResponsibilityFromReader(reader));
        }
        return hR_JobResponsibilities;
    }

    public HR_JobResponsibility GetHR_JobResponsibilityFromReader(IDataReader reader)
    {
        try
        {
            HR_JobResponsibility hR_JobResponsibility = new HR_JobResponsibility
                (

                     DataAccessObject.IsNULL<int>(reader["JobResponsibilityID"]),
                     DataAccessObject.IsNULL<string>(reader["JobResponsibilityName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_JobResponsibility;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_JobResponsibility  GetHR_JobResponsibilityByJobResponsibilityID(int  jobResponsibilityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobResponsibilityByJobResponsibilityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobResponsibilityID", SqlDbType.Int).Value = jobResponsibilityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobResponsibilityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_JobResponsibility(HR_JobResponsibility hR_JobResponsibility)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_JobResponsibility", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobResponsibilityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobResponsibilityName", SqlDbType.NVarChar).Value = hR_JobResponsibility.JobResponsibilityName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_JobResponsibility.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_JobResponsibility.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobResponsibility.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobResponsibility.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobResponsibilityID"].Value;
        }
    }

    public bool UpdateHR_JobResponsibility(HR_JobResponsibility hR_JobResponsibility)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_JobResponsibility", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobResponsibilityID", SqlDbType.Int).Value = hR_JobResponsibility.JobResponsibilityID;
            cmd.Parameters.Add("@JobResponsibilityName", SqlDbType.NVarChar).Value = hR_JobResponsibility.JobResponsibilityName;
            cmd.Parameters.Add("@JobResponsibilityName", SqlDbType.NVarChar).Value = hR_JobResponsibility.JobResponsibilityName;
            cmd.Parameters.Add("@JobResponsibilityName", SqlDbType.NVarChar).Value = hR_JobResponsibility.JobResponsibilityName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobResponsibility.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobResponsibility.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_JobResponsibility(int jobResponsibilityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_JobResponsibility", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobResponsibilityID", SqlDbType.Int).Value = jobResponsibilityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

