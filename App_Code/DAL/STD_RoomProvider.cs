using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_RoomProvider:DataAccessObject
{
	public SqlSTD_RoomProvider()
    {
    }


    public DataSet  GetAllSTD_Rooms()
    {
        DataSet STD_Rooms = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Rooms", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Rooms);
            myadapter.Dispose();
            connection.Close();

            return STD_Rooms;
        }
    }
	public DataSet GetSTD_RoomPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_RoomPageWise", connection))
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


    public STD_Room  GetSTD_RoomByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoomByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoomFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_Room()
    {
        DataSet STD_Rooms = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Rooms", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Rooms);
            myadapter.Dispose();
            connection.Close();

            return STD_Rooms;
        }
    }

    public DataSet   GetAllSTD_RoomsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_RoomsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Room> GetSTD_RoomsFromReader(IDataReader reader)
    {
        List<STD_Room> sTD_Rooms = new List<STD_Room>();

        while (reader.Read())
        {
            sTD_Rooms.Add(GetSTD_RoomFromReader(reader));
        }
        return sTD_Rooms;
    }

    public STD_Room GetSTD_RoomFromReader(IDataReader reader)
    {
        try
        {
            STD_Room sTD_Room = new STD_Room
                (

                     DataAccessObject.IsNULL<int>(reader["RoomID"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["RoomName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Room;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Room  GetSTD_RoomByRoomID(int  roomID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoomByRoomID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoomFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_RoomByCampusID(long campusID)
    {
        DataSet STD_Rooms = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoomByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Rooms);
            myadapter.Dispose();
            connection.Close();

            return STD_Rooms;
        }
    }



    public int InsertSTD_Room(STD_Room sTD_Room)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Room", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = sTD_Room.CampusID;
            cmd.Parameters.Add("@RoomName", SqlDbType.NVarChar).Value = sTD_Room.RoomName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Room.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Room.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Room.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Room.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Room.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RoomID"].Value;
        }
    }

    public bool UpdateSTD_Room(STD_Room sTD_Room)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Room", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = sTD_Room.RoomID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = sTD_Room.CampusID;
            cmd.Parameters.Add("@RoomName", SqlDbType.NVarChar).Value = sTD_Room.RoomName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Room.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Room.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Room.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Room.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Room.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Room(int roomID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Room", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

