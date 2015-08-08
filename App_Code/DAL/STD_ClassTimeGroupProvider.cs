using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassTimeGroupProvider:DataAccessObject
{
	public SqlSTD_ClassTimeGroupProvider()
    {
    }


    public DataSet  GetAllSTD_ClassTimeGroups()
    {
        DataSet STD_ClassTimeGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassTimeGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassTimeGroups);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassTimeGroups;
        }
    }
	public DataSet GetSTD_ClassTimeGroupPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassTimeGroupPageWise", connection))
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


    public STD_ClassTimeGroup  GetSTD_ClassTimeGroupByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassTimeGroupByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassTimeGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ClassTimeGroup()
    {
        DataSet STD_ClassTimeGroups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassTimeGroup", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassTimeGroups);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassTimeGroups;
        }
    }
    public List<STD_ClassTimeGroup> GetSTD_ClassTimeGroupsFromReader(IDataReader reader)
    {
        List<STD_ClassTimeGroup> sTD_ClassTimeGroups = new List<STD_ClassTimeGroup>();

        while (reader.Read())
        {
            sTD_ClassTimeGroups.Add(GetSTD_ClassTimeGroupFromReader(reader));
        }
        return sTD_ClassTimeGroups;
    }

    public STD_ClassTimeGroup GetSTD_ClassTimeGroupFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassTimeGroup sTD_ClassTimeGroup = new STD_ClassTimeGroup
                (

                     DataAccessObject.IsNULL<int>(reader["ClassTimeGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassTimeGroupName"]),
                     DataAccessObject.IsNULL<string>(reader["StartTime"]),
                     DataAccessObject.IsNULL<string>(reader["EndTime"]),
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
             return sTD_ClassTimeGroup;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassTimeGroup  GetSTD_ClassTimeGroupByClassTimeGroupID(int  classTimeGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassTimeGroupByClassTimeGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassTimeGroupID", SqlDbType.Int).Value = classTimeGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassTimeGroupFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassTimeGroup(STD_ClassTimeGroup sTD_ClassTimeGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassTimeGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTimeGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassTimeGroupName", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ClassTimeGroupName;
            cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.EndTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassTimeGroup.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassTimeGroup.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassTimeGroup.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassTimeGroupID"].Value;
        }
    }

    public bool UpdateSTD_ClassTimeGroup(STD_ClassTimeGroup sTD_ClassTimeGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassTimeGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTimeGroupID", SqlDbType.Int).Value = sTD_ClassTimeGroup.ClassTimeGroupID;
            cmd.Parameters.Add("@ClassTimeGroupName", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ClassTimeGroupName;
            cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.EndTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassTimeGroup.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassTimeGroup.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassTimeGroup.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassTimeGroup(int classTimeGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassTimeGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTimeGroupID", SqlDbType.Int).Value = classTimeGroupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

