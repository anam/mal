using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassTimeManager
{
	public STD_ClassTimeManager()
	{
	}

    public static DataSet  GetAllSTD_ClassTimes()
    {
       DataSet sTD_ClassTimes = new DataSet();
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        sTD_ClassTimes = sqlSTD_ClassTimeProvider.GetAllSTD_ClassTimes();
        return sTD_ClassTimes;
    }

	public static void sTD_ClassTimesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassTimePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
		DataSet ds =  sqlSTD_ClassTimeProvider.GetSTD_ClassTimePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassTimesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassTime()
    {
       DataSet sTD_ClassTimes = new DataSet();
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        sTD_ClassTimes = sqlSTD_ClassTimeProvider.GetDropDownListAllSTD_ClassTime();
        return sTD_ClassTimes;
    }


    public static STD_ClassTime GetSTD_ClassTimeByClassTimeID(int ClassTimeID)
    {
        STD_ClassTime sTD_ClassTime = new STD_ClassTime();
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        sTD_ClassTime = sqlSTD_ClassTimeProvider.GetSTD_ClassTimeByClassTimeID(ClassTimeID);
        return sTD_ClassTime;
    }


    public static DataSet GetSTD_ClassTimeByClassTimeGroupID(int ClassTimeGoupID)
    {
        DataSet sTD_ClassTime = new DataSet();
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        sTD_ClassTime = sqlSTD_ClassTimeProvider.GetSTD_ClassTimeByClassTimeGroupID(ClassTimeGoupID);
        return sTD_ClassTime;
    }

    public static int InsertSTD_ClassTime(STD_ClassTime sTD_ClassTime)
    {
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        return sqlSTD_ClassTimeProvider.InsertSTD_ClassTime(sTD_ClassTime);
    }


    public static bool UpdateSTD_ClassTime(STD_ClassTime sTD_ClassTime)
    {
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        return sqlSTD_ClassTimeProvider.UpdateSTD_ClassTime(sTD_ClassTime);
    }

    public static bool DeleteSTD_ClassTime(int sTD_ClassTimeID)
    {
        SqlSTD_ClassTimeProvider sqlSTD_ClassTimeProvider = new SqlSTD_ClassTimeProvider();
        return sqlSTD_ClassTimeProvider.DeleteSTD_ClassTime(sTD_ClassTimeID);
    }
}

