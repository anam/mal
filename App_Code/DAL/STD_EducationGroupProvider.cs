using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_EducationGroupProvider:DataAccessObject
{
	public SqlSTD_EducationGroupProvider()
    {
    }


    public DataSet  GetAllSTD_EducationGroups()
    {
        DataSet STD_EducationGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_EducationGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_EducationGroups);
            myadapter.Dispose();
            connection.Close();

            return STD_EducationGroups;
        }
    }
	public DataSet GetSTD_EducationGroupPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_EducationalGroupPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_EducationGroup()
    {
        DataSet STD_EducationGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_EducationGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_EducationGroups);
            myadapter.Dispose();
            connection.Close();

            return STD_EducationGroups;
        }
    }
    public List<STD_EducationGroup> GetSTD_EducationGroupsFromReader(IDataReader reader)
    {
        List<STD_EducationGroup> sTD_EducationGroups = new List<STD_EducationGroup>();

        while (reader.Read())
        {
            sTD_EducationGroups.Add(GetSTD_EducationGroupFromReader(reader));
        }
        return sTD_EducationGroups;
    }

    public STD_EducationGroup GetSTD_EducationGroupFromReader(IDataReader reader)
    {
        try
        {
            STD_EducationGroup sTD_EducationGroup = new STD_EducationGroup
                (

                     DataAccessObject.IsNULL<int>(reader["EducationGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["EducationGroupName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return sTD_EducationGroup;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_EducationGroup  GetSTD_EducationGroupByEducationGroupID(int  educationGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_EducationGroupByEducationGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EducationGroupID", SqlDbType.Int).Value = educationGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_EducationGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_EducationGroup(STD_EducationGroup sTD_EducationGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_EducationGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EducationGroupName", SqlDbType.NVarChar).Value = sTD_EducationGroup.EducationGroupName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_EducationGroup.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_EducationGroup.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_EducationGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_EducationGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EducationGroupID"].Value;
        }
    }

    public bool UpdateSTD_EducationGroup(STD_EducationGroup sTD_EducationGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_EducationGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationGroupID", SqlDbType.Int).Value = sTD_EducationGroup.EducationGroupID;
            cmd.Parameters.Add("@EducationGroupName", SqlDbType.NVarChar).Value = sTD_EducationGroup.EducationGroupName;
            //cmd.Parameters.Add("@EducationGroupName", SqlDbType.NVarChar).Value = sTD_EducationGroup.EducationGroupName;
            //cmd.Parameters.Add("@EducationGroupName", SqlDbType.NVarChar).Value = sTD_EducationGroup.EducationGroupName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_EducationGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_EducationGroup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_EducationGroup(int educationGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_EducationGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationGroupID", SqlDbType.Int).Value = educationGroupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

