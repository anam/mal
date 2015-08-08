using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ProgramProvider:DataAccessObject
{
	public SqlSTD_ProgramProvider()
    {
    }


    public DataSet  GetAllSTD_Programs()
    {
        DataSet STD_Programs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Programs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Programs);
            myadapter.Dispose();
            connection.Close();

            return STD_Programs;
        }
    }
	public DataSet GetSTD_ProgramPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ProgramPageWise", connection))
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


    public STD_Program  GetSTD_ProgramByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ProgramByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ProgramFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_Program()
    {
        DataSet STD_Programs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Program", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Programs);
            myadapter.Dispose();
            connection.Close();

            return STD_Programs;
        }
    }
    public List<STD_Program> GetSTD_ProgramsFromReader(IDataReader reader)
    {
        List<STD_Program> sTD_Programs = new List<STD_Program>();

        while (reader.Read())
        {
            sTD_Programs.Add(GetSTD_ProgramFromReader(reader));
        }
        return sTD_Programs;
    }

    public STD_Program GetSTD_ProgramFromReader(IDataReader reader)
    {
        try
        {
            STD_Program sTD_Program = new STD_Program
                (

                     DataAccessObject.IsNULL<int>(reader["ProgramID"]),
                     DataAccessObject.IsNULL<string>(reader["ProgramName"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<decimal>(reader["Duration"]),
                     DataAccessObject.IsNULL<decimal>(reader["Cost"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Program;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Program  GetSTD_ProgramByProgramID(int  programID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ProgramByProgramID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProgramID", SqlDbType.Int).Value = programID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ProgramFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Program(STD_Program sTD_Program)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Program", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ProgramName", SqlDbType.NVarChar).Value = sTD_Program.ProgramName;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Program.CourseID;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Program.Description;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = sTD_Program.Duration;
            cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = sTD_Program.Cost;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Program.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Program.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Program.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Program.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProgramID"].Value;
        }
    }

    public bool UpdateSTD_Program(STD_Program sTD_Program)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Program", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Value = sTD_Program.ProgramID;
            cmd.Parameters.Add("@ProgramName", SqlDbType.NVarChar).Value = sTD_Program.ProgramName;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Program.CourseID;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Program.Description;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = sTD_Program.Duration;
            cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = sTD_Program.Cost;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Program.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Program.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Program(int programID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Program", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Value = programID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

