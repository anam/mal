using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ExamDetailsStudentProvider:DataAccessObject
{
	public SqlSTD_ExamDetailsStudentProvider()
    {
    }


    public DataSet  GetAllSTD_ExamDetailsStudents()
    {
        DataSet STD_ExamDetailsStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamDetailsStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailsStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailsStudents;
        }
    }
	public DataSet GetSTD_ExamDetailsStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentPageWise", connection))
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


    public STD_ExamDetailsStudent  GetSTD_ExamDetailsStudentByExamDetailsID(int  examDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentByExamDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamDetailsID", SqlDbType.NVarChar).Value = examDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamDetailsStudent  GetSTD_ExamDetailsStudentByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamDetailsStudent  GetSTD_ExamDetailsStudentByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ExamDetailsStudent()
    {
        DataSet STD_ExamDetailsStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ExamDetailsStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailsStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailsStudents;
        }
    }

    public DataSet   GetAllSTD_ExamDetailsStudentsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamDetailsStudentsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ExamDetailsStudent> GetSTD_ExamDetailsStudentsFromReader(IDataReader reader)
    {
        List<STD_ExamDetailsStudent> sTD_ExamDetailsStudents = new List<STD_ExamDetailsStudent>();

        while (reader.Read())
        {
            sTD_ExamDetailsStudents.Add(GetSTD_ExamDetailsStudentFromReader(reader));
        }
        return sTD_ExamDetailsStudents;
    }

    public STD_ExamDetailsStudent GetSTD_ExamDetailsStudentFromReader(IDataReader reader)
    {
        try
        {
            STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent
                (

                     DataAccessObject.IsNULL<int>(reader["ExamDetailsStudentID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamDetailsStudentName"]),
                     DataAccessObject.IsNULL<int>(reader["ExamDetailsID"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<decimal>(reader["ObtainedMark"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return sTD_ExamDetailsStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ExamDetailsStudent  GetSTD_ExamDetailsStudentByExamDetailsStudentID(int  examDetailsStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentByExamDetailsStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamDetailsStudentID", SqlDbType.Int).Value = examDetailsStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ExamDetailsStudent(STD_ExamDetailsStudent sTD_ExamDetailsStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ExamDetailsStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamDetailsStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamDetailsStudentName", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExamDetailsStudentName;
            cmd.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = sTD_ExamDetailsStudent.ExamDetailsID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.StudentID;
            cmd.Parameters.Add("@ObtainedMark", SqlDbType.Decimal).Value = sTD_ExamDetailsStudent.ObtainedMark;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ExamDetailsStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamDetailsStudent.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamDetailsStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamDetailsStudentID"].Value;
        }
    }

    public bool UpdateSTD_ExamDetailsStudent(STD_ExamDetailsStudent sTD_ExamDetailsStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ExamDetailsStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamDetailsStudentID", SqlDbType.Int).Value = sTD_ExamDetailsStudent.ExamDetailsStudentID;
            cmd.Parameters.Add("@ExamDetailsStudentName", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExamDetailsStudentName;
            cmd.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = sTD_ExamDetailsStudent.ExamDetailsID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.StudentID;
            cmd.Parameters.Add("@ObtainedMark", SqlDbType.Decimal).Value = sTD_ExamDetailsStudent.ObtainedMark;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamDetailsStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamDetailsStudent.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamDetailsStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ExamDetailsStudent(int examDetailsStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ExamDetailsStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamDetailsStudentID", SqlDbType.Int).Value = examDetailsStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_StudentsObtainMarkByExamID(int examID)
    {
        DataSet STD_ExamDetailsStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentsObtainMarkByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailsStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailsStudents;
        }
    }

    public DataSet GetSTD_ExamResultByStudentID(string studentID)
    {
        DataSet STD_ExamDetailsStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamResultByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailsStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailsStudents;
        }
    }
}

