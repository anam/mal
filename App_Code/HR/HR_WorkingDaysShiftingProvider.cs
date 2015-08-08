using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_WorkingDaysShiftingProvider:DataAccessObject
{
	public SqlHR_WorkingDaysShiftingProvider()
    {
    }


    public DataSet  GetAllHR_WorkingDaysShiftings()
    {
        DataSet HR_WorkingDaysShiftings = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_WorkingDaysShiftings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_WorkingDaysShiftings);
            myadapter.Dispose();
            connection.Close();

            return HR_WorkingDaysShiftings;
        }
    }
	public DataSet GetHR_WorkingDaysShiftingPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_WorkingDaysShiftingPageWise", connection))
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

    public HR_WorkingDaysShifting GetHR_WorkingDaysShiftingObjectByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_WorkingDaysShiftingByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_WorkingDaysShiftingFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet  GetHR_WorkingDaysShiftingByEmployeeID(string  employeeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_WorkingDaysShiftingByEmployeeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", employeeID);
            
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
             
                return ds;
            }
        }
        
    }

    public DataSet  GetDropDownLisAllHR_WorkingDaysShifting()
    {
        DataSet HR_WorkingDaysShiftings = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_WorkingDaysShifting", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_WorkingDaysShiftings);
            myadapter.Dispose();
            connection.Close();

            return HR_WorkingDaysShiftings;
        }
    }

    public DataSet   GetAllHR_WorkingDaysShiftingsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_WorkingDaysShiftingsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_WorkingDaysShifting> GetHR_WorkingDaysShiftingsFromReader(IDataReader reader)
    {
        List<HR_WorkingDaysShifting> hR_WorkingDaysShiftings = new List<HR_WorkingDaysShifting>();

        while (reader.Read())
        {
            hR_WorkingDaysShiftings.Add(GetHR_WorkingDaysShiftingFromReader(reader));
        }
        return hR_WorkingDaysShiftings;
    }

    public HR_WorkingDaysShifting GetHR_WorkingDaysShiftingFromReader(IDataReader reader)
    {
        try
        {
            HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting
                (

                     DataAccessObject.IsNULL<int>(reader["WorkingDaysID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<bool>(reader["Saturday"]),
                     DataAccessObject.IsNULL<bool>(reader["Sunday"]),
                     DataAccessObject.IsNULL<bool>(reader["Monday"]),
                     DataAccessObject.IsNULL<bool>(reader["Tuesday"]),
                     DataAccessObject.IsNULL<bool>(reader["Wednesday"]),
                     DataAccessObject.IsNULL<bool>(reader["Thrusday"]),
                     DataAccessObject.IsNULL<bool>(reader["Friday"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ShiftStartTime"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ShiftEndTime"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_WorkingDaysShifting;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_WorkingDaysShifting  GetHR_WorkingDaysShiftingByWorkingDaysID(int  workingDaysID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_WorkingDaysShiftingByWorkingDaysID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@WorkingDaysID", SqlDbType.Int).Value = workingDaysID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_WorkingDaysShiftingFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_WorkingDaysShifting(HR_WorkingDaysShifting hR_WorkingDaysShifting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_WorkingDaysShifting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkingDaysID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.EmployeeID;
            cmd.Parameters.Add("@Saturday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Saturday;
            cmd.Parameters.Add("@Sunday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Sunday;
            cmd.Parameters.Add("@Monday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Monday;
            cmd.Parameters.Add("@Tuesday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Tuesday;
            cmd.Parameters.Add("@Wednesday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Wednesday;
            cmd.Parameters.Add("@Thrusday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Friday; ;
            cmd.Parameters.Add("@Friday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Thrusday;
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.ShiftStartTime;
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.ShiftEndTime;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@WorkingDaysID"].Value;
        }
    }

    public bool UpdateHR_WorkingDaysShifting(HR_WorkingDaysShifting hR_WorkingDaysShifting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_WorkingDaysShifting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkingDaysID", SqlDbType.Int).Value = hR_WorkingDaysShifting.WorkingDaysID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.EmployeeID;
            cmd.Parameters.Add("@Saturday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Saturday;
            cmd.Parameters.Add("@Sunday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Sunday;
            cmd.Parameters.Add("@Monday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Monday;
            cmd.Parameters.Add("@Tuesday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Tuesday;
            cmd.Parameters.Add("@Wednesday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Wednesday;
            cmd.Parameters.Add("@Thrusday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Thrusday;
            cmd.Parameters.Add("@Friday", SqlDbType.Bit).Value = hR_WorkingDaysShifting.Thrusday;
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.ShiftStartTime;
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.ShiftEndTime;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.Description;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_WorkingDaysShifting.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_WorkingDaysShifting.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_WorkingDaysShifting(int workingDaysID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_WorkingDaysShifting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkingDaysID", SqlDbType.Int).Value = workingDaysID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

