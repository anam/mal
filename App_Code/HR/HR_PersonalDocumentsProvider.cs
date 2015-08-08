using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_PersonalDocumentsProvider:DataAccessObject
{
	public SqlHR_PersonalDocumentsProvider()
    {
    }


    public DataSet  GetAllHR_PersonalDocumentss()
    {
        DataSet HR_PersonalDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PersonalDocumentss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PersonalDocumentss);
            myadapter.Dispose();
            connection.Close();

            return HR_PersonalDocumentss;
        }
    }
	public DataSet GetHR_PersonalDocumentsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_PersonalDocumentsPageWise", connection))
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


    public HR_PersonalDocuments  GetHR_PersonalDocumentsByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PersonalDocumentsByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PersonalDocumentsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_PersonalDocuments()
    {
        DataSet HR_PersonalDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_PersonalDocumentss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_PersonalDocumentss);
            myadapter.Dispose();
            connection.Close();

            return HR_PersonalDocumentss;
        }
    }

    public DataSet   GetAllHR_PersonalDocumentssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_PersonalDocumentssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_PersonalDocuments> GetHR_PersonalDocumentssFromReader(IDataReader reader)
    {
        List<HR_PersonalDocuments> hR_PersonalDocumentss = new List<HR_PersonalDocuments>();

        while (reader.Read())
        {
            hR_PersonalDocumentss.Add(GetHR_PersonalDocumentsFromReader(reader));
        }
        return hR_PersonalDocumentss;
    }

    public HR_PersonalDocuments GetHR_PersonalDocumentsFromReader(IDataReader reader)
    {
        try
        {
            HR_PersonalDocuments hR_PersonalDocuments = new HR_PersonalDocuments
                (

                     DataAccessObject.IsNULL<int>(reader["PersonalDocumentsID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["FileName"]),
                     DataAccessObject.IsNULL<string>(reader["FileLocationUrl"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_PersonalDocuments;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_PersonalDocuments  GetHR_PersonalDocumentsByPersonalDocumentsID(int  personalDocumentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_PersonalDocumentsByPersonalDocumentsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Value = personalDocumentsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_PersonalDocumentsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_PersonalDocuments(HR_PersonalDocuments hR_PersonalDocuments)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_PersonalDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_PersonalDocuments.EmployeeID;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = hR_PersonalDocuments.FileName;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = hR_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_PersonalDocuments.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_PersonalDocuments.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_PersonalDocuments.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_PersonalDocuments.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PersonalDocumentsID"].Value;
        }
    }

    public bool UpdateHR_PersonalDocuments(HR_PersonalDocuments hR_PersonalDocuments)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_PersonalDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Value = hR_PersonalDocuments.PersonalDocumentsID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_PersonalDocuments.EmployeeID;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = hR_PersonalDocuments.FileName;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = hR_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = hR_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@FileLocationUrl", SqlDbType.NVarChar).Value = hR_PersonalDocuments.FileLocationUrl;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_PersonalDocuments.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_PersonalDocuments.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_PersonalDocuments(int personalDocumentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_PersonalDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonalDocumentsID", SqlDbType.Int).Value = personalDocumentsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

