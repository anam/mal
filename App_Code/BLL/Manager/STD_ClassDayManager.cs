using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassDayManager
{
	public STD_ClassDayManager()
	{
	}

    public static DataSet  GetAllSTD_ClassDaies()
    {
       DataSet sTD_ClassDaies = new DataSet();
        SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
        sTD_ClassDaies = sqlSTD_ClassDayProvider.GetAllSTD_ClassDaies();
        return sTD_ClassDaies;
    }

	public static void sTD_ClassDaiesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassDayPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
		DataSet ds =  sqlSTD_ClassDayProvider.GetSTD_ClassDayPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassDaiesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassDay()
    {
       DataSet sTD_ClassDaies = new DataSet();
        SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
        sTD_ClassDaies = sqlSTD_ClassDayProvider.GetDropDownListAllSTD_ClassDay();
        return sTD_ClassDaies;
    }


    public static STD_ClassDay GetSTD_ClassDayByClassDayID(int ClassDayID)
    {
        STD_ClassDay sTD_ClassDay = new STD_ClassDay();
        SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
        sTD_ClassDay = sqlSTD_ClassDayProvider.GetSTD_ClassDayByClassDayID(ClassDayID);
        return sTD_ClassDay;
    }


    public static int InsertSTD_ClassDay(STD_ClassDay sTD_ClassDay)
    {
        SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
        return sqlSTD_ClassDayProvider.InsertSTD_ClassDay(sTD_ClassDay);
    }


    public static bool UpdateSTD_ClassDay(STD_ClassDay sTD_ClassDay)
    {
        SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
        return sqlSTD_ClassDayProvider.UpdateSTD_ClassDay(sTD_ClassDay);
    }

    public static bool DeleteSTD_ClassDay(int sTD_ClassDayID)
    {
        SqlSTD_ClassDayProvider sqlSTD_ClassDayProvider = new SqlSTD_ClassDayProvider();
        return sqlSTD_ClassDayProvider.DeleteSTD_ClassDay(sTD_ClassDayID);
    }
}

