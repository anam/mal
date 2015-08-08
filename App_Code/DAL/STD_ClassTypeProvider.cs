using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassTypeProvider:DataAccessObject
{
	public SqlSTD_ClassTypeProvider()
    {
    }


    public DataSet  GetAllSTD_ClassTypes()
    {
        DataSet STD_ClassTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassTypes;
        }
    }
	public DataSet GetSTD_ClassTypePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassTypePageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_ClassType()
    {
        DataSet STD_ClassTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassTypes;
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
    public List<STD_ClassType> GetSTD_ClassTypesFromReader(IDataReader reader)
    {
        List<STD_ClassType> sTD_ClassTypes = new List<STD_ClassType>();

        while (reader.Read())
        {
            sTD_ClassTypes.Add(GetSTD_ClassTypeFromReader(reader));
        }
        return sTD_ClassTypes;
    }

    public STD_ClassType GetSTD_ClassTypeFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassType sTD_ClassType = new STD_ClassType
                (

                     DataAccessObject.IsNULL<int>(reader["ClassTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassTypeName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_ClassType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassType  GetSTD_ClassTypeByClassTypeID(int  classTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassTypeByClassTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassTypeID", SqlDbType.Int).Value = classTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassType(STD_ClassType sTD_ClassType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassTypeName", SqlDbType.NVarChar).Value = sTD_ClassType.ClassTypeName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassType.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassType.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassType.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassTypeID"].Value;
        }
    }

    public bool UpdateSTD_ClassType(STD_ClassType sTD_ClassType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTypeID", SqlDbType.Int).Value = sTD_ClassType.ClassTypeID;
            cmd.Parameters.Add("@ClassTypeName", SqlDbType.NVarChar).Value = sTD_ClassType.ClassTypeName;
            //cmd.Parameters.Add("@ClassTypeName", SqlDbType.NVarChar).Value = sTD_ClassType.ClassTypeName;
            //cmd.Parameters.Add("@ClassTypeName", SqlDbType.NVarChar).Value = sTD_ClassType.ClassTypeName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassType.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassType(int classTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassTypeID", SqlDbType.Int).Value = classTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

