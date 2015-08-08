using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_SubjectManager
{
    public STD_SubjectManager()
    {
    }

    public static DataSet GetAllSTD_Subjects()
    {
        DataSet sTD_Subjects = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subjects = sqlSTD_SubjectProvider.GetAllSTD_Subjects();
        return sTD_Subjects;
    }

    public static bool DeleteSTD_SubjectEmployee(int SubjectEmployeeID)
    {
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        return sqlSTD_SubjectProvider.DeleteSTD_SubjectEmployee(SubjectEmployeeID);
    }

    public static void LoadSTD_SubjectEmployeePageWiseBySubject(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        DataSet ds = sqlSTD_SubjectProvider.GetSTD_SubjectEmployeePageWiseBySubject(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        COMN_CommonManager.Paggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static int InsertSTD_SubjectEmployee_List(STD_SubjectEmployee sTD_SubjectEmployee)
    {
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        return sqlSTD_SubjectProvider.InsertSTD_SubjectEmployee_List(sTD_SubjectEmployee);
    }

    public static DataSet GetSTD_SubjectEmployeeBySubjectID(int subjectID)
    {
        DataSet sTD_ClassStudent = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_ClassStudent = sqlSTD_SubjectProvider.GetSTD_SubjectEmployeeBySubjectID(subjectID, true);
        return sTD_ClassStudent;
    }


    public static DataSet GetDropDownListAllSTD_SubjectEmployee()
    {
        DataSet sTD_Classs = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Classs = sqlSTD_SubjectProvider.GetDropDownListAllSTD_SubjectEmployee();
        return sTD_Classs;
    }

    public static void sTD_SubjectsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadSTD_SubjectPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize, DropDownList ddlCourseID)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        DataSet ds = sqlSTD_SubjectProvider.GetSTD_SubjectPageWise(pageIndex, PageSize, out recordCount,ddlCourseID.SelectedValue);
        gv.DataSource = ds;
        gv.DataBind();
        //COMN_CommonManager common = new COMN_CommonManager();
        COMN_CommonManager.Paggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllSTD_Subject()
    {
        DataSet sTD_Subjects = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subjects = sqlSTD_SubjectProvider.GetDropDownListAllSTD_Subject();
        return sTD_Subjects;
    }

    public static DataSet GetDropDownListAllSTD_Subject(int courseID)
    {
        DataSet sTD_Subjects = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subjects = sqlSTD_SubjectProvider.GetDropDownListAllSTD_Subject(courseID);
        return sTD_Subjects;
    }

    public static DataSet GetDropDownListAllSTD_SubjectGeneral(int courseID)
    {
        DataSet sTD_Subjects = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subjects = sqlSTD_SubjectProvider.GetDropDownListAllSTD_SubjectGeneral(courseID);
        return sTD_Subjects;
    }

    public static DataSet GetDropDownListAllSTD_SubjectEnrollment(int courseID)
    {
        DataSet sTD_Subjects = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subjects = sqlSTD_SubjectProvider.GetDropDownListAllSTD_SubjectEnrollment(courseID);
        return sTD_Subjects;
    }


    public static DataSet GetAllSTD_SubjectsWithRelation()
    {
        DataSet sTD_Subjects = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subjects = sqlSTD_SubjectProvider.GetAllSTD_Subjects();
        return sTD_Subjects;
    }



    public static List<STD_Subject> GetSTD_SubjectsByCourseID(int CourseID)
    {
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        return sqlSTD_SubjectProvider.GetSTD_SubjectsByCourseID(CourseID);
    }


    public static STD_Subject GetSTD_SubjectBySubjectID(int SubjectID)
    {
        STD_Subject sTD_Subject = new STD_Subject();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subject = sqlSTD_SubjectProvider.GetSTD_SubjectBySubjectID(SubjectID);
        return sTD_Subject;
    }

    public static STD_Subject GetSTD_SubjectFromSubjectEmployeeBySubjectID(int SubjectID)
    {
        STD_Subject sTD_Subject = new STD_Subject();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subject = sqlSTD_SubjectProvider.GetSTD_SubjectFromSubjectEmployeeBySubjectID(SubjectID);
        return sTD_Subject;
    }

    public static int InsertSTD_Subject(STD_Subject sTD_Subject)
    {
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        return sqlSTD_SubjectProvider.InsertSTD_Subject(sTD_Subject);
    }


    public static bool UpdateSTD_Subject(STD_Subject sTD_Subject)
    {
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        return sqlSTD_SubjectProvider.UpdateSTD_Subject(sTD_Subject);
    }

    public static bool DeleteSTD_Subject(int sTD_SubjectID)
    {
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        return sqlSTD_SubjectProvider.DeleteSTD_Subject(sTD_SubjectID);
    }

    public static DataSet GetSTD_SubjectByCourseID(int CourseID)
    {
        DataSet sTD_Subject = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subject = sqlSTD_SubjectProvider.GetSTD_SubjectByCourseID(CourseID);
        return sTD_Subject;
    }


    public static DataSet GetDropDownListAllSTD_SubjectByClassID(int ClassID)
    {
        DataSet sTD_Subject = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subject = sqlSTD_SubjectProvider.GetSTD_SubjectByClassID(ClassID);
        return sTD_Subject;
    }

    public static DataSet GetSTD_ClassSubjectsByClassID(int ClassID)
    {
        DataSet sTD_Subject = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subject = sqlSTD_SubjectProvider.GetSTD_ClassSubjectsByClassID(ClassID);
        return sTD_Subject;
    }

    public static DataSet GetSTD_SubjectByCourseIDByStudentIDWhoHasnotTakenTheClass(int CourseID,string studentID)
    {
        DataSet sTD_Subject = new DataSet();
        SqlSTD_SubjectProvider sqlSTD_SubjectProvider = new SqlSTD_SubjectProvider();
        sTD_Subject = sqlSTD_SubjectProvider.GetSTD_SubjectByCourseIDByStudentIDWhoHasnotTakenTheClass(CourseID, studentID);
        return sTD_Subject;
    }

}

