using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_LunchTimeRuleProvider:DataAccessObject
{
	public SqlHR_LunchTimeRuleProvider()
    {
    }


    public DataSet  GetAllHR_LunchTimeRules()
    {
        DataSet HR_LunchTimeRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LunchTimeRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LunchTimeRules);
            myadapter.Dispose();
            connection.Close();

            return HR_LunchTimeRules;
        }
    }
	public DataSet GetHR_LunchTimeRulePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_LunchTimeRulePageWise", connection))
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


    public DataSet  GetDropDownListAllHR_LunchTimeRule()
    {
        DataSet HR_LunchTimeRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_LunchTimeRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LunchTimeRules);
            myadapter.Dispose();
            connection.Close();

            return HR_LunchTimeRules;
        }
    }

    public DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeaveRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_LunchTimeRule> GetHR_LunchTimeRulesFromReader(IDataReader reader)
    {
        List<HR_LunchTimeRule> hR_LunchTimeRules = new List<HR_LunchTimeRule>();

        while (reader.Read())
        {
            hR_LunchTimeRules.Add(GetHR_LunchTimeRuleFromReader(reader));
        }
        return hR_LunchTimeRules;
    }

    public HR_LunchTimeRule GetHR_LunchTimeRuleFromReader(IDataReader reader)
    {
        try
        {
            HR_LunchTimeRule hR_LunchTimeRule = new HR_LunchTimeRule
                (

                     DataAccessObject.IsNULL<int>(reader["LunchTimeRuleID"]),
                     DataAccessObject.IsNULL<string>(reader["LunchTimeRuleName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_LunchTimeRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_LunchTimeRule  GetHR_LunchTimeRuleByLunchTimeRuleID(int  lunchTimeRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LunchTimeRuleByLunchTimeRuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LunchTimeRuleID", SqlDbType.Int).Value = lunchTimeRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_LunchTimeRuleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_LunchTimeRule(HR_LunchTimeRule hR_LunchTimeRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_LunchTimeRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LunchTimeRuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LunchTimeRuleName", SqlDbType.NVarChar).Value = hR_LunchTimeRule.LunchTimeRuleName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_LunchTimeRule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_LunchTimeRule.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LunchTimeRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LunchTimeRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LunchTimeRuleID"].Value;
        }
    }

    public bool UpdateHR_LunchTimeRule(HR_LunchTimeRule hR_LunchTimeRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_LunchTimeRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LunchTimeRuleID", SqlDbType.Int).Value = hR_LunchTimeRule.LunchTimeRuleID;
            cmd.Parameters.Add("@LunchTimeRuleName", SqlDbType.NVarChar).Value = hR_LunchTimeRule.LunchTimeRuleName;
            cmd.Parameters.Add("@LunchTimeRuleName", SqlDbType.NVarChar).Value = hR_LunchTimeRule.LunchTimeRuleName;
            cmd.Parameters.Add("@LunchTimeRuleName", SqlDbType.NVarChar).Value = hR_LunchTimeRule.LunchTimeRuleName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LunchTimeRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LunchTimeRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_LunchTimeRule(int lunchTimeRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_LunchTimeRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LunchTimeRuleID", SqlDbType.Int).Value = lunchTimeRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

