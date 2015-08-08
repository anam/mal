using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_PackageRulesProvider:DataAccessObject
{
	public SqlHR_PackageRulesProvider()
    {
    }


    public DataSet  GetAllHR_PackageRuless()
    {
        DataSet HR_PackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PackageRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_PackageRuless;
        }
    }
    public DataSet GetAllHR_PackageRulessByPackageID(int PackageID)
    {
        DataSet HR_PackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PackageRulessByPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PackageID", PackageID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_PackageRuless;
        }
    }
    
    //GetAllHR_PackageAndPackageRuless

    public DataSet GetAllHR_PackageAndPackageRuless()
    {
        DataSet HR_PackageAndPackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PackageAndPackageRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PackageAndPackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_PackageAndPackageRuless;
        }
    }

	public DataSet GetHR_PackageRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_PackageRulesPageWise", connection))
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


    public HR_PackageRules  GetHR_PackageRulesByPackageID(int  packageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PackageRulesByPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PackageID", SqlDbType.NVarChar).Value = packageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_PackageRules()
    {
        DataSet HR_PackageRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_PackageRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PackageRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_PackageRuless;
        }
    }
    public List<HR_PackageRules> GetHR_PackageRulessFromReader(IDataReader reader)
    {
        List<HR_PackageRules> hR_PackageRuless = new List<HR_PackageRules>();

        while (reader.Read())
        {
            hR_PackageRuless.Add(GetHR_PackageRulesFromReader(reader));
        }
        return hR_PackageRuless;
    }

    public HR_PackageRules GetHR_PackageRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_PackageRules hR_PackageRules = new HR_PackageRules
                (

                     DataAccessObject.IsNULL<int>(reader["PackageRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["PackageRulesName"]),
                     DataAccessObject.IsNULL<int>(reader["PackageID"]),
                     DataAccessObject.IsNULL<int>(reader["RulesValue"]),
                     DataAccessObject.IsNULL<string>(reader["RulesOperator"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
             return hR_PackageRules;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_PackageRules  GetHR_PackageRulesByPackageRulesID(int  packageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PackageRulesByPackageRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PackageRulesID", SqlDbType.Int).Value = packageRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PackageRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_PackageRules(HR_PackageRules hR_PackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_PackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PackageRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PackageRulesName", SqlDbType.NVarChar).Value = hR_PackageRules.PackageRulesName;
            cmd.Parameters.Add("@PackageID", SqlDbType.Int).Value = hR_PackageRules.PackageID;
            cmd.Parameters.Add("@RulesValue", SqlDbType.Int).Value = hR_PackageRules.RulesValue;
            cmd.Parameters.Add("@RulesOperator", SqlDbType.NVarChar).Value = hR_PackageRules.RulesOperator;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_PackageRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_PackageRules.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_PackageRules.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = hR_PackageRules.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PackageRulesID"].Value;
        }
    }

    public bool UpdateHR_PackageRules(HR_PackageRules hR_PackageRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_PackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PackageRulesID", SqlDbType.Int).Value = hR_PackageRules.PackageRulesID;
            cmd.Parameters.Add("@PackageRulesName", SqlDbType.NVarChar).Value = hR_PackageRules.PackageRulesName;
            cmd.Parameters.Add("@PackageID", SqlDbType.Int).Value = hR_PackageRules.PackageID;
            cmd.Parameters.Add("@RulesValue", SqlDbType.Int).Value = hR_PackageRules.RulesValue;
            cmd.Parameters.Add("@RulesOperator", SqlDbType.NVarChar).Value = hR_PackageRules.RulesOperator;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_PackageRules.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = hR_PackageRules.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_PackageRules(int packageRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_PackageRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PackageRulesID", SqlDbType.Int).Value = packageRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

