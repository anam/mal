using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EmployeePackageProvider:DataAccessObject
{
	public SqlHR_EmployeePackageProvider()
    {
    }


    public DataSet  GetAllHR_EmployeePackages()
    {
        DataSet HR_EmployeePackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeePackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeePackages);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeePackages;
        }
    }
	public DataSet GetHR_EmployeePackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeePackagePageWise", connection))
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


    public DataSet  GetDropDownListAllHR_EmployeePackage()
    {
        DataSet HR_EmployeePackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeePackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeePackages);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeePackages;
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
    public List<HR_EmployeePackage> GetHR_EmployeePackagesFromReader(IDataReader reader)
    {
        List<HR_EmployeePackage> hR_EmployeePackages = new List<HR_EmployeePackage>();

        while (reader.Read())
        {
            hR_EmployeePackages.Add(GetHR_EmployeePackageFromReader(reader));
        }
        return hR_EmployeePackages;
    }

    public HR_EmployeePackage GetHR_EmployeePackageFromReader(IDataReader reader)
    {
        try
        {
            HR_EmployeePackage hR_EmployeePackage = new HR_EmployeePackage
                (

                     DataAccessObject.IsNULL<int>(reader["EmployeePackageID"]),
                     DataAccessObject.IsNULL<string>(reader["PackageName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_EmployeePackage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EmployeePackage  GetHR_EmployeePackageByEmployeePackageID(int  employeePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeePackageByEmployeePackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeePackageID", SqlDbType.Int).Value = employeePackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeePackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_EmployeePackage(HR_EmployeePackage hR_EmployeePackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployeePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeePackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = hR_EmployeePackage.PackageName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EmployeePackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EmployeePackage.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeePackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeePackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployeePackageID"].Value;
        }
    }

    public bool UpdateHR_EmployeePackage(HR_EmployeePackage hR_EmployeePackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeePackageID", SqlDbType.Int).Value = hR_EmployeePackage.EmployeePackageID;
            cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = hR_EmployeePackage.PackageName;
            cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = hR_EmployeePackage.PackageName;
            cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = hR_EmployeePackage.PackageName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeePackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeePackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EmployeePackage(int employeePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeePackageID", SqlDbType.Int).Value = employeePackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

