using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassSubjectStudentProvider:DataAccessObject
{
	public SqlSTD_ClassSubjectStudentProvider()
    {
    }


    public DataSet  GetAllSTD_ClassSubjectStudents()
    {
        DataSet STD_ClassSubjectStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjectStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectStudents;
        }
    }
	public DataSet GetSTD_ClassSubjectStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentPageWise", connection))
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

    public STD_ClassSubjectStudent GetSTD_ClassSubjectStudentByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassSubjectStudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet  GetSTD_ClassSubjectStudentByStudentID(string  studentID,bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByStudentID", connection))
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

    public STD_ClassSubjectStudent  GetSTD_ClassSubjectStudentByClassSubjectID(int  classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByClassSubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectID", SqlDbType.NVarChar).Value = classSubjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_ClassSubjectStudentByClassSubjectID(int classSubjectID,bool isDataset)
    {
        
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByClassSubjectID", connection))
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


    public DataSet GetSTD_ClassSubjectStudentByClassID(int classID)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByClassID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ClassSubjectStudent()
    {
        DataSet STD_ClassSubjectStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassSubjectStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectStudents;
        }
    }

    public DataSet   GetAllSTD_ClassSubjectStudentsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjectStudentsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassSubjectStudent> GetSTD_ClassSubjectStudentsFromReader(IDataReader reader)
    {
        List<STD_ClassSubjectStudent> sTD_ClassSubjectStudents = new List<STD_ClassSubjectStudent>();

        while (reader.Read())
        {
            sTD_ClassSubjectStudents.Add(GetSTD_ClassSubjectStudentFromReader(reader));
        }
        return sTD_ClassSubjectStudents;
    }

    public STD_ClassSubjectStudent GetSTD_ClassSubjectStudentFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent
                (

                     DataAccessObject.IsNULL<int>(reader["ClassSubjectStudentID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassSubjectStudentName"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ClassSubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return sTD_ClassSubjectStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassSubjectStudent  GetSTD_ClassSubjectStudentByClassSubjectStudentID(int  classSubjectStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByClassSubjectStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectStudentID", SqlDbType.Int).Value = classSubjectStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassSubjectStudent(STD_ClassSubjectStudent sTD_ClassSubjectStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassSubjectStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassSubjectStudentName", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.ClassSubjectStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.StudentID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubjectStudent.ClassSubjectID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassSubjectStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubjectStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassSubjectStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassSubjectStudentID"].Value;
        }
    }

    public bool UpdateSTD_ClassSubjectStudent(STD_ClassSubjectStudent sTD_ClassSubjectStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassSubjectStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectStudentID", SqlDbType.Int).Value = sTD_ClassSubjectStudent.ClassSubjectStudentID;
            cmd.Parameters.Add("@ClassSubjectStudentName", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.ClassSubjectStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.StudentID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubjectStudent.ClassSubjectID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassSubjectStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubjectStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassSubjectStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassSubjectStudent(int classSubjectStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectStudentID", SqlDbType.Int).Value = classSubjectStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteSTD_ClassSubjectStudentByClassSubjectID(int classSubjectStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectStudentByClassSubjectID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteSTD_ClassSubjectStudentByClassSubjectIDnStudentID(int classSubjectID, string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectStudentByClassSubjectIDnStudentID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteSTD_ClassSubjectStudentByClassIDnSubjectIDnStudentID(int classID, int subjectID, string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectStudentByClassIDnSubjectIDnStudentID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool HistorySTD_ClassSubjectStudentByClassSubjectIDnStudentID(int classSubjectStudentID, string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HistorySTD_ClassSubjectStudentByClassSubjectIDnStudentID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectStudentID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteSTD_ClassSubjectStudentByClassID(int classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectStudentByClassID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_StudentSubjectByStudentID(string studentID)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_StudentSubjectByStudentID", connection))
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
}

