using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_OverTimePackageProvider:DataAccessObject
{
	public SqlHR_OverTimePackageProvider()
    {
    }


    public DataSet  GetAllHR_OverTimePackages()
    {
        DataSet HR_OverTimePackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_OverTimePackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OverTimePackages);
            myadapter.Dispose();
            connection.Close();

            return HR_OverTimePackages;
        }
    }
	public DataSet GetHR_OverTimePackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_OverTimePackagePageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_OverTimePackage()
    {
        DataSet HR_OverTimePackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_OverTimePackage", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OverTimePackages);
            myadapter.Dispose();
            connection.Close();

            return HR_OverTimePackages;
        }
    }
    public List<HR_OverTimePackage> GetHR_OverTimePackagesFromReader(IDataReader reader)
    {
        List<HR_OverTimePackage> hR_OverTimePackages = new List<HR_OverTimePackage>();

        while (reader.Read())
        {
            hR_OverTimePackages.Add(GetHR_OverTimePackageFromReader(reader));
        }
        return hR_OverTimePackages;
    }

    public HR_OverTimePackage GetHR_OverTimePackageFromReader(IDataReader reader)
    {
        try
        {
            HR_OverTimePackage hR_OverTimePackage = new HR_OverTimePackage
                (

                     DataAccessObject.IsNULL<int>(reader["OverTimePackageID"]),
                     DataAccessObject.IsNULL<string>(reader["OverTimePackageName"]),
                     DataAccessObject.IsNULL<string>(reader["OverTimeFormula"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_OverTimePackage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_OverTimePackage  GetHR_OverTimePackageByOverTimePackageID(int  overTimePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OverTimePackageByOverTimePackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = overTimePackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_OverTimePackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_OverTimePackage(HR_OverTimePackage hR_OverTimePackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_OverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OverTimePackageName", SqlDbType.NVarChar).Value = hR_OverTimePackage.OverTimePackageName;
            cmd.Parameters.Add("@OverTimeFormula", SqlDbType.NVarChar).Value = hR_OverTimePackage.OverTimeFormula;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_OverTimePackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_OverTimePackage.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_OverTimePackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_OverTimePackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OverTimePackageID"].Value;
        }
    }

    public bool UpdateHR_OverTimePackage(HR_OverTimePackage hR_OverTimePackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_OverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = hR_OverTimePackage.OverTimePackageID;
            cmd.Parameters.Add("@OverTimePackageName", SqlDbType.NVarChar).Value = hR_OverTimePackage.OverTimePackageName;
            cmd.Parameters.Add("@OverTimeFormula", SqlDbType.NVarChar).Value = hR_OverTimePackage.OverTimeFormula;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_OverTimePackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_OverTimePackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_OverTimePackage(int overTimePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_OverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = overTimePackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

