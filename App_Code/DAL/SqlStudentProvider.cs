using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlStudentProvider:DataAccessObject
{
	public SqlStudentProvider()
    {
    }


    public bool DeleteStudent(int studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUCTEST_DeleteStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Student> GetAllStudents()
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand command = new SqlCommand("CUCTEST_GetAllStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetStudentsFromReader(reader);
        }
    }
    public List<Student> GetStudentsFromReader(IDataReader reader)
    {
        List<Student> students = new List<Student>();

        while (reader.Read())
        {
            students.Add(GetStudentFromReader(reader));
        }
        return students;
    }

    public Student GetStudentFromReader(IDataReader reader)
    {
        try
        {
            Student student = new Student
                (                   
                    reader["S_id"].ToString(),
                    reader["P_id"].ToString(),
                    reader["S_name"].ToString(),
                    reader["Password"].ToString(),
                    reader["Father_name"].ToString(),
                    reader["Pre_add"].ToString(),
                    reader["Tel"].ToString(),
                    reader["Mob"].ToString(),
                    reader["Email"].ToString(),
                    reader["Dob"].ToString(),
                    reader["Gender"].ToString(),
                    reader["R_id"].ToString(),
                    reader["Pay_method"].ToString(),
                    reader["Total"].ToString(),
                    reader["Course_discount"].ToString(),
                    reader["No_installment"].ToString(),
                    reader["Prev_payment"].ToString(),
                    reader["Pic_ext"].ToString(),
                    reader["TotalPayemt"].ToString()
                );
            
             return student;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Student GetStudentByID(string s_ID)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand command = new SqlCommand("CUCTEST_GetStudentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@S_id", SqlDbType.NVarChar).Value = s_ID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetStudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public void InsertStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUCTEST_InsertStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.Add("@S_id", SqlDbType.NVarChar).Value = student.S_id;
            cmd.Parameters.Add("@P_id", SqlDbType.NVarChar).Value = student.P_id;
            cmd.Parameters.Add("@S_name", SqlDbType.NVarChar).Value = student.S_name;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = student.Password;
            cmd.Parameters.Add("@Father_name", SqlDbType.NVarChar).Value = student.Father_name;
            cmd.Parameters.Add("@Pre_add", SqlDbType.NVarChar).Value = student.Pre_add;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = student.Tel;
            cmd.Parameters.Add("@Mob", SqlDbType.NVarChar).Value = student.Mob;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = student.Email;
            cmd.Parameters.Add("@Dob", SqlDbType.Int).Value = student.Dob;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = student.Gender;
            cmd.Parameters.Add("@R_id", SqlDbType.NVarChar).Value = student.R_id;
            cmd.Parameters.Add("@Pay_method", SqlDbType.NVarChar).Value = student.Pay_method;
            cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = student.Total;
            cmd.Parameters.Add("@Course_discount", SqlDbType.NVarChar).Value = student.Course_discount;
            cmd.Parameters.Add("@No_installment", SqlDbType.NVarChar).Value = student.No_installment;
            cmd.Parameters.Add("@Prev_payment", SqlDbType.NVarChar).Value = student.Prev_payment;
            cmd.Parameters.Add("@Pic_ext", SqlDbType.NVarChar).Value = student.Pic_ext;
            cmd.Parameters.Add("@TotalPayemt", SqlDbType.NVarChar).Value = student.TotalPayemt;
            connection.Open();

            int result = cmd.ExecuteNonQuery();         
        }
    }

    public bool UpdateStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(this.CUCConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUCTEST_UpdateStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@S_id", SqlDbType.NVarChar).Value = student.S_id;
            cmd.Parameters.Add("@P_id", SqlDbType.TinyInt).Value = student.P_id;
            cmd.Parameters.Add("@S_name", SqlDbType.NVarChar).Value = student.S_name;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = student.Password;
            cmd.Parameters.Add("@Father_name", SqlDbType.NVarChar).Value = student.Father_name;
            cmd.Parameters.Add("@Pre_add", SqlDbType.NVarChar).Value = student.Pre_add;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = student.Tel;
            cmd.Parameters.Add("@Mob", SqlDbType.NVarChar).Value = student.Mob;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = student.Email;
            cmd.Parameters.Add("@Dob", SqlDbType.Int).Value = student.Dob;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = student.Gender;
            cmd.Parameters.Add("@R_id", SqlDbType.TinyInt).Value = student.R_id;
            cmd.Parameters.Add("@Pay_method", SqlDbType.TinyInt).Value = student.Pay_method;
            cmd.Parameters.Add("@Total", SqlDbType.Money).Value = student.Total;
            cmd.Parameters.Add("@Course_discount", SqlDbType.Money).Value = student.Course_discount;
            cmd.Parameters.Add("@No_installment", SqlDbType.Int).Value = student.No_installment;
            cmd.Parameters.Add("@Prev_payment", SqlDbType.Money).Value = student.Prev_payment;
            cmd.Parameters.Add("@Pic_ext", SqlDbType.NVarChar).Value = student.Pic_ext;
            cmd.Parameters.Add("@TotalPayemt", SqlDbType.NVarChar).Value = student.TotalPayemt;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
