using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_RowStatusManager
{
	public COMN_RowStatusManager()
	{
	}

    public static DataSet  GetAllCOMN_RowStatuss()
    {
       DataSet cOMN_RowStatuss = new DataSet();
        SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
        cOMN_RowStatuss = sqlCOMN_RowStatusProvider.GetAllCOMN_RowStatuss();
        return cOMN_RowStatuss;
    }

	public static void cOMN_RowStatussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_RowStatusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
		DataSet ds =  sqlCOMN_RowStatusProvider.GetCOMN_RowStatusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_RowStatussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_RowStatus()
    {
       DataSet cOMN_RowStatuss = new DataSet();
        SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
        cOMN_RowStatuss = sqlCOMN_RowStatusProvider.GetDropDownLisAllCOMN_RowStatus();
        return cOMN_RowStatuss;
    }


    public static COMN_RowStatus GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        COMN_RowStatus cOMN_RowStatus = new COMN_RowStatus();
        SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
        cOMN_RowStatus = sqlCOMN_RowStatusProvider.GetCOMN_RowStatusByRowStatusID(RowStatusID);
        return cOMN_RowStatus;
    }


    public static int InsertCOMN_RowStatus(COMN_RowStatus cOMN_RowStatus)
    {
        SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
        return sqlCOMN_RowStatusProvider.InsertCOMN_RowStatus(cOMN_RowStatus);
    }


    public static bool UpdateCOMN_RowStatus(COMN_RowStatus cOMN_RowStatus)
    {
        SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
        return sqlCOMN_RowStatusProvider.UpdateCOMN_RowStatus(cOMN_RowStatus);
    }

    public static bool DeleteCOMN_RowStatus(int cOMN_RowStatusID)
    {
        SqlCOMN_RowStatusProvider sqlCOMN_RowStatusProvider = new SqlCOMN_RowStatusProvider();
        return sqlCOMN_RowStatusProvider.DeleteCOMN_RowStatus(cOMN_RowStatusID);
    }
}

