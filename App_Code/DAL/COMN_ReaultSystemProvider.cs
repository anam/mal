using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_ReaultSystemProvider:DataAccessObject
{
	public SqlCOMN_ReaultSystemProvider()
    {
    }


    public DataSet  GetAllCOMN_ReaultSystems()
    {
        DataSet COMN_ReaultSystems = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_ReaultSystems", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_ReaultSystems);
            myadapter.Dispose();
            connection.Close();

            return COMN_ReaultSystems;
        }
    }
	public DataSet GetCOMN_ReaultSystemPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_ReaultSystemPageWise", connection))
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


    public DataSet  GetDropDownListAllCOMN_ReaultSystem()
    {
        DataSet COMN_ReaultSystems = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_ReaultSystems", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_ReaultSystems);
            myadapter.Dispose();
            connection.Close();

            return COMN_ReaultSystems;
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
    public List<COMN_ReaultSystem> GetCOMN_ReaultSystemsFromReader(IDataReader reader)
    {
        List<COMN_ReaultSystem> cOMN_ReaultSystems = new List<COMN_ReaultSystem>();

        while (reader.Read())
        {
            cOMN_ReaultSystems.Add(GetCOMN_ReaultSystemFromReader(reader));
        }
        return cOMN_ReaultSystems;
    }

    public COMN_ReaultSystem GetCOMN_ReaultSystemFromReader(IDataReader reader)
    {
        try
        {
            COMN_ReaultSystem cOMN_ReaultSystem = new COMN_ReaultSystem
                (

                     DataAccessObject.IsNULL<int>(reader["ReaultSystemID"]),
                     DataAccessObject.IsNULL<string>(reader["ReaultSystemName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return cOMN_ReaultSystem;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_ReaultSystem  GetCOMN_ReaultSystemByReaultSystemID(int  reaultSystemID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_ReaultSystemByReaultSystemID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = reaultSystemID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_ReaultSystemFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_ReaultSystem(COMN_ReaultSystem cOMN_ReaultSystem)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_ReaultSystem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.ReaultSystemName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_ReaultSystem.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_ReaultSystem.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReaultSystemID"].Value;
        }
    }

    public bool UpdateCOMN_ReaultSystem(COMN_ReaultSystem cOMN_ReaultSystem)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_ReaultSystem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = cOMN_ReaultSystem.ReaultSystemID;
            cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.ReaultSystemName;
            cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.ReaultSystemName;
            cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.ReaultSystemName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_ReaultSystem.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_ReaultSystem.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_ReaultSystem(int reaultSystemID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_ReaultSystem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = reaultSystemID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

