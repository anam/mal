using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_PersonalDocumentsProvider:DataAccessObject
{
	public SqlCOMN_PersonalDocumentsProvider()
    {
    }


    public DataSet  GetAllCOMN_PersonalDocumentss()
    {
        DataSet COMN_PersonalDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_PersonalDocumentss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_PersonalDocumentss);
            myadapter.Dispose();
            connection.Close();

            return COMN_PersonalDocumentss;
        }
    }
	public DataSet GetCOMN_PersonalDocumentsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_PersonalDocumentsPageWise", connection))
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


    public COMN_PersonalDocuments  GetCOMN_PersonalDocumentsByUserID(string  userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_PersonalDocumentsByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_PersonalDocumentsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllCOMN_PersonalDocuments()
    {
        DataSet COMN_PersonalDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_PersonalDocumentss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_PersonalDocumentss);
            myadapter.Dispose();
            connection.Close();

            return COMN_PersonalDocumentss;
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
    public List<COMN_PersonalDocuments> GetCOMN_PersonalDocumentssFromReader(IDataReader reader)
    {
        List<COMN_PersonalDocuments> cOMN_PersonalDocumentss = new List<COMN_PersonalDocuments>();

        while (reader.Read())
        {
            cOMN_PersonalDocumentss.Add(GetCOMN_PersonalDocumentsFromReader(reader));
        }
        return cOMN_PersonalDocumentss;
    }

    public COMN_PersonalDocuments GetCOMN_PersonalDocumentsFromReader(IDataReader reader)
    {
        try
        {
            COMN_PersonalDocuments cOMN_PersonalDocuments = new COMN_PersonalDocuments
                (

                     DataAccessObject.IsNULL<int>(reader["PersonalDocumentsID"]),
                     DataAccessObject.IsNULL<string>(reader["UserID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["FileName"]),
                     DataAccessObject.IsNULL<string>(reader["FileLocationUrl"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return cOMN_PersonalDocuments;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_PersonalDocuments  GetCOMN_PersonalDocumentsByPersonalDocumentsID(int  personalDocumentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_PersonalDocumentsByPersonalDocumentsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Value = personalDocumentsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_PersonalDocumentsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_PersonalDocuments(COMN_PersonalDocuments cOMN_PersonalDocuments)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_PersonalDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.UserID;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.FileName;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_PersonalDocuments.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_PersonalDocuments.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PersonalDocumentsID"].Value;
        }
    }

    public bool UpdateCOMN_PersonalDocuments(COMN_PersonalDocuments cOMN_PersonalDocuments)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_PersonalDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Value = cOMN_PersonalDocuments.PersonalDocumentsID;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.UserID;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.FileName;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_PersonalDocuments.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_PersonalDocuments.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_PersonalDocuments(int personalDocumentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_PersonalDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Value = personalDocumentsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

