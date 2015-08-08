using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_PostingInformationProvider:DataAccessObject
{
	public SqlHR_PostingInformationProvider()
    {
    }


    public DataSet  GetAllHR_PostingInformations()
    {
        DataSet HR_PostingInformations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PostingInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PostingInformations);
            myadapter.Dispose();
            connection.Close();

            return HR_PostingInformations;
        }
    }
	public DataSet GetHR_PostingInformationPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_PostingInformationPageWise", connection))
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


    public HR_PostingInformation  GetHR_PostingInformationByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PostingInformationByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PostingInformationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_PostingInformation()
    {
        DataSet HR_PostingInformations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_PostingInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PostingInformations);
            myadapter.Dispose();
            connection.Close();

            return HR_PostingInformations;
        }
    }

    public DataSet   GetAllHR_PostingInformationsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PostingInformationsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_PostingInformation> GetHR_PostingInformationsFromReader(IDataReader reader)
    {
        List<HR_PostingInformation> hR_PostingInformations = new List<HR_PostingInformation>();

        while (reader.Read())
        {
            hR_PostingInformations.Add(GetHR_PostingInformationFromReader(reader));
        }
        return hR_PostingInformations;
    }

    public HR_PostingInformation GetHR_PostingInformationFromReader(IDataReader reader)
    {
        try
        {
            HR_PostingInformation hR_PostingInformation = new HR_PostingInformation
                (

                     DataAccessObject.IsNULL<int>(reader["PostingInformationID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["Department"]),
                     DataAccessObject.IsNULL<string>(reader["Designation"]),
                     DataAccessObject.IsNULL<string>(reader["JobLocation"]),
                     DataAccessObject.IsNULL<string>(reader["Supervisor"]),
                     DataAccessObject.IsNULL<DateTime>(reader["JoningDate"]),
                     DataAccessObject.IsNULL<string>(reader["Status"]),
                     DataAccessObject.IsNULL<DateTime>(reader["FindingDate"]),
                     DataAccessObject.IsNULL<DateTime>(reader["PostingDate"]),
                     DataAccessObject.IsNULL<string>(reader["JobResponsibily"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_PostingInformation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_PostingInformation  GetHR_PostingInformationByPostingInformationID(int  postingInformationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PostingInformationByPostingInformationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PostingInformationID", SqlDbType.Int).Value = postingInformationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PostingInformationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_PostingInformation(HR_PostingInformation hR_PostingInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_PostingInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PostingInformationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_PostingInformation.EmployeeID;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = hR_PostingInformation.Department;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = hR_PostingInformation.Designation;
            cmd.Parameters.Add("@JobLocation", SqlDbType.NVarChar).Value = hR_PostingInformation.JobLocation;
            cmd.Parameters.Add("@Supervisor", SqlDbType.NVarChar).Value = hR_PostingInformation.Supervisor;
            cmd.Parameters.Add("@JoningDate", SqlDbType.DateTime).Value = hR_PostingInformation.JoningDate;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = hR_PostingInformation.Status;
            cmd.Parameters.Add("@FindingDate", SqlDbType.DateTime).Value = hR_PostingInformation.FindingDate;
            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = hR_PostingInformation.PostingDate;
            cmd.Parameters.Add("@JobResponsibily", SqlDbType.NVarChar).Value = hR_PostingInformation.JobResponsibily;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_PostingInformation.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_PostingInformation.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_PostingInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_PostingInformation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PostingInformationID"].Value;
        }
    }

    public bool UpdateHR_PostingInformation(HR_PostingInformation hR_PostingInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_PostingInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PostingInformationID", SqlDbType.Int).Value = hR_PostingInformation.PostingInformationID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_PostingInformation.EmployeeID;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = hR_PostingInformation.Department;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = hR_PostingInformation.Designation;
            cmd.Parameters.Add("@JobLocation", SqlDbType.NVarChar).Value = hR_PostingInformation.JobLocation;
            cmd.Parameters.Add("@Supervisor", SqlDbType.NVarChar).Value = hR_PostingInformation.Supervisor;
            cmd.Parameters.Add("@JoningDate", SqlDbType.DateTime).Value = hR_PostingInformation.JoningDate;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = hR_PostingInformation.Status;
            cmd.Parameters.Add("@FindingDate", SqlDbType.DateTime).Value = hR_PostingInformation.FindingDate;
            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = hR_PostingInformation.PostingDate;
            cmd.Parameters.Add("@JobResponsibily", SqlDbType.NVarChar).Value = hR_PostingInformation.JobResponsibily;
            cmd.Parameters.Add("@JobResponsibily", SqlDbType.NVarChar).Value = hR_PostingInformation.JobResponsibily;
            cmd.Parameters.Add("@JobResponsibily", SqlDbType.NVarChar).Value = hR_PostingInformation.JobResponsibily;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_PostingInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_PostingInformation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_PostingInformation(int postingInformationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_PostingInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PostingInformationID", SqlDbType.Int).Value = postingInformationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

