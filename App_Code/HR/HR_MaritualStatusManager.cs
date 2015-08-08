using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_MaritualStatusManager
{
	public HR_MaritualStatusManager()
	{
	}

    public static DataSet  GetAllHR_MaritualStatuss()
    {
       DataSet hR_MaritualStatuss = new DataSet();
        SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
        hR_MaritualStatuss = sqlHR_MaritualStatusProvider.GetAllHR_MaritualStatuss();
        return hR_MaritualStatuss;
    }

	public static void hR_MaritualStatussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_MaritualStatusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
		DataSet ds =  sqlHR_MaritualStatusProvider.GetHR_MaritualStatusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_MaritualStatussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_MaritualStatus()
    {
       DataSet hR_MaritualStatuss = new DataSet();
        SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
        hR_MaritualStatuss = sqlHR_MaritualStatusProvider.GetDropDownListAllHR_MaritualStatus();
        return hR_MaritualStatuss;
    }


    public static HR_MaritualStatus GetHR_MaritualStatusByMaritualStatusID(int MaritualStatusID)
    {
        HR_MaritualStatus hR_MaritualStatus = new HR_MaritualStatus();
        SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
        hR_MaritualStatus = sqlHR_MaritualStatusProvider.GetHR_MaritualStatusByMaritualStatusID(MaritualStatusID);
        return hR_MaritualStatus;
    }


    public static int InsertHR_MaritualStatus(HR_MaritualStatus hR_MaritualStatus)
    {
        SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
        return sqlHR_MaritualStatusProvider.InsertHR_MaritualStatus(hR_MaritualStatus);
    }


    public static bool UpdateHR_MaritualStatus(HR_MaritualStatus hR_MaritualStatus)
    {
        SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
        return sqlHR_MaritualStatusProvider.UpdateHR_MaritualStatus(hR_MaritualStatus);
    }

    public static bool DeleteHR_MaritualStatus(int hR_MaritualStatusID)
    {
        SqlHR_MaritualStatusProvider sqlHR_MaritualStatusProvider = new SqlHR_MaritualStatusProvider();
        return sqlHR_MaritualStatusProvider.DeleteHR_MaritualStatus(hR_MaritualStatusID);
    }
}

