using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ProvidentfundAmountProvider : DataAccessObject
{
    public SqlHR_ProvidentfundAmountProvider()
    {
    }

    public DataSet GetAllHR_ProvidentfundAmounts()
    {
        DataSet HR_ProvidentfundAmounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ProvidentfundAmounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentfundAmounts);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentfundAmounts;
        }
    }

    public DataSet GetHR_ProvidentfundAmountPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ProvidentfundAmountPageWise", connection))
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

    public HR_ProvidentfundAmount GetHR_ProvidentfundAmountByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentfundAmountByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_ProvidentfundAmountFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownLisAllHR_ProvidentfundAmount()
    {
        DataSet HR_ProvidentfundAmounts = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ProvidentfundAmount", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentfundAmounts);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentfundAmounts;
        }
    }

    public DataSet GetAllHR_OverTimePackageRulesWithRelation()
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

    public List<HR_ProvidentfundAmount> GetHR_ProvidentfundAmountsFromReader(IDataReader reader)
    {
        List<HR_ProvidentfundAmount> hR_ProvidentfundAmounts = new List<HR_ProvidentfundAmount>();

        while (reader.Read())
        {
            hR_ProvidentfundAmounts.Add(GetHR_ProvidentfundAmountFromReader(reader));
        }
        return hR_ProvidentfundAmounts;
    }

    public HR_ProvidentfundAmount GetHR_ProvidentfundAmountFromReader(IDataReader reader)
    {
        try
        {
            HR_ProvidentfundAmount hR_ProvidentfundAmount = new HR_ProvidentfundAmount
                (

                     DataAccessObject.IsNULL<int>(reader["ProvidentfundAmountID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<decimal>(reader["EmployeeContributionAmount"]),
                     DataAccessObject.IsNULL<decimal>(reader["CompanyContributionAmount"]),
                     DataAccessObject.IsNULL<DateTime>(reader["PayrollDate"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            return hR_ProvidentfundAmount;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_ProvidentfundAmount GetHR_ProvidentfundAmountByProvidentfundAmountID(int providentfundAmountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentfundAmountByProvidentfundAmountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProvidentfundAmountID", SqlDbType.Int).Value = providentfundAmountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_ProvidentfundAmountFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertHR_ProvidentfundAmount(HR_ProvidentfundAmount hR_ProvidentfundAmount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ProvidentfundAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundAmountID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentfundAmount.EmployeeID;
            cmd.Parameters.Add("@EmployeeContributionAmount", SqlDbType.Decimal).Value = hR_ProvidentfundAmount.EmployeeContributionAmount;
            cmd.Parameters.Add("@CompanyContributionAmount", SqlDbType.Decimal).Value = hR_ProvidentfundAmount.CompanyContributionAmount;
            cmd.Parameters.Add("@PayrollDate", SqlDbType.DateTime).Value = hR_ProvidentfundAmount.PayrollDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundAmount.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentfundAmount.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundAmount.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentfundAmount.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProvidentfundAmountID"].Value;
        }
    }

    public bool UpdateHR_ProvidentfundAmount(HR_ProvidentfundAmount hR_ProvidentfundAmount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ProvidentfundAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundAmountID", SqlDbType.Int).Value = hR_ProvidentfundAmount.ProvidentfundAmountID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentfundAmount.EmployeeID;
            cmd.Parameters.Add("@EmployeeContributionAmount", SqlDbType.Decimal).Value = hR_ProvidentfundAmount.EmployeeContributionAmount;
            cmd.Parameters.Add("@CompanyContributionAmount", SqlDbType.Decimal).Value = hR_ProvidentfundAmount.CompanyContributionAmount;
            cmd.Parameters.Add("@PayrollDate", SqlDbType.DateTime).Value = hR_ProvidentfundAmount.PayrollDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentfundAmount.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentfundAmount.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ProvidentfundAmount(int providentfundAmountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ProvidentfundAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentfundAmountID", SqlDbType.Int).Value = providentfundAmountID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

