using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_AttendenceRulesProvider:DataAccessObject
{
	public SqlHR_AttendenceRulesProvider()
    {
    }


    public DataSet  GetAllHR_AttendenceRuless()
    {
        DataSet HR_AttendenceRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_AttendenceRuless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_AttendenceRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_AttendenceRuless;
        }
    }
	public DataSet GetHR_AttendenceRulesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_AttendenceRulesPageWise", connection))
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

    public HR_AttendenceRules GetHR_AttendenceRulesObjectByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_AttendenceRulesByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_AttendenceRulesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public DataSet GetHR_AttendenceRulesByEmployeeID(string employeeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_AttendenceRulesByEmployeeID", connection))
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

    public DataSet  GetDropDownLisAllHR_AttendenceRules()
    {
        DataSet HR_AttendenceRuless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_AttendenceRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_AttendenceRuless);
            myadapter.Dispose();
            connection.Close();

            return HR_AttendenceRuless;
        }
    }

    public DataSet   GetAllHR_AttendenceRulessWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_AttendenceRulessWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_AttendenceRules> GetHR_AttendenceRulessFromReader(IDataReader reader)
    {
        List<HR_AttendenceRules> hR_AttendenceRuless = new List<HR_AttendenceRules>();

        while (reader.Read())
        {
            hR_AttendenceRuless.Add(GetHR_AttendenceRulesFromReader(reader));
        }
        return hR_AttendenceRuless;
    }

    public HR_AttendenceRules GetHR_AttendenceRulesFromReader(IDataReader reader)
    {
        try
        {
            HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules
                (

                     DataAccessObject.IsNULL<int>(reader["AttendenceRulesID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["Rules"]),
                     DataAccessObject.IsNULL<int>(reader["Time"]),
                     DataAccessObject.IsNULL<string>(reader["Unit"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_AttendenceRules;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_AttendenceRules  GetHR_AttendenceRulesByAttendenceRulesID(int  attendenceRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_AttendenceRulesByAttendenceRulesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AttendenceRulesID", SqlDbType.Int).Value = attendenceRulesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_AttendenceRulesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_AttendenceRules(HR_AttendenceRules hR_AttendenceRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_AttendenceRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendenceRulesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_AttendenceRules.EmployeeID;
            cmd.Parameters.Add("@Rules", SqlDbType.NVarChar).Value = hR_AttendenceRules.Rules;
            cmd.Parameters.Add("@Time", SqlDbType.Int).Value = hR_AttendenceRules.Time;
            cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = hR_AttendenceRules.Unit;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_AttendenceRules.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_AttendenceRules.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_AttendenceRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_AttendenceRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AttendenceRulesID"].Value;
        }
    }

    public bool UpdateHR_AttendenceRules(HR_AttendenceRules hR_AttendenceRules)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_AttendenceRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendenceRulesID", SqlDbType.Int).Value = hR_AttendenceRules.AttendenceRulesID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_AttendenceRules.EmployeeID;
            cmd.Parameters.Add("@Rules", SqlDbType.NVarChar).Value = hR_AttendenceRules.Rules;
            cmd.Parameters.Add("@Time", SqlDbType.Int).Value = hR_AttendenceRules.Time;
            cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = hR_AttendenceRules.Unit;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_AttendenceRules.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_AttendenceRules.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_AttendenceRules(int attendenceRulesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_AttendenceRules", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendenceRulesID", SqlDbType.Int).Value = attendenceRulesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

