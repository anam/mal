using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_BloodGroupProvider:DataAccessObject
{
	public SqlCOMN_BloodGroupProvider()
    {
    }


    public DataSet  GetAllCOMN_BloodGroups()
    {
        DataSet COMN_BloodGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_BloodGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_BloodGroups);
            myadapter.Dispose();
            connection.Close();

            return COMN_BloodGroups;
        }
    }
    public DataSet GetDropDownLisAllHR_BloodGroup()
    {
        DataSet HR_BloodGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_BloodGroup", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_BloodGroups);
            myadapter.Dispose();
            connection.Close();

            return HR_BloodGroups;
        }
    }
	public DataSet GetCOMN_BloodGroupPageWise(int pageIndex, int PageSize, out int recordCount)
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


    public DataSet  GetDropDownListAllCOMN_BloodGroup()
    {
        DataSet COMN_BloodGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_BloodGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_BloodGroups);
            myadapter.Dispose();
            connection.Close();

            return COMN_BloodGroups;
        }
    }

    public DataSet   GetAllCOMN_CitiesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_CitiesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<COMN_BloodGroup> GetCOMN_BloodGroupsFromReader(IDataReader reader)
    {
        List<COMN_BloodGroup> cOMN_BloodGroups = new List<COMN_BloodGroup>();

        while (reader.Read())
        {
            cOMN_BloodGroups.Add(GetCOMN_BloodGroupFromReader(reader));
        }
        return cOMN_BloodGroups;
    }

    public COMN_BloodGroup GetCOMN_BloodGroupFromReader(IDataReader reader)
    {
        try
        {
            COMN_BloodGroup cOMN_BloodGroup = new COMN_BloodGroup
                (

                     DataAccessObject.IsNULL<int>(reader["BloodGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["BloodGroupName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return cOMN_BloodGroup;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_BloodGroup  GetCOMN_BloodGroupByBloodGroupID(int  bloodGroupID)
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
            return GetCOMN_BloodGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_BloodGroup(COMN_BloodGroup cOMN_BloodGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BloodGroupName", SqlDbType.NVarChar).Value = cOMN_BloodGroup.BloodGroupName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_BloodGroup.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_BloodGroup.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_BloodGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_BloodGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BloodGroupID"].Value;
        }
    }

    public bool UpdateCOMN_BloodGroup(COMN_BloodGroup cOMN_BloodGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = cOMN_BloodGroup.BloodGroupID;
            cmd.Parameters.Add("@BloodGroupName", SqlDbType.NVarChar).Value = cOMN_BloodGroup.BloodGroupName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_BloodGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_BloodGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_BloodGroup(int bloodGroupID)
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

