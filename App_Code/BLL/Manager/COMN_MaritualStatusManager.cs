using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_MaritualStatusManager
{
	public COMN_MaritualStatusManager()
	{
	}

    public static DataSet  GetAllCOMN_MaritualStatuss()
    {
       DataSet cOMN_MaritualStatuss = new DataSet();
        SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        cOMN_MaritualStatuss = sqlCOMN_MaritualStatusProvider.GetAllCOMN_MaritualStatuss();
        return cOMN_MaritualStatuss;
    }
    public static DataSet GetDropDownListAllHR_MaritualStatus()
    {
        DataSet hR_MaritualStatuss = new DataSet();
        SqlCOMN_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        hR_MaritualStatuss = sqlHR_MaritualStatusProvider.GetDropDownListAllCOMN_MaritualStatus();
        return hR_MaritualStatuss;
    }
	public static void cOMN_MaritualStatussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_MaritualStatusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
		DataSet ds =  sqlCOMN_MaritualStatusProvider.GetCOMN_MaritualStatusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_MaritualStatussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_MaritualStatus()
    {
       DataSet cOMN_MaritualStatuss = new DataSet();
        SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        cOMN_MaritualStatuss = sqlCOMN_MaritualStatusProvider.GetDropDownListAllCOMN_MaritualStatus();
        return cOMN_MaritualStatuss;
    }


    public static COMN_MaritualStatus GetCOMN_MaritualStatusByMaritualStatusID(int MaritualStatusID)
    {
        COMN_MaritualStatus cOMN_MaritualStatus = new COMN_MaritualStatus();
        SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        cOMN_MaritualStatus = sqlCOMN_MaritualStatusProvider.GetCOMN_MaritualStatusByMaritualStatusID(MaritualStatusID);
        return cOMN_MaritualStatus;
    }


    public static int InsertCOMN_MaritualStatus(COMN_MaritualStatus cOMN_MaritualStatus)
    {
        SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        return sqlCOMN_MaritualStatusProvider.InsertCOMN_MaritualStatus(cOMN_MaritualStatus);
    }


    public static bool UpdateCOMN_MaritualStatus(COMN_MaritualStatus cOMN_MaritualStatus)
    {
        SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        return sqlCOMN_MaritualStatusProvider.UpdateCOMN_MaritualStatus(cOMN_MaritualStatus);
    }

    public static bool DeleteCOMN_MaritualStatus(int cOMN_MaritualStatusID)
    {
        SqlCOMN_MaritualStatusProvider sqlCOMN_MaritualStatusProvider = new SqlCOMN_MaritualStatusProvider();
        return sqlCOMN_MaritualStatusProvider.DeleteCOMN_MaritualStatus(cOMN_MaritualStatusID);
    }
}

