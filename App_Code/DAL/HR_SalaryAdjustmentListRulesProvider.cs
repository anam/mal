using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class HR_SalaryAdjustmentListRulesProvider : DataAccessObject
{
    public HR_SalaryAdjustmentListRulesProvider()
    {
    }

    public DataSet GetAllSalaryAdjustmentListRuless()
    {
        DataSet SalaryAdjustmentListRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSalaryAdjustmentListRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(SalaryAdjustmentListRuless);
            myadapter.Dispose();
            connection.Close();

            return SalaryAdjustmentListRuless;
        }
    }
    public DataSet GetSalaryAdjustmentListRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSalaryAdjustmentListRulesPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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


    public DataSet GetSalaryAdjustmentListRulesByEmployeeID(string employeeID)
    {
        DataSet SalaryAdjustmentListRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentListRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();

            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(SalaryAdjustmentListRuless);
            myadapter.Dispose();
            connection.Close();

            return SalaryAdjustmentListRuless;
        }
    }

    public HR_SalaryAdjustmentListRules GetSalaryAdjustmentListRulesBySalaryAdjustmentGruoupID(int salaryAdjustmentGruoupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentListRulesBySalaryAdjustmentGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.NVarChar).Value = salaryAdjustmentGruoupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSalaryAdjustmentListRulesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownLisAllSalaryAdjustmentListRules()
    {
        DataSet SalaryAdjustmentListRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSalaryAdjustmentListRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(SalaryAdjustmentListRuless);
            myadapter.Dispose();
            connection.Close();

            return SalaryAdjustmentListRuless;
        }
    }

    public List<HR_SalaryAdjustmentListRules> GetSalaryAdjustmentListRulessFromReader(IDataReader reader)
    {
        List<HR_SalaryAdjustmentListRules> salaryAdjustmentListRuless = new List<HR_SalaryAdjustmentListRules>();

        while (reader.Read())
        {
            salaryAdjustmentListRuless.Add(GetSalaryAdjustmentListRulesFromReader(reader));
        }
        return salaryAdjustmentListRuless;
    }

    public HR_SalaryAdjustmentListRules GetSalaryAdjustmentListRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules
            (

            DataAccessObject.IsNULL<int>(reader["SalaryAdjustmentListRulesID"]),
            DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
            DataAccessObject.IsNULL<int>(reader["SalaryAdjustmentGroupID"]),
            DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
            DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
            DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
            DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
            );
            return salaryAdjustmentListRules;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryAdjustmentListRules GetSalaryAdjustmentListRulesBySalaryAdjustmentListRulesID(int salaryAdjustmentListRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentListRulesBySalaryAdjustmentListRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryAdjustmentListRulesID", SqlDbType.Int).Value = salaryAdjustmentListRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSalaryAdjustmentListRulesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSalaryAdjustmentListRules(HR_SalaryAdjustmentListRules salaryAdjustmentListRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryAdjustmentListRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentListRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = salaryAdjustmentListRules.EmployeeID;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Value = salaryAdjustmentListRules.SalaryAdjustmentGroupID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = salaryAdjustmentListRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = salaryAdjustmentListRules.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = salaryAdjustmentListRules.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = salaryAdjustmentListRules.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryAdjustmentListRulesID"].Value;
        }
    }

    public bool UpdateSalaryAdjustmentListRules(HR_SalaryAdjustmentListRules salaryAdjustmentListRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryAdjustmentListRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentListRulesID", SqlDbType.Int).Value = salaryAdjustmentListRules.SalaryAdjustmentListRulesID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = salaryAdjustmentListRules.EmployeeID;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Value = salaryAdjustmentListRules.SalaryAdjustmentGroupID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = salaryAdjustmentListRules.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = salaryAdjustmentListRules.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSalaryAdjustmentListRules(int salaryAdjustmentListRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryAdjustmentListRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentListRulesID", SqlDbType.Int).Value = salaryAdjustmentListRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}
