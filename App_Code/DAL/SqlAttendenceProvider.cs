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

public class SqlAttendenceProvider:DataAccessObject
{
	public SqlAttendenceProvider()
    {
    }


    public bool DeleteAttendence(int attendenceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("COMN_DeleteAttendence", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendenceID", SqlDbType.Int).Value = attendenceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Attendence> GetAllAttendences()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_GetAllAttendences", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttendencesFromReader(reader);
        }
    }

    public List<Attendence> GetAllAttendencesByUserID(string UserID,string date)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_GetAllAttendencesByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Date", date);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttendencesFromReader(reader);
        }
    }

    public List<Attendence> GetAllAttendencesByDate(string date)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_AttendenceByDate", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@datetoday", date);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttendencesFromReader(reader);
        }
    }


    public List<Attendence> GetAllAttendencesByDateForStudent(string date)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_AttendenceByDateForStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@datetoday", date);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttendencesFromReader(reader);
        }
    }


    public List<Attendence> GetAllAttendencesByDateJustPresent(string date)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_AttendenceByDateJustPresent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@datetoday", date);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttendencesFromReader(reader);
        }
    }


    public List<Attendence> GetAllAttendencesByDateForTeacher(string date)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_AttendenceByDateForTeacher", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@datetoday", date);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAttendencesFromReader(reader);
        }
    }



    public List<Attendence> GetAttendencesFromReader(IDataReader reader)
    {
        List<Attendence> attendences = new List<Attendence>();

        while (reader.Read())
        {
            attendences.Add(GetAttendenceFromReader(reader));
        }
        return attendences;
    }

    public Attendence GetAttendenceFromReader(IDataReader reader)
    {
        try
        {
            Attendence attendence = new Attendence
            (
                (int)reader["AttendenceID"],
                reader["UserID"].ToString(),
                (DateTime)reader["InOutTime"]
            );

            try
            {
                attendence.UserName = reader["UserName"].ToString();
            }
            catch(Exception ex)
            {
            
            }

            try
            {
                attendence.ID = reader["EmployeeID"].ToString();
            }
            catch (Exception ex)
            {

            }  

            return attendence;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Attendence GetAttendenceByID(int attendenceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("COMN_GetAttendenceByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AttendenceID", SqlDbType.Int).Value = attendenceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAttendenceFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAttendence(Attendence attendence)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("COMN_InsertAttendence", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendenceID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@UserID",  attendence.UserID );
            cmd.Parameters.Add("@InOutTime", SqlDbType.DateTime).Value = attendence.InOutTime;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AttendenceID"].Value;
        }
    }

    public bool UpdateAttendence(Attendence attendence)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("COMN_UpdateAttendence", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendenceID", SqlDbType.Int).Value = attendence.AttendenceID;
            cmd.Parameters.AddWithValue("@UserID", attendence.UserID);
            cmd.Parameters.Add("@InOutTime", SqlDbType.DateTime).Value = attendence.InOutTime;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
