using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ExamStudentProvider:DataAccessObject
{
	public SqlSTD_ExamStudentProvider()
    {
    }


    public DataSet  GetAllSTD_ExamStudents()
    {
        DataSet STD_ExamStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamStudents;
        }
    }
	public DataSet GetSTD_ExamStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamStudentPageWise", connection))
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


    public STD_ExamStudent  GetSTD_ExamStudentByExamID(int  examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamStudentByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.NVarChar).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamStudent  GetSTD_ExamStudentByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_ExamStudent()
    {
        DataSet STD_ExamStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ExamStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamStudents;
        }
    }

    public DataSet   GetAllSTD_QuestionAnswersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionAnswersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ExamStudent> GetSTD_ExamStudentsFromReader(IDataReader reader)
    {
        List<STD_ExamStudent> sTD_ExamStudents = new List<STD_ExamStudent>();

        while (reader.Read())
        {
            sTD_ExamStudents.Add(GetSTD_ExamStudentFromReader(reader));
        }
        return sTD_ExamStudents;
    }

    public STD_ExamStudent GetSTD_ExamStudentFromReader(IDataReader reader)
    {
        try
        {
            STD_ExamStudent sTD_ExamStudent = new STD_ExamStudent
                (

                     DataAccessObject.IsNULL<int>(reader["ExamStudentID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamStudent"]),
                     DataAccessObject.IsNULL<int>(reader["ExamID"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<decimal>(reader["ObtainedMark"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_ExamStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ExamStudent  GetSTD_ExamStudentByExamStudentID(int  examStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamStudentByExamStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = examStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ExamStudent(STD_ExamStudent sTD_ExamStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamStudent", SqlDbType.NVarChar).Value = sTD_ExamStudent.ExamStudent;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = sTD_ExamStudent.ExamID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ExamStudent.StudentID;
            cmd.Parameters.Add("@ObtainedMark", SqlDbType.Decimal).Value = sTD_ExamStudent.ObtainedMark;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ExamStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ExamStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ExamStudent.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamStudentID"].Value;
        }
    }

    public bool UpdateSTD_ExamStudent(STD_ExamStudent sTD_ExamStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = sTD_ExamStudent.ExamStudentID;
            cmd.Parameters.Add("@ExamStudent", SqlDbType.NVarChar).Value = sTD_ExamStudent.ExamStudent;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = sTD_ExamStudent.ExamID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ExamStudent.StudentID;
            cmd.Parameters.Add("@ObtainedMark", SqlDbType.Decimal).Value = sTD_ExamStudent.ObtainedMark;
            //cmd.Parameters.Add("@ObtainedMark", SqlDbType.Decimal).Value = sTD_ExamStudent.ObtainedMark;
            //cmd.Parameters.Add("@ObtainedMark", SqlDbType.Decimal).Value = sTD_ExamStudent.ObtainedMark;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ExamStudent.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ExamStudent(int examStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = examStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

