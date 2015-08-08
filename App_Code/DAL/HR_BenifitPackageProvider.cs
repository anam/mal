using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_BenifitPackageProvider:DataAccessObject
{
	public SqlHR_BenifitPackageProvider()
    {
    }
    public DataSet  GetAllHR_BenifitPackages()
    {
        DataSet HR_BenifitPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_BenifitPackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BenifitPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_BenifitPackages;
        }
    }
	public DataSet GetHR_BenifitPackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_BenifitPackagePageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_BenifitPackage()
    {
        DataSet HR_BenifitPackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_BenifitPackage", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BenifitPackages);
            myadapter.Dispose();
            connection.Close();

            return HR_BenifitPackages;
        }
    }

    public DataSet   GetAllHR_BanksWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_BanksWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_BenifitPackage> GetHR_BenifitPackagesFromReader(IDataReader reader)
    {
        List<HR_BenifitPackage> hR_BenifitPackages = new List<HR_BenifitPackage>();

        while (reader.Read())
        {
            hR_BenifitPackages.Add(GetHR_BenifitPackageFromReader(reader));
        }
        return hR_BenifitPackages;
    }

    public HR_BenifitPackage GetHR_BenifitPackageFromReader(IDataReader reader)
    {
        try
        {
            HR_BenifitPackage hR_BenifitPackage = new HR_BenifitPackage
                (

                     DataAccessObject.IsNULL<int>(reader["BenifitPackageID"]),
                     DataAccessObject.IsNULL<string>(reader["BenifitPackageName"]),
                     DataAccessObject.IsNULL<int>(reader["BenifitTimesYear"]),
                     DataAccessObject.IsNULL<string>(reader["BebifitFormula"]),
                     DataAccessObject.IsNULL<bool>(reader["IsRespectGross"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])

                    );
            return hR_BenifitPackage;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_BenifitPackage  GetHR_BenifitPackageByBenifitPackageID(int  benifitPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_BenifitPackageByBenifitPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Value = benifitPackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_BenifitPackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_BenifitPackage(HR_BenifitPackage hR_BenifitPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_BenifitPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BenifitPackageName", SqlDbType.NVarChar).Value = hR_BenifitPackage.BenifitPackageName;
            cmd.Parameters.Add("@BenifitTimesYear", SqlDbType.Int).Value = hR_BenifitPackage.BenifitTimesYear;
            cmd.Parameters.Add("@BebifitFormula", SqlDbType.NVarChar).Value = hR_BenifitPackage.BebifitFormula;
            cmd.Parameters.Add("@IsRespectGross", SqlDbType.Bit).Value = hR_BenifitPackage.IsGrossBenifit;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_BenifitPackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_BenifitPackage.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BenifitPackageID"].Value;
        }
    }

    public bool UpdateHR_BenifitPackage(HR_BenifitPackage hR_BenifitPackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_BenifitPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Value = hR_BenifitPackage.BenifitPackageID;
            cmd.Parameters.Add("@BenifitPackageName", SqlDbType.NVarChar).Value = hR_BenifitPackage.BenifitPackageName;
            cmd.Parameters.Add("@BenifitTimesYear", SqlDbType.Int).Value = hR_BenifitPackage.BenifitTimesYear;
            cmd.Parameters.Add("@BebifitFormula", SqlDbType.NVarChar).Value = hR_BenifitPackage.BebifitFormula;
            cmd.Parameters.Add("@IsRespectGross", SqlDbType.Int).Value = hR_BenifitPackage.IsGrossBenifit;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_BenifitPackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_BenifitPackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_BenifitPackage(int benifitPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_BenifitPackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Value = benifitPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

