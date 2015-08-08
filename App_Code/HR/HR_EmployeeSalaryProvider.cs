using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EmployeeSalaryProvider:DataAccessObject
{
	public SqlHR_EmployeeSalaryProvider()
    {
    }


    public DataSet  GetAllHR_EmployeeSalaries()
    {
        DataSet HR_EmployeeSalaries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSalaries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeSalaries);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeSalaries;
        }
    }
	public DataSet GetHR_EmployeeSalaryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryPageWise", connection))
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


    public HR_EmployeeSalary  GetHR_EmployeeSalaryByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeSalaryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }


    public DataSet GetHR_EmployeeBounusAll(int percentage)
    {
        
        DataSet HR_EmployeeSalaries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeBonusAll", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BonusPercentage", SqlDbType.Int).Value = percentage;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeSalaries);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeSalaries;
        }

    }

    public DataSet  GetDropDownLisAllHR_EmployeeSalary()
    {
        DataSet HR_EmployeeSalaries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeeSalary", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeSalaries);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeSalaries;
        }
    }

    public DataSet   GetAllHR_EmployeeSalariesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeSalariesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_EmployeeSalary> GetHR_EmployeeSalariesFromReader(IDataReader reader)
    {
        List<HR_EmployeeSalary> hR_EmployeeSalaries = new List<HR_EmployeeSalary>();

        while (reader.Read())
        {
            hR_EmployeeSalaries.Add(GetHR_EmployeeSalaryFromReader(reader));
        }
        return hR_EmployeeSalaries;
    }

    public HR_EmployeeSalary GetHR_EmployeeSalaryFromReader(IDataReader reader)
    {
        try
        {
            HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary
                (

                     DataAccessObject.IsNULL<int>(reader["EmployeeSalaryID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<bool>(reader["IsGross"]),
                     DataAccessObject.IsNULL<decimal>(reader["BasicAmount"]),
                      DataAccessObject.IsNULL<decimal>(reader["GrossAmount"]),
                     DataAccessObject.IsNULL<bool>(reader["IsActive"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_EmployeeSalary;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EmployeeSalary  GetHR_EmployeeSalaryByEmployeeSalaryID(int  employeeSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryByEmployeeSalaryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeSalaryID", SqlDbType.Int).Value = employeeSalaryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeSalaryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_EmployeeSalary GetHR_EmployeeSalaryByEmployeeID(int employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSalaryByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeSalaryID", SqlDbType.Int).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeSalaryFromReader(reader);
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
            SqlCommand cmd = new SqlCommand("CheckEmployeeIDHR_EmployeeSalary", connection);
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

    public int InsertHR_EmployeeSalary(HR_EmployeeSalary hR_EmployeeSalary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployeeSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeSalaryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EmployeeSalary.EmployeeID;
            cmd.Parameters.Add("@IsGross", SqlDbType.Bit).Value = hR_EmployeeSalary.IsGross;
            cmd.Parameters.Add("@BasicAmount", SqlDbType.Decimal).Value = hR_EmployeeSalary.BasicAmount;
            cmd.Parameters.Add("@GrossAmount", SqlDbType.Decimal).Value = hR_EmployeeSalary.GrossAmount;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = hR_EmployeeSalary.IsActive;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EmployeeSalary.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EmployeeSalary.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeeSalary.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeeSalary.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployeeSalaryID"].Value;
        }
    }

    public bool UpdateHR_EmployeeSalary(HR_EmployeeSalary hR_EmployeeSalary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeSalaryID", SqlDbType.Int).Value = hR_EmployeeSalary.EmployeeSalaryID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EmployeeSalary.EmployeeID;
            cmd.Parameters.Add("@IsGross", SqlDbType.Bit).Value = hR_EmployeeSalary.IsGross;
            cmd.Parameters.Add("@BasicAmount", SqlDbType.Decimal).Value = hR_EmployeeSalary.BasicAmount;
            cmd.Parameters.Add("@GrossAmount", SqlDbType.Decimal).Value = hR_EmployeeSalary.GrossAmount;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = hR_EmployeeSalary.IsActive;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeeSalary.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeeSalary.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EmployeeSalary(int employeeSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeSalaryID", SqlDbType.Int).Value = employeeSalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

