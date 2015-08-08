using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Summary description for ACC_EmployPayRoleSalaryProvider
/// </summary>
public class ACC_EmployPayRoleSalaryProvider : DataAccessObject
{
	public ACC_EmployPayRoleSalaryProvider()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool DeleteEmployPayRoleSalary(int employPayRoleSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_EmployPayRoleSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = employPayRoleSalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalaries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_EmployPayRoleSalaries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployPayRoleSalariesFromReader(reader);
        }
    }

    public List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalariesHistory()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_EmployPayRoleSalariesHistory", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployPayRoleSalariesFromReader(reader);
        }
    }

    public List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalaries(string SalaryOfDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_EmployPayRoleSalariesBySalaryOfDate", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = SalaryOfDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployPayRoleSalariesFromReader(reader);
        }
    }

    public List<ACC_EmployPayRoleSalary> GetEmployPayRoleSalariesFromReader(IDataReader reader)
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();

        while (reader.Read())
        {
            employPayRoleSalaries.Add(GetEmployPayRoleSalaryFromReader(reader));
        }
        return employPayRoleSalaries;
    }

    public ACC_EmployPayRoleSalary GetEmployPayRoleSalaryFromReader(IDataReader reader)
    {
        try
        {
            ACC_EmployPayRoleSalary employPayRoleSalary = new ACC_EmployPayRoleSalary();

            try { employPayRoleSalary.EmployPayRoleSalaryID = (int)reader["EmployPayRoleSalaryID"]; }
            catch (Exception ex) { }
            try { employPayRoleSalary.AddedBy = reader["AddedBy"].ToString(); }
            catch (Exception ex) { }
            try { employPayRoleSalary.AddedDate = (DateTime)reader["AddedDate"]; }
            catch (Exception ex) { }
            try { employPayRoleSalary.UpdatedBy = reader["UpdatedBy"].ToString(); }
            catch (Exception ex) { }
            try { employPayRoleSalary.UpdatedDate = (DateTime)reader["UpdatedDate"]; }
            catch (Exception ex) { }
            try { employPayRoleSalary.EmployeeID = reader["EmployeeID"].ToString(); }
            catch (Exception ex) { }
            try { employPayRoleSalary.SalaryAmount = (decimal)reader["SalaryAmount"]; }
            catch (Exception ex) { }
            try { employPayRoleSalary.PaidSalaryAmount = (decimal)reader["PaidSalaryAmount"]; }
            catch (Exception ex) { }
            try { employPayRoleSalary.UnpaidSalaryAmount = (decimal)reader["UnpaidSalaryAmount"]; }
            catch (Exception ex) { }
            try { employPayRoleSalary.Status = (int)reader["Status"]; }
            catch (Exception ex) { }

            try { employPayRoleSalary.SalaryOfDate = reader["SalaryOfDate"].ToString(); }
            catch (Exception ex) { }
            try
            {
                employPayRoleSalary.RowStatusID = (int)reader["RowStatusID"];
            }
            catch (Exception ex) { }
            try
            {
                employPayRoleSalary.ExtraField1 = reader["ExtraField1"].ToString();
                employPayRoleSalary.ExtraField2 = reader["ExtraField2"].ToString();
                employPayRoleSalary.ExtraField3 = reader["ExtraField3"].ToString();
                employPayRoleSalary.ExtraField4 = reader["ExtraField4"].ToString();
                employPayRoleSalary.ExtraField5 = reader["ExtraField5"].ToString();
                employPayRoleSalary.ExtraField6 = reader["ExtraField6"].ToString();
                employPayRoleSalary.ExtraField7 = reader["ExtraField7"].ToString();
                employPayRoleSalary.ExtraField8 = reader["ExtraField8"].ToString();
                employPayRoleSalary.ExtraField9 = reader["ExtraField9"].ToString();
                employPayRoleSalary.ExtraField10 = reader["ExtraField10"].ToString();
            }
            catch (Exception ex)
            {
                
            }
            return employPayRoleSalary;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ACC_EmployPayRoleSalary GetEmployPayRoleSalaryByID(int employPayRoleSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_EmployPayRoleSalaryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = employPayRoleSalaryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetEmployPayRoleSalaryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public ACC_EmployPayRoleSalary GetEmployPayRoleSalaryByEmployeeIDnSalaryOfDate(string SalaryOfDate, string EmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_EmployPayRoleSalaryBySalaryDateByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = SalaryOfDate;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetEmployPayRoleSalaryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertEmployPayRoleSalary(ACC_EmployPayRoleSalary employPayRoleSalary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_EmployPayRoleSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = employPayRoleSalary.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = employPayRoleSalary.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = employPayRoleSalary.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = employPayRoleSalary.UpdatedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employPayRoleSalary.EmployeeID;
            cmd.Parameters.Add("@SalaryAmount", SqlDbType.Money).Value = employPayRoleSalary.SalaryAmount;
            cmd.Parameters.Add("@PaidSalaryAmount", SqlDbType.Money).Value = employPayRoleSalary.PaidSalaryAmount;
            cmd.Parameters.Add("@UnpaidSalaryAmount", SqlDbType.Money).Value = employPayRoleSalary.UnpaidSalaryAmount;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = employPayRoleSalary.Status;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = employPayRoleSalary.RowStatusID;
            cmd.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = employPayRoleSalary.SalaryOfDate;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField5;
            cmd.Parameters.Add("@ExtraField6", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField6;
            cmd.Parameters.Add("@ExtraField7", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField7;
            cmd.Parameters.Add("@ExtraField8", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField8;
            cmd.Parameters.Add("@ExtraField9", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField9;
            cmd.Parameters.Add("@ExtraField10", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField10;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployPayRoleSalaryID"].Value;
        }
    }

    public bool UpdateEmployPayRoleSalary(ACC_EmployPayRoleSalary employPayRoleSalary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UpdateACC_EmployPayRoleSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = employPayRoleSalary.EmployPayRoleSalaryID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = employPayRoleSalary.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = employPayRoleSalary.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = employPayRoleSalary.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = employPayRoleSalary.UpdatedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employPayRoleSalary.EmployeeID;
            cmd.Parameters.Add("@SalaryAmount", SqlDbType.Money).Value = employPayRoleSalary.SalaryAmount;
            cmd.Parameters.Add("@PaidSalaryAmount", SqlDbType.Money).Value = employPayRoleSalary.PaidSalaryAmount;
            cmd.Parameters.Add("@UnpaidSalaryAmount", SqlDbType.Money).Value = employPayRoleSalary.UnpaidSalaryAmount;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = employPayRoleSalary.Status;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = employPayRoleSalary.RowStatusID;
            cmd.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = employPayRoleSalary.SalaryOfDate;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField1 == null ? "" : employPayRoleSalary.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField2 == null ? "" : employPayRoleSalary.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField3 == null ? "" : employPayRoleSalary.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField4 == null ? "" : employPayRoleSalary.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField5 == null ? "" : employPayRoleSalary.ExtraField5;
            cmd.Parameters.Add("@ExtraField6", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField6 == null ? "" : employPayRoleSalary.ExtraField6;
            cmd.Parameters.Add("@ExtraField7", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField7 == null ? "" : employPayRoleSalary.ExtraField7;
            cmd.Parameters.Add("@ExtraField8", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField8 == null ? "" : employPayRoleSalary.ExtraField8;
            cmd.Parameters.Add("@ExtraField9", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField9 == null ? "" : employPayRoleSalary.ExtraField9;
            cmd.Parameters.Add("@ExtraField10", SqlDbType.NVarChar).Value = employPayRoleSalary.ExtraField10 == null ? "" : employPayRoleSalary.ExtraField10;
            
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalariesByID(int employPayRoleSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_EmployPayRoleSalaryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployPayRoleSalaryID", SqlDbType.Int).Value = employPayRoleSalaryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployPayRoleSalariesFromReader(reader);
        }
    }

    public List<ACC_EmployPayRoleSalary> GetAllEmployeeByID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_EmployeeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", employeeID);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployPayRoleSalariesFromReader(reader);
        }
    }

    public List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalariesByNameAndStatus(string employeeName, int status)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_EmployPayRoleSalaryNameAndStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = employeeName;
            command.Parameters.Add("@Status", SqlDbType.Int).Value = status;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEmployPayRoleSalariesFromReader(reader);
        }
    }
    
    public DataSet GetACC_EmployPayRoleSalaryBySalaryDate(string salaryOfDate)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_EmployPayRoleSalaryBySalaryDate", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryOfDate", SqlDbType.NVarChar).Value = salaryOfDate;           
            connection.Open();

            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(command);
            oSqlDataAdapter.Fill(dataSet);
            oSqlDataAdapter.Dispose();
            connection.Close();
            return dataSet;
        }
    }

    public DataSet GetACC_AllSalaryDate()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_AllSalaryDate", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(command);
            oSqlDataAdapter.Fill(dataSet);
            oSqlDataAdapter.Dispose();
            connection.Close();
            return dataSet;
        }
    }
}