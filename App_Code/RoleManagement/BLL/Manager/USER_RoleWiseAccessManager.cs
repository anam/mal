using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_RoleWiseAccessManager
{
	public USER_RoleWiseAccessManager()
	{
	}

    public static DataSet  GetAllUSER_RoleWiseAccesss()
    {
       DataSet uSER_RoleWiseAccesss = new DataSet();
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        uSER_RoleWiseAccesss = sqlUSER_RoleWiseAccessProvider.GetAllUSER_RoleWiseAccesss();
        return uSER_RoleWiseAccesss;
    }

	public static void uSER_RoleWiseAccesssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadUSER_RoleWiseAccessPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
		DataSet ds =  sqlUSER_RoleWiseAccessProvider.GetUSER_RoleWiseAccessPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_RoleWiseAccesssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_RoleWiseAccess()
    {
       DataSet uSER_RoleWiseAccesss = new DataSet();
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        uSER_RoleWiseAccesss = sqlUSER_RoleWiseAccessProvider.GetDropDownLisAllUSER_RoleWiseAccess();
        return uSER_RoleWiseAccesss;
    }


    public static USER_RoleWiseAccess GetUserPageByPageID(int PageID)
    {
        USER_RoleWiseAccess uSER_RoleWiseAccess = new USER_RoleWiseAccess();
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        uSER_RoleWiseAccess = sqlUSER_RoleWiseAccessProvider.GetUSER_RoleWiseAccessByPageID(PageID);
        return uSER_RoleWiseAccess;
    }


    public static List<USER_RoleWiseAccess> GetUSER_RoleWiseAccessesByRoleID(string RoleID)
    {   
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();

        return sqlUSER_RoleWiseAccessProvider.GetUSER_RoleWiseAccessesByRoleID(RoleID);
    }


    public static USER_RoleWiseAccess GetUserOperationByOperationID(int OperationID)
    {
        USER_RoleWiseAccess uSER_RoleWiseAccess = new USER_RoleWiseAccess();
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        uSER_RoleWiseAccess = sqlUSER_RoleWiseAccessProvider.GetUSER_RoleWiseAccessByOperationID(OperationID);
        return uSER_RoleWiseAccess;
    }


    public static USER_RoleWiseAccess GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_RoleWiseAccess uSER_RoleWiseAccess = new USER_RoleWiseAccess();
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        uSER_RoleWiseAccess = sqlUSER_RoleWiseAccessProvider.GetUSER_RoleWiseAccessByRowStatusID(RowStatusID);
        return uSER_RoleWiseAccess;
    }


    public static USER_RoleWiseAccess GetUSER_RoleWiseAccessByID(int ID)
    {
        USER_RoleWiseAccess uSER_RoleWiseAccess = new USER_RoleWiseAccess();
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        uSER_RoleWiseAccess = sqlUSER_RoleWiseAccessProvider.GetUSER_RoleWiseAccessByID(ID);
        return uSER_RoleWiseAccess;
    }


    public static int InsertUSER_RoleWiseAccess(USER_RoleWiseAccess uSER_RoleWiseAccess)
    {
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        return sqlUSER_RoleWiseAccessProvider.InsertUSER_RoleWiseAccess(uSER_RoleWiseAccess);
    }


    public static bool UpdateUSER_RoleWiseAccess(USER_RoleWiseAccess uSER_RoleWiseAccess)
    {
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        return sqlUSER_RoleWiseAccessProvider.UpdateUSER_RoleWiseAccess(uSER_RoleWiseAccess);
    }

    public static bool DeleteUSER_RoleWiseAccess(int uSER_RoleWiseAccessID)
    {
        SqlUSER_RoleWiseAccessProvider sqlUSER_RoleWiseAccessProvider = new SqlUSER_RoleWiseAccessProvider();
        return sqlUSER_RoleWiseAccessProvider.DeleteUSER_RoleWiseAccess(uSER_RoleWiseAccessID);
    }
}

