using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_MenuManager
{
    public USER_MenuManager()
    {
    }

    public static DataSet GetAllUSER_Menus()
    {
        DataSet uSER_Menus = new DataSet();
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        uSER_Menus = sqlUSER_MenuProvider.GetAllUSER_Menus();
        return uSER_Menus;
    }

    public static void uSER_MenusPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadUSER_MenuPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        DataSet ds = sqlUSER_MenuProvider.GetUSER_MenuPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        uSER_MenusPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllUSER_Menu()
    {
        DataSet uSER_Menus = new DataSet();
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        uSER_Menus = sqlUSER_MenuProvider.GetDropDownLisAllUSER_Menu();
        return uSER_Menus;
    }

    public static DataSet GetAllUSER_MenusWithRelation()
    {
        DataSet uSER_Menus = new DataSet();
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        uSER_Menus = sqlUSER_MenuProvider.GetAllUSER_Menus();
        return uSER_Menus;
    }


    public static USER_Menu GetUserPageByPageID(int PageID)
    {
        USER_Menu uSER_Menu = new USER_Menu();
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        uSER_Menu = sqlUSER_MenuProvider.GetUSER_MenuByPageID(PageID);
        return uSER_Menu;
    }

    public static List<USER_Menu> GetUSER_Menu_ByModuleID(int moduleID)
    {
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        return sqlUSER_MenuProvider.GetUSER_Menu_ByModuleID(moduleID);
    }

    public static USER_Menu GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_Menu uSER_Menu = new USER_Menu();
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        uSER_Menu = sqlUSER_MenuProvider.GetUSER_MenuByRowStatusID(RowStatusID);
        return uSER_Menu;
    }


    public static USER_Menu GetUSER_MenuByMenuID(int MenuID)
    {
        USER_Menu uSER_Menu = new USER_Menu();
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        uSER_Menu = sqlUSER_MenuProvider.GetUSER_MenuByMenuID(MenuID);
        return uSER_Menu;
    }


    public static int InsertUSER_Menu(USER_Menu uSER_Menu)
    {
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        return sqlUSER_MenuProvider.InsertUSER_Menu(uSER_Menu);
    }


    public static bool UpdateUSER_Menu(USER_Menu uSER_Menu)
    {
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        return sqlUSER_MenuProvider.UpdateUSER_Menu(uSER_Menu);
    }

    public static bool DeleteUSER_Menu(int uSER_MenuID)
    {
        SqlUSER_MenuProvider sqlUSER_MenuProvider = new SqlUSER_MenuProvider();
        return sqlUSER_MenuProvider.DeleteUSER_Menu(uSER_MenuID);
    }
}

public class DisplayMenuManager
{
    public DisplayMenuManager()
    {
    }

    public static List<DisplayMenu> GetDisplayMenuByModuleNRole(int moduleID, string roleID)
    {
        SqlDisplayMenuProvider sqlDisplayMenuProvider = new SqlDisplayMenuProvider();
        return sqlDisplayMenuProvider.GetDisplayMenuByModuleNRole(moduleID, roleID);
    }
}

