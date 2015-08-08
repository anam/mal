using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_ExamStudentProvider:DataAccessObject
{
	public SqlQuiz_ExamStudentProvider()
    {
    }


    public DataSet  GetAllQuiz_ExamStudents()
    {
        DataSet Quiz_ExamStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_ExamStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_ExamStudents);
            myadapter.Dispose();
            connection.Close();

            return Quiz_ExamStudents;
        }
    }
	public DataSet GetQuiz_ExamStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamStudentPageWise", connection))
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


    public DataSet GetQuiz_ExamStudentPageWiseByStudent(int pageIndex, int PageSize, out int recordCount,string studentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamStudentPageWiseByStudent", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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


    public Quiz_ExamStudent  GetQuiz_ExamStudentByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_ExamStudent  GetQuiz_ExamStudentByClassSubjectID(int  classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamStudentByClassSubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectID", SqlDbType.NVarChar).Value = classSubjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_ExamStudent  GetQuiz_ExamStudentBySTDExamDetailsID(int  sTDExamDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamStudentBySTDExamDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STDExamDetailsID", SqlDbType.NVarChar).Value = sTDExamDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_ExamStudent  GetQuiz_ExamStudentByQuizExamID(int  quizExamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamStudentByQuizExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuizExamID", SqlDbType.NVarChar).Value = quizExamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_ExamStudent  GetQuiz_ExamStudentByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamStudentByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllQuiz_ExamStudent()
    {
        DataSet Quiz_ExamStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_ExamStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_ExamStudents);
            myadapter.Dispose();
            connection.Close();

            return Quiz_ExamStudents;
        }
    }
    public List<Quiz_ExamStudent> GetQuiz_ExamStudentsFromReader(IDataReader reader)
    {
        List<Quiz_ExamStudent> quiz_ExamStudents = new List<Quiz_ExamStudent>();

        while (reader.Read())
        {
            quiz_ExamStudents.Add(GetQuiz_ExamStudentFromReader(reader));
        }
        return quiz_ExamStudents;
    }

    public Quiz_ExamStudent GetQuiz_ExamStudentFromReader(IDataReader reader)
    {
        try
        {
            Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent
                (

                     DataAccessObject.IsNULL<int>(reader["ExamStudentID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamStudentName"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ClassSubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["STDExamDetailsID"]),
                     DataAccessObject.IsNULL<int>(reader["QuizExamID"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return quiz_ExamStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_ExamStudent  GetQuiz_ExamStudentByExamStudentID(int  examStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamStudentByExamStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = examStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_ExamStudent(Quiz_ExamStudent quiz_ExamStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamStudentName", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExamStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = quiz_ExamStudent.StudentID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = quiz_ExamStudent.ClassSubjectID;
            cmd.Parameters.Add("@STDExamDetailsID", SqlDbType.Int).Value = quiz_ExamStudent.STDExamDetailsID;
            cmd.Parameters.Add("@QuizExamID", SqlDbType.Int).Value = quiz_ExamStudent.QuizExamID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_ExamStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_ExamStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = quiz_ExamStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = quiz_ExamStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = quiz_ExamStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamStudentID"].Value;
        }
    }

    public bool UpdateQuiz_ExamStudent(Quiz_ExamStudent quiz_ExamStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = quiz_ExamStudent.ExamStudentID;
            cmd.Parameters.Add("@ExamStudentName", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExamStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = quiz_ExamStudent.StudentID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = quiz_ExamStudent.ClassSubjectID;
            cmd.Parameters.Add("@STDExamDetailsID", SqlDbType.Int).Value = quiz_ExamStudent.STDExamDetailsID;
            cmd.Parameters.Add("@QuizExamID", SqlDbType.Int).Value = quiz_ExamStudent.QuizExamID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = quiz_ExamStudent.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = quiz_ExamStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = quiz_ExamStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = quiz_ExamStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_ExamStudent(int examStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = examStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool RowStatusChangeQuiz_ExamStudent(int examStudentID,int RowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("RowStatusChangeQuiz_ExamStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamStudentID", SqlDbType.Int).Value = examStudentID;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

