using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassSubjectManager
{
	public STD_ClassSubjectManager()
	{
	}

    public static DataSet  GetAllSTD_ClassSubjects()
    {
       DataSet sTD_ClassSubjects = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubjects = sqlSTD_ClassSubjectProvider.GetAllSTD_ClassSubjects();
        return sTD_ClassSubjects;
    }

    

	public static void sTD_ClassSubjectsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassSubjectPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
		DataSet ds =  sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassSubjectsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassSubject()
    {
       DataSet sTD_ClassSubjects = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubjects = sqlSTD_ClassSubjectProvider.GetDropDownListAllSTD_ClassSubject();
        return sTD_ClassSubjects;
    }

    public static DataSet GetDropDownListAllSTD_ClassSubject_NotFinished()
    {
        DataSet sTD_ClassSubjects = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubjects = sqlSTD_ClassSubjectProvider.GetDropDownListAllSTD_ClassSubject_NotFinished();
        return sTD_ClassSubjects;
    }

    public static DataSet   GetAllSTD_ClassSubjectsWithRelation()
    {
       DataSet sTD_ClassSubjects = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubjects = sqlSTD_ClassSubjectProvider.GetAllSTD_ClassSubjects();
        return sTD_ClassSubjects;
    }


    public static STD_ClassSubject GetSTD_SubjectBySubjectID(int SubjectID)
    {
        STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectBySubjectID(SubjectID);
        return sTD_ClassSubject;
    }

    public static STD_ClassSubject GetSTD_SubjectBySubjectIDnClassID(int SubjectID,int ClassID)
    {
        STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectBySubjectIDnClassID(SubjectID,ClassID);
        return sTD_ClassSubject;
    }


    public static DataSet GetSTD_ClassSubjectBySubjectID(int SubjectID)
    {
        DataSet sTD_ClassSubject = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectBySubjectID(SubjectID,true);
        return sTD_ClassSubject;
    }

    public static List<STD_ClassSubject> GetSTD_ClassByClassID(int ClassID)
    {
        List<STD_ClassSubject> sTD_ClassSubject = new List<STD_ClassSubject>();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectByClassID(ClassID);
        return sTD_ClassSubject;
    }

    public static DataSet GetSTD_ClassSubjectByClassID(int ClassID, bool isdataset)
    {
        DataSet sTD_ClassSubject = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectByClassID(ClassID, isdataset);
        return sTD_ClassSubject;
    }

    public static DataSet GetSTD_ClassSubjectByClassIDTeacherAdd(int ClassID, bool isdataset)
    {
        DataSet sTD_ClassSubject = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectByClassIDTeacherAdd(ClassID, isdataset);
        return sTD_ClassSubject;
    }

    public static DataSet GetSTD_ClassSubjectByClassIDnStudentID(int ClassID,string studentID, bool isdataset)
    {
        DataSet sTD_ClassSubject = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectByClassIDnStudentID(ClassID,studentID, isdataset);
        return sTD_ClassSubject;
    }


    public static DataSet GetSTD_ClassSubjectEmployeeByClassID(int ClassID, bool isdataset)
    {
        DataSet sTD_ClassSubject = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectEmployeeByClassID(ClassID, isdataset);
        return sTD_ClassSubject;
    }

    public static DataSet GetSTD_ClassSubjectStudentByClassID(int ClassID, bool isdataset)
    {
        DataSet sTD_ClassSubject = new DataSet();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectStudentByClassID(ClassID, isdataset);
        return sTD_ClassSubject;
    }

    public static STD_ClassSubject GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID)
    {
        STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        sTD_ClassSubject = sqlSTD_ClassSubjectProvider.GetSTD_ClassSubjectByClassSubjectID(ClassSubjectID);
        return sTD_ClassSubject;
    }


    public static int InsertSTD_ClassSubject(STD_ClassSubject sTD_ClassSubject)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.InsertSTD_ClassSubject(sTD_ClassSubject);
    }


    public static bool UpdateSTD_ClassSubject(STD_ClassSubject sTD_ClassSubject)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.UpdateSTD_ClassSubject(sTD_ClassSubject);
    }

    public static bool DeleteSTD_ClassSubject(int sTD_ClassSubjectID)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.DeleteSTD_ClassSubject(sTD_ClassSubjectID);
    }

    public static bool CloseSTD_ClassSubject(int sTD_ClassSubjectID,string updatedBy)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.CloseSTD_ClassSubject(sTD_ClassSubjectID,updatedBy);
    }


    public static bool UndoCloseSTD_ClassSubject(int sTD_ClassSubjectID, string updatedBy)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.UndoCloseSTD_ClassSubject(sTD_ClassSubjectID, updatedBy);
    }


    public static bool DeleteSTD_ClassSubjectByClassID(int classID)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.DeleteSTD_ClassSubjectByClassID(classID);
    }

    public static bool DeleteSTD_ClassSubjectByClassIDnSubjectID(int classID,int SubjectID)
    {
        SqlSTD_ClassSubjectProvider sqlSTD_ClassSubjectProvider = new SqlSTD_ClassSubjectProvider();
        return sqlSTD_ClassSubjectProvider.DeleteSTD_ClassSubjectByClassIDnSubjectID(classID, SubjectID);
    }
}

