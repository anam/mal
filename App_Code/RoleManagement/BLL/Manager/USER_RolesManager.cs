using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_RolesManager
{
	public USER_RolesManager()
	{
	}

    public static DataSet  GetAllUSER_Roless()
    {
       DataSet uSER_Roless = new DataSet();
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        uSER_Roless = sqlUSER_RolesProvider.GetAllUSER_Roless();
        return uSER_Roless;
    }

	public static void uSER_RolessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadUSER_RolesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
		DataSet ds =  sqlUSER_RolesProvider.GetUSER_RolesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_RolessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_Roles()
    {
       DataSet uSER_Roless = new DataSet();
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        uSER_Roless = sqlUSER_RolesProvider.GetDropDownLisAllUSER_Roles();
        return uSER_Roless;
    }


    public static USER_Roles GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_Roles uSER_Roles = new USER_Roles();
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        uSER_Roles = sqlUSER_RolesProvider.GetUSER_RolesByRowStatusID(RowStatusID);
        return uSER_Roles;
    }


    public static USER_Roles GetUSER_RolesByRoleID(int RoleID)
    {
        USER_Roles uSER_Roles = new USER_Roles();
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        uSER_Roles = sqlUSER_RolesProvider.GetUSER_RolesByRoleID(RoleID);
        return uSER_Roles;
    }


    public static int InsertUSER_Roles(USER_Roles uSER_Roles)
    {
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        return sqlUSER_RolesProvider.InsertUSER_Roles(uSER_Roles);
    }


    public static bool UpdateUSER_Roles(USER_Roles uSER_Roles)
    {
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        return sqlUSER_RolesProvider.UpdateUSER_Roles(uSER_Roles);
    }

    public static bool DeleteUSER_Roles(int uSER_RolesID)
    {
        SqlUSER_RolesProvider sqlUSER_RolesProvider = new SqlUSER_RolesProvider();
        return sqlUSER_RolesProvider.DeleteUSER_Roles(uSER_RolesID);
    }
}

