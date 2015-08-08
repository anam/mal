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

public class SqlAttencenceProvider:DataAccessObject
{
	public SqlAttencenceProvider()
    {
    }


    public bool DeleteAttencence(int attencenceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cucwebappdb_DeleteAttencence", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttencenceID", SqlDbType.Int).Value = attencenceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Attencence> GetAllAttencences()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cucwebappdb_GetAllAttencences", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttencencesFromReader(reader);
        }
    }
    public List<Attencence> GetAttencencesFromReader(IDataReader reader)
    {
        List<Attencence> attencences = new List<Attencence>();

        while (reader.Read())
        {
            attencences.Add(GetAttencenceFromReader(reader));
        }
        return attencences;
    }

    public Attencence GetAttencenceFromReader(IDataReader reader)
    {
        try
        {
            Attencence attencence = new Attencence
                (
                    (int)reader["AttencenceID"],
                    reader["UserID"].ToString(),
                    (DateTime)reader["InOutTime"],
                    reader["ExtraField1"].ToString(),
                    reader["ExtraFileld2"].ToString()
                );
             return attencence;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Attencence GetAttencenceByID(int attencenceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cucwebappdb_GetAttencenceByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AttencenceID", SqlDbType.Int).Value = attencenceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAttencenceFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAttencence(Attencence attencence)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cucwebappdb_InsertAttencence", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttencenceID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = attencence.UserID;
            cmd.Parameters.Add("@InOutTime", SqlDbType.DateTime).Value = attencence.InOutTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = attencence.ExtraField1;
            cmd.Parameters.Add("@ExtraFileld2", SqlDbType.NVarChar).Value = attencence.ExtraFileld2;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AttencenceID"].Value;
        }
    }

    public bool UpdateAttencence(Attencence attencence)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cucwebappdb_UpdateAttencence", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttencenceID", SqlDbType.Int).Value = attencence.AttencenceID;
            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = attencence.UserID;
            cmd.Parameters.Add("@InOutTime", SqlDbType.DateTime).Value = attencence.InOutTime;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = attencence.ExtraField1;
            cmd.Parameters.Add("@ExtraFileld2", SqlDbType.NVarChar).Value = attencence.ExtraFileld2;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
