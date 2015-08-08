using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassManager
{
	public STD_ClassManager()
	{
	}

    public static DataSet  GetAllSTD_Classs()
    {
       DataSet sTD_Classs = new DataSet();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Classs = sqlSTD_ClassProvider.GetAllSTD_Classs();
        return sTD_Classs;
    }

	public static void sTD_ClasssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
		DataSet ds =  sqlSTD_ClassProvider.GetSTD_ClassPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClasssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadSTD_ClassPageSearch(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize, string SearchText)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        DataSet ds = sqlSTD_ClassProvider.GetSTD_ClassPageWiseSearch(pageIndex, PageSize, out recordCount, SearchText);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_ClasssPaggination(rptPager, recordCount, pageIndex, PageSize);
    }


    public static void LoadSTD_ClassPageByClass(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        DataSet ds = sqlSTD_ClassProvider.GetSTD_ClassPageWiseByClass(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_ClasssPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static void LoadSTD_ClassStudentPageByClass(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        DataSet ds = sqlSTD_ClassProvider.GetSTD_ClassStudentPageWiseByClass(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_ClasssPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static void LoadSTD_ClassPageByClassTeacher(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        DataSet ds = sqlSTD_ClassProvider.GetSTD_ClassPageWiseByClassTeacher(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_ClasssPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static void LoadSTD_ClassPageByClassStudent(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        DataSet ds = sqlSTD_ClassProvider.GetSTD_ClassPageWiseByClassStudent(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_ClasssPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllSTD_Class()
    {
       DataSet sTD_Classs = new DataSet();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Classs = sqlSTD_ClassProvider.GetDropDownListAllSTD_Class();
        return sTD_Classs;
    }

    public static DataSet GetDropDownListAllSTD_ClassWithHistory()
    {
        DataSet sTD_Classs = new DataSet();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Classs = sqlSTD_ClassProvider.GetDropDownListAllSTD_ClassWithHistory();
        return sTD_Classs;
    }

    public static DataSet GetDropDownListAllSTD_ClassStudent()
    {
        DataSet sTD_Classs = new DataSet();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Classs = sqlSTD_ClassProvider.GetDropDownListAllSTD_ClassStudent();
        return sTD_Classs;
    }
    public static DataSet   GetAllSTD_ClasssWithRelation()
    {
       DataSet sTD_Classs = new DataSet();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Classs = sqlSTD_ClassProvider.GetAllSTD_Classs();
        return sTD_Classs;
    }


    public static STD_Class GetSTD_ClassTypeByClassTypeID(int ClassTypeID)
    {
        STD_Class sTD_Class = new STD_Class();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Class = sqlSTD_ClassProvider.GetSTD_ClassByClassTypeID(ClassTypeID);
        return sTD_Class;
    }


    public static STD_Class GetSTD_ClassStatusByClassStatusID(int ClassStatusID)
    {
        STD_Class sTD_Class = new STD_Class();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Class = sqlSTD_ClassProvider.GetSTD_ClassByClassStatusID(ClassStatusID);
        return sTD_Class;
    }


    public static STD_Class GetSTD_ClassByClassID(int ClassID)
    {
        STD_Class sTD_Class = new STD_Class();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Class = sqlSTD_ClassProvider.GetSTD_ClassByClassID(ClassID);
        return sTD_Class;
    }

    public static DataSet GetSTD_ClassByStudentID(string studentID)
    {
        DataSet sTD_Class = new DataSet();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Class = sqlSTD_ClassProvider.GetSTD_ClassByStudentID(studentID);
        return sTD_Class;
    }


    public static int InsertSTD_Class(STD_Class sTD_Class)
    {
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        return sqlSTD_ClassProvider.InsertSTD_Class(sTD_Class);
    }


    public static bool UpdateSTD_Class(STD_Class sTD_Class)
    {
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        return sqlSTD_ClassProvider.UpdateSTD_Class(sTD_Class);
    }

    public static bool DeleteSTD_Class(int sTD_ClassID)
    {
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        return sqlSTD_ClassProvider.DeleteSTD_Class(sTD_ClassID);
    }

    public static bool HistorySTD_Class(int sTD_ClassID,string updatedBy)
    {
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        return sqlSTD_ClassProvider.HistorySTD_Class(sTD_ClassID,updatedBy);
    }

    public static bool UndoCloseSTD_Class(int sTD_ClassID, string updatedBy)
    {
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        return sqlSTD_ClassProvider.UndoCloseSTD_Class(sTD_ClassID, updatedBy);
    }


    public static STD_Class GetSTD_BasicInfoForStudentsAttentdant(int classID, int subjectID, string employeeID)
    {
        STD_Class sTD_Class = new STD_Class();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Class = sqlSTD_ClassProvider.GetSTD_BasicInfoForStudentsAttentdant(classID,subjectID,employeeID);
        return sTD_Class;
    }

    public static List<STD_Class> GetSTD_BasicInfoForStudentsAttentdantByStudentID(string studentID)
    {
        List<STD_Class> sTD_Class = new List<STD_Class>();
        SqlSTD_ClassProvider sqlSTD_ClassProvider = new SqlSTD_ClassProvider();
        sTD_Class = sqlSTD_ClassProvider.GetSTD_BasicInfoForStudentsAttentdantByStudentID(studentID);
        return sTD_Class;
    }
}

