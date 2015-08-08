using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassSubjectStudentManager
{
	public STD_ClassSubjectStudentManager()
	{
	}

    public static DataSet  GetAllSTD_ClassSubjectStudents()
    {
       DataSet sTD_ClassSubjectStudents = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudents = sqlSTD_ClassSubjectStudentProvider.GetAllSTD_ClassSubjectStudents();
        return sTD_ClassSubjectStudents;
    }

	public static void sTD_ClassSubjectStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassSubjectStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
		DataSet ds =  sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassSubjectStudentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassSubjectStudent()
    {
       DataSet sTD_ClassSubjectStudents = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudents = sqlSTD_ClassSubjectStudentProvider.GetDropDownLisAllSTD_ClassSubjectStudent();
        return sTD_ClassSubjectStudents;
    }

    public static DataSet   GetAllSTD_ClassSubjectStudentsWithRelation()
    {
       DataSet sTD_ClassSubjectStudents = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudents = sqlSTD_ClassSubjectStudentProvider.GetAllSTD_ClassSubjectStudents();
        return sTD_ClassSubjectStudents;
    }


    public static STD_ClassSubjectStudent GetSTD_StudentByStudentID(string StudentID)
    {
        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentByStudentID(StudentID);
        return sTD_ClassSubjectStudent;
    }


    public static DataSet GetSTD_ClassSubjectStudentByStudentID(string StudentID)
    {
        DataSet sTD_ClassSubjectStudent = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentByStudentID(StudentID,true);
        return sTD_ClassSubjectStudent;
    }


    public static STD_ClassSubjectStudent GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID)
    {
        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentByClassSubjectID(ClassSubjectID);
        return sTD_ClassSubjectStudent;
    }

    public static DataSet GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID,bool isDataset)
    {
        DataSet sTD_ClassSubjectStudent = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentByClassSubjectID(ClassSubjectID,isDataset);
        return sTD_ClassSubjectStudent;
    }

    public static DataSet GetSTD_ClassSubjectStudentByClassID(int ClassID)
    {
        DataSet sTD_ClassSubjectStudent = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentByClassID(ClassID);
        return sTD_ClassSubjectStudent;
    }

    public static STD_ClassSubjectStudent GetSTD_ClassSubjectStudentByClassSubjectStudentID(int ClassSubjectStudentID)
    {
        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_ClassSubjectStudentByClassSubjectStudentID(ClassSubjectStudentID);
        return sTD_ClassSubjectStudent;
    }


    public static int InsertSTD_ClassSubjectStudent(STD_ClassSubjectStudent sTD_ClassSubjectStudent)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
    }

    public static int InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(STD_ClassStudent sTD_ClassStudent)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(sTD_ClassStudent);
    }

    public static int InsertSTD_ClassSubjectStudent_List_KeepStudentInMultipleClassActive(STD_ClassSubjectStudent sTD_ClassStudent)
    {
        SqlSTD_ClassStudentProvider sqlSTD_ClassStudentProvider = new SqlSTD_ClassStudentProvider();
        return sqlSTD_ClassStudentProvider.InsertSTD_ClassSubjectStudent_List_KeepStudentInMultipleClassActive(sTD_ClassStudent);
    }

    public static bool UpdateSTD_ClassSubjectStudent(STD_ClassSubjectStudent sTD_ClassSubjectStudent)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.UpdateSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
    }

    public static bool DeleteSTD_ClassSubjectStudent(int sTD_ClassSubjectStudentID)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.DeleteSTD_ClassSubjectStudent(sTD_ClassSubjectStudentID);
    }


    public static bool DeleteSTD_ClassSubjectStudentByClassSubjectID(int classSubjectID)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.DeleteSTD_ClassSubjectStudentByClassSubjectID(classSubjectID);
    }

    public static bool DeleteSTD_ClassSubjectStudentByClassID(int classID)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.DeleteSTD_ClassSubjectStudentByClassID(classID);
    }

    public static bool DeleteSTD_ClassSubjectStudentByClassSubjectIDnStudentID(int classSubjectID, string StudentID)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.DeleteSTD_ClassSubjectStudentByClassSubjectIDnStudentID(classSubjectID, StudentID);
    }

    public static bool DeleteSTD_ClassSubjectStudentByClassIDnSubjectIDnStudentID(int classID, int subjectID, string StudentID)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.DeleteSTD_ClassSubjectStudentByClassIDnSubjectIDnStudentID(classID, subjectID, StudentID);
    }

    public static bool HistorySTD_ClassSubjectStudentByClassSubjectIDnStudentID(int classSubjectID, string StudentID)
    {
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        return sqlSTD_ClassSubjectStudentProvider.HistorySTD_ClassSubjectStudentByClassSubjectIDnStudentID(classSubjectID, StudentID);
    }

    public static DataSet GetSTD_StudentSubjectByStudentID(string studentID)
    {
        DataSet sTD_ClassSubjectStudent = new DataSet();
        SqlSTD_ClassSubjectStudentProvider sqlSTD_ClassSubjectStudentProvider = new SqlSTD_ClassSubjectStudentProvider();
        sTD_ClassSubjectStudent = sqlSTD_ClassSubjectStudentProvider.GetSTD_StudentSubjectByStudentID(studentID);
        return sTD_ClassSubjectStudent;
    }
}

