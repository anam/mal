using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ProgramManager
{
	public STD_ProgramManager()
	{
	}

    public static DataSet  GetAllSTD_Programs()
    {
       DataSet sTD_Programs = new DataSet();
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        sTD_Programs = sqlSTD_ProgramProvider.GetAllSTD_Programs();
        return sTD_Programs;
    }

	public static void sTD_ProgramsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ProgramPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
		DataSet ds =  sqlSTD_ProgramProvider.GetSTD_ProgramPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		COMN_CommonManager common= new COMN_CommonManager();
        COMN_CommonManager.Paggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Program()
    {
       DataSet sTD_Programs = new DataSet();
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        sTD_Programs = sqlSTD_ProgramProvider.GetDropDownLisAllSTD_Program();
        return sTD_Programs;
    }


    public static STD_Program GetSTD_CourseByCourseID(int CourseID)
    {
        STD_Program sTD_Program = new STD_Program();
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        sTD_Program = sqlSTD_ProgramProvider.GetSTD_ProgramByCourseID(CourseID);
        return sTD_Program;
    }


    public static STD_Program GetSTD_ProgramByProgramID(int ProgramID)
    {
        STD_Program sTD_Program = new STD_Program();
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        sTD_Program = sqlSTD_ProgramProvider.GetSTD_ProgramByProgramID(ProgramID);
        return sTD_Program;
    }


    public static int InsertSTD_Program(STD_Program sTD_Program)
    {
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        return sqlSTD_ProgramProvider.InsertSTD_Program(sTD_Program);
    }


    public static bool UpdateSTD_Program(STD_Program sTD_Program)
    {
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        return sqlSTD_ProgramProvider.UpdateSTD_Program(sTD_Program);
    }

    public static bool DeleteSTD_Program(int sTD_ProgramID)
    {
        SqlSTD_ProgramProvider sqlSTD_ProgramProvider = new SqlSTD_ProgramProvider();
        return sqlSTD_ProgramProvider.DeleteSTD_Program(sTD_ProgramID);
    }
}

