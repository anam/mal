using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryIncrementPackageProvider:DataAccessObject
{
	public SqlHR_SalaryIncrementPackageProvider()
    {
    }


    public DataSet  GetAllHR_SalaryIncrementPackages()
    {
        DataSet HR_SalaryIncrementPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryIncrementPackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryIncrementPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryIncrementPackages;
        }
    }
	public DataSet GetHR_SalaryIncrementPackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPackagePageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_SalaryIncrementPackage()
    {
        DataSet HR_SalaryIncrementPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryIncrementPackage", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryIncrementPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryIncrementPackages;
        }
    }

    public DataSet   GetAllHR_OverTimePackageRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_OverTimePackageRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_SalaryIncrementPackage> GetHR_SalaryIncrementPackagesFromReader(IDataReader reader)
    {
        List<HR_SalaryIncrementPackage> hR_SalaryIncrementPackages = new List<HR_SalaryIncrementPackage>();

        while (reader.Read())
        {
            hR_SalaryIncrementPackages.Add(GetHR_SalaryIncrementPackageFromReader(reader));
        }
        return hR_SalaryIncrementPackages;
    }

    public HR_SalaryIncrementPackage GetHR_SalaryIncrementPackageFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryIncrementPackage hR_SalaryIncrementPackage = new HR_SalaryIncrementPackage
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryIncrementPackageID"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryIncrementPackageName"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryIncrementFormula"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryIncrementPackage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryIncrementPackage  GetHR_SalaryIncrementPackageBySalaryIncrementPackageID(int  salaryIncrementPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPackageBySalaryIncrementPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.Int).Value = salaryIncrementPackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryIncrementPackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_SalaryIncrementPackage(HR_SalaryIncrementPackage hR_SalaryIncrementPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryIncrementPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryIncrementPackageName", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.SalaryIncrementPackageName;
            cmd.Parameters.Add("@SalaryIncrementFormula", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.SalaryIncrementFormula;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryIncrementPackage.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryIncrementPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryIncrementPackageID"].Value;
        }
    }

    public bool UpdateHR_SalaryIncrementPackage(HR_SalaryIncrementPackage hR_SalaryIncrementPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryIncrementPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.Int).Value = hR_SalaryIncrementPackage.SalaryIncrementPackageID;
            cmd.Parameters.Add("@SalaryIncrementPackageName", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.SalaryIncrementPackageName;
            cmd.Parameters.Add("@SalaryIncrementFormula", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.SalaryIncrementFormula;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryIncrementPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryIncrementPackage(int salaryIncrementPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryIncrementPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.Int).Value = salaryIncrementPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

