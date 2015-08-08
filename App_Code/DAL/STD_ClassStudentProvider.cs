using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassStudentProvider:DataAccessObject
{
	public SqlSTD_ClassStudentProvider()
    {
    }


    public DataSet  GetAllSTD_ClassStudents()
    {
        DataSet STD_ClassStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassStudents;
        }
    }


    public DataSet GetAllSTD_ClassStudentsNotAnyClass()
    {
        DataSet STD_ClassStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassStudentsNotAnyClass", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassStudents;
        }
    }
	public DataSet GetSTD_ClassStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStudentPageWise", connection))
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


    public STD_ClassStudent  GetSTD_ClassStudentByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ClassStudent  GetSTD_ClassStudentByClassID(int  classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassStudentByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = classID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_ClassStudentByClassID(int classID,bool isdataset)
    {        
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStudentByClassID", connection))
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

    public DataSet GetSTD_ClassStudentByClassIDWithHistory(int classID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStudentByClassIDWithHistory", connection))
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


    public DataSet GetSTD_StudentByClassID(int classID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_StudentByClassID", connection))
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


    public DataSet GetSTD_StudentByClassIDWithHistory(int classID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_StudentByClassIDWithHistory", connection))
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

    public DataSet GetSTD_ClassStudentByClassIDnStudentID(int classID, string studentID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStudentByClassIDnStudentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
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

    public DataSet GetSTD_ClassStudentByStudentID(string studentID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStudentByStudentIDDataSet", connection))
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


    public DataSet  GetDropDownListAllSTD_ClassStudent()
    {
        DataSet STD_ClassStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassStudents;
        }
    }

    public DataSet   GetAllSTD_ClassStudentsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassStudentsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassStudent> GetSTD_ClassStudentsFromReader(IDataReader reader)
    {
        List<STD_ClassStudent> sTD_ClassStudents = new List<STD_ClassStudent>();

        while (reader.Read())
        {
            sTD_ClassStudents.Add(GetSTD_ClassStudentFromReader(reader));
        }
        return sTD_ClassStudents;
    }

    public STD_ClassStudent GetSTD_ClassStudentFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent
                (

                     DataAccessObject.IsNULL<int>(reader["ClassStudentID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassStudentName"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ClassID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return sTD_ClassStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassStudent  GetSTD_ClassStudentByClassStudentID(int  classStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassStudentByClassStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassStudentID", SqlDbType.Int).Value = classStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassStudent(STD_ClassStudent sTD_ClassStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassStudentName", SqlDbType.NVarChar).Value = sTD_ClassStudent.ClassStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ClassStudent.StudentID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassStudent.ClassID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassStudentID"].Value;
        }
    }

    public int InsertSTD_ClassStudent_List(STD_ClassStudent sTD_ClassStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassStudent_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StudentIDs", SqlDbType.NVarChar).Value = sTD_ClassStudent.StudentID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassStudent.ClassID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStudent.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Count"].Value;
        }
    }

    public int InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(STD_ClassStudent sTD_ClassStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StudentIDs", SqlDbType.NVarChar).Value = sTD_ClassStudent.StudentID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassStudent.ClassID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStudent.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Count"].Value;
        }
    }

    public int InsertSTD_ClassSubjectStudent_List_KeepStudentInMultipleClassActive(STD_ClassSubjectStudent sTD_ClassStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassSubjectStudent_List_KeepStudentInMultipleClassActive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StudentIDs", SqlDbType.NVarChar).Value = sTD_ClassStudent.StudentID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassStudent.ClassSubjectID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStudent.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Count"].Value;
        }
    }

    public bool UpdateSTD_ClassStudent(STD_ClassStudent sTD_ClassStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassStudentID", SqlDbType.Int).Value = sTD_ClassStudent.ClassStudentID;
            cmd.Parameters.Add("@ClassStudentName", SqlDbType.NVarChar).Value = sTD_ClassStudent.ClassStudentName;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ClassStudent.StudentID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassStudent.ClassID;
            //cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassStudent.ClassID;
            //cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassStudent.ClassID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassStudent.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassStudent(int classStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassStudentID", SqlDbType.Int).Value = classStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

