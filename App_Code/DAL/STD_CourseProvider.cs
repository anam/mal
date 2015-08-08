using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_CourseProvider : DataAccessObject
{
    public SqlSTD_CourseProvider()
    {
    }


    public DataSet GetAllSTD_Courses()
    {
        DataSet STD_Courses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Courses", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Courses);
            myadapter.Dispose();
            connection.Close();

            return STD_Courses;
        }
    }
    public DataSet GetSTD_CoursePageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_CoursePageWise", connection))
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


    public DataSet GetDropDownListAllSTD_Course()
    {
        DataSet STD_Courses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Courses", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Courses);
            myadapter.Dispose();
            connection.Close();

            return STD_Courses;
        }
    }

    public DataSet GetAllSTD_ContactsWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ContactsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Course> GetSTD_CoursesFromReader(IDataReader reader)
    {
        List<STD_Course> sTD_Courses = new List<STD_Course>();

        while (reader.Read())
        {
            sTD_Courses.Add(GetSTD_CourseFromReader(reader));
        }
        return sTD_Courses;
    }

    public STD_Course GetSTD_CourseFromReader(IDataReader reader)
    {
        try
        {
            STD_Course sTD_Course = new STD_Course
                (

                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<string>(reader["CourseName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["Duration"]),
                     DataAccessObject.IsNULL<decimal>(reader["Cost"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
            return sTD_Course;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_Course GetSTD_CourseByCourseID(int courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CourseByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_CourseFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSTD_Course(STD_Course sTD_Course)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Course", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CourseName", SqlDbType.NVarChar).Value = sTD_Course.CourseName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Course.Description;
            cmd.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = sTD_Course.Duration;
            cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = sTD_Course.Cost;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Course.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Course.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Course.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Course.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CourseID"].Value;
        }
    }

    public bool UpdateSTD_Course(STD_Course sTD_Course)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Course", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Course.CourseID;
            cmd.Parameters.Add("@CourseName", SqlDbType.NVarChar).Value = sTD_Course.CourseName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Course.Description;
            cmd.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = sTD_Course.Duration;
            cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = sTD_Course.Cost;
            //cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = sTD_Course.Cost;
            //cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = sTD_Course.Cost;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Course.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Course.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Course(int courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Course", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_CourseByClassID(int classID)
    {
        DataSet STD_Courses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CourseByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Courses);
            myadapter.Dispose();
            connection.Close();

            return STD_Courses;
        }
    }
}

