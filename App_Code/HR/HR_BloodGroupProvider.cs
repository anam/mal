using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_BloodGroupProvider:DataAccessObject
{
	public SqlHR_BloodGroupProvider()
    {
    }


    public DataSet  GetAllHR_BloodGroups()
    {
        DataSet HR_BloodGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_BloodGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BloodGroups);
            myadapter.Dispose();
            connection.Close();

            return HR_BloodGroups;
        }
    }
   
	public DataSet GetHR_BloodGroupPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_BloodGroupPageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_BloodGroup()
    {
        DataSet HR_BloodGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_BloodGroup", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BloodGroups);
            myadapter.Dispose();
            connection.Close();

            return HR_BloodGroups;
        }
    }

    public DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_LeaveRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_BloodGroup> GetHR_BloodGroupsFromReader(IDataReader reader)
    {
        List<HR_BloodGroup> hR_BloodGroups = new List<HR_BloodGroup>();

        while (reader.Read())
        {
            hR_BloodGroups.Add(GetHR_BloodGroupFromReader(reader));
        }
        return hR_BloodGroups;
    }

    public HR_BloodGroup GetHR_BloodGroupFromReader(IDataReader reader)
    {
        try
        {
            HR_BloodGroup hR_BloodGroup = new HR_BloodGroup
                (

                     DataAccessObject.IsNULL<int>(reader["BloodGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["BloodGroupName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_BloodGroup;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_BloodGroup  GetHR_BloodGroupByBloodGroupID(int  bloodGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_BloodGroupByBloodGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = bloodGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_BloodGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_BloodGroup(HR_BloodGroup hR_BloodGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BloodGroupName", SqlDbType.NVarChar).Value = hR_BloodGroup.BloodGroupName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_BloodGroup.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_BloodGroup.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_BloodGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_BloodGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BloodGroupID"].Value;
        }
    }

    public bool UpdateHR_BloodGroup(HR_BloodGroup hR_BloodGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = hR_BloodGroup.BloodGroupID;
            cmd.Parameters.Add("@BloodGroupName", SqlDbType.NVarChar).Value = hR_BloodGroup.BloodGroupName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_BloodGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_BloodGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_BloodGroup(int bloodGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = bloodGroupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

