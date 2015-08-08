using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ProvidentfundContributionProvider:DataAccessObject
{
	public SqlHR_ProvidentfundContributionProvider()
    {
    }


    public DataSet  GetAllHR_ProvidentfundContributions()
    {
        DataSet HR_ProvidentfundContributions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ProvidentfundContributions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentfundContributions);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentfundContributions;
        }
    }
	public DataSet GetHR_ProvidentfundContributionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ProvidentfundContributionPageWise", connection))
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


    public HR_ProvidentfundContribution  GetHR_ProvidentfundContributionByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentfundContributionByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ProvidentfundContributionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_ProvidentfundContribution()
    {
        DataSet HR_ProvidentfundContributions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ProvidentfundContribution", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentfundContributions);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentfundContributions;
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
    public List<HR_ProvidentfundContribution> GetHR_ProvidentfundContributionsFromReader(IDataReader reader)
    {
        List<HR_ProvidentfundContribution> hR_ProvidentfundContributions = new List<HR_ProvidentfundContribution>();

        while (reader.Read())
        {
            hR_ProvidentfundContributions.Add(GetHR_ProvidentfundContributionFromReader(reader));
        }
        return hR_ProvidentfundContributions;
    }

    public HR_ProvidentfundContribution GetHR_ProvidentfundContributionFromReader(IDataReader reader)
    {
        try
        {
            HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution
                (

                     DataAccessObject.IsNULL<int>(reader["ProvidentfundContributionID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ProvidentfundRulesID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Amount"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_ProvidentfundContribution;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_ProvidentfundContribution  GetHR_ProvidentfundContributionByProvidentfundContributionID(int  providentfundContributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentfundContributionByProvidentfundContributionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProvidentfundContributionID", SqlDbType.Int).Value = providentfundContributionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ProvidentfundContributionFromReader(reader);
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
            SqlCommand cmd = new SqlCommand("CheckEmployeeIDHR_ProvidentfundContribution", connection);
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

    public int InsertHR_ProvidentfundContribution(HR_ProvidentfundContribution hR_ProvidentfundContribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ProvidentfundContribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundContributionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentfundContribution.EmployeeID;
            cmd.Parameters.Add("@ProvidentfundRulesID", SqlDbType.Int).Value = hR_ProvidentfundContribution.ProvidentfundRulesID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = hR_ProvidentfundContribution.Amount;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundContribution.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentfundContribution.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundContribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentfundContribution.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProvidentfundContributionID"].Value;
        }
    }

    public bool UpdateHR_ProvidentfundContribution(HR_ProvidentfundContribution hR_ProvidentfundContribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ProvidentfundContribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundContributionID", SqlDbType.Int).Value = hR_ProvidentfundContribution.ProvidentfundContributionID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentfundContribution.EmployeeID;
            cmd.Parameters.Add("@ProvidentfundRulesID", SqlDbType.Int).Value = hR_ProvidentfundContribution.ProvidentfundRulesID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = hR_ProvidentfundContribution.Amount;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundContribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentfundContribution.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ProvidentfundContribution(int providentfundContributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ProvidentfundContribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundContributionID", SqlDbType.Int).Value = providentfundContributionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

