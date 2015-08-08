using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_RoleWiseMenuManager
{
	public USER_RoleWiseMenuManager()
	{
	}

    public static DataSet  GetAllUSER_RoleWiseMenus()
    {
       DataSet uSER_RoleWiseMenus = new DataSet();
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        uSER_RoleWiseMenus = sqlUSER_RoleWiseMenuProvider.GetAllUSER_RoleWiseMenus();
        return uSER_RoleWiseMenus;
    }

	public static void uSER_RoleWiseMenusPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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

 	public static void LoadUSER_RoleWiseMenuPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
		DataSet ds =  sqlUSER_RoleWiseMenuProvider.GetUSER_RoleWiseMenuPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_RoleWiseMenusPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_RoleWiseMenu()
    {
       DataSet uSER_RoleWiseMenus = new DataSet();
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        uSER_RoleWiseMenus = sqlUSER_RoleWiseMenuProvider.GetDropDownLisAllUSER_RoleWiseMenu();
        return uSER_RoleWiseMenus;
    }


    public static USER_RoleWiseMenu GetUserMenuByMenuID(int MenuID)
    {
        USER_RoleWiseMenu uSER_RoleWiseMenu = new USER_RoleWiseMenu();
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        uSER_RoleWiseMenu = sqlUSER_RoleWiseMenuProvider.GetUSER_RoleWiseMenuByMenuID(MenuID);
        return uSER_RoleWiseMenu;
    }


    public static List<USER_RoleWiseMenu> GetUSER_RoleWiseMenuByRoleID(string RoleID)
    {
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        return sqlUSER_RoleWiseMenuProvider.GetUSER_RoleWiseMenuByRoleID(RoleID);
    }


    public static USER_RoleWiseMenu GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_RoleWiseMenu uSER_RoleWiseMenu = new USER_RoleWiseMenu();
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        uSER_RoleWiseMenu = sqlUSER_RoleWiseMenuProvider.GetUSER_RoleWiseMenuByRowStatusID(RowStatusID);
        return uSER_RoleWiseMenu;
    }


    public static USER_RoleWiseMenu GetUSER_RoleWiseMenuByID(int ID)
    {
        USER_RoleWiseMenu uSER_RoleWiseMenu = new USER_RoleWiseMenu();
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        uSER_RoleWiseMenu = sqlUSER_RoleWiseMenuProvider.GetUSER_RoleWiseMenuByID(ID);
        return uSER_RoleWiseMenu;
    }


    public static int InsertUSER_RoleWiseMenu(USER_RoleWiseMenu uSER_RoleWiseMenu)
    {
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        return sqlUSER_RoleWiseMenuProvider.InsertUSER_RoleWiseMenu(uSER_RoleWiseMenu);
    }


    public static bool UpdateUSER_RoleWiseMenu(USER_RoleWiseMenu uSER_RoleWiseMenu)
    {
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        return sqlUSER_RoleWiseMenuProvider.UpdateUSER_RoleWiseMenu(uSER_RoleWiseMenu);
    }

    public static bool DeleteUSER_RoleWiseMenu(int uSER_RoleWiseMenuID)
    {
        SqlUSER_RoleWiseMenuProvider sqlUSER_RoleWiseMenuProvider = new SqlUSER_RoleWiseMenuProvider();
        return sqlUSER_RoleWiseMenuProvider.DeleteUSER_RoleWiseMenu(uSER_RoleWiseMenuID);
    }
}

