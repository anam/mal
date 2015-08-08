using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryIncrementPackageRulesProvider:DataAccessObject
{
	public SqlHR_SalaryIncrementPackageRulesProvider()
    {
    }


    public DataSet  GetAllHR_SalaryIncrementPackageRuless()
    {
        DataSet HR_SalaryIncrementPackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryIncrementPackageRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryIncrementPackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryIncrementPackageRuless;
        }
    }
	public DataSet GetHR_SalaryIncrementPackageRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPackageRulesPageWise", connection))
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


    public HR_SalaryIncrementPackageRules  GetHR_SalaryIncrementPackageRulesByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPackageRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryIncrementPackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_SalaryIncrementPackageRules  GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageID(int  salaryIncrementPackageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.NVarChar).Value = salaryIncrementPackageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryIncrementPackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_SalaryIncrementPackageRules()
    {
        DataSet HR_SalaryIncrementPackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryIncrementPackageRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryIncrementPackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryIncrementPackageRuless;
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
    public List<HR_SalaryIncrementPackageRules> GetHR_SalaryIncrementPackageRulessFromReader(IDataReader reader)
    {
        List<HR_SalaryIncrementPackageRules> hR_SalaryIncrementPackageRuless = new List<HR_SalaryIncrementPackageRules>();

        while (reader.Read())
        {
            hR_SalaryIncrementPackageRuless.Add(GetHR_SalaryIncrementPackageRulesFromReader(reader));
        }
        return hR_SalaryIncrementPackageRuless;
    }

    public HR_SalaryIncrementPackageRules GetHR_SalaryIncrementPackageRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryIncrementPackageRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["SalaryIncrementPackageID"]),
                     DataAccessObject.IsNULL<int>(reader["Year"]),
                     DataAccessObject.IsNULL<int>(reader["Month"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryIncrementPackageRules;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryIncrementPackageRules  GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageRulesID(int  salaryIncrementPackageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryIncrementPackageRulesID", SqlDbType.Int).Value = salaryIncrementPackageRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryIncrementPackageRulesFromReader(reader);
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
            SqlCommand cmd = new SqlCommand("[CheckEmployeeIDHR_SalaryIncrementPackageRules]", connection);
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

    public int InsertHR_SalaryIncrementPackageRules(HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryIncrementPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementPackageRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackageRules.EmployeeID;
            cmd.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.SalaryIncrementPackageID;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.Year;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.Month;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackageRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryIncrementPackageRules.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackageRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryIncrementPackageRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryIncrementPackageRulesID"].Value;
        }
    }

    public bool UpdateHR_SalaryIncrementPackageRules(HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryIncrementPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementPackageRulesID", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.SalaryIncrementPackageRulesID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackageRules.EmployeeID;
            cmd.Parameters.Add("@SalaryIncrementPackageID", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.SalaryIncrementPackageID;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.Year;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = hR_SalaryIncrementPackageRules.Month;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrementPackageRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryIncrementPackageRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryIncrementPackageRules(int salaryIncrementPackageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryIncrementPackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementPackageRulesID", SqlDbType.Int).Value = salaryIncrementPackageRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

