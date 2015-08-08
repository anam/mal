using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_OverTimePackageRuleProvider:DataAccessObject
{
	public SqlHR_OverTimePackageRuleProvider()
    {
    }


    public DataSet  GetAllHR_OverTimePackageRules()
    {
        DataSet HR_OverTimePackageRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_OverTimePackageRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OverTimePackageRules);
            myadapter.Dispose();
            connection.Close();

            return HR_OverTimePackageRules;
        }
    }
	public DataSet GetHR_OverTimePackageRulePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_OverTimePackageRulePageWise", connection))
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


    public DataSet GetHR_OverTimePackageRuleByOverTimePackageID(int overTimePackageID)
    {
        DataSet HR_OverTimePackageRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OverTimePackageRuleByOverTimePackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OverTimePackageID", SqlDbType.NVarChar).Value = overTimePackageID;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OverTimePackageRules);
            myadapter.Dispose();
            connection.Close();

            return HR_OverTimePackageRules;
        }

       
    }

    public DataSet  GetDropDownLisAllHR_OverTimePackageRule()
    {
        DataSet HR_OverTimePackageRules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_OverTimePackageRule", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OverTimePackageRules);
            myadapter.Dispose();
            connection.Close();

            return HR_OverTimePackageRules;
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
    public List<HR_OverTimePackageRule> GetHR_OverTimePackageRulesFromReader(IDataReader reader)
    {
        List<HR_OverTimePackageRule> hR_OverTimePackageRules = new List<HR_OverTimePackageRule>();

        while (reader.Read())
        {
            hR_OverTimePackageRules.Add(GetHR_OverTimePackageRuleFromReader(reader));
        }
        return hR_OverTimePackageRules;
    }

    public HR_OverTimePackageRule GetHR_OverTimePackageRuleFromReader(IDataReader reader)
    {
        try
        {
            HR_OverTimePackageRule hR_OverTimePackageRule = new HR_OverTimePackageRule
                (

                     DataAccessObject.IsNULL<int>(reader["OverTimeRuleID"]),
                     DataAccessObject.IsNULL<int>(reader["OverTimePackageID"]),
                     DataAccessObject.IsNULL<string>(reader["OverTimeRuleName"]),
                     DataAccessObject.IsNULL<int>(reader["OverTimeRuleValue"]),
                     DataAccessObject.IsNULL<string>(reader["OverTimeRuleOperator"])
                );
             return hR_OverTimePackageRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_OverTimePackageRule  GetHR_OverTimePackageRuleByOverTimeRuleID(int  overTimeRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OverTimePackageRuleByOverTimeRuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OverTimeRuleID", SqlDbType.Int).Value = overTimeRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_OverTimePackageRuleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_OverTimePackageRule(HR_OverTimePackageRule hR_OverTimePackageRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_OverTimePackageRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeRuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = hR_OverTimePackageRule.OverTimePackageID;
            cmd.Parameters.Add("@OverTimeRuleName", SqlDbType.NVarChar).Value = hR_OverTimePackageRule.OverTimeRuleName;
            cmd.Parameters.Add("@OverTimeRuleValue", SqlDbType.Int).Value = hR_OverTimePackageRule.OverTimeRuleValue;
            cmd.Parameters.Add("@OverTimeRuleOperator", SqlDbType.NVarChar).Value = hR_OverTimePackageRule.OverTimeRuleOperator;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OverTimeRuleID"].Value;
        }
    }

    public bool UpdateHR_OverTimePackageRule(HR_OverTimePackageRule hR_OverTimePackageRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_OverTimePackageRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeRuleID", SqlDbType.Int).Value = hR_OverTimePackageRule.OverTimeRuleID;
            cmd.Parameters.Add("@OverTimePackageID", SqlDbType.Int).Value = hR_OverTimePackageRule.OverTimePackageID;
            cmd.Parameters.Add("@OverTimeRuleName", SqlDbType.NVarChar).Value = hR_OverTimePackageRule.OverTimeRuleName;
            cmd.Parameters.Add("@OverTimeRuleValue", SqlDbType.Int).Value = hR_OverTimePackageRule.OverTimeRuleValue;
            cmd.Parameters.Add("@OverTimeRuleOperator", SqlDbType.NVarChar).Value = hR_OverTimePackageRule.OverTimeRuleOperator;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_OverTimePackageRule(int overTimeRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_OverTimePackageRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeRuleID", SqlDbType.Int).Value = overTimeRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

