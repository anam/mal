using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_BenifitPackageRulesProvider:DataAccessObject
{
	public SqlHR_BenifitPackageRulesProvider()
    {
    }


    public DataSet  GetAllHR_BenifitPackagesRules()
    {
        DataSet HR_BenifitPackageRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_BenifitPackageRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BenifitPackageRules);
            myadapter.Dispose();
            connection.Close();

            return HR_BenifitPackageRules;
        }
    }

    //public DataSet GetHR_BenifitPackagePageWise(int pageIndex, int PageSize, out int recordCount)
    //{
    //DataSet ds = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        using (SqlCommand command = new SqlCommand("GetHR_BenifitPackagePageWise", connection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.AddWithValue("@PageIndex", pageIndex);
    //            command.Parameters.AddWithValue("@PageSize",  PageSize );
    //            command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
    //            command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
    //            connection.Open();
    //            SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //            myadapter.Fill(ds);
    //            myadapter.Dispose();
    //            connection.Close();
    //            recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
    //            return ds;
    //        }
    //    }
    //}


    //public DataSet  GetDropDownLisAllHR_BenifitPackage()
    //{
    //    DataSet HR_BenifitPackages = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetDropDownListAllHR_BenifitPackage", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        myadapter.Fill(HR_BenifitPackages);
    //        myadapter.Dispose();
    //        connection.Close();

    //        return HR_BenifitPackages;
    //    }
    //}

    //public DataSet   GetAllHR_BanksWithRelation()
    //{
    //   DataSet ds = new DataSet();
    //   using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetAllHR_BanksWithRelation", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        myadapter.Fill(ds);
    //        myadapter.Dispose();
    //        connection.Close();

    //        return ds;
    //    }
    //}

    public List<HR_BenifitPackageRules> GetHR_BenifitPackageRulesCollFromReader(IDataReader reader)
    {
        List<HR_BenifitPackageRules> hR_BenifitPackageRulesColl = new List<HR_BenifitPackageRules>();

        while (reader.Read())
        {
            hR_BenifitPackageRulesColl.Add(GetHR_BenifitPackageRulesFromReader(reader));
        }
        return hR_BenifitPackageRulesColl;
    }

    public HR_BenifitPackageRules GetHR_BenifitPackageRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_BenifitPackageRules hR_BenifitPackageRules = new HR_BenifitPackageRules
                (
                     DataAccessObject.IsNULL<int>(reader["BenifitPackageRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["BenifitPackageID"])
                );
            return hR_BenifitPackageRules;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_BenifitPackageRules GetHR_BenifitPackageRulesByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_BenifitPackageRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_BenifitPackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetAllHR_BenifitPackageRulesByEmployeeID(string employeeID)
    {
        DataSet HR_BenifitPackageRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_BenifitPackageRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BenifitPackageRules);
            myadapter.Dispose();
            connection.Close();

            return HR_BenifitPackageRules;
        }
    }

    public bool IsEmployeeExist(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CheckEmployeeIDHR_BenifitPackageRules", connection);
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

    public int InsertHR_BenifitPackageRules(HR_BenifitPackageRules hR_BenifitPackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_BenifitPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenifitPackageRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_BenifitPackageRules.EmployeeID;
            cmd.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Value = hR_BenifitPackageRules.BenifitPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BenifitPackageRulesID"].Value;
        }
    }

    public bool UpdateHR_BenifitPackage(HR_BenifitPackageRules hR_BenifitPackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_BenifitPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenifitPackageRulesID", SqlDbType.Int).Value = hR_BenifitPackageRules.BenifitPackageID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_BenifitPackageRules.EmployeeID;
            cmd.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Value = hR_BenifitPackageRules.BenifitPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_BenifitPackageRules(int benifitPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_BenifitPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenifitPackageRulesID", SqlDbType.Int).Value = benifitPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteHR_BenifitPackageRulesByEmpIDAndBenPackageID (string employeeID, int benifitPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_BenifitPackageRulesByEmpIDAndBenPackID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            cmd.Parameters.Add("@BenifitPackageID", SqlDbType.Int).Value = benifitPackageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

