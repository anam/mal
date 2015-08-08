using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_OperationManager
{
	public USER_OperationManager()
	{
	}

    public static DataSet  GetAllUSER_Operations()
    {
       DataSet uSER_Operations = new DataSet();
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        uSER_Operations = sqlUSER_OperationProvider.GetAllUSER_Operations();
        return uSER_Operations;
    }

	public static void uSER_OperationsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadUSER_OperationPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
		DataSet ds =  sqlUSER_OperationProvider.GetUSER_OperationPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_OperationsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_Operation()
    {
       DataSet uSER_Operations = new DataSet();
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        uSER_Operations = sqlUSER_OperationProvider.GetDropDownLisAllUSER_Operation();
        return uSER_Operations;
    }


    public static USER_Operation GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_Operation uSER_Operation = new USER_Operation();
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        uSER_Operation = sqlUSER_OperationProvider.GetUSER_OperationByRowStatusID(RowStatusID);
        return uSER_Operation;
    }


    public static USER_Operation GetUSER_OperationByOperationID(int OperationID)
    {
        USER_Operation uSER_Operation = new USER_Operation();
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        uSER_Operation = sqlUSER_OperationProvider.GetUSER_OperationByOperationID(OperationID);
        return uSER_Operation;
    }


    public static int InsertUSER_Operation(USER_Operation uSER_Operation)
    {
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        return sqlUSER_OperationProvider.InsertUSER_Operation(uSER_Operation);
    }


    public static bool UpdateUSER_Operation(USER_Operation uSER_Operation)
    {
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        return sqlUSER_OperationProvider.UpdateUSER_Operation(uSER_Operation);
    }

    public static bool DeleteUSER_Operation(int uSER_OperationID)
    {
        SqlUSER_OperationProvider sqlUSER_OperationProvider = new SqlUSER_OperationProvider();
        return sqlUSER_OperationProvider.DeleteUSER_Operation(uSER_OperationID);
    }
}

