using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_LeaveRuleProvider:DataAccessObject
{
	public SqlHR_LeaveRuleProvider()
    {
    }


    public DataSet  GetAllHR_LeaveRules()
    {
        DataSet HR_LeaveRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeaveRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LeaveRules);
            myadapter.Dispose();
            connection.Close();

            return HR_LeaveRules;
        }
    }
	public DataSet GetHR_LeaveRulePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_LeaveRulePageWise", connection))
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


    public DataSet  GetDropDownListAllHR_LeaveRule()
    {
        DataSet HR_LeaveRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_LeaveRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_LeaveRules);
            myadapter.Dispose();
            connection.Close();

            return HR_LeaveRules;
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
    public List<HR_LeaveRule> GetHR_LeaveRulesFromReader(IDataReader reader)
    {
        List<HR_LeaveRule> hR_LeaveRules = new List<HR_LeaveRule>();

        while (reader.Read())
        {
            hR_LeaveRules.Add(GetHR_LeaveRuleFromReader(reader));
        }
        return hR_LeaveRules;
    }

    public HR_LeaveRule GetHR_LeaveRuleFromReader(IDataReader reader)
    {
        try
        {
            HR_LeaveRule hR_LeaveRule = new HR_LeaveRule
                (

                     DataAccessObject.IsNULL<int>(reader["LeaveRuleID"]),
                     DataAccessObject.IsNULL<string>(reader["LeaveRuleName"]),
                     DataAccessObject.IsNULL<int>(reader["Day"]),
                     DataAccessObject.IsNULL<string>(reader["Status"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_LeaveRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_LeaveRule  GetHR_LeaveRuleByLeaveRuleID(int  leaveRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_LeaveRuleByLeaveRuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = leaveRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_LeaveRuleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_LeaveRule(HR_LeaveRule hR_LeaveRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_LeaveRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LeaveRuleName", SqlDbType.NVarChar).Value = hR_LeaveRule.LeaveRuleName;
            cmd.Parameters.Add("@Day", SqlDbType.Int).Value = hR_LeaveRule.Day;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = hR_LeaveRule.Status;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_LeaveRule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_LeaveRule.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LeaveRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LeaveRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeaveRuleID"].Value;
        }
    }

    public bool UpdateHR_LeaveRule(HR_LeaveRule hR_LeaveRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_LeaveRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = hR_LeaveRule.LeaveRuleID;
            cmd.Parameters.Add("@LeaveRuleName", SqlDbType.NVarChar).Value = hR_LeaveRule.LeaveRuleName;
            cmd.Parameters.Add("@Day", SqlDbType.Int).Value = hR_LeaveRule.Day;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = hR_LeaveRule.Status;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = hR_LeaveRule.Status;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = hR_LeaveRule.Status;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_LeaveRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_LeaveRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_LeaveRule(int leaveRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_LeaveRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeaveRuleID", SqlDbType.Int).Value = leaveRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

