using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_RoutineTimeProvider:DataAccessObject
{
	public SqlSTD_RoutineTimeProvider()
    {
    }


    public DataSet  GetAllSTD_RoutineTimes()
    {
        DataSet STD_RoutineTimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_RoutineTimes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_RoutineTimes);
            myadapter.Dispose();
            connection.Close();

            return STD_RoutineTimes;
        }
    }

    public DataSet GetAllSTD_RoutineTimesByClassSubjectTeacher(int ClassID,int SubjectID,string teacherID)
    {
        DataSet STD_RoutineTimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_RoutineTimesByClassSubjectTeacher", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@SubjectID", SubjectID);
            command.Parameters.AddWithValue("@TeacherID", teacherID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_RoutineTimes);
            myadapter.Dispose();
            connection.Close();

            return STD_RoutineTimes;
        }
    }

	public DataSet GetSTD_RoutineTimePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_RoutineTimePageWise", connection))
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

    public DataSet STD_SearchRoutineTime(STD_RoutineTime routineTime, string studentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("STD_SearchRoutineTime", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoutineID", routineTime.RoutineID);
                command.Parameters.AddWithValue("@ClassID", routineTime.ClassID);
                command.Parameters.AddWithValue("@RoomID", routineTime.RoomID);
                command.Parameters.AddWithValue("@SubjectID", routineTime.SubjectID);
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@EmployeeID", routineTime.EmployeeID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet STD_SearchRoutineTimeForRoutineCheck(STD_RoutineTime routineTime, string studentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("STD_SearchRoutineTimeForRoutineCheck", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", routineTime.ClassID);
                command.Parameters.AddWithValue("@RoomID", routineTime.RoomID);
                command.Parameters.AddWithValue("@SubjectID", routineTime.SubjectID);
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@EmployeeID", routineTime.EmployeeID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }




    public STD_RoutineTime  GetSTD_RoutineTimeByRoomID(int  roomID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByRoomID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoomID", SqlDbType.NVarChar).Value = roomID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeByClassID(int  classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = classID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeByClassDayID(int  classDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByClassDayID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassDayID", SqlDbType.NVarChar).Value = classDayID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeByClassTimeID(int  classTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByClassTimeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassTimeID", SqlDbType.NVarChar).Value = classTimeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeByRoutineID(int  routineID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByRoutineID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoutineID", SqlDbType.NVarChar).Value = routineID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_RoutineTime()
    {
        DataSet STD_RoutineTimes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_RoutineTime", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_RoutineTimes);
            myadapter.Dispose();
            connection.Close();

            return STD_RoutineTimes;
        }
    }

    public DataSet   GetAllSTD_RoutineTimesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_RoutineTimesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_RoutineTime> GetSTD_RoutineTimesFromReader(IDataReader reader)
    {
        List<STD_RoutineTime> sTD_RoutineTimes = new List<STD_RoutineTime>();

        while (reader.Read())
        {
            sTD_RoutineTimes.Add(GetSTD_RoutineTimeFromReader(reader));
        }
        return sTD_RoutineTimes;
    }

    public STD_RoutineTime GetSTD_RoutineTimeFromReader(IDataReader reader)
    {
        try
        {
            STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime
                (

                     DataAccessObject.IsNULL<int>(reader["RoutineTimeID"]),
                     DataAccessObject.IsNULL<string>(reader["RoutineTimeName"]),
                     DataAccessObject.IsNULL<int>(reader["RoomID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ClassID"]),
                     DataAccessObject.IsNULL<int>(reader["ClassDayID"]),
                     DataAccessObject.IsNULL<int>(reader["ClassTimeID"]),
                     DataAccessObject.IsNULL<int>(reader["RoutineID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_RoutineTime;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_RoutineTime  GetSTD_RoutineTimeByRoutineTimeID(int  routineTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByRoutineTimeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoutineTimeID", SqlDbType.Int).Value = routineTimeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineTimeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_RoutineTime(STD_RoutineTime sTD_RoutineTime)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_RoutineTime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoutineTimeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RoutineTimeName", SqlDbType.NVarChar).Value = sTD_RoutineTime.RoutineTimeName;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = sTD_RoutineTime.RoomID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_RoutineTime.SubjectID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = sTD_RoutineTime.EmployeeID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_RoutineTime.ClassID;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = sTD_RoutineTime.ClassDayID;
            cmd.Parameters.Add("@ClassTimeID", SqlDbType.Int).Value = sTD_RoutineTime.ClassTimeID;
            cmd.Parameters.Add("@RoutineID", SqlDbType.Int).Value = sTD_RoutineTime.RoutineID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_RoutineTime.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_RoutineTime.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_RoutineTime.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_RoutineTime.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RoutineTimeID"].Value;
        }
    }

    public bool UpdateSTD_RoutineTime(STD_RoutineTime sTD_RoutineTime)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_RoutineTime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoutineTimeID", SqlDbType.Int).Value = sTD_RoutineTime.RoutineTimeID;
            cmd.Parameters.Add("@RoutineTimeName", SqlDbType.NVarChar).Value = sTD_RoutineTime.RoutineTimeName;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = sTD_RoutineTime.RoomID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_RoutineTime.SubjectID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = sTD_RoutineTime.EmployeeID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_RoutineTime.ClassID;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = sTD_RoutineTime.ClassDayID;
            cmd.Parameters.Add("@ClassTimeID", SqlDbType.Int).Value = sTD_RoutineTime.ClassTimeID;
            cmd.Parameters.Add("@RoutineID", SqlDbType.Int).Value = sTD_RoutineTime.RoutineID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_RoutineTime.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_RoutineTime.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_RoutineTime(int routineTimeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_RoutineTime", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoutineTimeID", SqlDbType.Int).Value = routineTimeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

