using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_SubjectProvider : DataAccessObject
{
    public SqlSTD_SubjectProvider()
    {
    }


    public bool DeleteSTD_SubjectEmployee(int SubjectEmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_SubjectEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectEmployeeID", SqlDbType.Int).Value = SubjectEmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetAllSTD_Subjects()
    {
        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Subjects", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }
    }

    public int InsertSTD_SubjectEmployee_List(STD_SubjectEmployee sTD_SubjectEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_SubjectEmployee_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeIDs", SqlDbType.NVarChar).Value = sTD_SubjectEmployee.EmployeeID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_SubjectEmployee.SubjectID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = sTD_SubjectEmployee.CampusID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_SubjectEmployee.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_SubjectEmployee.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_SubjectEmployee.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_SubjectEmployee.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Count"].Value;
        }
    }

    public DataSet GetSTD_SubjectEmployeeBySubjectID(int subjectID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectEmployeeBySubjectID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SubjectID", subjectID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetSTD_SubjectEmployeePageWiseBySubject(int pageIndex, int PageSize, out int recordCount)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectEmployeePageWiseBySubject", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
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


    public DataSet GetDropDownListAllSTD_SubjectEmployee()
    {
        DataSet STD_Classs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_SubjectEmployee", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Classs);
            myadapter.Dispose();
            connection.Close();

            return STD_Classs;
        }
    }
    public DataSet GetSTD_SubjectByCourseID(int courseID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseID", courseID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetSTD_SubjectByCourseIDForRoutine(int courseID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseIDForRoutine", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseID", courseID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetSTD_SubjectByCourseIDByStudentIDWhoHasnotTakenTheClass(int courseID, string studentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseIDByStudentIDWhoHasnotTakenTheClass", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseID", courseID);
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

    public DataSet GetSTD_SubjectPageWise(int pageIndex, int PageSize, out int recordCount,string CourseID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_SubjectPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@CourseID", CourseID);
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



    public List<STD_Subject> GetSTD_SubjectsByCourseID(int courseID)

    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {

            SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            return GetSTD_SubjectsFromReader(reader);

        }
    }

    public DataSet GetDropDownListAllSTD_Subject()
    {
        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Subjects", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }
    }

    public DataSet GetDropDownListAllSTD_Subject(int courseID)
    {
        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }
    }

    public DataSet GetDropDownListAllSTD_SubjectGeneral(int courseID)
    {
        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseIDGeneral", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }
    }

    public DataSet GetDropDownListAllSTD_SubjectEnrollment(int courseID)
    {
        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectByCourseIDEnrollment", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }
    }

    public DataSet GetAllSTD_SubjectsWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_SubjectsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetSTD_SubjectByClassID(int classID)
    {

        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }

    }

    public DataSet GetSTD_ClassSubjectsByClassID(int classID)
    {

        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectsByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }

    }


    public List<STD_Subject> GetSTD_SubjectsFromReader(IDataReader reader)
    {
        List<STD_Subject> sTD_Subjects = new List<STD_Subject>();

        while (reader.Read())
        {
            sTD_Subjects.Add(GetSTD_SubjectFromReader(reader));
        }
        return sTD_Subjects;
    }

    public STD_Subject GetSTD_SubjectFromReader(IDataReader reader)
    {
        try
        {
            STD_Subject sTD_Subject = new STD_Subject
                (

                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<string>(reader["SubjectName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
            return sTD_Subject;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_Subject GetSTD_SubjectBySubjectID(int subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_SubjectFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public STD_Subject GetSTD_SubjectFromSubjectEmployeeBySubjectID(int subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SubjectFromSubjectEmployeeBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_SubjectFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public int InsertSTD_Subject(STD_Subject sTD_Subject)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Subject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Subject.CourseID;
            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar).Value = sTD_Subject.SubjectName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Subject.Description;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Subject.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Subject.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Subject.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Subject.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            int subjectID = (int)cmd.Parameters["@SubjectID"].Value;

            using (SqlConnection connection2 = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("InsertQuiz_Chapter", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@ChapterID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
                cmd1.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Subject.CourseID;
                cmd1.Parameters.Add("@ChapterName", SqlDbType.NVarChar).Value = "All Chapter";
                cmd1.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Subject.AddedBy;
                cmd1.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Subject.AddedDate;
                cmd1.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_Subject.UpdatedBy;
                cmd1.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_Subject.UpdateDate;
                connection2.Open();

                result = cmd1.ExecuteNonQuery();
            }

            return subjectID;
        }
    }

    public bool UpdateSTD_Subject(STD_Subject sTD_Subject)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Subject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_Subject.SubjectID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Subject.CourseID;
            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar).Value = sTD_Subject.SubjectName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Subject.Description;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_Subject.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Subject.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Subject.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Subject.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Subject.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Subject(int subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Subject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

