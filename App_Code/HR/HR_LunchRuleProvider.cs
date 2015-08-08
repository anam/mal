using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_LunchRuleProvider : DataAccessObject
{
    public SqlHR_LunchRuleProvider()
    {
    }


    public DataSet GetAllHR_LunchRules()
    {
        DataSet HR_LunchRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LunchRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LunchRules);
            myadapter.Dispose();
            connection.Close();

            return HR_LunchRules;
        }
    }
    public DataSet GetHR_LunchRulePageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_LunchRulePageWise", connection))
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

    public HR_LunchRule GetHR_LunchRuleByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LunchRuleByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", employeeID);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_LunchRuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownLisAllHR_LunchRule()
    {
        DataSet HR_LunchRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_LunchRule", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LunchRules);
            myadapter.Dispose();
            connection.Close();

            return HR_LunchRules;
        }
    }

    public DataSet GetAllHR_LunchRulesWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LunchRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_LunchRule> GetHR_LunchRulesFromReader(IDataReader reader)
    {
        List<HR_LunchRule> hR_LunchRules = new List<HR_LunchRule>();

        while (reader.Read())
        {
            hR_LunchRules.Add(GetHR_LunchRuleFromReader(reader));
        }
        return hR_LunchRules;
    }

    public HR_LunchRule GetHR_LunchRuleFromReader(IDataReader reader)
    {
        try
        {
            HR_LunchRule hR_LunchRule = new HR_LunchRule
                (

                     DataAccessObject.IsNULL<int>(reader["LunchRuleID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["LunchTimeStart"]),
                     DataAccessObject.IsNULL<DateTime>(reader["LunchTimeEnd"]),
                     DataAccessObject.IsNULL<int>(reader["LunchFlexibleTimeMins"]),
                     DataAccessObject.IsNULL<int>(reader["LunchTimeAllowed"]),
                     DataAccessObject.IsNULL<bool>(reader["LunchFlag"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            return hR_LunchRule;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_LunchRule GetHR_LunchRuleByLunchRuleID(int lunchRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LunchRuleByLunchRuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LunchRuleID", SqlDbType.Int).Value = lunchRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_LunchRuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertHR_LunchRule(HR_LunchRule hR_LunchRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_LunchRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LunchRuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_LunchRule.EmployeeID;
            cmd.Parameters.Add("@LunchTimeStart", SqlDbType.DateTime).Value = hR_LunchRule.LunchTimeStart;
            cmd.Parameters.Add("@LunchTimeEnd", SqlDbType.DateTime).Value = hR_LunchRule.LunchTimeEnd;
            cmd.Parameters.Add("@LunchFlexibleTimeMins", SqlDbType.Int).Value = hR_LunchRule.LunchFlexibleTimeMins;
            cmd.Parameters.Add("@LunchTimeAllowed", SqlDbType.Int).Value = hR_LunchRule.LunchTimeAllowed;
            cmd.Parameters.Add("@LunchFlag", SqlDbType.Bit).Value = hR_LunchRule.LunchFlag;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_LunchRule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_LunchRule.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LunchRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = /*(object)DBNull.Value;*/hR_LunchRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LunchRuleID"].Value;
        }
    }

    public bool UpdateHR_LunchRule(HR_LunchRule hR_LunchRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_LunchRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LunchRuleID", SqlDbType.Int).Value = hR_LunchRule.LunchRuleID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_LunchRule.EmployeeID;
            cmd.Parameters.Add("@LunchTimeStart", SqlDbType.DateTime).Value = hR_LunchRule.LunchTimeStart;
            cmd.Parameters.Add("@LunchTimeEnd", SqlDbType.DateTime).Value = hR_LunchRule.LunchTimeEnd;
            cmd.Parameters.Add("@LunchFlexibleTimeMins", SqlDbType.Int).Value = hR_LunchRule.LunchFlexibleTimeMins;
            cmd.Parameters.Add("@LunchTimeAllowed", SqlDbType.Int).Value = hR_LunchRule.LunchTimeAllowed;
            cmd.Parameters.Add("@LunchFlag", SqlDbType.Bit).Value = hR_LunchRule.LunchFlag;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LunchRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LunchRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_LunchRule(int lunchRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_LunchRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LunchRuleID", SqlDbType.Int).Value = lunchRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

