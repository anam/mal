using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ExamProvider:DataAccessObject
{
	public SqlSTD_ExamProvider()
    {
    }


    public DataSet  GetAllSTD_Exams()
    {
        DataSet STD_Exams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Exams", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Exams);
            myadapter.Dispose();
            connection.Close();

            return STD_Exams;
        }
    }
	public DataSet GetSTD_ExamPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamPageWise", connection))
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


    public STD_Exam  GetSTD_ExamByClassSubjectID(int  classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamByClassSubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectID", SqlDbType.NVarChar).Value = classSubjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_ExamByClassSubjectID(int classSubjectID,bool isDataset)
    {
       

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamByClassSubjectID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassSubjectID", classSubjectID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetQuiz_ExamByClassSubjectID(int classSubjectID, bool isDataset)
    {


        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamByClassSubjectID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassSubjectID", classSubjectID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public STD_Exam  GetSTD_ExamByExamTypeID(int  examTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamByExamTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamTypeID", SqlDbType.NVarChar).Value = examTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_Exam  GetSTD_ExamByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_Exam()
    {
        DataSet STD_Exams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Exam", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Exams);
            myadapter.Dispose();
            connection.Close();

            return STD_Exams;
        }
    }

    public DataSet   GetAllSTD_ExamsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Exam> GetSTD_ExamsFromReader(IDataReader reader)
    {
        List<STD_Exam> sTD_Exams = new List<STD_Exam>();

        while (reader.Read())
        {
            sTD_Exams.Add(GetSTD_ExamFromReader(reader));
        }
        return sTD_Exams;
    }

    public STD_Exam GetSTD_ExamFromReader(IDataReader reader)
    {
        try
        {
            STD_Exam sTD_Exam = new STD_Exam
                (

                     DataAccessObject.IsNULL<int>(reader["ExamID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["ClassSubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ExamTypeID"]),
                     DataAccessObject.IsNULL<Decimal>(reader["TotalMarks"]),
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
             return sTD_Exam;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Exam  GetSTD_ExamByExamID(int  examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Exam(STD_Exam sTD_Exam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Exam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamName", SqlDbType.NVarChar).Value = sTD_Exam.ExamName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Exam.Description;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_Exam.ClassSubjectID;
            cmd.Parameters.Add("@ExamTypeID", SqlDbType.Int).Value = sTD_Exam.ExamTypeID;
            cmd.Parameters.Add("@TotalMarks", SqlDbType.Decimal).Value = sTD_Exam.TotalMarks;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Exam.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Exam.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Exam.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_Exam.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Exam.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamID"].Value;
        }
    }

    public bool UpdateSTD_Exam(STD_Exam sTD_Exam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Exam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = sTD_Exam.ExamID;
            cmd.Parameters.Add("@ExamName", SqlDbType.NVarChar).Value = sTD_Exam.ExamName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Exam.Description;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_Exam.ClassSubjectID;
            cmd.Parameters.Add("@ExamTypeID", SqlDbType.Int).Value = sTD_Exam.ExamTypeID;
            cmd.Parameters.Add("@TotalMarks", SqlDbType.Decimal).Value = sTD_Exam.TotalMarks;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_Exam.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Exam.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_Exam.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Exam.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Exam(int examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Exam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_ExamTeacherByExamID(int examID)
    {
        DataSet STD_Exams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamTeacherByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Exams);
            myadapter.Dispose();
            connection.Close();

            return STD_Exams;
        }
    }
}

