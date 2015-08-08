using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class StudentManager
{
	public StudentManager()
	{
	}

    public static List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();
        SqlStudentProvider sqlStudentProvider = new SqlStudentProvider();
        students = sqlStudentProvider.GetAllStudents();
        return students;
    }


    public static Student GetStudentByID(string id)
    {
        Student student = new Student();
        SqlStudentProvider sqlStudentProvider = new SqlStudentProvider();
        student = sqlStudentProvider.GetStudentByID(id);
        return student;
    }


    public static void InsertStudent(Student student)
    {
        SqlStudentProvider sqlStudentProvider = new SqlStudentProvider();
         sqlStudentProvider.InsertStudent(student);
    }


    public static bool UpdateStudent(Student student)
    {
        SqlStudentProvider sqlStudentProvider = new SqlStudentProvider();
        return sqlStudentProvider.UpdateStudent(student);
    }

    public static bool DeleteStudent(int studentID)
    {
        SqlStudentProvider sqlStudentProvider = new SqlStudentProvider();
        return sqlStudentProvider.DeleteStudent(studentID);
    }
}
