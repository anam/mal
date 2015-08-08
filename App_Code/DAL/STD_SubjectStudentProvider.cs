using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_SubjectStudentProvider:DataAccessObject
{
	public SqlSTD_SubjectStudentProvider()
    {
    }


    public DataSet  GetAllSTD_SubjectStudents()
    {
        DataSet STD_SubjectStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_SubjectStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_SubjectStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_SubjectStudents;
        }
    }
	public DataSet GetSTD_SubjectStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectStudentPageWise", connection))
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


    public STD_SubjectStudent  GetSTD_SubjectStudentByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_SubjectStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_SubjectStudentByStudentID(string studentID,bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectStudentByStudentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetSTD_SubjectStudentByStudentIDWithHistory(string studentID, bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectStudentByStudentIDWithHistory", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public STD_SubjectStudent  GetSTD_SubjectStudentBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectStudentBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_SubjectStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_SubjectStudent  GetSTD_SubjectStudentByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectStudentByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_SubjectStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_SubjectStudent()
    {
        DataSet STD_SubjectStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_SubjectStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_SubjectStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_SubjectStudents;
        }
    }

    public DataSet   GetAllSTD_SubjectStudentsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_SubjectStudentsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_SubjectStudent> GetSTD_SubjectStudentsFromReader(IDataReader reader)
    {
        List<STD_SubjectStudent> sTD_SubjectStudents = new List<STD_SubjectStudent>();

        while (reader.Read())
        {
            sTD_SubjectStudents.Add(GetSTD_SubjectStudentFromReader(reader));
        }
        return sTD_SubjectStudents;
    }

    public STD_SubjectStudent GetSTD_SubjectStudentFromReader(IDataReader reader)
    {
        try
        {
            STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent
                (

                     DataAccessObject.IsNULL<int>(reader["SubjectStudentID"]),
                     DataAccessObject.IsNULL<string>(reader["SubjectStudentName"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return sTD_SubjectStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_SubjectStudent  GetSTD_SubjectStudentBySubjectStudentID(int  subjectStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectStudentBySubjectStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectStudentID", SqlDbType.Int).Value = subjectStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_SubjectStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_SubjectStudent(STD_SubjectStudent sTD_SubjectStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_SubjectStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubjectStudentName", SqlDbType.NVarChar).Value = sTD_SubjectStudent.SubjectStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_SubjectStudent.StudentID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_SubjectStudent.SubjectID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_SubjectStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_SubjectStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_SubjectStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_SubjectStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_SubjectStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SubjectStudentID"].Value;
        }
    }

    public bool UpdateSTD_SubjectStudent(STD_SubjectStudent sTD_SubjectStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_SubjectStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectStudentID", SqlDbType.Int).Value = sTD_SubjectStudent.SubjectStudentID;
            cmd.Parameters.Add("@SubjectStudentName", SqlDbType.NVarChar).Value = sTD_SubjectStudent.SubjectStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_SubjectStudent.StudentID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_SubjectStudent.SubjectID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_SubjectStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_SubjectStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_SubjectStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_SubjectStudent(int subjectStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_SubjectStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectStudentID", SqlDbType.Int).Value = subjectStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

