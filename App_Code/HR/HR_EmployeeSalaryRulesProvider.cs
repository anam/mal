using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EmployeeSalaryRulesProvider:DataAccessObject
{
	public SqlHR_EmployeeSalaryRulesProvider()
    {
    }


    public DataSet  GetAllHR_EmployeeSalaryRuless()
    {
        DataSet HR_EmployeeSalaryRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSalaryRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeSalaryRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeSalaryRuless;
        }
    }

    
	public DataSet GetHR_EmployeeSalaryRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryRulesPageWise", connection))
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


    //public IList<HR_EmployeeSalaryRules> GetHR_EmployeeSalaryRulesByEmployeeID(string employeeID)
    //{
    //    IList<HR_EmployeeSalaryRules> employeeSalaryRulesColl = new IList<HR_EmployeeSalaryRules>();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryRulesByEmployeeID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
    //        while (reader.Read())
    //        {
    //            HR_EmployeeSalaryRules employeeSalaryRules = GetHR_EmployeeSalaryRulesFromReader(reader);
    //            employeeSalaryRulesColl.Add(employeeSalaryRules);
    //        }
    //    }
    //    return employeeSalaryRulesColl;
    //}

    public HR_EmployeeSalaryRules GetHR_EmployeeSalaryRulesObjectByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeSalaryRulesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetHR_EmployeeSalaryRulesByEmployeeID(string employeeID)
    {
        DataSet HR_EmployeeSalaryRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeSalaryRuless);
            myadapter.Dispose();
            connection.Close();
            return HR_EmployeeSalaryRuless;
        }
    }

    public HR_EmployeeSalaryRules  GetHR_EmployeeSalaryRulesByPackageRulesID(int  packageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryRulesByPackageRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PackageRulesID", SqlDbType.NVarChar).Value = packageRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeSalaryRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_EmployeeSalaryRules()
    {
        DataSet HR_EmployeeSalaryRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeeSalaryRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeSalaryRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeSalaryRuless;
        }
    }

    public DataSet   GetAllHR_EmployeeSalaryRulessWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSalaryRulessWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_EmployeeSalaryRules> GetHR_EmployeeSalaryRulessFromReader(IDataReader reader)
    {
        List<HR_EmployeeSalaryRules> hR_EmployeeSalaryRuless = new List<HR_EmployeeSalaryRules>();

        while (reader.Read())
        {
            hR_EmployeeSalaryRuless.Add(GetHR_EmployeeSalaryRulesFromReader(reader));
        }
        return hR_EmployeeSalaryRuless;
    }

    public HR_EmployeeSalaryRules GetHR_EmployeeSalaryRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules
                (

                     DataAccessObject.IsNULL<int>(reader["EmployeeSalaryPackageRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["PackageRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
             return hR_EmployeeSalaryRules;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EmployeeSalaryRules  GetHR_EmployeeSalaryRulesByEmployeeSalaryPackageRulesID(int  employeeSalaryPackageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryRulesByEmployeeSalaryPackageRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeSalaryPackageRulesID", SqlDbType.Int).Value = employeeSalaryPackageRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeSalaryRulesFromReader(reader);
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
            SqlCommand cmd = new SqlCommand("CheckEmployeeIDHR_EmployeeSalaryRules", connection);
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

    public int InsertHR_EmployeeSalaryRules(HR_EmployeeSalaryRules hR_EmployeeSalaryRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployeeSalaryRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeSalaryPackageRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EmployeeSalaryRules.EmployeeID;
            cmd.Parameters.Add("@PackageRulesID", SqlDbType.Int).Value = hR_EmployeeSalaryRules.PackageRulesID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EmployeeSalaryRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EmployeeSalaryRules.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_EmployeeSalaryRules.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = hR_EmployeeSalaryRules.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployeeSalaryPackageRulesID"].Value;
        }
    }

    public bool UpdateHR_EmployeeSalaryRules(HR_EmployeeSalaryRules hR_EmployeeSalaryRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeSalaryRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeSalaryPackageRulesID", SqlDbType.Int).Value = hR_EmployeeSalaryRules.EmployeeSalaryPackageRulesID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EmployeeSalaryRules.EmployeeID;
            cmd.Parameters.Add("@PackageRulesID", SqlDbType.Int).Value = hR_EmployeeSalaryRules.PackageRulesID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_EmployeeSalaryRules.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = hR_EmployeeSalaryRules.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EmployeeSalaryRules(int employeeSalaryPackageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeSalaryRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeSalaryPackageRulesID", SqlDbType.Int).Value = employeeSalaryPackageRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteHR_EmployeeSalaryRulesByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeSalaryRulesByEmployeeID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result > 0);
        }
    }
}

