using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassStatusProvider:DataAccessObject
{
	public SqlSTD_ClassStatusProvider()
    {
    }


    public DataSet  GetAllSTD_ClassStatuss()
    {
        DataSet STD_ClassStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassStatuss);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassStatuss;
        }
    }
	public DataSet GetSTD_ClassStatusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStatusPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_ClassStatus()
    {
        DataSet STD_ClassStatuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassStatuss);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassStatuss;
        }
    }

    public DataSet   GetAllSTD_ClasssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClasssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassStatus> GetSTD_ClassStatussFromReader(IDataReader reader)
    {
        List<STD_ClassStatus> sTD_ClassStatuss = new List<STD_ClassStatus>();

        while (reader.Read())
        {
            sTD_ClassStatuss.Add(GetSTD_ClassStatusFromReader(reader));
        }
        return sTD_ClassStatuss;
    }

    public STD_ClassStatus GetSTD_ClassStatusFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassStatus sTD_ClassStatus = new STD_ClassStatus
                (

                     DataAccessObject.IsNULL<int>(reader["ClassStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassStatusName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_ClassStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassStatus  GetSTD_ClassStatusByClassStatusID(int  classStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassStatusByClassStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassStatusID", SqlDbType.Int).Value = classStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassStatusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassStatus(STD_ClassStatus sTD_ClassStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassStatusName", SqlDbType.NVarChar).Value = sTD_ClassStatus.ClassStatusName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassStatus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassStatus.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStatus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStatus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassStatusID"].Value;
        }
    }

    public bool UpdateSTD_ClassStatus(STD_ClassStatus sTD_ClassStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassStatusID", SqlDbType.Int).Value = sTD_ClassStatus.ClassStatusID;
            cmd.Parameters.Add("@ClassStatusName", SqlDbType.NVarChar).Value = sTD_ClassStatus.ClassStatusName;
            //cmd.Parameters.Add("@ClassStatusName", SqlDbType.NVarChar).Value = sTD_ClassStatus.ClassStatusName;
            //cmd.Parameters.Add("@ClassStatusName", SqlDbType.NVarChar).Value = sTD_ClassStatus.ClassStatusName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStatus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStatus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassStatus(int classStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassStatusID", SqlDbType.Int).Value = classStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

