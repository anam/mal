using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_TaxProvider:DataAccessObject
{
	public SqlHR_TaxProvider()
    {
    }


    public DataSet  GetAllHR_Taxs()
    {
        DataSet HR_Taxs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Taxs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Taxs);
            myadapter.Dispose();
            connection.Close();

            return HR_Taxs;
        }
    }
	public DataSet GetHR_TaxPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_TaxPageWise", connection))
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


    public HR_Tax  GetHR_TaxByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_TaxByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_TaxFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_Tax()
    {
        DataSet HR_Taxs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Taxs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Taxs);
            myadapter.Dispose();
            connection.Close();

            return HR_Taxs;
        }
    }

    public DataSet   GetAllHR_TaxsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_TaxsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_Tax> GetHR_TaxsFromReader(IDataReader reader)
    {
        List<HR_Tax> hR_Taxs = new List<HR_Tax>();

        while (reader.Read())
        {
            hR_Taxs.Add(GetHR_TaxFromReader(reader));
        }
        return hR_Taxs;
    }

    public HR_Tax GetHR_TaxFromReader(IDataReader reader)
    {
        try
        {
            HR_Tax hR_Tax = new HR_Tax
                (

                     DataAccessObject.IsNULL<int>(reader["TaxID"]),
                     DataAccessObject.IsNULL<string>(reader["TaxName"]),
                     DataAccessObject.IsNULL<decimal>(reader["Ratio"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString())
                );
             return hR_Tax;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Tax  GetHR_TaxByTaxID(int  taxID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_TaxByTaxID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TaxID", SqlDbType.Int).Value = taxID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_TaxFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Tax(HR_Tax hR_Tax)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Tax", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TaxName", SqlDbType.NVarChar).Value = hR_Tax.TaxName;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_Tax.Ratio;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Tax.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Tax.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Tax.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Tax.ModifiedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Tax.EmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TaxID"].Value;
        }
    }

    public bool UpdateHR_Tax(HR_Tax hR_Tax)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Tax", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = hR_Tax.TaxID;
            cmd.Parameters.Add("@TaxName", SqlDbType.NVarChar).Value = hR_Tax.TaxName;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_Tax.Ratio;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_Tax.Ratio;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_Tax.Ratio;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Tax.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Tax.ModifiedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Tax.EmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Tax(int taxID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Tax", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = taxID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

