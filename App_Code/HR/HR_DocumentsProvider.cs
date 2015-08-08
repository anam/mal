using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_DocumentsProvider:DataAccessObject
{
	public SqlHR_DocumentsProvider()
    {
    }


    public DataSet  GetAllHR_Documentss()
    {
        DataSet HR_Documentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Documentss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Documentss);
            myadapter.Dispose();
            connection.Close();

            return HR_Documentss;
        }
    }
	public DataSet GetHR_DocumentsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_DocumentsPageWise", connection))
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


    public DataSet GetHR_DocumentsByEmployeeID(string employeeID)
    {
        DataSet HR_Documentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_DocumentsByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Documentss);
            myadapter.Dispose();
            connection.Close();

            return HR_Documentss;
        }
        
    }

    public DataSet  GetDropDownLisAllHR_Documents()
    {
        DataSet HR_Documentss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Documents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Documentss);
            myadapter.Dispose();
            connection.Close();

            return HR_Documentss;
        }
    }

    public DataSet   GetAllHR_DocumentssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_DocumentssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_Documents> GetHR_DocumentssFromReader(IDataReader reader)
    {
        List<HR_Documents> hR_Documentss = new List<HR_Documents>();

        while (reader.Read())
        {
            hR_Documentss.Add(GetHR_DocumentsFromReader(reader));
        }
        return hR_Documentss;
    }

    public HR_Documents GetHR_DocumentsFromReader(IDataReader reader)
    {
        try
        {
            HR_Documents hR_Documents = new HR_Documents
                (

                     DataAccessObject.IsNULL<int>(reader["DocumentsID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["CvDocs"]),
                     DataAccessObject.IsNULL<string>(reader["JobAgreement"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Documents;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Documents  GetHR_DocumentsByDocumentsID(int  documentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_DocumentsByDocumentsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DocumentsID", SqlDbType.Int).Value = documentsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_DocumentsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Documents(HR_Documents hR_Documents)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Documents", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DocumentsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Documents.EmployeeID;
            cmd.Parameters.Add("@CvDocs", SqlDbType.NVarChar).Value = hR_Documents.CvDocs;
            cmd.Parameters.Add("@JobAgreement", SqlDbType.NVarChar).Value = hR_Documents.JobAgreement;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Documents.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Documents.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Documents.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Documents.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DocumentsID"].Value;
        }
    }

    public bool UpdateHR_Documents(HR_Documents hR_Documents)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Documents", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DocumentsID", SqlDbType.Int).Value = hR_Documents.DocumentsID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Documents.EmployeeID;
            cmd.Parameters.Add("@CvDocs", SqlDbType.NVarChar).Value = hR_Documents.CvDocs;
            cmd.Parameters.Add("@JobAgreement", SqlDbType.NVarChar).Value = hR_Documents.JobAgreement;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Documents.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Documents.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Documents(int documentsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Documents", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DocumentsID", SqlDbType.Int).Value = documentsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

