using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryPackageProvider:DataAccessObject
{
	public SqlHR_SalaryPackageProvider()
    {
    }


    public DataSet  GetAllHR_SalaryPackages()
    {
        DataSet HR_SalaryPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryPackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryPackages;
        }
    }
	public DataSet GetHR_SalaryPackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryPackagePageWise", connection))
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


    public HR_SalaryPackage  GetHR_SalaryPackageByDepartmentID(int  departmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryPackageByDepartmentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepartmentID", SqlDbType.NVarChar).Value = departmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryPackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_SalaryPackage()
    {
        DataSet HR_SalaryPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryPackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryPackages;
        }
    }

    public DataSet   GetAllHR_SalaryPackagesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryPackagesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_SalaryPackage> GetHR_SalaryPackagesFromReader(IDataReader reader)
    {
        List<HR_SalaryPackage> hR_SalaryPackages = new List<HR_SalaryPackage>();

        while (reader.Read())
        {
            hR_SalaryPackages.Add(GetHR_SalaryPackageFromReader(reader));
        }
        return hR_SalaryPackages;
    }

    public HR_SalaryPackage GetHR_SalaryPackageFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryPackage hR_SalaryPackage = new HR_SalaryPackage
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryPackageID"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryPackageName"]),
                     DataAccessObject.IsNULL<int>(reader["DepartmentID"]),
                     DataAccessObject.IsNULL<string>(reader["Rank"]),
                     DataAccessObject.IsNULL<decimal>(reader["Ratio"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryPackage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryPackage  GetHR_SalaryPackageBySalaryPackageID(int  salaryPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryPackageBySalaryPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryPackageID", SqlDbType.Int).Value = salaryPackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryPackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_SalaryPackage(HR_SalaryPackage hR_SalaryPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryPackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryPackageName", SqlDbType.NVarChar).Value = hR_SalaryPackage.SalaryPackageName;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_SalaryPackage.DepartmentID;
            cmd.Parameters.Add("@Rank", SqlDbType.NVarChar).Value = hR_SalaryPackage.Rank;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryPackage.Ratio;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryPackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryPackage.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryPackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryPackageID"].Value;
        }
    }

    public bool UpdateHR_SalaryPackage(HR_SalaryPackage hR_SalaryPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryPackageID", SqlDbType.Int).Value = hR_SalaryPackage.SalaryPackageID;
            cmd.Parameters.Add("@SalaryPackageName", SqlDbType.NVarChar).Value = hR_SalaryPackage.SalaryPackageName;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = hR_SalaryPackage.DepartmentID;
            cmd.Parameters.Add("@Rank", SqlDbType.NVarChar).Value = hR_SalaryPackage.Rank;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryPackage.Ratio;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryPackage.Ratio;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryPackage.Ratio;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryPackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryPackage(int salaryPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryPackageID", SqlDbType.Int).Value = salaryPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

