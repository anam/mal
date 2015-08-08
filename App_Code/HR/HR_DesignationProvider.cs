using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_DesignationProvider:DataAccessObject
{
	public SqlHR_DesignationProvider()
    {
    }


    public DataSet  GetAllHR_Designations()
    {
        DataSet HR_Designations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Designations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Designations);
            myadapter.Dispose();
            connection.Close();

            return HR_Designations;
        }
    }
	public DataSet GetHR_DesignationPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_DesignationPageWise", connection))
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


    public DataSet GetHR_DesignationByDepartmentID(int departmentID)
    {
        DataSet HR_Designations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_DesignationByDepartmentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepartmentID", SqlDbType.NVarChar).Value = departmentID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Designations);
            myadapter.Dispose();
            connection.Close();

            return HR_Designations;
        }
    }

    public DataSet  GetDropDownLisAllHR_Designation()
    {
        DataSet HR_Designations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Designation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Designations);
            myadapter.Dispose();
            connection.Close();

            return HR_Designations;
        }
    }

    public DataSet   GetAllHR_DesignationsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_DesignationsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_Designation> GetHR_DesignationsFromReader(IDataReader reader)
    {
        List<HR_Designation> hR_Designations = new List<HR_Designation>();

        while (reader.Read())
        {
            hR_Designations.Add(GetHR_DesignationFromReader(reader));
        }
        return hR_Designations;
    }

    public HR_Designation GetHR_DesignationFromReader(IDataReader reader)
    {
        try
        {
            HR_Designation hR_Designation = new HR_Designation
                (

                     DataAccessObject.IsNULL<int>(reader["DesignationID"]),
                     DataAccessObject.IsNULL<string>(reader["DesignationName"]),
                     DataAccessObject.IsNULL<int>(reader["DepartmentID"]),
                     DataAccessObject.IsNULL<string>(reader["Supervisor"]),
                     DataAccessObject.IsNULL<string>(reader["JobResponsibility"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Designation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Designation  GetHR_DesignationByDesignationID(int  designationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_DesignationByDesignationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesignationID", SqlDbType.Int).Value = designationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_DesignationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Designation(HR_Designation hR_Designation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Designation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DesignationName", SqlDbType.NVarChar).Value = hR_Designation.DesignationName;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_Designation.DepartmentID;
            cmd.Parameters.Add("@Supervisor", SqlDbType.NVarChar).Value = hR_Designation.Supervisor;
            cmd.Parameters.Add("@JobResponsibility", SqlDbType.NVarChar).Value = hR_Designation.JobResponsibility;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Designation.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Designation.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Designation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Designation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DesignationID"].Value;
        }
    }

    public bool UpdateHR_Designation(HR_Designation hR_Designation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Designation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = hR_Designation.DesignationID;
            cmd.Parameters.Add("@DesignationName", SqlDbType.NVarChar).Value = hR_Designation.DesignationName;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_Designation.DepartmentID;
            cmd.Parameters.Add("@Supervisor", SqlDbType.NVarChar).Value = hR_Designation.Supervisor;
            cmd.Parameters.Add("@JobResponsibility", SqlDbType.NVarChar).Value = hR_Designation.JobResponsibility;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Designation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Designation.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Designation(int designationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Designation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = designationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

