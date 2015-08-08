using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_RetirementsRuleEmployeeProvider:DataAccessObject
{
	public SqlHR_RetirementsRuleEmployeeProvider()
    {
    }


    public DataSet  GetAllHR_RetirementsRuleEmployees()
    {
        DataSet HR_RetirementsRuleEmployees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_RetirementsRuleEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_RetirementsRuleEmployees);
            myadapter.Dispose();
            connection.Close();

            return HR_RetirementsRuleEmployees;
        }
    }
	public DataSet GetHR_RetirementsRuleEmployeePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_RetirementsRuleEmployeePageWise", connection))
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


    public HR_RetirementsRuleEmployee  GetHR_RetirementsRuleEmployeeByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_RetirementsRuleEmployeeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_RetirementsRuleEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_RetirementsRuleEmployee()
    {
        DataSet HR_RetirementsRuleEmployees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_RetirementsRuleEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_RetirementsRuleEmployees);
            myadapter.Dispose();
            connection.Close();

            return HR_RetirementsRuleEmployees;
        }
    }

    public DataSet   GetAllHR_RetirementsRuleEmployeesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_RetirementsRuleEmployeesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_RetirementsRuleEmployee> GetHR_RetirementsRuleEmployeesFromReader(IDataReader reader)
    {
        List<HR_RetirementsRuleEmployee> hR_RetirementsRuleEmployees = new List<HR_RetirementsRuleEmployee>();

        while (reader.Read())
        {
            hR_RetirementsRuleEmployees.Add(GetHR_RetirementsRuleEmployeeFromReader(reader));
        }
        return hR_RetirementsRuleEmployees;
    }

    public HR_RetirementsRuleEmployee GetHR_RetirementsRuleEmployeeFromReader(IDataReader reader)
    {
        try
        {
            HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee = new HR_RetirementsRuleEmployee
                (

                     DataAccessObject.IsNULL<int>(reader["RetirementRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["RetirementRulesName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_RetirementsRuleEmployee;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_RetirementsRuleEmployee  GetHR_RetirementsRuleEmployeeByRetirementRulesID(int  retirementRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_RetirementsRuleEmployeeByRetirementRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RetirementRulesID", SqlDbType.Int).Value = retirementRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_RetirementsRuleEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_RetirementsRuleEmployee(HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_RetirementsRuleEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RetirementRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.EmployeeID;
            cmd.Parameters.Add("@RetirementRulesName", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.RetirementRulesName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_RetirementsRuleEmployee.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_RetirementsRuleEmployee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RetirementRulesID"].Value;
        }
    }

    public bool UpdateHR_RetirementsRuleEmployee(HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_RetirementsRuleEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RetirementRulesID", SqlDbType.Int).Value = hR_RetirementsRuleEmployee.RetirementRulesID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.EmployeeID;
            cmd.Parameters.Add("@RetirementRulesName", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.RetirementRulesName;
            cmd.Parameters.Add("@RetirementRulesName", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.RetirementRulesName;
            cmd.Parameters.Add("@RetirementRulesName", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.RetirementRulesName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_RetirementsRuleEmployee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_RetirementsRuleEmployee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_RetirementsRuleEmployee(int retirementRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_RetirementsRuleEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RetirementRulesID", SqlDbType.Int).Value = retirementRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

