using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ProvidentFundRegisterProvider:DataAccessObject
{
	public SqlHR_ProvidentFundRegisterProvider()
    {
    }


    public DataSet  GetAllHR_ProvidentFundRegisters()
    {
        DataSet HR_ProvidentFundRegisters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ProvidentFundRegisters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentFundRegisters);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentFundRegisters;
        }
    }
	public DataSet GetHR_ProvidentFundRegisterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ProvidentFundRegisterPageWise", connection))
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


    public HR_ProvidentFundRegister  GetHR_ProvidentFundRegisterByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentFundRegisterByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ProvidentFundRegisterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetHR_PFRegisterByEmpIDTotalFund(string employeeID)
    {
        DataSet TotalFund = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PFRegisterByEmpIDTotalFund", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(TotalFund);
            myadapter.Dispose();
            connection.Close();
            return TotalFund;
        }
    }

    public HR_ProvidentFundRegister  GetHR_ProvidentFundRegisterByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentFundRegisterByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ProvidentFundRegisterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_ProvidentFundRegister()
    {
        DataSet HR_ProvidentFundRegisters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ProvidentFundRegister", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentFundRegisters);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentFundRegisters;
        }
    }
    public List<HR_ProvidentFundRegister> GetHR_ProvidentFundRegistersFromReader(IDataReader reader)
    {
        List<HR_ProvidentFundRegister> hR_ProvidentFundRegisters = new List<HR_ProvidentFundRegister>();

        while (reader.Read())
        {
            hR_ProvidentFundRegisters.Add(GetHR_ProvidentFundRegisterFromReader(reader));
        }
        return hR_ProvidentFundRegisters;
    }

    public HR_ProvidentFundRegister GetHR_ProvidentFundRegisterFromReader(IDataReader reader)
    {
        try
        {
            HR_ProvidentFundRegister hR_ProvidentFundRegister = new HR_ProvidentFundRegister
                (

                     DataAccessObject.IsNULL<int>(reader["ProvidentFundRegisterID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["PayrollMonthDate"]),
                     DataAccessObject.IsNULL<decimal>(reader["EPF"]),
                     DataAccessObject.IsNULL<decimal>(reader["CPF"]),
                     DataAccessObject.IsNULL<decimal>(reader["TotalPFAmount"]),
                     DataAccessObject.IsNULL<decimal>(reader["WithdrawAmount"]),
                     DataAccessObject.IsNULL<DateTime>(reader["WithdrawLastDate"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return hR_ProvidentFundRegister;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_ProvidentFundRegister  GetHR_ProvidentFundRegisterByProvidentFundRegisterID(int  providentFundRegisterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentFundRegisterByProvidentFundRegisterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProvidentFundRegisterID", SqlDbType.Int).Value = providentFundRegisterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ProvidentFundRegisterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_ProvidentFundRegister(HR_ProvidentFundRegister hR_ProvidentFundRegister)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ProvidentFundRegister1", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundRegisterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.EmployeeID;
            cmd.Parameters.Add("@PayrollMonthDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.PayrollMonthDate;
            cmd.Parameters.Add("@EPF", SqlDbType.Money).Value = hR_ProvidentFundRegister.EPF;
            cmd.Parameters.Add("@CPF", SqlDbType.Money).Value = hR_ProvidentFundRegister.CPF;
            cmd.Parameters.Add("@TotalPFAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.TotalPFAmount;
            cmd.Parameters.Add("@WithdrawAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.WithdrawAmount;
            cmd.Parameters.Add("@WithdrawLastDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.WithdrawLastDate;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.ModifiedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = hR_ProvidentFundRegister.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProvidentFundRegisterID"].Value;
        }
    }

    public int InsertHR_ProvidentFundRegisterWithdrawAmount(HR_ProvidentFundRegister hR_ProvidentFundRegister)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ProvidentFundRegisterWithdrawAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundRegisterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.EmployeeID;
            cmd.Parameters.Add("@PayrollMonthDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.PayrollMonthDate;
            cmd.Parameters.Add("@EPF", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@CPF", SqlDbType.Money).Value =0;
            cmd.Parameters.Add("@TotalPFAmount", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@WithdrawAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.WithdrawAmount;
            cmd.Parameters.Add("@WithdrawLastDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.WithdrawLastDate;//hR_ProvidentFundRegister.WithdrawLastDate == DateTime.MinValue ? (object)DBNull.Value : hR_ProvidentFundRegister.WithdrawLastDate;
            //cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField1;
            //cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField2;
            //cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField3;
            //cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField4;
            //cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.AddedDate;
            //cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ModifiedBy;
            //cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.ModifiedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = hR_ProvidentFundRegister.RowStatusID;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            int outValue = (int)cmd.Parameters["@ProvidentFundRegisterID"].Value;
            return outValue;
        }

    }

    public bool InsertHR_ProvidentFundRegister(List<HR_ProvidentFundRegister> providentFundRegisterColl)
    {
        int totalCount = 0;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            connection.Open();
            foreach (HR_ProvidentFundRegister hR_ProvidentFundRegister in providentFundRegisterColl)
            {
                SqlCommand cmd = new SqlCommand("InsertHR_ProvidentFundRegister", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProvidentFundRegisterID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.EmployeeID;
                cmd.Parameters.Add("@PayrollMonthDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.PayrollMonthDate;
                cmd.Parameters.Add("@EPF", SqlDbType.Money).Value = hR_ProvidentFundRegister.EPF;
                cmd.Parameters.Add("@CPF", SqlDbType.Money).Value = hR_ProvidentFundRegister.CPF;
                cmd.Parameters.Add("@TotalPFAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.TotalPFAmount;
                //cmd.Parameters.Add("@WithdrawAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.WithdrawAmount;
                //cmd.Parameters.Add("@WithdrawLastDate", SqlDbType.DateTime).Value = null;//hR_ProvidentFundRegister.WithdrawLastDate == DateTime.MinValue ? (object)DBNull.Value : hR_ProvidentFundRegister.WithdrawLastDate;
                cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField1;
                //cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField2;
                //cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField3;
                //cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField4;
                //cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField5;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.AddedBy;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.AddedDate;
                //cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ModifiedBy;
                //cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.ModifiedDate;
                cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = hR_ProvidentFundRegister.RowStatusID;
                int result = cmd.ExecuteNonQuery();
                totalCount += result;
                int outValue=  (int)cmd.Parameters["@ProvidentFundRegisterID"].Value;
            }
            return true;
        }
    }


    public bool UpdateHR_ProvidentFundRegister(HR_ProvidentFundRegister hR_ProvidentFundRegister)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ProvidentFundRegister", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundRegisterID", SqlDbType.Int).Value = hR_ProvidentFundRegister.ProvidentFundRegisterID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.EmployeeID;
            cmd.Parameters.Add("@PayrollMonthDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.PayrollMonthDate;
            cmd.Parameters.Add("@EPF", SqlDbType.Money).Value = hR_ProvidentFundRegister.EPF;
            cmd.Parameters.Add("@CPF", SqlDbType.Money).Value = hR_ProvidentFundRegister.CPF;
            cmd.Parameters.Add("@TotalPFAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.TotalPFAmount;
            cmd.Parameters.Add("@WithdrawAmount", SqlDbType.Money).Value = hR_ProvidentFundRegister.WithdrawAmount;
            cmd.Parameters.Add("@WithdrawLastDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.WithdrawLastDate;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ExtraField5;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundRegister.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentFundRegister.ModifiedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = hR_ProvidentFundRegister.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ProvidentFundRegister(int providentFundRegisterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ProvidentFundRegister", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundRegisterID", SqlDbType.Int).Value = providentFundRegisterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

