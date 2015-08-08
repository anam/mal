using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EmployeeOverTimePackageProvider:DataAccessObject
{
	public SqlHR_EmployeeOverTimePackageProvider()
    {
    }


    public DataSet  GetAllHR_EmployeeOverTimePackages()
    {
        DataSet HR_EmployeeOverTimePackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeOverTimePackages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeOverTimePackages);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeOverTimePackages;
        }
    }
	public DataSet GetHR_EmployeeOverTimePackagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeeOverTimePackagePageWise", connection))
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


    public HR_EmployeeOverTimePackage  GetHR_EmployeeOverTimePackageByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeOverTimePackageByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeOverTimePackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_EmployeeOverTimePackage  GetHR_EmployeeOverTimePackageByOverTimePackageID(int  overTimePackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeOverTimePackageByOverTimePackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OverTimePackageID", SqlDbType.NVarChar).Value = overTimePackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeOverTimePackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_EmployeeOverTimePackage()
    {
        DataSet HR_EmployeeOverTimePackages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeeOverTimePackage", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeOverTimePackages);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeOverTimePackages;
        }
    }

    public DataSet   GetAllHR_EmployeeOverTimePackagesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeOverTimePackagesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_EmployeeOverTimePackage> GetHR_EmployeeOverTimePackagesFromReader(IDataReader reader)
    {
        List<HR_EmployeeOverTimePackage> hR_EmployeeOverTimePackages = new List<HR_EmployeeOverTimePackage>();

        while (reader.Read())
        {
            hR_EmployeeOverTimePackages.Add(GetHR_EmployeeOverTimePackageFromReader(reader));
        }
        return hR_EmployeeOverTimePackages;
    }

    public HR_EmployeeOverTimePackage GetHR_EmployeeOverTimePackageFromReader(IDataReader reader)
    {
        try
        {
            HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage = new HR_EmployeeOverTimePackage
                (

                     DataAccessObject.IsNULL<int>(reader["OverTimeID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["OverTimePackageID"]),
                     DataAccessObject.IsNULL<decimal>(reader["OverTimeTakaPerHour"]),
                     DataAccessObject.IsNULL<bool>(reader["OverTimeFlag"]),
                     DataAccessObject.IsNULL<string>(reader["DayMonth"]),
                     DataAccessObject.IsNULL<DateTime>(reader["OverTimeDate"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_EmployeeOverTimePackage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EmployeeOverTimePackage  GetHR_EmployeeOverTimePackageByOverTimeID(int  overTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeOverTimePackageByOverTimeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OverTimeID", SqlDbType.Int).Value = overTimeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeOverTimePackageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public bool IsEmployeeExist(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CheckEmployeeIDHR_EmployeeOverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public int InsertHR_EmployeeOverTimePackage(HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployeeOverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.EmployeeID;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = hR_EmployeeOverTimePackage.OverTimePackageID;
            cmd.Parameters.Add("@OverTimeTakaPerHour", SqlDbType.Decimal).Value = hR_EmployeeOverTimePackage.OverTimeTakaPerHour;
            cmd.Parameters.Add("@OverTimeFlag", SqlDbType.Bit).Value = hR_EmployeeOverTimePackage.OverTimeFlag;
            cmd.Parameters.Add("@DayMonth", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.DayMonth;
            cmd.Parameters.Add("@OverTimeDate", SqlDbType.DateTime).Value = hR_EmployeeOverTimePackage.OverTimeDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EmployeeOverTimePackage.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeeOverTimePackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OverTimeID"].Value;
        }
    }

    public bool UpdateHR_EmployeeOverTimePackage(HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeOverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeID", SqlDbType.Int).Value = hR_EmployeeOverTimePackage.OverTimeID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.EmployeeID;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = hR_EmployeeOverTimePackage.OverTimePackageID;
            cmd.Parameters.Add("@OverTimeTakaPerHour", SqlDbType.Decimal).Value = hR_EmployeeOverTimePackage.OverTimeTakaPerHour;
            cmd.Parameters.Add("@OverTimeFlag", SqlDbType.Bit).Value = hR_EmployeeOverTimePackage.OverTimeFlag;
            cmd.Parameters.Add("@DayMonth", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.DayMonth;
            cmd.Parameters.Add("@OverTimeDate", SqlDbType.DateTime).Value = hR_EmployeeOverTimePackage.OverTimeDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeeOverTimePackage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeeOverTimePackage.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EmployeeOverTimePackage(int overTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeOverTimePackage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeID", SqlDbType.Int).Value = overTimeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

