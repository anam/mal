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

public class SqlAttencenceIDProvider:DataAccessObject
{
	public SqlAttencenceIDProvider()
    {
    }


    public bool DeleteAttencenceID(int attencenceIDID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cucwebappdb_DeleteAttencenceID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttencenceIDID", SqlDbType.Int).Value = attencenceIDID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<AttencenceID> GetAllAttencenceIDs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cucwebappdb_GetAllAttencenceIDs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttencenceIDsFromReader(reader);
        }
    }
    public List<AttencenceID> GetAttencenceIDsFromReader(IDataReader reader)
    {
        List<AttencenceID> attencenceIDs = new List<AttencenceID>();

        while (reader.Read())
        {
            attencenceIDs.Add(GetAttencenceIDFromReader(reader));
        }
        return attencenceIDs;
    }

    public AttencenceID GetAttencenceIDFromReader(IDataReader reader)
    {
        try
        {
            AttencenceID attencenceID = new AttencenceID
                (
                    (int)reader["AttencenceIDID"],
                    reader["UserID"].ToString(),
                    (DateTime)reader["InOutTime"],
                    reader["ExtraField1"].ToString(),
                    reader["ExtraFileld2"].ToString()
                );
             return attencenceID;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public AttencenceID GetAttencenceIDByID(int attencenceIDID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cucwebappdb_GetAttencenceIDByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AttencenceIDID", SqlDbType.Int).Value = attencenceIDID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAttencenceIDFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAttencenceID(AttencenceID attencenceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cucwebappdb_InsertAttencenceID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttencenceIDID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = attencenceID.UserID;
            cmd.Parameters.Add("@InOutTime", SqlDbType.DateTime).Value = attencenceID.InOutTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = attencenceID.ExtraField1;
            cmd.Parameters.Add("@ExtraFileld2", SqlDbType.NVarChar).Value = attencenceID.ExtraFileld2;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AttencenceIDID"].Value;
        }
    }

    public bool UpdateAttencenceID(AttencenceID attencenceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cucwebappdb_UpdateAttencenceID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttencenceIDID", SqlDbType.Int).Value = attencenceID.AttencenceIDID;
            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = attencenceID.UserID;
            cmd.Parameters.Add("@InOutTime", SqlDbType.DateTime).Value = attencenceID.InOutTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = attencenceID.ExtraField1;
            cmd.Parameters.Add("@ExtraFileld2", SqlDbType.NVarChar).Value = attencenceID.ExtraFileld2;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
