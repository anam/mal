using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_JobLocationProvider:DataAccessObject
{
	public SqlHR_JobLocationProvider()
    {
    }


    public DataSet  GetAllHR_JobLocations()
    {
        DataSet HR_JobLocations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_JobLocations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobLocations);
            myadapter.Dispose();
            connection.Close();

            return HR_JobLocations;
        }
    }
	public DataSet GetHR_JobLocationPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_JobLocationPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_JobLocation()
    {
        DataSet HR_JobLocations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_JobLocations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobLocations);
            myadapter.Dispose();
            connection.Close();

            return HR_JobLocations;
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
    public List<HR_JobLocation> GetHR_JobLocationsFromReader(IDataReader reader)
    {
        List<HR_JobLocation> hR_JobLocations = new List<HR_JobLocation>();

        while (reader.Read())
        {
            hR_JobLocations.Add(GetHR_JobLocationFromReader(reader));
        }
        return hR_JobLocations;
    }

    public HR_JobLocation GetHR_JobLocationFromReader(IDataReader reader)
    {
        try
        {
            HR_JobLocation hR_JobLocation = new HR_JobLocation
                (

                     DataAccessObject.IsNULL<int>(reader["JobLocationID"]),
                     DataAccessObject.IsNULL<string>(reader["JobLocationName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_JobLocation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_JobLocation  GetHR_JobLocationByJobLocationID(int  jobLocationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobLocationByJobLocationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobLocationID", SqlDbType.Int).Value = jobLocationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobLocationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_JobLocation(HR_JobLocation hR_JobLocation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_JobLocation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobLocationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobLocationName", SqlDbType.NVarChar).Value = hR_JobLocation.JobLocationName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_JobLocation.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_JobLocation.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobLocation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobLocation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobLocationID"].Value;
        }
    }

    public bool UpdateHR_JobLocation(HR_JobLocation hR_JobLocation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_JobLocation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobLocationID", SqlDbType.Int).Value = hR_JobLocation.JobLocationID;
            cmd.Parameters.Add("@JobLocationName", SqlDbType.NVarChar).Value = hR_JobLocation.JobLocationName;
            cmd.Parameters.Add("@JobLocationName", SqlDbType.NVarChar).Value = hR_JobLocation.JobLocationName;
            cmd.Parameters.Add("@JobLocationName", SqlDbType.NVarChar).Value = hR_JobLocation.JobLocationName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobLocation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobLocation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_JobLocation(int jobLocationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_JobLocation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobLocationID", SqlDbType.Int).Value = jobLocationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

