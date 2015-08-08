using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_RoutineProvider:DataAccessObject
{
	public SqlSTD_RoutineProvider()
    {
    }


    public DataSet  GetAllSTD_Routines()
    {
        DataSet STD_Routines = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Routines", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Routines);
            myadapter.Dispose();
            connection.Close();

            return STD_Routines;
        }
    }
	public DataSet GetSTD_RoutinePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_RoutinePageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_Routine()
    {
        DataSet STD_Routines = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Routines", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Routines);
            myadapter.Dispose();
            connection.Close();

            return STD_Routines;
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
    public List<STD_Routine> GetSTD_RoutinesFromReader(IDataReader reader)
    {
        List<STD_Routine> sTD_Routines = new List<STD_Routine>();

        while (reader.Read())
        {
            sTD_Routines.Add(GetSTD_RoutineFromReader(reader));
        }
        return sTD_Routines;
    }

    public STD_Routine GetSTD_RoutineFromReader(IDataReader reader)
    {
        try
        {
            STD_Routine sTD_Routine = new STD_Routine
                (

                     DataAccessObject.IsNULL<int>(reader["RoutineID"]),
                     DataAccessObject.IsNULL<string>(reader["RoutineName"]),
                     DataAccessObject.IsNULL<DateTime>(reader["StartDate"]),
                     DataAccessObject.IsNULL<DateTime>(reader["EndDate"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Routine;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Routine  GetSTD_RoutineByRoutineID(int  routineID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_RoutineByRoutineID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoutineID", SqlDbType.Int).Value = routineID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_RoutineFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Routine(STD_Routine sTD_Routine)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Routine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoutineID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RoutineName", SqlDbType.NVarChar).Value = sTD_Routine.RoutineName;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = sTD_Routine.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = sTD_Routine.EndDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Routine.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Routine.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Routine.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Routine.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RoutineID"].Value;
        }
    }

    public bool UpdateSTD_Routine(STD_Routine sTD_Routine)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Routine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoutineID", SqlDbType.Int).Value = sTD_Routine.RoutineID;
            cmd.Parameters.Add("@RoutineName", SqlDbType.NVarChar).Value = sTD_Routine.RoutineName;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = sTD_Routine.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = sTD_Routine.EndDate;
            //cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = sTD_Routine.EndDate;
            //cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = sTD_Routine.EndDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Routine.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Routine.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Routine(int routineID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Routine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoutineID", SqlDbType.Int).Value = routineID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

