using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_PageManager
{
	public USER_PageManager()
	{
	}

    public static DataSet  GetAllUSER_Pages()
    {
       DataSet uSER_Pages = new DataSet();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Pages = sqlUSER_PageProvider.GetAllUSER_Pages();
        return uSER_Pages;
    }

	public static void uSER_PagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadUSER_PagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
		DataSet ds =  sqlUSER_PageProvider.GetUSER_PagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_PagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_Page()
    {
       DataSet uSER_Pages = new DataSet();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Pages = sqlUSER_PageProvider.GetDropDownLisAllUSER_Page();
        return uSER_Pages;
    }

    public static DataSet   GetAllUSER_PagesWithRelation()
    {
       DataSet uSER_Pages = new DataSet();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Pages = sqlUSER_PageProvider.GetAllUSER_Pages();
        return uSER_Pages;
    }


    public static List<USER_Page> GetUSER_PagesByModuleID(int ModuleID)
    {
        List<USER_Page> uSER_Pages = new List<USER_Page>();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Pages = sqlUSER_PageProvider.GetUSER_PagesByModuleID(ModuleID);
        return uSER_Pages;
    }


    public static USER_Page GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_Page uSER_Page = new USER_Page();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Page = sqlUSER_PageProvider.GetUSER_PageByRowStatusID(RowStatusID);
        return uSER_Page;
    }


    public static USER_Page GetUSER_PageByPageID(int PageID)
    {
        USER_Page uSER_Page = new USER_Page();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Page = sqlUSER_PageProvider.GetUSER_PageByPageID(PageID);
        return uSER_Page;
    }

    public static USER_Page GetUSER_PageByPageTitle(string PageTitle)
    {
        USER_Page uSER_Page = new USER_Page();
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        uSER_Page = sqlUSER_PageProvider.GetUSER_PageByPageTitle(PageTitle);
        return uSER_Page;
    }

    public static int InsertUSER_Page(USER_Page uSER_Page)
    {
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        return sqlUSER_PageProvider.InsertUSER_Page(uSER_Page);
    }


    public static bool UpdateUSER_Page(USER_Page uSER_Page)
    {
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        return sqlUSER_PageProvider.UpdateUSER_Page(uSER_Page);
    }

    public static bool DeleteUSER_Page(int uSER_PageID)
    {
        SqlUSER_PageProvider sqlUSER_PageProvider = new SqlUSER_PageProvider();
        return sqlUSER_PageProvider.DeleteUSER_Page(uSER_PageID);
    }
}

