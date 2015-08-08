using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_OvertimeProvider:DataAccessObject
{
	public SqlHR_OvertimeProvider()
    {
    }


    public DataSet  GetAllHR_Overtimes()
    {
        DataSet HR_Overtimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Overtimes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Overtimes);
            myadapter.Dispose();
            connection.Close();

            return HR_Overtimes;
        }
    }
	public DataSet GetHR_OvertimePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_OvertimePageWise", connection))
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


    public HR_Overtime  GetHR_OvertimeByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OvertimeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_OvertimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }


    public double GetHR_OvertimeByEmployeeIDAndDateInterval(string employeeID, DateTime fromDate, DateTime toDate)
    {
        double totalCalculatedHour = 0;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OvertimeByEmployeeIDAndDateInterval", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
            connection.Open();

            object totalHour = command.ExecuteScalar();
            if (totalHour!=DBNull.Value)
            {
                totalCalculatedHour = Convert.ToDouble(totalHour);
                return totalCalculatedHour;
            }
            else
            {
                totalCalculatedHour = 0;
                return totalCalculatedHour;
            }       
        }
    }

    public HR_Overtime  GetHR_OvertimeByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OvertimeByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_OvertimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_Overtime()
    {
        DataSet HR_Overtimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Overtime", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Overtimes);
            myadapter.Dispose();
            connection.Close();

            return HR_Overtimes;
        }
    }

    public DataSet GetOverTimeEmployeeByEmployeeID(string employeeID)
    {
        DataSet HR_Overtimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Get_OverTimeEmployeeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Overtimes);
            myadapter.Dispose();
            connection.Close();

            return HR_Overtimes;
        }
    }

    public DataSet   GetAllHR_OvertimesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_OvertimesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_Overtime> GetHR_OvertimesFromReader(IDataReader reader)
    {
        List<HR_Overtime> hR_Overtimes = new List<HR_Overtime>();

        while (reader.Read())
        {
            hR_Overtimes.Add(GetHR_OvertimeFromReader(reader));
        }
        return hR_Overtimes;
    }

    public HR_Overtime GetHR_OvertimeFromReader(IDataReader reader)
    {
        try
        {
            HR_Overtime hR_Overtime = new HR_Overtime
                (

                     DataAccessObject.IsNULL<int>(reader["OverTimeID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["Date"]),
                     DataAccessObject.IsNULL<decimal>(reader["Hours"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return hR_Overtime;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Overtime  GetHR_OvertimeByOverTimeID(int  overTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OvertimeByOverTimeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OverTimeID", SqlDbType.Int).Value = overTimeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_OvertimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Overtime(HR_Overtime hR_Overtime)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Overtime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Overtime.EmployeeID;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = hR_Overtime.Date;
            cmd.Parameters.Add("@Hours", SqlDbType.Decimal).Value = hR_Overtime.Hours;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Overtime.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Overtime.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_Overtime.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hR_Overtime.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = hR_Overtime.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OverTimeID"].Value;
        }
    }

    public bool UpdateHR_Overtime(HR_Overtime hR_Overtime)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Overtime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeID", SqlDbType.Int).Value = hR_Overtime.OverTimeID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Overtime.EmployeeID;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = hR_Overtime.Date;
            cmd.Parameters.Add("@Hours", SqlDbType.Decimal).Value = hR_Overtime.Hours;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = hR_Overtime.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_Overtime.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hR_Overtime.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = hR_Overtime.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Overtime(int overTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Overtime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OverTimeID", SqlDbType.Int).Value = overTimeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

