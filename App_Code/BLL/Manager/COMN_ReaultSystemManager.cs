using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_ReaultSystemManager
{
	public COMN_ReaultSystemManager()
	{
	}

    public static DataSet  GetAllCOMN_ReaultSystems()
    {
       DataSet cOMN_ReaultSystems = new DataSet();
        SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
        cOMN_ReaultSystems = sqlCOMN_ReaultSystemProvider.GetAllCOMN_ReaultSystems();
        return cOMN_ReaultSystems;
    }

	public static void cOMN_ReaultSystemsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_ReaultSystemPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
		DataSet ds =  sqlCOMN_ReaultSystemProvider.GetCOMN_ReaultSystemPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_ReaultSystemsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_ReaultSystem()
    {
       DataSet cOMN_ReaultSystems = new DataSet();
        SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
        cOMN_ReaultSystems = sqlCOMN_ReaultSystemProvider.GetDropDownListAllCOMN_ReaultSystem();
        return cOMN_ReaultSystems;
    }


    public static COMN_ReaultSystem GetCOMN_ReaultSystemByReaultSystemID(int ReaultSystemID)
    {
        COMN_ReaultSystem cOMN_ReaultSystem = new COMN_ReaultSystem();
        SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
        cOMN_ReaultSystem = sqlCOMN_ReaultSystemProvider.GetCOMN_ReaultSystemByReaultSystemID(ReaultSystemID);
        return cOMN_ReaultSystem;
    }


    public static int InsertCOMN_ReaultSystem(COMN_ReaultSystem cOMN_ReaultSystem)
    {
        SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
        return sqlCOMN_ReaultSystemProvider.InsertCOMN_ReaultSystem(cOMN_ReaultSystem);
    }


    public static bool UpdateCOMN_ReaultSystem(COMN_ReaultSystem cOMN_ReaultSystem)
    {
        SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
        return sqlCOMN_ReaultSystemProvider.UpdateCOMN_ReaultSystem(cOMN_ReaultSystem);
    }

    public static bool DeleteCOMN_ReaultSystem(int cOMN_ReaultSystemID)
    {
        SqlCOMN_ReaultSystemProvider sqlCOMN_ReaultSystemProvider = new SqlCOMN_ReaultSystemProvider();
        return sqlCOMN_ReaultSystemProvider.DeleteCOMN_ReaultSystem(cOMN_ReaultSystemID);
    }
}

