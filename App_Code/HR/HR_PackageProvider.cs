using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_PackageProvider:DataAccessObject
{
	public SqlHR_PackageProvider()
    {
    }


    public DataSet  GetAllHR_Packages()
    {
        DataSet HR_Packages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Packages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Packages);
            myadapter.Dispose();
            connection.Close();

            return HR_Packages;
        }
    }
	public DataSet GetHR_PackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_PackagePageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_Package()
    {
        DataSet HR_Packages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Package", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Packages);
            myadapter.Dispose();
            connection.Close();

            return HR_Packages;
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
    public List<HR_Package> GetHR_PackagesFromReader(IDataReader reader)
    {
        List<HR_Package> hR_Packages = new List<HR_Package>();

        while (reader.Read())
        {
            hR_Packages.Add(GetHR_PackageFromReader(reader));
        }
        return hR_Packages;
    }

    public HR_Package GetHR_PackageFromReader(IDataReader reader)
    {
        try
        {
            HR_Package hR_Package = new HR_Package
                (

                     DataAccessObject.IsNULL<int>(reader["PackageID"]),
                     DataAccessObject.IsNULL<string>(reader["PackageName"]),
                     DataAccessObject.IsNULL<int>(reader["PackageValue"])
                );
             return hR_Package;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Package  GetHR_PackageByPackageID(int  packageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PackageByPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PackageID", SqlDbType.Int).Value = packageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Package(HR_Package hR_Package)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Package", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = hR_Package.PackageName;
            cmd.Parameters.Add("@PackageValue", SqlDbType.Int).Value = hR_Package.PackageValue;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PackageID"].Value;
        }
    }

    public bool UpdateHR_Package(HR_Package hR_Package)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Package", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PackageID", SqlDbType.Int).Value = hR_Package.PackageID;
            cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = hR_Package.PackageName;
            cmd.Parameters.Add("@PackageValue", SqlDbType.Int).Value = hR_Package.PackageValue;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Package(int packageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Package", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PackageID", SqlDbType.Int).Value = packageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

