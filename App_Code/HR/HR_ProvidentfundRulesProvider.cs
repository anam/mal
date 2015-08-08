using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ProvidentfundRulesProvider:DataAccessObject
{
	public SqlHR_ProvidentfundRulesProvider()
    {
    }


    public DataSet  GetAllHR_ProvidentfundRuless()
    {
        DataSet HR_ProvidentfundRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ProvidentfundRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentfundRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentfundRuless;
        }
    }
	public DataSet GetHR_ProvidentfundRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ProvidentfundRulesPageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_ProvidentfundRules()
    {
        DataSet HR_ProvidentfundRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ProvidentfundRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentfundRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentfundRuless;
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
    public List<HR_ProvidentfundRules> GetHR_ProvidentfundRulessFromReader(IDataReader reader)
    {
        List<HR_ProvidentfundRules> hR_ProvidentfundRuless = new List<HR_ProvidentfundRules>();

        while (reader.Read())
        {
            hR_ProvidentfundRuless.Add(GetHR_ProvidentfundRulesFromReader(reader));
        }
        return hR_ProvidentfundRuless;
    }

    public HR_ProvidentfundRules GetHR_ProvidentfundRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_ProvidentfundRules hR_ProvidentfundRules = new HR_ProvidentfundRules
                (

                     DataAccessObject.IsNULL<int>(reader["ProvidentfundRulesID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Value"]),
                     DataAccessObject.IsNULL<bool>(reader["IsGrossPortion"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            return hR_ProvidentfundRules;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_ProvidentfundRules  GetHR_ProvidentfundRulesByProvidentfundRulesID(int  providentfundRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentfundRulesByProvidentfundRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProvidentfundRulesID", SqlDbType.Int).Value = providentfundRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ProvidentfundRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }
  
    public int InsertHR_ProvidentfundRules(HR_ProvidentfundRules hR_ProvidentfundRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ProvidentfundRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = hR_ProvidentfundRules.Value;
            cmd.Parameters.Add("@IsGrossPortion", SqlDbType.Bit).Value = hR_ProvidentfundRules.IsGrossPortion;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentfundRules.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentfundRules.ModifiedDate;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProvidentfundRulesID"].Value;
        }
    }

    public bool UpdateHR_ProvidentfundRules(HR_ProvidentfundRules hR_ProvidentfundRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ProvidentfundRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundRulesID", SqlDbType.Int).Value = hR_ProvidentfundRules.ProvidentfundRulesID;
            cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = hR_ProvidentfundRules.Value;
            cmd.Parameters.Add("@IsGrossPortion", SqlDbType.Bit).Value = hR_ProvidentfundRules.IsGrossPortion;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentfundRules.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentfundRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ProvidentfundRules(int providentfundRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ProvidentfundRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundRulesID", SqlDbType.Int).Value = providentfundRulesID;
            connection.Open();
            int result = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            
            return (result == 1);
        }
    }
}

