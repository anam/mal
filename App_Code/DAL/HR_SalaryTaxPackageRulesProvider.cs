using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryTaxPackageRulesProvider:DataAccessObject
{
	public SqlHR_SalaryTaxPackageRulesProvider()
    {
    }


    public DataSet  GetAllHR_SalaryTaxPackageRuless()
    {
        DataSet HR_SalaryTaxPackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryTaxPackageRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryTaxPackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryTaxPackageRuless;
        }
    }
	public DataSet GetHR_SalaryTaxPackageRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryTaxPackageRulesPageWise", connection))
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


    public HR_SalaryTaxPackageRules  GetHR_SalaryTaxPackageRulesByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryTaxPackageRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryTaxPackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_SalaryTaxPackageRules  GetHR_SalaryTaxPackageRulesBySalaryTaxPackageID(int  salaryTaxPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryTaxPackageRulesBySalaryTaxPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryTaxPackageID", SqlDbType.NVarChar).Value = salaryTaxPackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryTaxPackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_SalaryTaxPackageRules()
    {
        DataSet HR_SalaryTaxPackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryTaxPackageRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryTaxPackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryTaxPackageRuless;
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
    public List<HR_SalaryTaxPackageRules> GetHR_SalaryTaxPackageRulessFromReader(IDataReader reader)
    {
        List<HR_SalaryTaxPackageRules> hR_SalaryTaxPackageRuless = new List<HR_SalaryTaxPackageRules>();

        while (reader.Read())
        {
            hR_SalaryTaxPackageRuless.Add(GetHR_SalaryTaxPackageRulesFromReader(reader));
        }
        return hR_SalaryTaxPackageRuless;
    }

    public HR_SalaryTaxPackageRules GetHR_SalaryTaxPackageRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryTaxPackageRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["SalaryTaxPackageID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryTaxPackageRules;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryTaxPackageRules  GetHR_SalaryTaxPackageRulesBySalaryTaxPackageRulesID(int  salaryTaxPackageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryTaxPackageRulesBySalaryTaxPackageRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryTaxPackageRulesID", SqlDbType.Int).Value = salaryTaxPackageRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryTaxPackageRulesFromReader(reader);
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
            SqlCommand cmd = new SqlCommand("CheckEmployeeIDHR_SalaryTaxPackageRules", connection);
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

    public int InsertHR_SalaryTaxPackageRules(HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryTaxPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryTaxPackageRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryTaxPackageRules.EmployeeID;
            cmd.Parameters.Add("@SalaryTaxPackageID", SqlDbType.Int).Value = hR_SalaryTaxPackageRules.SalaryTaxPackageID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryTaxPackageRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryTaxPackageRules.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryTaxPackageRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryTaxPackageRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryTaxPackageRulesID"].Value;
        }
    }

    public bool UpdateHR_SalaryTaxPackageRules(HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryTaxPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryTaxPackageRulesID", SqlDbType.Int).Value = hR_SalaryTaxPackageRules.SalaryTaxPackageRulesID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryTaxPackageRules.EmployeeID;
            cmd.Parameters.Add("@SalaryTaxPackageID", SqlDbType.Int).Value = hR_SalaryTaxPackageRules.SalaryTaxPackageID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryTaxPackageRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryTaxPackageRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryTaxPackageRules(int salaryTaxPackageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryTaxPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryTaxPackageRulesID", SqlDbType.Int).Value = salaryTaxPackageRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

