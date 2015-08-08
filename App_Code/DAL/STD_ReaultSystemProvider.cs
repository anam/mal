using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ReaultSystemProvider:DataAccessObject
{
	public SqlSTD_ReaultSystemProvider()
    {
    }


    public DataSet  GetAllSTD_ReaultSystems()
    {
        DataSet STD_ReaultSystems = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ReaultSystems", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ReaultSystems);
            myadapter.Dispose();
            connection.Close();

            return STD_ReaultSystems;
        }
    }
	public DataSet GetSTD_ReaultSystemPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ReaultSystemPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_ReaultSystem()
    {
        DataSet STD_ReaultSystems = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ReaultSystems", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ReaultSystems);
            myadapter.Dispose();
            connection.Close();

            return STD_ReaultSystems;
        }
    }

    public DataSet   GetAllSTD_QuestionsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ReaultSystem> GetSTD_ReaultSystemsFromReader(IDataReader reader)
    {
        List<STD_ReaultSystem> sTD_ReaultSystems = new List<STD_ReaultSystem>();

        while (reader.Read())
        {
            sTD_ReaultSystems.Add(GetSTD_ReaultSystemFromReader(reader));
        }
        return sTD_ReaultSystems;
    }

    public STD_ReaultSystem GetSTD_ReaultSystemFromReader(IDataReader reader)
    {
        try
        {
            STD_ReaultSystem sTD_ReaultSystem = new STD_ReaultSystem
                (

                     DataAccessObject.IsNULL<int>(reader["ReaultSystemID"]),
                     DataAccessObject.IsNULL<string>(reader["ReaultSystemName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return sTD_ReaultSystem;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ReaultSystem  GetSTD_ReaultSystemByReaultSystemID(int  reaultSystemID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ReaultSystemByReaultSystemID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = reaultSystemID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ReaultSystemFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ReaultSystem(STD_ReaultSystem sTD_ReaultSystem)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ReaultSystem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = sTD_ReaultSystem.ReaultSystemName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ReaultSystem.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ReaultSystem.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_ReaultSystem.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_ReaultSystem.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReaultSystemID"].Value;
        }
    }

    public bool UpdateSTD_ReaultSystem(STD_ReaultSystem sTD_ReaultSystem)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ReaultSystem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = sTD_ReaultSystem.ReaultSystemID;
            cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = sTD_ReaultSystem.ReaultSystemName;
            //cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = sTD_ReaultSystem.ReaultSystemName;
            //cmd.Parameters.Add("@ReaultSystemName", SqlDbType.NVarChar).Value = sTD_ReaultSystem.ReaultSystemName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_ReaultSystem.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_ReaultSystem.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ReaultSystem(int reaultSystemID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ReaultSystem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = reaultSystemID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

