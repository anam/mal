using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_RoutineByValueProvider : DataAccessObject
{
    public SqlSTD_RoutineByValueProvider()
    {
    }


    public DataSet GetAllSTD_RoutineTimes()
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

    //public STD_RoutineTime GetSTD_RoutineTimeByRoomID(int roomID)
    //{
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByRoomID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@RoomID", SqlDbType.NVarChar).Value = roomID;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
    //        if (reader.Read())
    //        {
    //            return GetSTD_RoutineTimeFromReader(reader);
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}

    public DataSet GetSTD_RoutineTimeByStudentParams(string StudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {

            Guid gStudentID = new Guid(StudentID);

            SqlCommand command = new SqlCommand("GenerateRoutineByStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.UniqueIdentifier).Value = gStudentID;
            connection.Open();
            DataSet dsRoutine = new DataSet();
            SqlDataAdapter sdaRoutine = new SqlDataAdapter();
            sdaRoutine.SelectCommand = command;
            sdaRoutine.Fill(dsRoutine, "tblRoutine");
            connection.Close();
            return dsRoutine;
        }
    }
    public DataSet GetSTD_RoutineTimeByParams(string subjectID, string employeeID, string classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GenerateRoutineByValue", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            command.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = classID;
            connection.Open();
            DataSet dsRoutine = new DataSet();
            SqlDataAdapter sdaRoutine = new SqlDataAdapter();
            sdaRoutine.SelectCommand = command;
            sdaRoutine.Fill(dsRoutine, "tblRoutine");
            connection.Close();
            return dsRoutine;
        }
    }

    public DataSet GetSTD_ColumnNames()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetColumnNamesForRoutine", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            DataSet dsRoutine = new DataSet();
            SqlDataAdapter sdaRoutine = new SqlDataAdapter();
            sdaRoutine.SelectCommand = command;
            sdaRoutine.Fill(dsRoutine, "tblColumnNames");
            connection.Close();
            return dsRoutine;
        }
    }

    //public STD_RoutineTime GetSTD_RoutineTimeByEmployeeID(string employeeID)
    //{
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByEmployeeID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
    //        if (reader.Read())
    //        {
    //            return GetSTD_RoutineTimeFromReader(reader);
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}

    //public STD_RoutineTime GetSTD_RoutineTimeByClassID(int classID)
    //{
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByClassID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = classID;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
    //        if (reader.Read())
    //        {
    //            return GetSTD_RoutineTimeFromReader(reader);
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}

    //public STD_RoutineTime GetSTD_RoutineTimeByClassDayID(int classDayID)
    //{
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetSTD_RoutineTimeByClassDayID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@ClassDayID", SqlDbType.NVarChar).Value = classDayID;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
    //        if (reader.Read())
    //        {
    //            return GetSTD_RoutineTimeFromReader(reader);
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}

    public DataSet GetSTD_WeekDayName()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetWeekDayNameForRoutine", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            DataSet dsRoutine = new DataSet();
            SqlDataAdapter sdaRoutine = new SqlDataAdapter();
            sdaRoutine.SelectCommand = command;
            sdaRoutine.Fill(dsRoutine, "tblWeekDays");
            connection.Close();
            return dsRoutine;
        }
    }
}

