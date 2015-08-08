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

public class SqlSTD_ArchiveProvider:DataAccessObject
{
	public SqlSTD_ArchiveProvider()
    {
    }


    public bool DeleteSTD_Archive(int sTD_ArchiveID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_DeleteSTD_Archive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STD_ArchiveID", SqlDbType.Int).Value = sTD_ArchiveID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STD_Archive> GetAllSTD_Archives()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetAllSTD_Archives", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTD_ArchivesFromReader(reader);
        }
    }
    public List<STD_Archive> GetSTD_ArchivesFromReader(IDataReader reader)
    {
        List<STD_Archive> sTD_Archives = new List<STD_Archive>();

        while (reader.Read())
        {
            sTD_Archives.Add(GetSTD_ArchiveFromReader(reader));
        }
        return sTD_Archives;
    }

    public STD_Archive GetSTD_ArchiveFromReader(IDataReader reader)
    {
        try
        {
            STD_Archive sTD_Archive = new STD_Archive
                (
                    (int)reader["STD_ArchiveID"],
                    reader["Archive"].ToString(),
                    (DateTime)reader["AddedDate"]
                );
             return sTD_Archive;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Archive GetSTD_ArchiveByID(int sTD_ArchiveID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetSTD_ArchiveByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STD_ArchiveID", SqlDbType.Int).Value = sTD_ArchiveID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSTD_ArchiveFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSTD_Archive(STD_Archive sTD_Archive)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_InsertSTD_Archive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STD_ArchiveID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Archive", SqlDbType.NText).Value = sTD_Archive.Archive;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Archive.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@STD_ArchiveID"].Value;
        }
    }

    public bool UpdateSTD_Archive(STD_Archive sTD_Archive)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_UpdateSTD_Archive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STD_ArchiveID", SqlDbType.Int).Value = sTD_Archive.STD_ArchiveID;
            cmd.Parameters.Add("@Archive", SqlDbType.NText).Value = sTD_Archive.Archive;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Archive.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
