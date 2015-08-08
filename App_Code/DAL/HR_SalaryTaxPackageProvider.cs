using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryTaxPackageProvider:DataAccessObject
{
	public SqlHR_SalaryTaxPackageProvider()
    {
    }


    public DataSet  GetAllHR_SalaryTaxPackages()
    {
        DataSet HR_SalaryTaxPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryTaxPackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryTaxPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryTaxPackages;
        }
    }
	public DataSet GetHR_SalaryTaxPackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryTaxPackagePageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_SalaryTaxPackage()
    {
        DataSet HR_SalaryTaxPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryTaxPackage", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryTaxPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryTaxPackages;
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
    public List<HR_SalaryTaxPackage> GetHR_SalaryTaxPackagesFromReader(IDataReader reader)
    {
        List<HR_SalaryTaxPackage> hR_SalaryTaxPackages = new List<HR_SalaryTaxPackage>();

        while (reader.Read())
        {
            hR_SalaryTaxPackages.Add(GetHR_SalaryTaxPackageFromReader(reader));
        }
        return hR_SalaryTaxPackages;
    }

    public HR_SalaryTaxPackage GetHR_SalaryTaxPackageFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryTaxPackage hR_SalaryTaxPackage = new HR_SalaryTaxPackage
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryTaxPackagePackageID"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryTaxPackagePackageName"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryTaxPackageFormula"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryTaxPackage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryTaxPackage  GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(int  salaryTaxPackagePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryTaxPackagePackageID", SqlDbType.Int).Value = salaryTaxPackagePackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryTaxPackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_SalaryTaxPackage(HR_SalaryTaxPackage hR_SalaryTaxPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryTaxPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryTaxPackagePackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryTaxPackagePackageName", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.SalaryTaxPackagePackageName;
            cmd.Parameters.Add("@SalaryTaxPackageFormula", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.SalaryTaxPackageFormula;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryTaxPackage.AddedDate;
            //cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.ModifiedBy;
            //cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryTaxPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryTaxPackagePackageID"].Value;
        }
    }

    public bool UpdateHR_SalaryTaxPackage(HR_SalaryTaxPackage hR_SalaryTaxPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryTaxPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryTaxPackagePackageID", SqlDbType.Int).Value = hR_SalaryTaxPackage.SalaryTaxPackagePackageID;
            cmd.Parameters.Add("@SalaryTaxPackagePackageName", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.SalaryTaxPackagePackageName;
            cmd.Parameters.Add("@SalaryTaxPackageFormula", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.SalaryTaxPackageFormula;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryTaxPackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryTaxPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryTaxPackage(int salaryTaxPackagePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryTaxPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryTaxPackagePackageID", SqlDbType.Int).Value = salaryTaxPackagePackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

