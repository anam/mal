using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ComprehensionProvider:DataAccessObject
{
	public SqlSTD_ComprehensionProvider()
    {
    }


    public DataSet  GetAllSTD_Comprehensions()
    {
        DataSet STD_Comprehensions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Comprehensions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Comprehensions);
            myadapter.Dispose();
            connection.Close();

            return STD_Comprehensions;
        }
    }
	public DataSet GetSTD_ComprehensionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ComprehensionPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_Comprehension()
    {
        DataSet STD_Comprehensions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Comprehensions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Comprehensions);
            myadapter.Dispose();
            connection.Close();

            return STD_Comprehensions;
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
    public List<STD_Comprehension> GetSTD_ComprehensionsFromReader(IDataReader reader)
    {
        List<STD_Comprehension> sTD_Comprehensions = new List<STD_Comprehension>();

        while (reader.Read())
        {
            sTD_Comprehensions.Add(GetSTD_ComprehensionFromReader(reader));
        }
        return sTD_Comprehensions;
    }

    public STD_Comprehension GetSTD_ComprehensionFromReader(IDataReader reader)
    {
        try
        {
            STD_Comprehension sTD_Comprehension = new STD_Comprehension
                (

                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<string>(reader["ComprehensionName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Comprehension;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Comprehension  GetSTD_ComprehensionByComprehensionID(int  comprehensionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ComprehensionByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = comprehensionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ComprehensionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Comprehension(STD_Comprehension sTD_Comprehension)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Comprehension", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ComprehensionName", SqlDbType.NVarChar).Value = sTD_Comprehension.ComprehensionName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Comprehension.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Comprehension.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Comprehension.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Comprehension.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Comprehension.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ComprehensionID"].Value;
        }
    }

    public bool UpdateSTD_Comprehension(STD_Comprehension sTD_Comprehension)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Comprehension", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = sTD_Comprehension.ComprehensionID;
            cmd.Parameters.Add("@ComprehensionName", SqlDbType.NVarChar).Value = sTD_Comprehension.ComprehensionName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Comprehension.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Comprehension.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Comprehension.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Comprehension.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Comprehension.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Comprehension(int comprehensionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Comprehension", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = comprehensionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

