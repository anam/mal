using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamStudentManager
{
	public STD_ExamStudentManager()
	{
	}

    public static DataSet  GetAllSTD_ExamStudents()
    {
       DataSet sTD_ExamStudents = new DataSet();
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        sTD_ExamStudents = sqlSTD_ExamStudentProvider.GetAllSTD_ExamStudents();
        return sTD_ExamStudents;
    }

	public static void sTD_ExamStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ExamStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
		DataSet ds =  sqlSTD_ExamStudentProvider.GetSTD_ExamStudentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamStudentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ExamStudent()
    {
       DataSet sTD_ExamStudents = new DataSet();
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        sTD_ExamStudents = sqlSTD_ExamStudentProvider.GetDropDownListAllSTD_ExamStudent();
        return sTD_ExamStudents;
    }


    public static STD_ExamStudent GetSTD_ExamByExamID(int ExamID)
    {
        STD_ExamStudent sTD_ExamStudent = new STD_ExamStudent();
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        sTD_ExamStudent = sqlSTD_ExamStudentProvider.GetSTD_ExamStudentByExamID(ExamID);
        return sTD_ExamStudent;
    }


    public static STD_ExamStudent GetSTD_StudentByStudentID(string StudentID)
    {
        STD_ExamStudent sTD_ExamStudent = new STD_ExamStudent();
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        sTD_ExamStudent = sqlSTD_ExamStudentProvider.GetSTD_ExamStudentByStudentID(StudentID);
        return sTD_ExamStudent;
    }


    public static STD_ExamStudent GetSTD_ExamStudentByExamStudentID(int ExamStudentID)
    {
        STD_ExamStudent sTD_ExamStudent = new STD_ExamStudent();
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        sTD_ExamStudent = sqlSTD_ExamStudentProvider.GetSTD_ExamStudentByExamStudentID(ExamStudentID);
        return sTD_ExamStudent;
    }


    public static int InsertSTD_ExamStudent(STD_ExamStudent sTD_ExamStudent)
    {
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        return sqlSTD_ExamStudentProvider.InsertSTD_ExamStudent(sTD_ExamStudent);
    }


    public static bool UpdateSTD_ExamStudent(STD_ExamStudent sTD_ExamStudent)
    {
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        return sqlSTD_ExamStudentProvider.UpdateSTD_ExamStudent(sTD_ExamStudent);
    }

    public static bool DeleteSTD_ExamStudent(int sTD_ExamStudentID)
    {
        SqlSTD_ExamStudentProvider sqlSTD_ExamStudentProvider = new SqlSTD_ExamStudentProvider();
        return sqlSTD_ExamStudentProvider.DeleteSTD_ExamStudent(sTD_ExamStudentID);
    }
}

