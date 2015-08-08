using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_CourseManager
{
    public STD_CourseManager()
    {
    }

    public static DataSet GetAllSTD_Courses()
    {
        DataSet sTD_Courses = new DataSet();
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        sTD_Courses = sqlSTD_CourseProvider.GetAllSTD_Courses();
        return sTD_Courses;
    }

    public static void sTD_CoursesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadSTD_CoursePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        DataSet ds = sqlSTD_CourseProvider.GetSTD_CoursePageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_CoursesPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllSTD_Course()
    {
        DataSet sTD_Courses = new DataSet();
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        sTD_Courses = sqlSTD_CourseProvider.GetDropDownListAllSTD_Course();
        return sTD_Courses;
    }


    public static STD_Course GetSTD_CourseByCourseID(int CourseID)
    {
        STD_Course sTD_Course = new STD_Course();
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        sTD_Course = sqlSTD_CourseProvider.GetSTD_CourseByCourseID(CourseID);
        return sTD_Course;
    }


    public static int InsertSTD_Course(STD_Course sTD_Course)
    {
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        return sqlSTD_CourseProvider.InsertSTD_Course(sTD_Course);
    }


    public static bool UpdateSTD_Course(STD_Course sTD_Course)
    {
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        return sqlSTD_CourseProvider.UpdateSTD_Course(sTD_Course);
    }

    public static bool DeleteSTD_Course(int sTD_CourseID)
    {
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        return sqlSTD_CourseProvider.DeleteSTD_Course(sTD_CourseID);
    }

    public static DataSet GetSTD_CourseByClassID(int classID)
    {
        DataSet sTD_Courses = new DataSet();
        SqlSTD_CourseProvider sqlSTD_CourseProvider = new SqlSTD_CourseProvider();
        sTD_Courses = sqlSTD_CourseProvider.GetSTD_CourseByClassID(classID);
        return sTD_Courses;
    }
}

