using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamDetailsStudentManager
{
	public STD_ExamDetailsStudentManager()
	{
	}

    public static DataSet  GetAllSTD_ExamDetailsStudents()
    {
       DataSet sTD_ExamDetailsStudents = new DataSet();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudents = sqlSTD_ExamDetailsStudentProvider.GetAllSTD_ExamDetailsStudents();
        return sTD_ExamDetailsStudents;
    }

	public static void sTD_ExamDetailsStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadSTD_ExamDetailsStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
		DataSet ds =  sqlSTD_ExamDetailsStudentProvider.GetSTD_ExamDetailsStudentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamDetailsStudentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ExamDetailsStudent()
    {
       DataSet sTD_ExamDetailsStudents = new DataSet();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudents = sqlSTD_ExamDetailsStudentProvider.GetDropDownLisAllSTD_ExamDetailsStudent();
        return sTD_ExamDetailsStudents;
    }

    public static DataSet   GetAllSTD_ExamDetailsStudentsWithRelation()
    {
       DataSet sTD_ExamDetailsStudents = new DataSet();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudents = sqlSTD_ExamDetailsStudentProvider.GetAllSTD_ExamDetailsStudents();
        return sTD_ExamDetailsStudents;
    }


    public static STD_ExamDetailsStudent GetSTD_ExamDetailsByExamDetailsID(int ExamDetailsID)
    {
        STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudent = sqlSTD_ExamDetailsStudentProvider.GetSTD_ExamDetailsStudentByExamDetailsID(ExamDetailsID);
        return sTD_ExamDetailsStudent;
    }


    public static STD_ExamDetailsStudent GetSTD_StudentByStudentID(string StudentID)
    {
        STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudent = sqlSTD_ExamDetailsStudentProvider.GetSTD_ExamDetailsStudentByStudentID(StudentID);
        return sTD_ExamDetailsStudent;
    }


    public static STD_ExamDetailsStudent GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudent = sqlSTD_ExamDetailsStudentProvider.GetSTD_ExamDetailsStudentByRowStatusID(RowStatusID);
        return sTD_ExamDetailsStudent;
    }


    public static STD_ExamDetailsStudent GetSTD_ExamDetailsStudentByExamDetailsStudentID(int ExamDetailsStudentID)
    {
        STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudent = sqlSTD_ExamDetailsStudentProvider.GetSTD_ExamDetailsStudentByExamDetailsStudentID(ExamDetailsStudentID);
        return sTD_ExamDetailsStudent;
    }


    public static int InsertSTD_ExamDetailsStudent(STD_ExamDetailsStudent sTD_ExamDetailsStudent)
    {
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        return sqlSTD_ExamDetailsStudentProvider.InsertSTD_ExamDetailsStudent(sTD_ExamDetailsStudent);
    }


    public static bool UpdateSTD_ExamDetailsStudent(STD_ExamDetailsStudent sTD_ExamDetailsStudent)
    {
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        return sqlSTD_ExamDetailsStudentProvider.UpdateSTD_ExamDetailsStudent(sTD_ExamDetailsStudent);
    }

    public static bool DeleteSTD_ExamDetailsStudent(int sTD_ExamDetailsStudentID)
    {
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        return sqlSTD_ExamDetailsStudentProvider.DeleteSTD_ExamDetailsStudent(sTD_ExamDetailsStudentID);
    }

    public static DataSet GetSTD_StudentsObtainMarkByExamID(int examID)
    {
        DataSet sTD_ExamDetailsStudents = new DataSet();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudents = sqlSTD_ExamDetailsStudentProvider.GetSTD_StudentsObtainMarkByExamID(examID);
        return sTD_ExamDetailsStudents;
    }

    public static DataSet GetSTD_ExamResultByStudentID(string studentID)
    {
        DataSet sTD_ExamDetailsStudents = new DataSet();
        SqlSTD_ExamDetailsStudentProvider sqlSTD_ExamDetailsStudentProvider = new SqlSTD_ExamDetailsStudentProvider();
        sTD_ExamDetailsStudents = sqlSTD_ExamDetailsStudentProvider.GetSTD_ExamResultByStudentID(studentID);
        return sTD_ExamDetailsStudents;
    }
}

