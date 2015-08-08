using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryIncrementProvider:DataAccessObject
{
	public SqlHR_SalaryIncrementProvider()
    {
    }


    public DataSet  GetAllHR_SalaryIncrements()
    {
        DataSet HR_SalaryIncrements = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryIncrements", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryIncrements);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryIncrements;
        }
    }
	public DataSet GetHR_SalaryIncrementPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryIncrementPageWise", connection))
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


    public HR_SalaryIncrement  GetHR_SalaryIncrementByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryIncrementByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryIncrementFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_SalaryIncrement()
    {
        DataSet HR_SalaryIncrements = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryIncrements", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryIncrements);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryIncrements;
        }
    }

    public DataSet   GetAllHR_SalaryIncrementsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryIncrementsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_SalaryIncrement> GetHR_SalaryIncrementsFromReader(IDataReader reader)
    {
        List<HR_SalaryIncrement> hR_SalaryIncrements = new List<HR_SalaryIncrement>();

        while (reader.Read())
        {
            hR_SalaryIncrements.Add(GetHR_SalaryIncrementFromReader(reader));
        }
        return hR_SalaryIncrements;
    }

    public HR_SalaryIncrement GetHR_SalaryIncrementFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryIncrement hR_SalaryIncrement = new HR_SalaryIncrement
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryIncrementID"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryIncrementName"]),
                     DataAccessObject.IsNULL<int>(reader["PerYearNoTimes"]),
                     DataAccessObject.IsNULL<decimal>(reader["Ratio"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString())
                );
             return hR_SalaryIncrement;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryIncrement  GetHR_SalaryIncrementBySalaryIncrementID(int  salaryIncrementID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryIncrementBySalaryIncrementID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryIncrementID", SqlDbType.Int).Value = salaryIncrementID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryIncrementFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_SalaryIncrement(HR_SalaryIncrement hR_SalaryIncrement)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryIncrement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryIncrementName", SqlDbType.NVarChar).Value = hR_SalaryIncrement.SalaryIncrementName;
            cmd.Parameters.Add("@PerYearNoTimes", SqlDbType.Int).Value = hR_SalaryIncrement.PerYearNoTimes;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryIncrement.Ratio;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrement.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryIncrement.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrement.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryIncrement.ModifiedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryIncrement.EmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryIncrementID"].Value;
        }
    }

    public bool UpdateHR_SalaryIncrement(HR_SalaryIncrement hR_SalaryIncrement)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryIncrement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementID", SqlDbType.Int).Value = hR_SalaryIncrement.SalaryIncrementID;
            cmd.Parameters.Add("@SalaryIncrementName", SqlDbType.NVarChar).Value = hR_SalaryIncrement.SalaryIncrementName;
            cmd.Parameters.Add("@PerYearNoTimes", SqlDbType.Int).Value = hR_SalaryIncrement.PerYearNoTimes;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryIncrement.Ratio;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryIncrement.Ratio;
            cmd.Parameters.Add("@Ratio", SqlDbType.Decimal).Value = hR_SalaryIncrement.Ratio;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryIncrement.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryIncrement.ModifiedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryIncrement.EmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryIncrement(int salaryIncrementID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryIncrement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryIncrementID", SqlDbType.Int).Value = salaryIncrementID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

