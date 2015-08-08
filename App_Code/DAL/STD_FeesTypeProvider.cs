using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_FeesTypeProvider:DataAccessObject
{
	public SqlSTD_FeesTypeProvider()
    {
    }


    public DataSet  GetAllSTD_FeesTypes()
    {
        DataSet STD_FeesTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeesTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_FeesTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_FeesTypes;
        }
    }
	public DataSet GetSTD_FeesTypePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesTypePageWise", connection))
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


    public STD_FeesType  GetSTD_FeesTypeByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesTypeByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_FeesType()
    {
        DataSet STD_FeesTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_FeesType", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_FeesTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_FeesTypes;
        }
    }

    public DataSet   GetAllSTD_FeessWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeessWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_FeesType> GetSTD_FeesTypesFromReader(IDataReader reader)
    {
        List<STD_FeesType> sTD_FeesTypes = new List<STD_FeesType>();

        while (reader.Read())
        {
            sTD_FeesTypes.Add(GetSTD_FeesTypeFromReader(reader));
        }
        return sTD_FeesTypes;
    }

    public STD_FeesType GetSTD_FeesTypeFromReader(IDataReader reader)
    {
        try
        {
            STD_FeesType sTD_FeesType = new STD_FeesType
                (

                     DataAccessObject.IsNULL<int>(reader["FeesTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["FeesTypeName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return sTD_FeesType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_FeesType  GetSTD_FeesTypeByFeesTypeID(int  feesTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesTypeByFeesTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = feesTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_FeesType(STD_FeesType sTD_FeesType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_FeesType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@FeesTypeName", SqlDbType.NVarChar).Value = sTD_FeesType.FeesTypeName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_FeesType.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_FeesType.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_FeesType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_FeesType.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_FeesType.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FeesTypeID"].Value;
        }
    }

    public bool UpdateSTD_FeesType(STD_FeesType sTD_FeesType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_FeesType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = sTD_FeesType.FeesTypeID;
            cmd.Parameters.Add("@FeesTypeName", SqlDbType.NVarChar).Value = sTD_FeesType.FeesTypeName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_FeesType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_FeesType.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_FeesType.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_FeesType(int feesTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_FeesType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = feesTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

