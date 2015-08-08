using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryAdjustmentGroupProvider1:DataAccessObject
{
    /*
	public SqlHR_SalaryAdjustmentGroupProvider()
    {
    }


    public DataSet  GetAllHR_SalaryAdjustmentGroups()
    {
        DataSet HR_SalaryAdjustments = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryAdjustmentGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryAdjustments);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryAdjustments;
        }
    }

    public DataSet GetHR_SalaryAdjustmentGroupPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentGroupPageWise", connection))
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

    public HR_SalaryAdjustmentGroup  GetHR_SalaryAdjustmentGroupByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentGroupByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryAdjustmentGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_SalaryAdjustmentGroup()
    {
        DataSet HR_SalaryAdjustments = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryAdjustmentGroup", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryAdjustments);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryAdjustments;
        }
    }

    public List<HR_SalaryAdjustmentGroup> GetHR_SalaryAdjustmentGroupsFromReader(IDataReader reader)
    {
        List<HR_SalaryAdjustmentGroup> hR_SalaryAdjustments = new List<HR_SalaryAdjustmentGroup>();

        while (reader.Read())
        {
            hR_SalaryAdjustments.Add(GetHR_SalaryAdjustmentGroupFromReader(reader));
        }
        return hR_SalaryAdjustments;
    }

    public HR_SalaryAdjustmentGroup GetHR_SalaryAdjustmentGroupFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryAdjustmentGroup hR_SalaryAdjustment = new HR_SalaryAdjustmentGroup
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryAdjustmentGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["GroupName"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryAdjustment;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryAdjustmentGroup  GetHR_SalaryAdjustmentGroupBySalaryAdjustmentGroupID(int  salaryAdjustmentGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentGroupBySalaryAdjustmentGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Value = salaryAdjustmentGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_SalaryAdjustmentGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_SalaryAdjustmentGroup(HR_SalaryAdjustmentGroup hR_SalaryAdjustmentGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryAdjustmentGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = hR_SalaryAdjustmentGroup.GroupName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.DateTime).Value = hR_SalaryAdjustmentGroup.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.NVarChar).Value = hR_SalaryAdjustmentGroup.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryAdjustmentGroupID"].Value;
        }
    }

    public bool UpdateHR_SalaryAdjustmentGroup(HR_SalaryAdjustmentGroup hR_SalaryAdjustmentGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryAdjustmentGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Value = hR_SalaryAdjustmentGroup.SalaryAdjustmentGroupID;
            cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = hR_SalaryAdjustmentGroup.GroupName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.DateTime).Value = hR_SalaryAdjustmentGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.NVarChar).Value = hR_SalaryAdjustmentGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryAdjustmentGroup(int salaryAdjustmentGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryAdjustmentGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Value = salaryAdjustmentGroupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
     * */
}

