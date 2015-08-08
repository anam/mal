using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlFileProvider:DataAccessObject
{
	public SqlFileProvider()
    {
    }


    public bool DeleteFile(int fileID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_DeleteFile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FileID", SqlDbType.Int).Value = fileID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<COMN_File> GetAllFiles()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetAllFiles", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetFilesFromReader(reader);
        }
    }
    public List<COMN_File> GetFilesFromReader(IDataReader reader)
    {
        List<COMN_File> files = new List<COMN_File>();

        while (reader.Read())
        {
            files.Add(GetFileFromReader(reader));
        }
        return files;
    }

    public COMN_File GetFileFromReader(IDataReader reader)
    {
        try
        {
            COMN_File file = new COMN_File
                (
                    (int)reader["FileID"],
                    reader["FileContent"].ToString(),
                    (int)reader["RowStatusID"],
                    (DateTime)reader["AddedDate"],
                    reader["AddedBy"].ToString()
                );
             return file;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_File GetFileByID(int fileID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetFileByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FileID", SqlDbType.Int).Value = fileID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetFileFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertFile(COMN_File file)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_InsertFile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FileID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@FileContent", SqlDbType.NText).Value = file.FileContent;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = file.RowStatusID;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = file.AddedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = file.AddedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FileID"].Value;
        }
    }

    public bool UpdateFile(COMN_File file)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_UpdateFile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FileID", SqlDbType.Int).Value = file.FileID;
            cmd.Parameters.Add("@FileContent", SqlDbType.NText).Value = file.FileContent;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = file.RowStatusID;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = file.AddedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.UniqueIdentifier).Value = file.AddedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
