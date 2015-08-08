using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_OthersDocumentsProvider:DataAccessObject
{
	public SqlHR_OthersDocumentsProvider()
    {
    }


    public DataSet  GetAllHR_OthersDocumentss()
    {
        DataSet HR_OthersDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_OthersDocumentss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OthersDocumentss);
            myadapter.Dispose();
            connection.Close();

            return HR_OthersDocumentss;
        }
    }
	public DataSet GetHR_OthersDocumentsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_OthersDocumentsPageWise", connection))
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


    public DataSet GetHR_OthersDocumentsByEmployeeID(string employeeID)
    {
        DataSet HR_OthersDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OthersDocumentsByEmployeeID", connection);
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OthersDocumentss);
            myadapter.Dispose();
            connection.Close();

            return HR_OthersDocumentss;
        }
         
    }

    public DataSet  GetDropDownLisAllHR_OthersDocuments()
    {
        DataSet HR_OthersDocumentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_OthersDocuments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_OthersDocumentss);
            myadapter.Dispose();
            connection.Close();

            return HR_OthersDocumentss;
        }
    }

    public DataSet   GetAllHR_OthersDocumentssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_OthersDocumentssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_OthersDocuments> GetHR_OthersDocumentssFromReader(IDataReader reader)
    {
        List<HR_OthersDocuments> hR_OthersDocumentss = new List<HR_OthersDocuments>();

        while (reader.Read())
        {
            hR_OthersDocumentss.Add(GetHR_OthersDocumentsFromReader(reader));
        }
        return hR_OthersDocumentss;
    }

    public HR_OthersDocuments GetHR_OthersDocumentsFromReader(IDataReader reader)
    {
        try
        {
            HR_OthersDocuments hR_OthersDocuments = new HR_OthersDocuments
                (

                     DataAccessObject.IsNULL<int>(reader["OthersDocumentsID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["DocumentsType"]),
                     DataAccessObject.IsNULL<string>(reader["DocumentName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_OthersDocuments;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_OthersDocuments  GetHR_OthersDocumentsByOthersDocumentsID(int  othersDocumentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_OthersDocumentsByOthersDocumentsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OthersDocumentsID", SqlDbType.Int).Value = othersDocumentsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_OthersDocumentsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_OthersDocuments(HR_OthersDocuments hR_OthersDocuments)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_OthersDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OthersDocumentsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_OthersDocuments.EmployeeID;
            cmd.Parameters.Add("@DocumentsType", SqlDbType.NVarChar).Value = hR_OthersDocuments.DocumentsType;
            cmd.Parameters.Add("@DocumentName", SqlDbType.NVarChar).Value = hR_OthersDocuments.DocumentName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_OthersDocuments.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_OthersDocuments.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_OthersDocuments.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_OthersDocuments.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OthersDocumentsID"].Value;
        }
    }

    public bool UpdateHR_OthersDocuments(HR_OthersDocuments hR_OthersDocuments)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_OthersDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OthersDocumentsID", SqlDbType.Int).Value = hR_OthersDocuments.OthersDocumentsID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_OthersDocuments.EmployeeID;
            cmd.Parameters.Add("@DocumentsType", SqlDbType.NVarChar).Value = hR_OthersDocuments.DocumentsType;
            cmd.Parameters.Add("@DocumentName", SqlDbType.NVarChar).Value = hR_OthersDocuments.DocumentName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_OthersDocuments.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_OthersDocuments.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_OthersDocuments(int othersDocumentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_OthersDocuments", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OthersDocumentsID", SqlDbType.Int).Value = othersDocumentsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

