using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_ModuleManager
{
	public USER_ModuleManager()
	{
	}

    public static DataSet  GetAllUSER_Modules()
    {
       DataSet uSER_Modules = new DataSet();
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        uSER_Modules = sqlUSER_ModuleProvider.GetAllUSER_Modules();
        return uSER_Modules;
    }

	public static void uSER_ModulesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadUSER_ModulePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
		DataSet ds =  sqlUSER_ModuleProvider.GetUSER_ModulePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_ModulesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_Module()
    {
       DataSet uSER_Modules = new DataSet();
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        uSER_Modules = sqlUSER_ModuleProvider.GetDropDownLisAllUSER_Module();
        return uSER_Modules;
    }


    public static USER_Module GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_Module uSER_Module = new USER_Module();
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        uSER_Module = sqlUSER_ModuleProvider.GetUSER_ModuleByRowStatusID(RowStatusID);
        return uSER_Module;
    }


    public static USER_Module GetUSER_ModuleByModuleID(int ModuleID)
    {
        USER_Module uSER_Module = new USER_Module();
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        uSER_Module = sqlUSER_ModuleProvider.GetUSER_ModuleByModuleID(ModuleID);
        return uSER_Module;
    }


    public static int InsertUSER_Module(USER_Module uSER_Module)
    {
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        return sqlUSER_ModuleProvider.InsertUSER_Module(uSER_Module);
    }


    public static bool UpdateUSER_Module(USER_Module uSER_Module)
    {
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        return sqlUSER_ModuleProvider.UpdateUSER_Module(uSER_Module);
    }

    public static bool DeleteUSER_Module(int uSER_ModuleID)
    {
        SqlUSER_ModuleProvider sqlUSER_ModuleProvider = new SqlUSER_ModuleProvider();
        return sqlUSER_ModuleProvider.DeleteUSER_Module(uSER_ModuleID);
    }
}

