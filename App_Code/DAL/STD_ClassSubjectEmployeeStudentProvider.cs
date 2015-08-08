using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassSubjectEmployeeStudentProvider:DataAccessObject
{
	public SqlSTD_ClassSubjectEmployeeStudentProvider()
    {
    }


    public DataSet  GetAllSTD_ClassSubjectEmployeeStudents()
    {
        DataSet STD_ClassSubjectEmployeeStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjectEmployeeStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectEmployeeStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectEmployeeStudents;
        }
    }

    public DataSet GetSTD_ClassSummeryDetailsByClassSubjectID(int classSubjectID)
    {
        DataSet STD_ClassSubjectEmployeeStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSummeryDetailsByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectEmployeeStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectEmployeeStudents;
        }
    }

   

	public DataSet GetSTD_ClassSubjectEmployeeStudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentPageWise", connection))
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


    public STD_ClassSubjectEmployeeStudent  GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeID(int  classSubjectEmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.NVarChar).Value = classSubjectEmployeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDDataset(int classSubjectEmployeeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassSubjectEmployeeID", classSubjectEmployeeID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
               return ds;
            }
        }

    }

    public DataSet GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDDatasetDistinct(int classSubjectEmployeeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDDistinct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassSubjectEmployeeID", classSubjectEmployeeID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }


    public STD_ClassSubjectEmployeeStudent  GetSTD_ClassSubjectEmployeeStudentByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ClassSubjectEmployeeStudent  GetSTD_ClassSubjectEmployeeStudentByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ClassSubjectEmployeeStudent()
    {
        DataSet STD_ClassSubjectEmployeeStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassSubjectEmployeeStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectEmployeeStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectEmployeeStudents;
        }
    }

    public DataSet   GetAllSTD_ClassSubjectEmployeeStudentsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjectEmployeeStudentsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public  List<STD_ClassSubjectEmployeeStudent> GetSTD_StudentsAttentdantAlreadyAttendedAllTime(int ClassID, int SubjectID, String EmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentsAttentdantAlreadyAttendedAllTime", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = SubjectID;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTD_ClassSubjectEmployeeStudentsFromReader(reader);
        }
    }
    
    public List<STD_ClassSubjectEmployeeStudent> GetSTD_ClassSubjectEmployeeStudentsFromReader(IDataReader reader)
    {
        List<STD_ClassSubjectEmployeeStudent> sTD_ClassSubjectEmployeeStudents = new List<STD_ClassSubjectEmployeeStudent>();

        while (reader.Read())
        {
            sTD_ClassSubjectEmployeeStudents.Add(GetSTD_ClassSubjectEmployeeStudentFromReader(reader));
        }
        return sTD_ClassSubjectEmployeeStudents;
    }

    public STD_ClassSubjectEmployeeStudent GetSTD_ClassSubjectEmployeeStudentFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent
                (
                     DataAccessObject.IsNULL<int>(reader["ClassSubjectEmployeeStudentID"]),
                     DataAccessObject.IsNULL<int>(reader["ClassSubjectEmployeeID"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"].ToString())

                );
             return sTD_ClassSubjectEmployeeStudent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassSubjectEmployeeStudent  GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeStudentID(int  classSubjectEmployeeStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectEmployeeStudentID", SqlDbType.Int).Value = classSubjectEmployeeStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeStudentFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassSubjectEmployeeStudent(STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassSubjectEmployeeStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectEmployeeStudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Value = sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.StudentID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassSubjectEmployeeStudent.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubjectEmployeeStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassSubjectEmployeeStudent.RowStatusID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.ExtraField3;
            cmd.Parameters.Add("@TodayRemark", SqlDbType.NText).Value = sTD_ClassSubjectEmployeeStudent.TodayRemark;
            cmd.Parameters.Add("@IsExam", SqlDbType.Bit).Value = sTD_ClassSubjectEmployeeStudent.IsExam;
            cmd.Parameters.Add("@IsAbsence", SqlDbType.Bit).Value = sTD_ClassSubjectEmployeeStudent.IsAbsence;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassSubjectEmployeeStudentID"].Value;
        }
    }

    public bool UpdateSTD_ClassSubjectEmployeeStudent(STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassSubjectEmployeeStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectEmployeeStudentID", SqlDbType.Int).Value = sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeStudentID;
            cmd.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Value = sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.StudentID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubjectEmployeeStudent.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ClassSubjectEmployeeStudent.RowStatusID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployeeStudent.ExtraField2;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassSubjectEmployeeStudent(int classSubjectEmployeeStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectEmployeeStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectEmployeeStudentID", SqlDbType.Int).Value = classSubjectEmployeeStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_AttendantDateByEmployeeID(string employeeID)
    {
        DataSet STD_ClassSubjectEmployeeStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_AttendantDateByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectEmployeeStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectEmployeeStudents;
        }
    }
}

