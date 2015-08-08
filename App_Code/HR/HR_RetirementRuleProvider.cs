using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_RetirementRuleProvider:DataAccessObject
{
	public SqlHR_RetirementRuleProvider()
    {
    }


    public DataSet  GetAllHR_RetirementRules()
    {
        DataSet HR_RetirementRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_RetirementRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_RetirementRules);
            myadapter.Dispose();
            connection.Close();

            return HR_RetirementRules;
        }
    }
	public DataSet GetHR_RetirementRulePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_RetirementRulePageWise", connection))
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


    public DataSet  GetDropDownListAllHR_RetirementRule()
    {
        DataSet HR_RetirementRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_RetirementRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_RetirementRules);
            myadapter.Dispose();
            connection.Close();

            return HR_RetirementRules;
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
    public List<HR_RetirementRule> GetHR_RetirementRulesFromReader(IDataReader reader)
    {
        List<HR_RetirementRule> hR_RetirementRules = new List<HR_RetirementRule>();

        while (reader.Read())
        {
            hR_RetirementRules.Add(GetHR_RetirementRuleFromReader(reader));
        }
        return hR_RetirementRules;
    }

    public HR_RetirementRule GetHR_RetirementRuleFromReader(IDataReader reader)
    {
        try
        {
            HR_RetirementRule hR_RetirementRule = new HR_RetirementRule
                (

                     DataAccessObject.IsNULL<int>(reader["RetirementRuleID"]),
                     DataAccessObject.IsNULL<string>(reader["RetirementRuleName"]),
                     DataAccessObject.IsNULL<int>(reader["YearOfApplicable"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_RetirementRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_RetirementRule  GetHR_RetirementRuleByRetirementRuleID(int  retirementRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_RetirementRuleByRetirementRuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RetirementRuleID", SqlDbType.Int).Value = retirementRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_RetirementRuleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_RetirementRule(HR_RetirementRule hR_RetirementRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_RetirementRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RetirementRuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RetirementRuleName", SqlDbType.NVarChar).Value = hR_RetirementRule.RetirementRuleName;
            cmd.Parameters.Add("@YearOfApplicable", SqlDbType.Int).Value = hR_RetirementRule.YearOfApplicable;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_RetirementRule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_RetirementRule.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_RetirementRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_RetirementRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RetirementRuleID"].Value;
        }
    }

    public bool UpdateHR_RetirementRule(HR_RetirementRule hR_RetirementRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_RetirementRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RetirementRuleID", SqlDbType.Int).Value = hR_RetirementRule.RetirementRuleID;
            cmd.Parameters.Add("@RetirementRuleName", SqlDbType.NVarChar).Value = hR_RetirementRule.RetirementRuleName;
            cmd.Parameters.Add("@YearOfApplicable", SqlDbType.Int).Value = hR_RetirementRule.YearOfApplicable;
            cmd.Parameters.Add("@YearOfApplicable", SqlDbType.Int).Value = hR_RetirementRule.YearOfApplicable;
            cmd.Parameters.Add("@YearOfApplicable", SqlDbType.Int).Value = hR_RetirementRule.YearOfApplicable;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_RetirementRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_RetirementRule.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_RetirementRule(int retirementRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_RetirementRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RetirementRuleID", SqlDbType.Int).Value = retirementRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

