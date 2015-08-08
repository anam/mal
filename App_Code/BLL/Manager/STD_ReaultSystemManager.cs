using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ReaultSystemManager
{
	public STD_ReaultSystemManager()
	{
	}

    public static DataSet  GetAllSTD_ReaultSystems()
    {
       DataSet sTD_ReaultSystems = new DataSet();
        SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
        sTD_ReaultSystems = sqlSTD_ReaultSystemProvider.GetAllSTD_ReaultSystems();
        return sTD_ReaultSystems;
    }

	public static void sTD_ReaultSystemsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ReaultSystemPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
		DataSet ds =  sqlSTD_ReaultSystemProvider.GetSTD_ReaultSystemPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ReaultSystemsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ReaultSystem()
    {
       DataSet sTD_ReaultSystems = new DataSet();
        SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
        sTD_ReaultSystems = sqlSTD_ReaultSystemProvider.GetDropDownListAllSTD_ReaultSystem();
        return sTD_ReaultSystems;
    }


    public static STD_ReaultSystem GetSTD_ReaultSystemByReaultSystemID(int ReaultSystemID)
    {
        STD_ReaultSystem sTD_ReaultSystem = new STD_ReaultSystem();
        SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
        sTD_ReaultSystem = sqlSTD_ReaultSystemProvider.GetSTD_ReaultSystemByReaultSystemID(ReaultSystemID);
        return sTD_ReaultSystem;
    }


    public static int InsertSTD_ReaultSystem(STD_ReaultSystem sTD_ReaultSystem)
    {
        SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
        return sqlSTD_ReaultSystemProvider.InsertSTD_ReaultSystem(sTD_ReaultSystem);
    }


    public static bool UpdateSTD_ReaultSystem(STD_ReaultSystem sTD_ReaultSystem)
    {
        SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
        return sqlSTD_ReaultSystemProvider.UpdateSTD_ReaultSystem(sTD_ReaultSystem);
    }

    public static bool DeleteSTD_ReaultSystem(int sTD_ReaultSystemID)
    {
        SqlSTD_ReaultSystemProvider sqlSTD_ReaultSystemProvider = new SqlSTD_ReaultSystemProvider();
        return sqlSTD_ReaultSystemProvider.DeleteSTD_ReaultSystem(sTD_ReaultSystemID);
    }
}

