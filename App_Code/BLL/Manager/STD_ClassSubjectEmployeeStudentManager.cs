using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassSubjectEmployeeStudentManager
{
	public STD_ClassSubjectEmployeeStudentManager()
	{
	}

    public static DataSet  GetAllSTD_ClassSubjectEmployeeStudents()
    {
       DataSet sTD_ClassSubjectEmployeeStudents = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudents = sqlSTD_ClassSubjectEmployeeStudentProvider.GetAllSTD_ClassSubjectEmployeeStudents();
        return sTD_ClassSubjectEmployeeStudents;
    }

    public static DataSet GetSTD_ClassSummeryDetailsByClassSubjectID(int classSubjectID)
    {
        DataSet sTD_ClassSubjectEmployeeStudents = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudents = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSummeryDetailsByClassSubjectID(classSubjectID);
        return sTD_ClassSubjectEmployeeStudents;
    }
  

	public static void sTD_ClassSubjectEmployeeStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassSubjectEmployeeStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
		DataSet ds =  sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassSubjectEmployeeStudentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassSubjectEmployeeStudent()
    {
       DataSet sTD_ClassSubjectEmployeeStudents = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudents = sqlSTD_ClassSubjectEmployeeStudentProvider.GetDropDownLisAllSTD_ClassSubjectEmployeeStudent();
        return sTD_ClassSubjectEmployeeStudents;
    }

    public static DataSet   GetAllSTD_ClassSubjectEmployeeStudentsWithRelation()
    {
       DataSet sTD_ClassSubjectEmployeeStudents = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudents = sqlSTD_ClassSubjectEmployeeStudentProvider.GetAllSTD_ClassSubjectEmployeeStudents();
        return sTD_ClassSubjectEmployeeStudents;
    }


    public static STD_ClassSubjectEmployeeStudent GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeID(int ClassSubjectEmployeeID)
    {
        STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeID(ClassSubjectEmployeeID);
        return sTD_ClassSubjectEmployeeStudent;
    }

    public static List<STD_ClassSubjectEmployeeStudent> GetSTD_StudentsAttentdantAlreadyAttendedAllTime(int ClassID, int SubjectID, String EmployeeID)
    {
        List<STD_ClassSubjectEmployeeStudent> sTD_ClassSubjectEmployeeStudent = new List<STD_ClassSubjectEmployeeStudent>();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_StudentsAttentdantAlreadyAttendedAllTime(ClassID, SubjectID, EmployeeID);
        return sTD_ClassSubjectEmployeeStudent;
    }

    public static DataSet GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeIDDataset(int ClassSubjectEmployeeID)
    {
        DataSet sTD_ClassSubjectEmployeeStudent = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDDataset(ClassSubjectEmployeeID);
        return sTD_ClassSubjectEmployeeStudent;
    }


    public static DataSet GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeIDDatasetDistinct(int ClassSubjectEmployeeID)
    {
        DataSet sTD_ClassSubjectEmployeeStudent = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDDatasetDistinct(ClassSubjectEmployeeID);
        return sTD_ClassSubjectEmployeeStudent;
    }


    public static STD_ClassSubjectEmployeeStudent GetSTD_StudentByStudentID(string StudentID)
    {
        STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentByStudentID(StudentID);
        return sTD_ClassSubjectEmployeeStudent;
    }


    public static STD_ClassSubjectEmployeeStudent GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentByRowStatusID(RowStatusID);
        return sTD_ClassSubjectEmployeeStudent;
    }


    public static STD_ClassSubjectEmployeeStudent GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeStudentID(int ClassSubjectEmployeeStudentID)
    {
        STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudent = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeStudentID(ClassSubjectEmployeeStudentID);
        return sTD_ClassSubjectEmployeeStudent;
    }


    public static int InsertSTD_ClassSubjectEmployeeStudent(STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent)
    {
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        return sqlSTD_ClassSubjectEmployeeStudentProvider.InsertSTD_ClassSubjectEmployeeStudent(sTD_ClassSubjectEmployeeStudent);
    }


    public static bool UpdateSTD_ClassSubjectEmployeeStudent(STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent)
    {
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        return sqlSTD_ClassSubjectEmployeeStudentProvider.UpdateSTD_ClassSubjectEmployeeStudent(sTD_ClassSubjectEmployeeStudent);
    }

    public static bool DeleteSTD_ClassSubjectEmployeeStudent(int sTD_ClassSubjectEmployeeStudentID)
    {
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        return sqlSTD_ClassSubjectEmployeeStudentProvider.DeleteSTD_ClassSubjectEmployeeStudent(sTD_ClassSubjectEmployeeStudentID);
    }

    public static DataSet GetSTD_AttendantDateByEmployeeID(string employeeID)
    {
        DataSet sTD_ClassSubjectEmployeeStudents = new DataSet();
        SqlSTD_ClassSubjectEmployeeStudentProvider sqlSTD_ClassSubjectEmployeeStudentProvider = new SqlSTD_ClassSubjectEmployeeStudentProvider();
        sTD_ClassSubjectEmployeeStudents = sqlSTD_ClassSubjectEmployeeStudentProvider.GetSTD_AttendantDateByEmployeeID(employeeID);
        return sTD_ClassSubjectEmployeeStudents;
    }
}

