using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ContactTypeProvider:DataAccessObject
{
	public SqlSTD_ContactTypeProvider()
    {
    }


    public DataSet  GetAllSTD_ContactTypes()
    {
        DataSet STD_ContactTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ContactTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ContactTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_ContactTypes;
        }
    }
	public DataSet GetSTD_ContactTypePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ContactTypePageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_ContactType()
    {
        DataSet STD_ContactTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ContactTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ContactTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_ContactTypes;
        }
    }

    public DataSet   GetAllSTD_ContactsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ContactsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ContactType> GetSTD_ContactTypesFromReader(IDataReader reader)
    {
        List<STD_ContactType> sTD_ContactTypes = new List<STD_ContactType>();

        while (reader.Read())
        {
            sTD_ContactTypes.Add(GetSTD_ContactTypeFromReader(reader));
        }
        return sTD_ContactTypes;
    }

    public STD_ContactType GetSTD_ContactTypeFromReader(IDataReader reader)
    {
        try
        {
            STD_ContactType sTD_ContactType = new STD_ContactType
                (

                     DataAccessObject.IsNULL<int>(reader["ContactTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["ContactTypeName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return sTD_ContactType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ContactType  GetSTD_ContactTypeByContactTypeID(int  contactTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ContactTypeByContactTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = contactTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ContactTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ContactType(STD_ContactType sTD_ContactType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ContactType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ContactTypeName", SqlDbType.NVarChar).Value = sTD_ContactType.ContactTypeName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ContactType.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ContactType.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_ContactType.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_ContactType.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ContactTypeID"].Value;
        }
    }

    public bool UpdateSTD_ContactType(STD_ContactType sTD_ContactType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ContactType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = sTD_ContactType.ContactTypeID;
            cmd.Parameters.Add("@ContactTypeName", SqlDbType.NVarChar).Value = sTD_ContactType.ContactTypeName;
            //cmd.Parameters.Add("@ContactTypeName", SqlDbType.NVarChar).Value = sTD_ContactType.ContactTypeName;
            //cmd.Parameters.Add("@ContactTypeName", SqlDbType.NVarChar).Value = sTD_ContactType.ContactTypeName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_ContactType.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_ContactType.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ContactType(int contactTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ContactType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int).Value = contactTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

