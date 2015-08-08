using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassStudentManager
{
	public STD_ClassStudentManager()
	{
	}

    public static DataSet  GetAllSTD_ClassStudents()
    {
       DataSet sTD_ClassStudents = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudents = sqlSTD_ClassStudentProvider.GetAllSTD_ClassStudents();
        return sTD_ClassStudents;
    }

    public static DataSet GetAllSTD_ClassStudentsNotAnyClass()
    {
        DataSet sTD_ClassStudents = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudents = sqlSTD_ClassStudentProvider.GetAllSTD_ClassStudentsNotAnyClass();
        return sTD_ClassStudents;
    }


	public static void sTD_ClassStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
		DataSet ds =  sqlSTD_ClassStudentProvider.GetSTD_ClassStudentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassStudentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassStudent()
    {
       DataSet sTD_ClassStudents = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudents = sqlSTD_ClassStudentProvider.GetDropDownListAllSTD_ClassStudent();
        return sTD_ClassStudents;
    }


    public static STD_ClassStudent GetSTD_StudentByStudentID(string StudentID)
    {
        STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByStudentID(StudentID);
        return sTD_ClassStudent;
    }


    public static STD_ClassStudent GetSTD_ClassByClassID(int ClassID)
    {
        STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByClassID(ClassID);
        return sTD_ClassStudent;
    }

    public static DataSet GetSTD_ClassStudentByClassID(int ClassID)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByClassID(ClassID,true);
        return sTD_ClassStudent;
    }

    public static DataSet GetSTD_ClassStudentByClassIDWithHistory(int ClassID)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByClassIDWithHistory(ClassID, true);
        return sTD_ClassStudent;
    }


    public static DataSet GetSTD_StudentByClassID(int ClassID)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_StudentByClassID(ClassID);
        return sTD_ClassStudent;
    }

    public static DataSet GetSTD_StudentByClassIDWithHistory(int ClassID)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_StudentByClassIDWithHistory(ClassID);
        return sTD_ClassStudent;
    }


    public static DataSet GetSTD_ClassStudentByClassIDnStudentID(int ClassID, string StudentID)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByClassIDnStudentID(ClassID, StudentID, true);
        return sTD_ClassStudent;
    }

    public static DataSet GetSTD_ClassStudentByStudentID(string StudentID,bool isdataset)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByStudentID(StudentID, true);
        return sTD_ClassStudent;
    }


    public static STD_ClassStudent GetSTD_ClassStudentByClassStudentID(int ClassStudentID)
    {
        STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        sTD_ClassStudent = sqlSTD_ClassStudentProvider.GetSTD_ClassStudentByClassStudentID(ClassStudentID);
        return sTD_ClassStudent;
    }


    public static int InsertSTD_ClassStudent(STD_ClassStudent sTD_ClassStudent)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.InsertSTD_ClassStudent(sTD_ClassStudent);
    }

    public static int InsertSTD_ClassStudent_List(STD_ClassStudent sTD_ClassStudent)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.InsertSTD_ClassStudent_List(sTD_ClassStudent);
    }

    public static int InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(STD_ClassStudent sTD_ClassStudent)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(sTD_ClassStudent);
    }


    public static bool UpdateSTD_ClassStudent(STD_ClassStudent sTD_ClassStudent)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.UpdateSTD_ClassStudent(sTD_ClassStudent);
    }

    public static bool DeleteSTD_ClassStudent(int sTD_ClassStudentID)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.DeleteSTD_ClassStudent(sTD_ClassStudentID);
    }
}

