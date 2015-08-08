using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_SubjectStudentManager
{
	public STD_SubjectStudentManager()
	{
	}

    public static DataSet  GetAllSTD_SubjectStudents()
    {
       DataSet sTD_SubjectStudents = new DataSet();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudents = sqlSTD_SubjectStudentProvider.GetAllSTD_SubjectStudents();
        return sTD_SubjectStudents;
    }

	public static void sTD_SubjectStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_SubjectStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
		DataSet ds =  sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentPageWise(pageIndex, PageSize, out recordCount);
		        
        gv.DataSource = ds;
		gv.DataBind();
		
        COMN_CommonManager.Paggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static void LoadSTD_SubjectStudentPageCustomize(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        DataSet ds = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentPageWise(pageIndex, PageSize, out recordCount);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["msg"].ToString() == "Not available")
            {
                dr["msg"] = "Class/ Subject none is available so please <a href='../Class/ClassAdd.aspx' target='_blank'>Manage Class/Subject</a>";
            }
            else if (dr["msg"].ToString() == "Class And Subject is available")
            {
                dr["msg"] = "Subject is available only. Class is not available. so please change the class to <a target='_blank' href='../Class/StudentClassSubjectAdd.aspx?ProcessEnrollment=1&StudentCode=" + dr["StudentCode"].ToString() + "&ClassID=" + dr["SubjectStudentName"].ToString() + "&CourseID=" + dr["CourseID"].ToString() + "&SubjectID=" + dr["SubjectID"].ToString() + "'>approve enrollment.</a>";
            }
            else if (dr["msg"].ToString() == "Subject is available only. Class is not available")
            {
                dr["msg"] = "Subject is available only. Class is not available. so please change the class to  <a target='_blank' href='../Class/StudentClassSubjectAdd.aspx?ProcessEnrollment=1&StudentCode=" + dr["StudentCode"].ToString() + "&ClassID=" + dr["SubjectStudentName"].ToString() + "&CourseID=" + dr["CourseID"].ToString() + "&SubjectID=" + dr["SubjectID"].ToString() + "'>approve enrollment.</a>";
            }
            else if (dr["msg"].ToString() == "Subject is available")
            {
                dr["msg"] = "Subject is available. so please assigne the class to  <a target='_blank' href='../Class/StudentClassSubjectAdd.aspx?ProcessEnrollment=1&StudentCode=" + dr["StudentCode"].ToString() + "&ClassID=" + dr["SubjectStudentName"].ToString() + "&CourseID=" + dr["CourseID"].ToString() + "&SubjectID=" + dr["SubjectID"].ToString() + "'>approve enrollment.</a>";
            }
            
        }

        gv.DataSource = ds;
        gv.DataBind();

        COMN_CommonManager.Paggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllSTD_SubjectStudent()
    {
       DataSet sTD_SubjectStudents = new DataSet();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudents = sqlSTD_SubjectStudentProvider.GetDropDownLisAllSTD_SubjectStudent();
        return sTD_SubjectStudents;
    }

    public static DataSet   GetAllSTD_SubjectStudentsWithRelation()
    {
       DataSet sTD_SubjectStudents = new DataSet();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudents = sqlSTD_SubjectStudentProvider.GetAllSTD_SubjectStudents();
        return sTD_SubjectStudents;
    }


    public static STD_SubjectStudent GetSTD_StudentByStudentID(string StudentID)
    {
        STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudent = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentByStudentID(StudentID);
        return sTD_SubjectStudent;
    }

    public static DataSet GetSTD_StudentByStudentID(string StudentID,bool isdataset)
    {
        DataSet sTD_SubjectStudent = new DataSet();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudent = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentByStudentID(StudentID,true);
        return sTD_SubjectStudent;
    }

    public static DataSet GetSTD_StudentByStudentIDWithHistory(string StudentID, bool isdataset)
    {
        DataSet sTD_SubjectStudent = new DataSet();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudent = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentByStudentIDWithHistory(StudentID, true);
        return sTD_SubjectStudent;
    }


    public static STD_SubjectStudent GetSTD_SubjectBySubjectID(int SubjectID)
    {
        STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudent = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentBySubjectID(SubjectID);
        return sTD_SubjectStudent;
    }


    public static STD_SubjectStudent GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudent = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentByRowStatusID(RowStatusID);
        return sTD_SubjectStudent;
    }


    public static STD_SubjectStudent GetSTD_SubjectStudentBySubjectStudentID(int SubjectStudentID)
    {
        STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        sTD_SubjectStudent = sqlSTD_SubjectStudentProvider.GetSTD_SubjectStudentBySubjectStudentID(SubjectStudentID);
        return sTD_SubjectStudent;
    }


    public static int InsertSTD_SubjectStudent(STD_SubjectStudent sTD_SubjectStudent)
    {
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        return sqlSTD_SubjectStudentProvider.InsertSTD_SubjectStudent(sTD_SubjectStudent);
    }


    public static bool UpdateSTD_SubjectStudent(STD_SubjectStudent sTD_SubjectStudent)
    {
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        return sqlSTD_SubjectStudentProvider.UpdateSTD_SubjectStudent(sTD_SubjectStudent);
    }

    public static bool DeleteSTD_SubjectStudent(int sTD_SubjectStudentID)
    {
        SqlSTD_SubjectStudentProvider sqlSTD_SubjectStudentProvider = new SqlSTD_SubjectStudentProvider();
        return sqlSTD_SubjectStudentProvider.DeleteSTD_SubjectStudent(sTD_SubjectStudentID);
    }
}

